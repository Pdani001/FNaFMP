using System.IO;

namespace Alzaitu.Lacewing.Client.Packet.Message
{
    [PacketType(4, true, false)]
    internal class WritePacketBinaryServerChannelMessage : Packet
    {
        public byte SubChannel { get; set; }

        public int Channel { get; set; }

        public byte[] Message { get; set; }

        protected override void WriteImpl(BinaryWriter wrt)
        {
            wrt.Write(SubChannel);
            wrt.Write(InverseShort(Channel));
            wrt.Write(Message);
        }

        public override long GetSize() => 3 + Message.LongLength;
    }
}
