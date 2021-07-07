using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alzaitu.Lacewing.Client;
using DiscordRPC;
using DiscordRPC.Logging;
using Duality;

namespace FNaFMP
{
    /// <summary>
    /// Defines a Duality core plugin.
    /// </summary>
    public class Core : CorePlugin
    {
        public const string VERSION = "0.1.1";
        private static string secret = Guid.NewGuid().ToString();
        private static Guid party = Guid.NewGuid();
        public static Guid PartyID
        {
            get { return party; }
            set { party = value; }
        }
        private static Character character = Character.None;
        public static Character SelfCharacter
        {
            get { return character; }
            set { character = value; }
        }
        public static readonly string[] CharacterName =
        {
            "None",
            "Freddy",
            "Bonnie",
            "Chica",
            "Foxy",
            "Guard"
        };
        public enum Character
        {
            None,
            Freddy,
            Bonnie,
            Chica,
            Foxy,
            Guard
        }
        private static DateTime Start = DateTime.UtcNow;
        private static DiscordRpcClient discord;
        public static DiscordRpcClient DRPC
        {
            get { return discord; }
        }
        private static LacewingClient client;
        public static LacewingClient Client
        {
            get { return client; }
        }
        public static void Reset()
        {
            Start = DateTime.UtcNow;
            client.Dispose();
            client = new LacewingClient();
            party = Guid.NewGuid();
            discord.SetPresence(BuildPresence("In Menu","",party.ToString(),1,1));
        }
        public static RichPresence BuildPresence(string Details, string State, string PartyID, int PartyMax, int PartySize)
        {
            return new RichPresence()
            {
                Details = Details,
                State = State,
                Assets = new Assets()
                {
                    LargeImageKey = "icon"
                },
                Timestamps = new Timestamps()
                {
                    Start = Start,
                },
                Secrets = new Secrets()
                {
                    JoinSecret = secret
                },
                Party = new Party()
                {
                    ID = PartyID,
                    Max = PartyMax,
                    Size = PartySize,
                    Privacy = Party.PrivacySetting.Public
                }
            };
        }
        protected override void OnGameStarting()
        {
            character = Character.None;

            client = new LacewingClient();

            Start = DateTime.UtcNow;
            party = Guid.NewGuid();
            discord = new DiscordRpcClient("629989727549784085");
            discord.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            //Subscribe to events
            discord.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };
            discord.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };
            discord.Initialize();
            discord.RegisterUriScheme();
            discord.SetPresence(BuildPresence("In Menu", "", party.ToString(), 1, 1));
        }
        protected override void OnGameEnded()
        {
            if(discord != null)
            {
                discord.Dispose();
                discord = null;
            }
            if(client != null)
            {
                client.Dispose();
                client = null;
            }
        }
    }
}
