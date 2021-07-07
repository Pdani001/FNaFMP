using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Alzaitu.Lacewing.Client.Packet.EventData;
using Alzaitu.Lacewing.Client.Packet.Message;
using Alzaitu.Lacewing.Client.Packet.Request;
using Alzaitu.Lacewing.Client.Packet.Response;

namespace Alzaitu.Lacewing.Client.Packet
{
    class PacketHandler
    {
        public static void Handle(Packet packet, LacewingClient client, bool blasted = false)
        {
            if (!client.IsConnected)
            {
                switch (packet)
                {
                    case PacketResponseConnect responseConnect:
                        if (responseConnect.Success)
                        {
                            client.Event.OnResponseConnect(new EventResponseConnect
                            {
                                PeerID = responseConnect.PeerId,
                                Client = client
                            });
                            client.ID = responseConnect.PeerId;
                            client.IsConnected = true;
                            client.FinishConnect();
                        }
                        else
                        {
                            //Console.WriteLine("Connection declined: " + responseConnect.DenyReason);
                            client.Dispose();
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (packet)
                {
                    case PacketResponseSetName responseSetName:
                        if (blasted)
                            break;
                        if (responseSetName.Success)
                        {
                            client.Event.OnResponseSetName(new EventResponseSetName
                            {
                                PeerID = client.ID,
                                NewName = responseSetName.Name,
                                Client = client
                            });
                            client.UserName = responseSetName.Name;
                        } else
                        {
                            client.Event.OnResponseSetName(new EventResponseSetName
                            {
                                PeerID = client.ID,
                                DenyReason = responseSetName.DenyReason,
                                Client = client
                            });
                        }
                        break;
                    case PacketResponseJoinChannel responseJoinChannel:
                        if (blasted)
                            break;
                        if (responseJoinChannel.Success)
                        {
                            client.IsMaster = responseJoinChannel.IsMaster;
                            ClientChannel channel = ClientChannel.GetChannel(client, responseJoinChannel.Channel.Name);
                            client.joinedChannels.Add(channel);
                            client.Event.OnResponseJoinChannel(new EventResponseJoinChannel
                            {
                                PeerID = client.ID,
                                Channel = responseJoinChannel.Channel.Name,
                                Client = client
                            });
                            foreach(ClientPeer peer in channel)
                            {
                                client.clientsByID[peer.Id] = peer;
                            }
                        }
                        break;
                    case PacketResponseLeaveChannel responseLeaveChannel:
                        if (blasted)
                            break;
                        if (responseLeaveChannel.Success)
                        {
                            ClientChannel channel = ClientChannel.GetChannelByID(client, responseLeaveChannel.ChannelID);
                            client.joinedChannels.Remove(channel);
                            client.Event.OnResponseLeaveChannel(new EventResponseLeaveChannel
                            {
                                PeerID = client.ID,
                                Channel = responseLeaveChannel.ChannelID,
                                Client = client
                            });
                        }
                        break;
                    case PacketResponseChannelList responseChannelList:
                        if (blasted)
                            break;
                        client.Event.OnResponseChannelList(new EventResponseChannelList
                        {
                            ChannelList = responseChannelList.ChannelList,
                            Client = client
                        });
                        break;
                    case PacketBinaryPeerMessage packetBinaryPeer:
                        ClientPeer c;
                        client.clientsByID.TryGetValue(packetBinaryPeer.Peer, out c);
                        ClientChannel ch = ClientChannel.GetChannelByID(client, packetBinaryPeer.Channel);
                        if (ch.Contains(c))
                        {
                            switch (packet.Variant) {
                                case 2:
                                    client.Event.OnBinaryMessage(new EventBinaryMessage
                                    {
                                        PeerID = packetBinaryPeer.Peer,
                                        Channel = packetBinaryPeer.Channel,
                                        SubChannel = packetBinaryPeer.SubChannel,
                                        Message = packetBinaryPeer.Message,
                                        Blasted = blasted,
                                        Client = client,
                                        Type = MessageEventType.Peer
                                    });
                                    break;
                                case 1:
                                    client.Event.OnNumberMessage(new EventNumberMessage
                                    {
                                        PeerID = packetBinaryPeer.Peer,
                                        Channel = packetBinaryPeer.Channel,
                                        SubChannel = packetBinaryPeer.SubChannel,
                                        Message = BitConverter.ToInt32(packetBinaryPeer.Message, 0),
                                        Blasted = blasted,
                                        Client = client,
                                        Type = MessageEventType.Peer
                                    });
                                    break;
                                case 0:
                                    client.Event.OnTextMessage(new EventTextMessage
                                    {
                                        PeerID = packetBinaryPeer.Peer,
                                        Channel = packetBinaryPeer.Channel,
                                        SubChannel = packetBinaryPeer.SubChannel,
                                        Message = Encoding.UTF8.GetString(packetBinaryPeer.Message),
                                        Blasted = blasted,
                                        Client = client,
                                        Type = MessageEventType.Peer
                                    });
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case ReadPacketBinaryChannelMessage packetBinaryChannel:
                        switch (packet.Variant)
                        {
                            case 2:
                                client.Event.OnBinaryMessage(new EventBinaryMessage
                                {
                                    PeerID = packetBinaryChannel.Peer,
                                    Channel = packetBinaryChannel.Channel,
                                    SubChannel = packetBinaryChannel.SubChannel,
                                    Message = packetBinaryChannel.Message,
                                    Blasted = blasted,
                                    Client = client,
                                    Type = MessageEventType.Channel
                                });
                                break;
                            case 1:
                                client.Event.OnNumberMessage(new EventNumberMessage
                                {
                                    PeerID = packetBinaryChannel.Peer,
                                    Channel = packetBinaryChannel.Channel,
                                    SubChannel = packetBinaryChannel.SubChannel,
                                    Message = BitConverter.ToInt32(packetBinaryChannel.Message,0),
                                    Blasted = blasted,
                                    Client = client,
                                    Type = MessageEventType.Channel
                                });
                                break;
                            case 0:
                                client.Event.OnTextMessage(new EventTextMessage
                                {
                                    PeerID = packetBinaryChannel.Peer,
                                    Channel = packetBinaryChannel.Channel,
                                    SubChannel = packetBinaryChannel.SubChannel,
                                    Message = Encoding.UTF8.GetString(packetBinaryChannel.Message),
                                    Blasted = blasted,
                                    Client = client,
                                    Type = MessageEventType.Channel
                                });
                                break;
                            default:
                                break;
                        }
                        break;
                    case ReadPacketPeer packetPeer:
                        if (blasted)
                            break;
                        packetPeer.UpdatePeer(client);
                        client.Event.OnPeer(new EventPeer
                        {
                            PeerID = packetPeer.PeerID,
                            Action = packetPeer.Action,
                            Channel = packetPeer.Channel,
                            Client = client
                        });
                        break;
                    case ReadPacketPing _:
                        client.Event.OnPing(new EventPing
                        {
                            PeerID = client.ID,
                            Client = client
                        });
                        client.WritePacket(new WritePacketPong(), blasted);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
