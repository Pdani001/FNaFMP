using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Alzaitu.Lacewing.Client;
using DiscordRPC;
using DiscordRPC.Logging;
using Duality;
using Duality.Resources;
using FNaFMP.Configuration;
using FNaFMP.Utility;
using Newtonsoft.Json;
using SharpYaml.Serialization;

namespace FNaFMP
{
	/// <summary>
	/// Defines a Duality core plugin.
	/// </summary>
	public class Core : CorePlugin
	{
		private string ConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\FNaFMultiplayer\\config1.yml";
		public const string VERSION = "0.1.6";
		public static string LeaveReason { get; set; }
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

		/// <summary>
		/// List of characters, starting with None (0)
		/// </summary>
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
			client = new LacewingClient(username);
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
				Server = "server1.dark-wire.com:6121"
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
			if (!File.Exists(ConfigPath))
			{
				config = DefaultConfig;
				string content = ser.Serialize(DefaultConfig,typeof(RootConfig));
				try
				{
					FileInfo info = new FileInfo(ConfigPath);
					info.Directory.Create();
					StreamWriter write = File.CreateText(ConfigPath);
					write.Write(content);
					write.Flush();
					write.Close();
				}
				catch (Exception e)
				{
					Logs.Core.Write("Unable to create config file: {0}", e);
				}
			}
			else
			{
				StreamReader input = new StreamReader(ConfigPath);
				config = (RootConfig)ser.Deserialize(input, typeof(RootConfig));
				if (config == null)
				{
					File.Delete(ConfigPath);
					LoadConfig();
				}
			}
		}

		private void SaveConfig()
		{
			if(config == null)
			{
				File.Delete(ConfigPath);
				return;
			}
			Serializer ser = new Serializer();
			string content = ser.Serialize(Config, typeof(RootConfig));
			try
			{
				StreamWriter write = File.CreateText(ConfigPath);
				write.Write(content);
				write.Flush();
				write.Close();
			}
			catch (Exception e)
			{
				Logs.Core.Write("Unable to write config file: {0}", e);
			}
		}

		public static string[] Hosts { get; private set; }

		internal static void LoadHosts()
		{
			Hosts = new string[0];
			Logs.Core.Write("Loading server list");
			WebClient web = new WebClient();
			string hosts = web.DownloadString("https://pdani.hu/lacewing.php");
			var result = JsonConvert.DeserializeObject<ServerHostList>(hosts);
			Hosts = result.hosts;
			Logs.Core.Write("Loaded {0} servers",Hosts.Length);
			web.Dispose();
		}


		private static string username = null;

		bool fullscreen = false;

		public static Point2 MaxWindowSize { get; private set; }

		private int restart = -1;
		protected override void OnAfterUpdate()
		{
			DualityUserData data = DualityApp.UserData;
			if(DualityApp.WindowSize.X != MaxWindowSize.X || DualityApp.WindowSize.Y != MaxWindowSize.Y)
			{
				if (DualityApp.UserData.WindowMode == ScreenMode.FixedWindow)
				{
					Logs.Core.WriteError($"Window size is not {MaxWindowSize.X}x{MaxWindowSize.Y} !! (Current: {DualityApp.WindowSize.X}x{DualityApp.WindowSize.Y})");
					data.WindowSize = new Point2(MaxWindowSize.X, MaxWindowSize.Y);
					DualityApp.UserData = data;
				}
			}
			if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.F11))
			{
				fullscreen = !fullscreen;
				Logs.Core.Write($"Changing to {(fullscreen ? "fullscreen" : "windowed")}");
				if (!fullscreen)
				{
					data.WindowMode = ScreenMode.FixedWindow;
				}
				else
				{
					data.WindowMode = ScreenMode.Fullscreen;
				}
			}
			if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.F2))
			{
				if (restart == -1)
					restart = Time.FrameCount;
				if(restart > -1 && restart + 90 > Time.FrameCount && restart + 1 <= Time.FrameCount && DualityApp.Keyboard.KeyHit(Duality.Input.Key.F2))
				{
					restart = -1;
					if (Scene.Current != DualityApp.AppData.StartScene.Res)
						Scene.SwitchTo(DualityApp.AppData.StartScene);
					else
						Scene.Reload();
				}
				if(restart > -1 && restart + 90 <= Time.FrameCount)
				{
					restart = -1;
				}
			}
			DualityApp.UserData = data;
		}

		/**
		 * <summary>List of game difficulties</summary>
		 */
		public enum GameDifficulty
		{
			/// <summary>
			/// StringValue: Very Easy
			/// </summary>
			[StringValue("Very Easy")]
			VeryEasy = 0,
			/// <summary>
			/// StringValue: Easy
			/// </summary>
			[StringValue("Easy")]
			Easy = 1,
			/// <summary>
			/// StringValue: Medium
			/// </summary>
			[StringValue("Medium")]
			Medium = 2,
			/// <summary>
			/// StringValue: Hard
			/// </summary>
			[StringValue("Hard")]
			Hard = 3,
			/// <summary>
			/// StringValue: Very Hard
			/// </summary>
			[StringValue("Very Hard")]
			VeryHard = 4
		}

		/// <summary>
		/// Defines the difficulty of the game
		/// </summary>
		public static GameDifficulty Difficulty { get; set; }

		protected override void OnGameStarting()
		{
			Difficulty = GameDifficulty.VeryEasy;
			fullscreen = DualityApp.UserData.WindowMode == ScreenMode.Fullscreen;
			MaxWindowSize = DualityApp.AppData.ForcedRenderSize;
			username = null;
			LoadConfig();
			string[] args = Environment.GetCommandLineArgs();
			string t = "";
			bool editor = false;
			foreach(string a in args)
			{
				if (t.Length == 0)
					t += $"'{a}'";
				else
					t += ", " + $"'{a}'";

				if (a.ToLower().Contains("dualityeditor.exe"))
					editor = true;
			}
			if(!editor)
				LoadHosts();
			//Console.WriteLine("args = [{0}]",t);
			Logs.Core.Write("args = [{0}]",t);
			Logs.Core.Write("CurrentDirectory = [{0}]", System.Reflection.Assembly.GetEntryAssembly().Location);
			debug = args.Contains("--debug");
			character = Character.None;
			

			if(Config != null && Config.Gamejolt != null && !debug)
			{
				if(Config.Gamejolt.UserName != null && Config.Gamejolt.Token != null)
				{
					GamejoltAuth gamejolt = new GamejoltAuth("637821", "b285cf95496af9351bbab65b39322eaf");
					AuthResponse auth = gamejolt.Login(Config.Gamejolt.UserName, Base64.Decode(Config.Gamejolt.Token));
					if (auth.response.success)
					{
						Logs.Core.Write("Logged in as {0}",Config.Gamejolt.UserName);
						username = Config.Gamejolt.UserName;
					}
				}
			}
			client = new LacewingClient(username);

			Start = DateTime.UtcNow;
			party = Guid.NewGuid();
			discord = new DiscordRpcClient("629989727549784085");
			discord.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
			/*discord.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};
			discord.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};*/
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
			SaveConfig();
		}
	}
}
