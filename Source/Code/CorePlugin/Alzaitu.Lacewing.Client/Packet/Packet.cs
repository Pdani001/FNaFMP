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

        public void Write(object stream)
        {
            var siz = GetSize();

            byte type = (byte)(((Type & 0xF) << 4) | Variant & 0xF);


            if (SubType != null)
            {
                siz += sizeof(byte);

            }


            if (siz > uint.MaxValue)
                throw new InvalidOperationException($"Cannot send a message that's more than {uint.MaxValue} bytes long.");

            if (stream.GetType() == typeof(NetworkStream))
            {
                var wrt = new BinaryWriter((NetworkStream)stream);

                if (NeedsFirstZero())
                {
                    wrt.Write((byte)0);
                }

                wrt.Write(type);

                if (siz < 254)
                    wrt.Write((byte)(siz & 0xff));
                else if (siz < 65535)
                {
                    wrt.Write((byte)254);
                    wrt.Write((ushort)(siz & 0xffff));
                }
                else
                {
                    wrt.Write((byte)255);
                    wrt.Write((uint)siz);
                }

                if (SubType != null)
                    wrt.Write(SubType.Value);

                WriteImpl(wrt);
            }
            else if(stream.GetType() == typeof(LacewingClient))
            {
                LacewingClient client = (LacewingClient)stream;
                List<byte> byteList = new List<byte>();

                byteList.Add(type);
                byteList.AddRange(BitConverter.GetBytes(client.ID));


                if (SubType != null)
                    byteList.Add(SubType.Value);

                WriteImpl(byteList.Count, out byte[] bytes);

                byteList.AddRange(bytes);

                client._udp.Send(byteList.ToArray(), byteList.Count);
            }
            else
            {
                throw new InvalidOperationException("Type of 'stream' ("+ stream.GetType() + ") is neither NetworkStream or LacewingClient");
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

            byte[] ReadBuffer = new byte[256];
            int pos = 0;
            stream.Read(ReadBuffer, 0, ReadBuffer.Length);
            byte type = ReadBuffer[pos++];

            if(!TypeReadMap.TryGetValue((byte) ((type >> 4) & 0xF), out var packetTypeBlock))
                throw new InvalidDataException($"The packet read from the stream ({(type >> 4) & 0xF}.{type & 0xF}) does not have an associated type.");

            long size = ReadBuffer[pos++];
            if (size == 254)
                size = BitConverter.ToUInt16(new byte[2] { ReadBuffer[pos++], ReadBuffer[pos++] },0);
            else if (size == 255)
            {
                byte[] number = new byte[4];
                for(int i = 0; i < 4; i++)
                {
                    number[i] = ReadBuffer[pos++];
                }
                size = BitConverter.ToInt32(number, 0);
            }

            Type packetType;
            if (packetTypeBlock.ContainsKey(-1))
                packetType = packetTypeBlock[-1];
            else
            {
                var subType = ReadBuffer[pos++];
                if(!packetTypeBlock.TryGetValue(subType, out packetType))
                    throw new InvalidDataException($"The packet read from the stream ({(type >> 4) & 0xF}.{type & 0xF}.{subType}) does not have an associated type.");
                size -= sizeof(byte);
            }

            var instance = (Packet) Activator.CreateInstance(packetType);
            instance.Variant = (byte)(type & 0xF);

            byte[] PacketData = new byte[size];
            for(int i = 0; i < size; i++)
            {
                PacketData[i] = ReadBuffer[pos++];
            }

            instance.ReadImpl(PacketData, size,0,client);

            return instance;
        }

        /**
         Example UDP Binary message: {Type: xx, Sub: xx, Channel id: x, x, User ID: x, x, Message...}
         */
        public static Packet ReadPacket(byte[] bytes, LacewingClient client = null)
        {
            var pos = 0;
            var type = bytes[pos++];

            if (!TypeReadMap.TryGetValue((byte)((type >> 4) & 0xF), out var packetTypeBlock))
                throw new InvalidDataException($"The packet read from the stream ({(type >> 4) & 0xF}.{type & 0xF}) does not have an associated type.");
            

            Type packetType;
            if (packetTypeBlock.ContainsKey(-1))
                packetType = packetTypeBlock[-1];
            else
            {
                var subType = bytes[pos++];
                if (!packetTypeBlock.TryGetValue(subType, out packetType))
                    throw new InvalidDataException($"The packet read from the stream ({(type >> 4) & 0xF}.{type & 0xF}.{subType}) does not have an associated type.");
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
