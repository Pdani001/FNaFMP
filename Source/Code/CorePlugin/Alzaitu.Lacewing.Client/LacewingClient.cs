using Alzaitu.Lacewing.Client.Packet.EventData;
using Alzaitu.Lacewing.Client.Packet.Message;
using Alzaitu.Lacewing.Client.Packet.Request;
using Alzaitu.Lacewing.Client.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Alzaitu.Lacewing.Client
{
	public sealed class LacewingClient
	{
		internal readonly Logger logger = Logger.GetLogger("Lacewing");
		public readonly bool debug = false;
		public string UserName { get; internal set; }
		internal string ServerAddress;
		internal int ServerPort;

		public bool Disposed { get; internal set; }

		public readonly ClientEvent Event = new ClientEvent();

		public readonly Dictionary<string, ClientChannel> globalChannels = new Dictionary<string, ClientChannel>();
		public readonly SortedDictionary<int, ClientChannel> globalChannelsByID = new SortedDictionary<int, ClientChannel>();
		public readonly SortedDictionary<int, ClientPeer> clientsByID = new SortedDictionary<int, ClientPeer>();
		public readonly List<ClientChannel> joinedChannels = new List<ClientChannel>();

		private ClientThread thread;

		private NetworkStream stream;
		private TcpClient _client;
		public UdpClient _udp { get; private set; }
		public IPEndPoint UdpEndpoint = null;
		public ushort ID { get; internal set; }
		public bool IsConnected { get; internal set; }
		public bool IsMaster { get; internal set; }
		public bool LateMessages { get; internal set; }

		public LacewingClient(string username = null)
		{
			LateMessages = false;
			_client = new TcpClient();
			_udp = new UdpClient();
			UserName = username;
			IsConnected = false;
			debug = Environment.GetCommandLineArgs().Contains("--debug");
		}

		public void Connect(string address, int port = 6121)
		{
			if (_client.Connected)
			{
				return;
			}
			IPAddress IP;
			try
			{
				try
				{
					IP = IPAddress.Parse(address);
					_client.BeginConnect(IP, port, OnConnect, null);
				}
				catch (FormatException)
				{
					_client.BeginConnect(address, port, OnConnect, null);
				}
				ServerAddress = address;
				ServerPort = port;
			}
			catch (Exception)
			{
				_client = new TcpClient();
				_udp = new UdpClient();
				IsConnected = false;
				Connect(address, port);
			}
		}

		private void OnConnect(IAsyncResult result)
		{
			try
			{
				_client.EndConnect(result);
				_client.NoDelay = true;
				stream = _client.GetStream();
				UdpEndpoint = (IPEndPoint)_client.Client.RemoteEndPoint;
				if (debug)
					logger.Write("TCP connected on address '{0}'", _client.Client.AddressFamily);
				thread = new ClientThread(this);
				thread.Start();
				WritePacket(new PacketRequestConnect
				{
					Version = PacketRequestConnect.CURRENT_VERSION
				});
			} catch(Exception e)
			{
				if (debug)
					logger.Write("TCP failed to connect: {0}",e);
				Event.OnError(new EventError
				{
					Client = this,
					Error = string.Format("Failed to connect to server: {0}", e)
				});
			}
		}

		internal void FinishConnect()
		{
			if (UserName != null)
				SetName(UserName);
			IPAddress IP;
			try
			{
				try
				{
					IP = IPAddress.Parse(ServerAddress);
					_udp.Connect(IP, ServerPort);
				}
				catch (FormatException)
				{
					_udp.Connect(ServerAddress, ServerPort);
				}
				if (debug)
					logger.Write("UDP connected on address '{0}'",_udp.Client.AddressFamily);
				_udp.BeginReceive(UDPReceive,null);
				WritePacket(new WritePacketUdpHello(), true);
			}
			catch (SocketException)
			{
				if(debug)
					logger.Write("Error - UDP failed to connect!");
			}
		}

		public void RequestChannelList()
		{
			WritePacket(new PacketRequestChannelList());
		}

		public void SetName(string name)
		{
			WritePacket(new PacketRequestSetName
			{
				Name = name
			});
		}

		public void JoinChannel(string Channel, bool hidden = false, bool autoclose = false)
		{
			WritePacket(new PacketRequestJoinChannel
			{
				ChannelName = Channel,
				Flags = (byte)((hidden ? 1 : 0) | (autoclose ? 2 : 0))
			});
		}

		public void LeaveChannel(ClientChannel Channel)
		{
			WritePacket(new PacketRequestLeaveChannel
			{
				ChannelId = (short)Channel.Id
			});
		}

		public void SendBinaryChannelMessage(string name, byte subchannel, byte[] message, bool blasted = false)
		{
			foreach(ClientChannel channel in joinedChannels) {
				if (channel.Name != name)
					continue;
				Packet.Packet packet = new WritePacketBinaryChannelMessage
				{
					Channel = (ushort)channel.Id,
					SubChannel = subchannel,
					Message = message
				};
				packet.Variant = 2;
				WritePacket(packet, blasted);
			}
		}

		public void SendTextChannelMessage(string name, byte subchannel, string message, bool blasted = false)
		{
			foreach (ClientChannel channel in joinedChannels)
			{
				if (channel.Name != name)
					continue;
				Packet.Packet packet = new WritePacketBinaryChannelMessage
				{
					Channel = (ushort)channel.Id,
					SubChannel = subchannel,
					Message = Encoding.UTF8.GetBytes(message)
				};
				packet.Variant = 0;
				WritePacket(packet, blasted);
			}
		}

		public void SendNumberChannelMessage(string name, byte subchannel, int message, bool blasted = false)
		{
			foreach (ClientChannel channel in joinedChannels)
			{
				if (channel.Name != name)
					continue;
				Packet.Packet packet = new WritePacketBinaryChannelMessage
				{
					Channel = (ushort)channel.Id,
					SubChannel = subchannel,
					Message = BitConverter.GetBytes(message)
				};
				packet.Variant = 1;
				WritePacket(packet, blasted);
			}
		}

		private void UDPReceive(IAsyncResult result)
		{
			if (Disposed)
				return;
			byte[] data = _udp.EndReceive(result, ref UdpEndpoint);
			String msg = "{";
			for(int i = 0; i<data.Length;i++)
			{
				msg += ((i > 0) ? ", " : "") + data[i];
			}
			msg += "}";
			if (data.Length >= 1)
			{
				//Console.WriteLine($"UDP message: {msg}");
				Packet.Packet packet = Packet.Packet.ReadPacket(data, this);
				Packet.PacketHandler.Handle(packet, this, true);
			}
			_udp.BeginReceive(UDPReceive, result.AsyncState);
		}

		internal Packet.Packet ReadPacket()
		{
			return Packet.Packet.ReadPacket(stream, this);
		}

		internal NetworkStream GetStream()
		{
			return stream;
		}

		internal void WritePacket(Packet.Packet packet, bool blasted = false)
		{
			try
			{
				packet.Write(this, blasted);
			}
			catch (Exception e)
			{
				if (IsConnected)
				{
					Event.OnDisconnect(new EventDisconnect
					{
						Client = this,
						Reason = e.Message
					});
					Dispose();
				}
			}
		}

		public void Dispose()
		{
			IsConnected = false;
			Disposed = true;
			_client.Close();
			try
			{
				_udp.Close();
			}
			catch (Exception) { }
		}
	}
}
