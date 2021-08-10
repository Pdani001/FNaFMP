using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Alzaitu.Lacewing.Client;
using DiscordRPC;
using DiscordRPC.Logging;
using Duality;
using FNaFMP.Configuration;
using FNaFMP.Utility;
using SharpYaml.Serialization;

namespace FNaFMP
{
    /// <summary>
    /// Defines a Duality core plugin.
    /// </summary>
    public class Core : CorePlugin
    {
        public const string VERSION = "0.1.3";
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
        public enum Character
        {
            [StringValue("None")]
            None,
            [StringValue("Freddy")]
            Freddy,
            [StringValue("Bonnie")]
            Bonnie,
            [StringValue("Chica")]
            Chica,
            [StringValue("Foxy")]
            Foxy,
            [StringValue("Guard")]
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
            discord.SetPresence(BuildPresence("In Menu", "", party.ToString(), 1, 1));
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
        private static bool debug = false;

        /**
         * <summary>
         * If true, more information will be available to the user
         * </summary>
         */
        public static bool DEBUG
        {
            get { return debug; }
        }

        private RootConfig DefaultConfig => new RootConfig
        {
            Settings = new Settings
            {
                TempServer = "shadsoft.fr"
            }
        };

        public static RootConfig Config
        {
            get { return config; }
        }
        private static RootConfig config = null;
        private void LoadConfig()
        {
            Serializer ser = new Serializer();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FNaFMultiplayer\\config1.yml";
            if (!File.Exists(path))
            {
                config = DefaultConfig;
                string content = ser.Serialize(DefaultConfig,typeof(RootConfig));
                try
                {
                    FileInfo info = new FileInfo(path);
                    info.Directory.Create();
                    StreamWriter write = File.CreateText(path);
                    write.Write(content);
                    write.Flush();
                }
                catch (Exception e)
                {
                    Logs.Core.Write("Unable to create config file: {0}", e);
                }
            }
            else
            {
                StreamReader input = new StreamReader(path);
                config = (RootConfig)ser.Deserialize(input, typeof(RootConfig));
            }
        }
        
        protected override void OnGameStarting()
        {
            LoadConfig();
            string[] args = Environment.GetCommandLineArgs();
            string t = "";
            foreach(string a in args)
            {
                if (t.Length == 0)
                    t += $"'{a}'";
                else
                    t += ", " + $"'{a}'";
            }
            Console.WriteLine("args = [{0}]",t);
            debug = args.Contains("--debug");

            character = Character.None;

            string username = null;
            if(config != null && config.Settings != null)
            {
                username = config.Settings.TempName;
            }
            client = new LacewingClient(username);

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
