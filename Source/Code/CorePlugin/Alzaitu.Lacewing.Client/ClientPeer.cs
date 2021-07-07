using Alzaitu.Lacewing.Client.StateMachine;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using Alzaitu.Lacewing.Client.Packet.Response;
using System;
using Alzaitu.Lacewing.Client.Packet.Message;
using System.Net;
using System.Text;

namespace Alzaitu.Lacewing.Client
{
    public sealed class ClientPeer
    {

        public string Name { get; internal set; }

        public ushort Id { get; private set; }

        public bool ChannelMaster { get; internal set; }

        internal ClientPeer(ushort Id)
        {
            this.Id = Id;
        }

        public void SendBinaryMessage(LacewingClient client, int subChannel, ClientChannel channel, byte[] data)
        {
            if (channel.Contains(this))
            {
                Packet.Packet packet = new PacketBinaryPeerMessage
                {
                    SubChannel = (byte)subChannel,
                    Channel = channel.Id,
                    Peer = Id,
                    Message = data
                };
                packet.Variant = 2;
                client.WritePacket(packet);
            }
        }

        public static ClientPeer GetPeer(LacewingClient lc, ushort id)
        {
            if (!lc.clientsByID.ContainsKey(id))
                lc.clientsByID.Add(id, new ClientPeer(id));

            return lc.clientsByID[id];
        }
    }
}
