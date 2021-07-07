using System;
using System.Collections.Generic;
using System.Text;

namespace Alzaitu.Lacewing.Client.Packet
{
    public class BinaryReader
    {
        private byte[] Message { get; set; }
        private int cursor = 0;
        public BinaryReader(byte[] message)
        {
            Message = message;
        }

        public byte ReadByte(int position = int.MaxValue)
        {
            if(position == int.MaxValue)
            {
                position = cursor;
                cursor++;
            }
            if(Message.Length > position)
            {
                return Message[position];
            }
            return 0;
        }

        public string ReadText(int length = 0, int position = int.MaxValue)
        {
            if (position == int.MaxValue)
            {
                position = cursor;
                cursor++;
            }
            if(length == 0)
            {
                List<byte> list = new List<byte>();
                bool terminate = false;
                while (Message.Length > position)
                {
                    if (Message[position] != 0)
                        list.Add(Message[position]);
                    else
                        terminate = true;
                    position++;
                    cursor++;
                    if (terminate)
                        break;
                }
                if(terminate)
                    return Encoding.UTF8.GetString(list.ToArray());
            } else
            {
                if (Message.Length > position + length - 1)
                {
                    List<byte> list = new List<byte>();
                    for (int i = 0; i < length; i++)
                    {
                        list.Add(Message[position]);
                        position++;
                        cursor++;
                    }
                    return Encoding.UTF8.GetString(list.ToArray());
                }
            }
            return null;
        }

        public int ReadInt(int position = int.MaxValue)
        {
            if (position == int.MaxValue)
            {
                position = cursor;
                cursor += sizeof(int);
            }
            if (Message.Length > position+(sizeof(int)-1))
            {
                return BitConverter.ToInt32(Message,position);
            }
            return 0;
        }

        public uint ReadUInt(int position = int.MaxValue)
        {
            if (position == int.MaxValue)
            {
                position = cursor;
                cursor += sizeof(uint);
            }
            if (Message.Length > position + (sizeof(uint) - 1))
            {
                return BitConverter.ToUInt32(Message, position);
            }
            return 0;
        }

        public short ReadShort(int position = int.MaxValue)
        {
            if (position == int.MaxValue)
            {
                position = cursor;
                cursor += sizeof(short);
            }
            if (Message.Length > position + (sizeof(short) - 1))
            {
                return BitConverter.ToInt16(Message, position);
            }
            return 0;
        }

        public ushort ReadUShort(int position = int.MaxValue)
        {
            if (position == int.MaxValue)
            {
                position = cursor;
                cursor += sizeof(ushort);
            }
            if (Message.Length > position + (sizeof(ushort) - 1))
            {
                return BitConverter.ToUInt16(Message, position);
            }
            return 0;
        }

        public float ReadFloat(int position = int.MaxValue)
        {
            if (position == int.MaxValue)
            {
                position = cursor;
                cursor += sizeof(float);
            }
            if (Message.Length > position + (sizeof(float) - 1))
            {
                return BitConverter.ToSingle(Message, position);
            }
            return 0;
        }
    }
}
