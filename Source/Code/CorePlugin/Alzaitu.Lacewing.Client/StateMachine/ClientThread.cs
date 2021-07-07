using System;
using System.Collections.Generic;
using System.Text;
using Alzaitu.Lacewing.Client.Packet;
using System.Threading;
using System.IO;

namespace Alzaitu.Lacewing.Client.StateMachine
{
    class ClientThread : BaseThread
    {
        private readonly LacewingClient client;
        public ClientThread(LacewingClient client)
        {
            this.client = client;
        }
        protected override void RunThread()
        {
            Packet.Packet packet;
            while (!client.Disposed)
            {
                if (!client.IsConnected)
                {
                    packet = client.ReadPacket();
                    PacketHandler.Handle(packet,client);
                } else
                {
                    try
                    {
                        packet = client.ReadPacket();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: "+e.Message);
                        if (e.GetType() == typeof(IOException))
                            break;
                        else
                            continue;
                    }
                    PacketHandler.Handle(packet,client);
                }
            }
            if(!client.Disposed)
                client.Dispose();
        }
    }
}
