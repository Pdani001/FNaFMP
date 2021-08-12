using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace Alzaitu.Lacewing.Client.Packet
{
	internal abstract class Packet
	{
		private static Dictionary<byte, Dictionary<int, Type>> _typeReadMap;
		private static Dictionary<byte, Dictionary<int, Type>> TypeReadMap =>
			_typeReadMap ?? (_typeReadMap = typeof(Packet).Assembly.GetTypes()
				.Where(x => typeof(Packet).IsAssignableFrom(x) &&
							!x.IsAbstract && !x.IsInterface &&
							x.GetCustomAttribute<PacketTypeAttribute>()?.CanRead == true)
				.GroupBy(x => x.GetCustomAttribute<PacketTypeAttribute>().Type)
				.ToDictionary(x => x.Key,
					x => x.ToDictionary(y => y.GetCustomAttribute<PacketTypeAttribute>().SubType ?? -1, y => y)));

		public byte Type => GetType().GetCustomAttribute<PacketTypeAttribute>().Type;
		public byte? SubType => GetType().GetCustomAttribute<PacketTypeAttribute>().SubType;

		public byte Variant { get; set; }

		public bool CanWrite => GetType().GetCustomAttribute<PacketTypeAttribute>().CanWrite;
		public bool CanRead => GetType().GetCustomAttribute<PacketTypeAttribute>().CanRead;

		public void Write(LacewingClient client, bool blasted)
		{
			var siz = GetSize();

			byte type = (byte)(((Type & 0xF) << 4) | Variant & 0xF);


			if (SubType != null)
			{
				siz += sizeof(byte);

			}


			if (siz > uint.MaxValue)
				throw new InvalidOperationException($"Cannot send a message that's more than {uint.MaxValue} bytes long.");

			if (!blasted)
			{
				var wrt = new BinaryWriter(client.GetStream());

				if (NeedsFirstZero())
				{
					if (client.debug)
					{
						client.logger.Write("[TCP] Initial zero set");
					}
					wrt.Write((byte)0);
				}

				if (client.debug)
				{
					client.logger.Write("[TCP] Write Type = {0} ({1})",Type, type);
				}
				wrt.Write(type);

				if (client.debug)
				{
					client.logger.Write("[TCP] Write Size = {0}", siz);
				}
				if (siz < 254)
					wrt.Write((byte)siz);
				else if (siz < 65535)
				{
					wrt.Write((byte)254);
					wrt.Write(BitConverter.GetBytes((ushort)siz));
				}
				else
				{
					wrt.Write((byte)255);
					wrt.Write(BitConverter.GetBytes((uint)siz));
				}

				if (SubType != null)
				{
					if (client.debug)
					{
						client.logger.Write("[TCP] Write Subtype = {0}", SubType.Value);
					}
					wrt.Write(SubType.Value);
				}

				WriteImpl(wrt);

				wrt.Flush();
			}
			else
			{
				List<byte> byteList = new List<byte>();

				if (client.debug)
				{
					client.logger.Write("[UDP] Write Type = {0} ({1})", Type, type);
				}
				byteList.Add(type);

				if (client.debug)
				{
					client.logger.Write("[UDP] Write Client = {0}", client.ID);
				}
				byteList.AddRange(BitConverter.GetBytes(client.ID));


				if (SubType != null)
				{
					if (client.debug)
					{
						client.logger.Write("[TCP] Write Subtype = {0}", SubType.Value);
					}
					byteList.Add(SubType.Value);
				}

				WriteImpl(byteList.Count, out byte[] bytes);

				byteList.AddRange(bytes);

				client._udp.Send(byteList.ToArray(), byteList.Count);
			}
		}

		protected virtual void WriteImpl(BinaryWriter wrt) => throw new InvalidOperationException("This packet does not support binary writing.");
		protected virtual void WriteImpl(int pos,out byte[] bytes) => throw new InvalidOperationException("This packet does not support byte writing.");
		protected virtual void ReadImpl(byte[] bytes, long size, int pos, LacewingClient client = null, bool blasted = false) => throw new InvalidOperationException("This packet does not support reading.");
		protected virtual bool NeedsFirstZero() => false;

		/// <summary>
		/// Retrive the size of the packet, in bytes.
		/// </summary>
		/// <returns>A number between 0 and 4294967295 describing the length of the packet in bytes.</returns>
		public virtual long GetSize() => 1;

		private static bool Message = false;

		public static byte[] ReadMessage(NetworkStream stream, long size)
		{
			if (size <= 0)
				return new byte[0];
			Message = true;
			while (!stream.DataAvailable) ;

			byte[] ReadBuffer = new byte[size];
			stream.Read(ReadBuffer, 0, ReadBuffer.Length);
			Message = false;
			return ReadBuffer;
		}

		public static Packet ReadPacket(NetworkStream stream, LacewingClient client = null)
		{
			if (Message)
				return null;
			if (!stream.DataAvailable)
				return null;

			List<byte> data = new List<byte>();
			while (stream.DataAvailable)
			{
				byte[] ReadBuffer = new byte[1];
				stream.Read(ReadBuffer, 0, ReadBuffer.Length);
				data.AddRange(ReadBuffer);
			}
			int pos = 0;
			byte type = data[pos++];

			if(client != null && client.debug)
			{
				client.logger.Write("[TCP] Read Type = {0} ({1}.{2})",type, (type >> 4) & 0xF, type & 0xF);
			}

			if(!TypeReadMap.TryGetValue((byte) ((type >> 4) & 0xF), out var packetTypeBlock))
				throw new InvalidDataException($"[TCP] The packet read from the stream ({type} {(type >> 4) & 0xF}.{type & 0xF}) does not have an associated type.");

			long size = data[pos++];
			if (size == 254)
				size = BitConverter.ToUInt16(new byte[2] { data[pos++], data[pos++] },0);
			else if (size == 255)
			{
				byte[] number = new byte[4];
				for(int i = 0; i < 4; i++)
				{
					number[i] = data[pos++];
				}
				size = BitConverter.ToInt32(number, 0);
			}

			if (client != null && client.debug)
			{
				client.logger.Write("[TCP] Read Size = {0}", size);
			}

			Type packetType;
			if (packetTypeBlock.ContainsKey(-1))
				packetType = packetTypeBlock[-1];
			else
			{
				var subType = data[pos++];
				if (client != null && client.debug)
				{
					client.logger.Write("[TCP] Read Subtype = {0}", subType);
				}
				if (!packetTypeBlock.TryGetValue(subType, out packetType))
					throw new InvalidDataException($"[TCP] The packet read from the stream ({(type >> 4) & 0xF}.{type & 0xF}.{subType}) does not have an associated type.");
				size -= sizeof(byte);
			}

			var instance = (Packet) Activator.CreateInstance(packetType);
			instance.Variant = (byte)(type & 0xF);

			List<byte> PacketData = new List<byte>();
			for (int i = 0; i < size; i++)
			{
				if (data.Count <= pos)
					break;
				PacketData.Add(data[pos++]);
			}

			if (client.debug)
				client.logger.Write("Packet size: {0}/{1}",PacketData.Count,size);

			instance.ReadImpl(PacketData.ToArray(), size,0,client);

			return instance;
		}

		/**
		 Example UDP Binary message: {Type: xx, Sub: xx, Channel id: x, x, User ID: x, x, Message...}
		 */
		public static Packet ReadPacket(byte[] bytes, LacewingClient client = null)
		{
			var pos = 0;
			var type = bytes[pos++];

			if (client != null && client.debug)
			{
				client.logger.Write("[UDP] Read Type = {0} ({1}.{2})", type, (type >> 4) & 0xF, type & 0xF);
			}

			if (!TypeReadMap.TryGetValue((byte)((type >> 4) & 0xF), out var packetTypeBlock))
				throw new InvalidDataException($"[UDP] The packet read from the stream ({(type >> 4) & 0xF}.{type & 0xF}) does not have an associated type.");
			

			Type packetType;
			if (packetTypeBlock.ContainsKey(-1))
				packetType = packetTypeBlock[-1];
			else
			{
				return null;
			}

			List<byte> msg = new List<byte>();

			while (bytes.Length > pos)
			{
				msg.Add(bytes[pos++]);
			}

			var instance = (Packet)Activator.CreateInstance(packetType);
			instance.Variant = (byte)(type & 0xF);
			instance.ReadImpl(msg.ToArray(),msg.Count,0,client,true);

			return instance;
		}

		public static byte[] InverseShort(int data)
		{
			data &= 0xffff;
			byte[] bata = new byte[] { (byte)(data & 0xff), (byte)((data >> 8) & 0xff) };
			return bata;
		}

		public static int ReadInversedShort(byte[] data)
		{
			return ((((int)data[1] & 0xff) << 8) | ((int)data[0] & 0xff)) & 0xffff;
		}

	}
}
