﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Alzaitu.Lacewing.Client.Packet.Message
{
	[PacketType(3, true, true)]
	internal class PacketBinaryPeerMessage : Packet
	{
		public byte SubChannel { get; set; }

		public int Channel { get; set; }

		public int Peer { get; set; }

		public byte[] Message { get; set; }

		protected override void WriteImpl(BinaryWriter wrt)
		{
			wrt.Write(SubChannel);
			wrt.Write(BitConverter.GetBytes((ushort)Channel));
			wrt.Write(BitConverter.GetBytes((ushort)Peer));
			wrt.Write(Message);
		}

		protected override void WriteImpl(int pos, out byte[] bytes)
		{
			List<byte> list = new List<byte>();
			list.Add(SubChannel);
			list.AddRange(BitConverter.GetBytes((ushort)Channel));
			list.AddRange(BitConverter.GetBytes((ushort)Peer));
			list.AddRange(Message);
			bytes = list.ToArray();
		}

		protected override void ReadImpl(byte[] bytes, long size, int pos, LacewingClient client = null, bool blasted = false)
		{
			SubChannel = bytes[pos++];
			Channel = BitConverter.ToUInt16(new byte[2] { bytes[pos++], bytes[pos++] },0);
			Peer = BitConverter.ToUInt16(new byte[2] { bytes[pos++], bytes[pos++] },0);
			byte[] data;
			if (blasted)
			{
				size -= pos;
				data = new byte[size];
				for (int i = 0; i < size; i++)
				{
					data[i] = bytes[pos++];
				}
			}
			else
			{
				if (bytes.Length > pos)
				{
					List<byte> m = new List<byte>();
					for (int i = pos; i < bytes.Length; i++)
					{
						m.Add(bytes[i]);
					}
					if (m.Count < size - 5)
					{
						m.AddRange(ReadMessage(client.GetStream(), size - m.Count - 5));
					}
					data = m.ToArray();
				}
				else
				{
					data = ReadMessage(client.GetStream(), size - 5);
				}
			}
			Message = data;
		}

		public override long GetSize() => sizeof(byte) + sizeof(ushort) + sizeof(ushort) + Message.LongLength;
	}
}
