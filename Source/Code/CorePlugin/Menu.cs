﻿using Duality;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Resources;
using Duality.Input;
using FNaFMP.Utility;
using FNaFMP.Startup;
using Alzaitu.Lacewing.Client.Packet.EventData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duality.Components;
using Alzaitu.Lacewing.Client;
using Duality.Editor;
using Alzaitu.Lacewing.Client.Packet;
using FNaFMP.Alzaitu.Lacewing.Client.Packet;

namespace FNaFMP.Menu
{
	[RequiredComponent(typeof(SpriteRenderer))]
	public class Logo : Component, ICmpInitializable
	{
		private SpriteRenderer render = null;
		public void OnActivate()
		{
			if (render == null)
				render = GameObj.GetComponent<SpriteRenderer>();
			if (SplashText.IsLast)
				render.ColorTint = render.ColorTint.WithAlpha(0);
			else
				render.ColorTint = render.ColorTint.WithAlpha(255);
		}

		public void OnDeactivate()
		{
			SplashText.IsLast = false;
		}
	}
	[RequiredComponent(typeof(SpriteRenderer))]
	public class Background : Component, ICmpUpdatable, ICmpInitializable
	{
		public static SoundManager SM { get; private set; }
		private static int opacity = 0;
		private static int Opacity
		{
			get { return opacity; }
			set { opacity = value; }
		}
		public static int GetOpacity()
		{
			return Opacity;
		}
		private ContentRef<Material> def = null;
		private ContentRef<Material> fnaf57bg = null;
		private ContentRef<Sound> ambience = null;
		private ContentRef<Sound> themetune = null;
		private ContentRef<Sound> fnaf57 = null;
		public ContentRef<Sound> Ambience
		{
			get { return ambience; }
			set { ambience = value; }
		}
		public ContentRef<Sound> ThemeTune
		{
			get { return themetune; }
			set { themetune = value; }
		}
		public ContentRef<Sound> RareMusic
		{
			get { return fnaf57; }
			set { fnaf57 = value; }
		}
		public ContentRef<Material> RareBackground
		{
			get { return fnaf57bg; }
			set { fnaf57bg = value; }
		}
		private int music = 0;
		public int Music
		{
			get { return music; }
		}
		private int lastOpacity = 0;
		private int lastSprite = 0;
		private readonly Random rnd = new Random();
		private SpriteRenderer render = null;
		private SoundEmitter.Source source = null;
		private bool nosound = false;
		public void OnUpdate()
		{
			if (render == null)
			{
				render = GameObj.GetComponent<SpriteRenderer>();
				return;
			}
			if (SM == null)
				return;
			if(def == null)
			{
				def = render.SharedMaterial;
			}
			if(source == null && !nosound)
			{
				switch (music)
				{
					case 0:
						if (!SplashText.IsLast)
							music = Randomizer.Random(2,5);
						else
							music = 1;
						break;
					case 1:
						if (RareMusic != null)
							source = SM.PlaySound(RareMusic, true);
						else
							nosound = true;
						break;
					case 5:
						if (ThemeTune != null)
							source = SM.PlaySound(ThemeTune, false);
						else
							nosound = true;
						break;
					default:
						if (Ambience != null)
							source = SM.PlaySound(Ambience, false);
						else
							nosound = true;
						break;
				}
			}
			if(source != null)
			{
				switch (music)
				{
					case 1:
						break;
					case 5:
						if (!SM.IsPlaying(source))
						{
							music = Randomizer.Random(2, 4);
							source = null;
						}
						break;
					default:
						if (!SM.IsPlaying(source))
						{
							music = Randomizer.Random(2, 5);
							source = null;
						}
						break;
				}
			}
			ColorRgba color = render.ColorTint;
			TimeSpan span = Time.MainTimer;
			int seconds = (int)span.TotalMilliseconds;
			if (lastOpacity + 90 < seconds)
			{
				Opacity = rnd.Next(250);
				lastOpacity = seconds;
			}
			if (music != 1)
			{
				render.SharedMaterial = def;
				if (lastSprite + 300 < seconds)
				{
					int bg = rnd.Next(100);
					render.SpriteIndex = (bg > 96) ? bg - 96 : 0;
					lastSprite = seconds;
				}
				color.A = (byte)(255 - Opacity);
			} else
			{
				if(fnaf57bg != null)
					render.SharedMaterial = fnaf57bg;
				render.SpriteIndex = 0;
				color.A = 255;
			}
			render.ColorTint = color;
		}

		public void OnActivate()
		{
			SoundManager.OnLoad += SoundManager_OnLoad;
			if (Core.DRPC != null)
			{
				Core.DRPC.SetPresence(Core.BuildPresence(!SplashText.IsLast ? "In Menu" : "In Space", "", Core.PartyID.ToString(), 1, 1));
			}
		}

		private void SoundManager_OnLoad(object sender, SoundManager e)
		{
			SM = e;
			SoundManager.OnLoad -= SoundManager_OnLoad;
		}

		public void OnDeactivate()
		{
			music = 0;
			SM.StopSound(source);
			SM = null;
		}
	}

	public class MenuText : Component, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups | VisibilityFlag.ScreenOverlay;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			this.canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = font;

			Point2 window = Core.MaxWindowSize;
			string display = string.Format("v{0}, Build {1}", Core.VERSION, DualityApp.AppData.Version);
			Vector2 size = canvas.MeasureText(display);
			canvas.DrawText(display, window.X - size.X - 5, window.Y - size.Y);


			this.canvas.End();
		}
	}

	public class LobbyStatusText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> Font { get; set; }
		
		[EditorHintFlags(MemberFlags.Visible)]
		private Point2 Position { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private int MaxLength { get; set; }

		public static string Status { get; set; }

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups | VisibilityFlag.ScreenOverlay;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			if (Status == null)
				Status = "";

			this.canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = Font;

			Vector2 size = canvas.MeasureText(Status);
			int height = 16;
			if (Font != null)
			{
				height = Font.Res.Height;
			}
			if (size.X > MaxLength)
			{
				int maxChar = 0;
				if (maxChar == 0)
				{
					size = canvas.MeasureText(Status.Substring(0, maxChar++));
					while (size.X < MaxLength)
					{
						size = canvas.MeasureText(Status.Substring(0, maxChar++));
					}
				}
				int step = maxChar;
				int nextline = 0;
				int cut = (int)Math.Floor(Status.Length / (float)step);
				for (int i = 0; i <= cut; i++)
				{
					int max = step;
					int min = i * step;
					if (min + max > Status.Length)
						max = Status.Length - min;
					canvas.DrawText(Status.Substring(min,max), Position.X, Position.Y + nextline);
					nextline += height;
				}
			}
			else
			{
				canvas.DrawText(Status, Position.X, Position.Y);
			}


			this.canvas.End();
		}

		public void OnActivate()
		{
			Status = null;
			if (Core.Client != null) {
				if(!Core.Client.IsConnected)
					Status = "...";
				else
					Status = "";
			}
			if(Core.LeaveReason != null)
			{
				Status = Core.LeaveReason;
				Core.LeaveReason = null;
			}
		}

		public void OnDeactivate()
		{
			Status = null;
		}
	}

	public class LobbyListSettings
	{
		private Point2 start = new Point2();
		public Point2 Start
		{
			get { return start; }
			set
			{
				if (value == null)
					return;
				start = value;
			}
		}
		private int rowstep = 32;
		public int RowStep
		{
			get { return rowstep; }
			set
			{
				rowstep = value;
			}
		}
		private int columnstep = 352;
		public int ColumnStep
		{
			get { return columnstep; }
			set
			{
				columnstep = value;
			}
		}
		private int maxrows = 10;
		public int MaxRows
		{
			get { return maxrows; }
			set
			{
				maxrows = value;
			}
		}
		private int maxcolumns = 3;
		public int MaxColumns
		{
			get { return maxcolumns; }
			set
			{
				maxcolumns = value;
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class LobbyListText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}
		
		private ContentRef<Scene> scene = null;
		public ContentRef<Scene> NextScene
		{
			get { return scene; }
			set { scene = value; }
		}

		private LobbyListSettings settings = new LobbyListSettings();
		public LobbyListSettings Settings
		{
			get { return settings; }
			set
			{
				if (value == null)
					return;
				settings = value;
			}
		}

		private string DenyReason = null;
		private string Event = null;
		private Dictionary<string,ClientChannel> ChannelList = null;
		private Dictionary<Rect,string> ListRects = null;
		private int lastFrame = 0;
		private int inforetry = -1;
		private int attempt = 0;

		private Transform transform = null;
		private SpriteRenderer renderer = null;

		private bool join = false;

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			this.canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = !SplashText.IsLast ? ColorRgba.White : new ColorRgba(181, 0, 0);
			canvas.State.TextFont = this.font;

			Point2 window = Core.MaxWindowSize;
			if(ChannelList != null)
			{
				int row = 0;
				int column = 0;
				foreach(string key in ChannelList.Keys)
				{
					if (column > settings.MaxColumns * settings.ColumnStep)
						break;
					ClientChannel channel = ChannelList[key];
					string name = channel.Name;
					if (!name.StartsWith("f1mp#"))
						continue;
					name = name.Substring("f1mp#".Length);
					if (name.Length > 22)
						name = name.Substring(0, 22);
					string display = $"{name} ({channel.Count})";
					Vector2 size = canvas.MeasureText(display);
					canvas.DrawText(display, settings.Start.X + column , settings.Start.Y + row);
					Rect rect = new Rect(settings.Start.X + column, settings.Start.Y + row, size.X, size.Y);
					if (!ListRects.ContainsKey(rect))
					{
						ListRects.Add(rect, key);
					}
					row += settings.RowStep;
					if(row >= settings.MaxRows * settings.RowStep)
					{
						row = 0;
						column += settings.ColumnStep;
					}
				}
			}

			if(ListRects != null && !join)
			{
				Vector2 mPos = DualityApp.Mouse.Pos;
				foreach(Rect rect in ListRects.Keys)
				{
					if(mPos.X > rect.X && mPos.Y > rect.Y && mPos.X < rect.X + rect.W && mPos.Y < rect.Y + rect.H)
					{
						string display = "Double click the lobby name to join!";
						Vector2 size = canvas.MeasureText(display);
						canvas.DrawText(display, window.X - size.X, 0);
						string key = ListRects[rect];
						if (DualityApp.Mouse.ButtonHit(MouseButton.Left))
						{
							if (lastFrame == 0)
							{
								lastFrame = (int)Time.MainTimer.TotalMilliseconds;
							}
							else
							{	// DOUBLE CLICKED
								Utilities.Logger.Write($"Lobby '{key}' selected, joining...");
								lastFrame = 0;
								join = true;
								Core.Client.JoinChannel(key, false, true);
							}
						} else
						{
							if (lastFrame != 0)
							{
								if (lastFrame + 500 < (int)Time.MainTimer.TotalMilliseconds)
									lastFrame = 0;
							}
						}
					}
				}
			}
			this.canvas.End();

			if(inforetry > -1 && inforetry <= Time.MainTimer.TotalSeconds)
			{
				attempt++;
				if(attempt >= 3)
				{
					inforetry = -1;
					attempt = 0;
					LobbyStatusText.Status = "Authentication failed, leaving lobby";
					Utilities.Logger.Write(DualityLogger.LogLevel.WARN,"Authentication failed, leaving channel");
					Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
				}
				else
				{
					LobbyStatusText.Status = "Authentication failed, retrying...";
					Utilities.Logger.Write(DualityLogger.LogLevel.WARN, "Authentication failed, retrying...");
					inforetry += 5;
					SendVersion();
				}
			}

			// REFRESH BUTTON
			if (renderer == null || transform == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				ColorRgba color = renderer.ColorTint;
				color.A = (byte)(ChannelList == null ? 127 : 255);
				renderer.ColorTint = color;
				if (ChannelList == null)
					return;
				Material mat = renderer.SharedMaterial.Res;
				if (mat == null)
				{
					return;
				}
				Texture text = mat.MainTexture.Res;
				if (text == null)
				{
					return;
				}
				Point2 size = text.Size;
				Vector3 pos = transform.Pos;
				Vector2 mouse = DualityApp.Mouse.Pos;
				if (mouse.X > pos.X && mouse.X < pos.X + size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + size.Y)
				{
					if (DualityApp.Mouse.ButtonHit(MouseButton.Left))
					{
						ChannelList = null;
						ListRects = null;
						Core.Client.RequestChannelList();
					}
				}
			}
		}

		private void ClientConnect(object sender, EventResponseConnect args)
		{
			if(error)
				Core.Config.Settings.Server = Core.Hosts[host-1];
			LobbyStatusText.Status = "Connected, setting name...";
			Utilities.Logger.Write("Connected, setting name...");
			if(Core.Client.UserName == null)
				Core.Client.SetName("FMPlayer"+new Random().Next(999999));
		}

		private void ClientSetName(object sender, EventResponseSetName args)
		{
			if(args.DenyReason != null)
			{
				Utilities.Logger.Write("Name set failed: "+args.DenyReason);
				LobbyStatusText.Status = "Name set failed: "+args.DenyReason;
				Event = "SetName";
				DenyReason = args.DenyReason;
				Core.Client.SetName("FMPlayer" + new Random().Next(999999));
			}
			else
			{
				LobbyStatusText.Status = "Connected to server";
				Utilities.Logger.Write("Name set, requesting channel list...");
				Core.Client.RequestChannelList();
			}
		}

		private void ClientChannelListReceive(object sender, EventResponseChannelList args)
		{
			ChannelList = args.ChannelList;
			ListRects = new Dictionary<Rect, string>();
			Utilities.Logger.Write($"Channel list received!");
		}

		public void OnChannelJoin(object sender, EventResponseJoinChannel args)
		{
			if (!join)
				return;
			if (Core.Client.IsMaster)
			{
				LobbyStatusText.Status = "Lobby no longer exists";
				Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
				return;
			}
			LobbyStatusText.Status = "Authenticating with lobby master...";
			Utilities.Logger.Write("Joined channel '{0}', starting authentication", args.Channel);
			SendVersion();
			inforetry = (int)Time.MainTimer.TotalSeconds + 5;
			attempt = 1;
			/*if (scene != null)
				Scene.SwitchTo(scene);*/
		}

		private void SendVersion()
		{
			Utilities.Logger.Write("Sending client version '"+Core.VERSION+"'...");
			List<byte> msg = new List<byte>();
			int length = Encoding.UTF8.GetByteCount(Core.VERSION);
			msg.AddRange(BinaryData.GetData(length));
			msg.AddRange(Encoding.UTF8.GetBytes(Core.VERSION));
			Utilities.Logger.Write("Length: "+length+"; "+msg.Count);
			Core.Client.joinedChannels[0].ChannelMaster.SendBinaryMessage(Core.Client, 12, Core.Client.joinedChannels[0], msg.ToArray());
		}
		
		private void BinaryMessage(object sender, EventBinaryMessage e)
		{
			if (e.Message == null)
			{
				Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "Message was null!");
				return;
			}
			Utilities.Logger.Write("Received message type {0}, on subchannel {1}", (int)e.Type, e.SubChannel);
			if (e.Type == MessageEventType.Peer && e.SubChannel == 12)
			{
				Utilities.Logger.Write("Received lobby info from peer {0}", e.PeerID);
				Utilities.Logger.Write("Channel master is {0}", Core.Client.joinedChannels[0].ChannelMaster.Id);
				if (e.PeerID == Core.Client.joinedChannels[0].ChannelMaster.Id)
				{
					Utilities.Logger.Write("Peer was channel master",e.PeerID);
					inforetry = -1;
					attempt = 0;
					BinaryReader reader = new BinaryReader(e.Message);
					bool success = reader.ReadByte() == 1;
					if (!success)
					{
						DenyReason = reader.ReadText(reader.ReadInt());
						Event = "LobbyJoin";
						LobbyStatusText.Status = "Join denied: "+DenyReason;
						Utilities.Logger.Write(DualityLogger.LogLevel.WARN,"'{0}': {1}", Event, DenyReason);
						Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
						join = false;
					} else
					{
						LobbyStatusText.Status = "Join successful, switching to character selection...";
						Utilities.Logger.Write("Join successful, switching to next scene");
						int count = reader.ReadByte();
						bool password = reader.ReadByte() == 1;	// NOT IMPLEMENTED YET (2021-06-30) ~Pdani
						// TODO: Create the password Scene! (But make the lobby chat first lol)
						int party_length = reader.ReadInt();
						string party = reader.ReadText(party_length);
						Core.DRPC.UpdateParty(new DiscordRPC.Party()
						{
							ID = party,
							Max = 5,
							Size = count,
							Privacy = DiscordRPC.Party.PrivacySetting.Public
						});
						if (scene != null)
							Scene.SwitchTo(scene);
					}
				}
			}
		}
		public void OnActivate()
		{
			Core.Difficulty = Core.GameDifficulty.VeryEasy;
			join = false;
			ChannelList = null;
			ListRects = null;
			inforetry = -1;
			attempt = 0;
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseConnect += ClientConnect;
				Core.Client.Event.ResponseSetName += ClientSetName;
				Core.Client.Event.ResponseChannelList += ClientChannelListReceive;
				Core.Client.Event.ResponseJoinChannel += OnChannelJoin;
				Core.Client.Event.ResponseLeaveChannel += OnChannelLeave;
				Core.Client.Event.BinaryMessage += BinaryMessage;
				Core.Client.Event.Error += Event_Error;
				if (!Core.Client.IsConnected)
				{
					string srv = null;
					if(Core.Config != null && Core.Config.Settings != null)
					{
						srv = Core.Config.Settings.Server;
					}
					if (srv == null)
						Core.Client.Connect("lekkit.hopto.org", 6121);
					else
					{
						connect(srv);
					}
					LobbyStatusText.Status = "Connecting to server...";
					Utilities.Logger.Write("Connecting to server...");
				}
				else
				{
					if(Core.Client.joinedChannels.Count > 0)
					{
						foreach(ClientChannel channel in Core.Client.joinedChannels)
						{
							Core.Client.LeaveChannel(channel);
						}
					}
					Core.Client.RequestChannelList();
				}
			}
		}

		private void connect(string srv)
		{
			if (srv.Contains(":"))
				Core.Client.Connect(srv.Split(':')[0], int.Parse(srv.Split(':')[1]));
			else
				Core.Client.Connect(srv, 6121);
		}

		private bool error = false;
		private int host = 0;
		private void Event_Error(object sender, EventError e)
		{
			if(e.Error.ToLower().StartsWith("failed to connect"))
			{
				Logs.Game.WriteWarning("Failed to connect to server: {0}", e.Error);
				Logs.Game.WriteWarning("Current host: {0}", Core.Config.Settings.Server);
				LobbyStatusText.Status = "Failed to connect to server";
				if (Core.Hosts == null)
					return;
				error = true;
				if(Core.Hosts.Length > 0 && Core.Hosts.Length > host)
				{
					LobbyStatusText.Status += "; Retrying...";
					connect(Core.Hosts[host++]);
				}
			}
		}

		private void OnChannelLeave(object sender, EventResponseLeaveChannel e)
		{
			join = false;
			Core.Client.RequestChannelList();
			ChannelList = null;
			ListRects = null;
			inforetry = -1;
			attempt = 0;
		}

		public void OnDeactivate()
		{
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseConnect -= ClientConnect;
				Core.Client.Event.ResponseSetName -= ClientSetName;
				Core.Client.Event.ResponseChannelList -= ClientChannelListReceive;
				Core.Client.Event.ResponseLeaveChannel -= OnChannelLeave;
				Core.Client.Event.ResponseJoinChannel -= OnChannelJoin;
				Core.Client.Event.BinaryMessage -= BinaryMessage;
				Core.Client.Event.Error -= Event_Error;
			}
		}
	}
	
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class LobbyNameText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		private int maxlength = 22;
		[EditorHintRange(10, 22)]
		public int MaxLength
		{
			get { return maxlength; }
			set { maxlength = value; }
		}
		
		private int minlength = 3;
		[EditorHintRange(0, 10)]
		public int MinLength
		{
			get { return minlength; }
			set { minlength = value; }
		}

		private ContentRef<Scene> scene = null;
		public ContentRef<Scene> NextScene
		{
			get { return scene; }
			set { scene = value; }
		}

		private Transform transform = null;
		private SpriteRenderer renderer = null;

		private string Name = "";
		private string extra = "";

		private bool join = false;

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			this.canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.Black;
			canvas.State.TextFont = this.font;

			if(input > -1 && input <= Time.MainTimer.TotalMilliseconds)
			{
				if (extra == "")
					extra = "|";
				else
					extra = "";
				input = (int)Time.MainTimer.TotalMilliseconds + 500;
			}

			if (transform != null)
				canvas.DrawText(Name + extra, transform.Pos.X+5, transform.Pos.Y+3);

			this.canvas.End();

			if(backspace > -1 && backspace < Time.MainTimer.TotalMilliseconds)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 50;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			if(repeat > -1 && repeat < Time.MainTimer.TotalMilliseconds)
			{
				repeat = (int)Time.MainTimer.TotalMilliseconds + 50;
				if (Name.Length < maxlength)
					Name += c;
			}

			// NAME BOX
			if (renderer == null || transform == null)
			{
				transform = GameObj.Transform;
				renderer = GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				Material mat = renderer.SharedMaterial.Res;
				if (mat == null)
				{
					return;
				}
				Texture text = mat.MainTexture.Res;
				if (text == null)
				{
					return;
				}
				Point2 size = text.Size;
				Vector3 pos = transform.Pos;
				Vector2 mouse = DualityApp.Mouse.Pos;
				if (DualityApp.Mouse.ButtonHit(MouseButton.Left))
				{
					bool onbox = (mouse.X > pos.X && mouse.X < pos.X + size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + size.Y);
					input = onbox ? (int)Time.MainTimer.TotalMilliseconds + 500 : -1;
					extra = onbox ? "|" : "";
				}

				if (input > -1)
				{
					this.canvas.Begin(device);

					canvas.State.SetMaterial(DrawTechnique.Mask);
					canvas.State.ColorTint = !SplashText.IsLast ? ColorRgba.White : new ColorRgba(181, 0, 0);
					canvas.State.TextFont = this.font;

					string create = "Press enter!";
					Vector2 textSize = canvas.MeasureText(create);

					canvas.DrawText(create, pos.X + size.X - textSize.X, pos.Y + size.Y);

					this.canvas.End();
				}
			}
		}

		private int input = -1;
		private int backspace = -1;
		private int repeat = -1;
		private string c = "";
		private void KeyDown(object sender, KeyboardKeyEventArgs args)
		{
			if (input == -1)
				return;
			if(args.Key == Key.BackSpace)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds+500;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			else if (args.Key == Key.Enter || args.Key == Key.KeypadEnter)
			{
				if (input > -1)
				{
					if (Name.Length < minlength)
						return;
					input = -1;
					extra = "";
					if (Core.Client != null && !join)
					{
						if (Core.Client.IsConnected && Core.Client.UserName != null)
						{
							LobbyStatusText.Status = $"Creating lobby {Name}...";
							join = true;
							Core.Client.JoinChannel($"f1mp#{Name}", false, true);
						}
					}
				}
			}
			else if(args.Key == Key.Escape)
			{
				input = -1;
				extra = "";
			}
			else
			{
				if (Name.Length >= maxlength)
					return;
				c = DualityApp.Keyboard.CharInput;
				if (!c.Equals(""))
				{
					Name += c;
					repeat = (int)Time.MainTimer.TotalMilliseconds + 500;
				} else
				{
					repeat = -1;
				}
			}
		}
		private void KeyUp(object sender, KeyboardKeyEventArgs args)
		{
			if (args.Key == Key.Enter || args.Key == Key.KeypadEnter)
				return;
			if (args.Key == Key.BackSpace)
				backspace = -1;
			else
				repeat = -1;
		}

		public void OnChannelJoin(object sender, EventResponseJoinChannel args)
		{
			if (!join)
				return;
			if(!Core.Client.IsMaster)
			{
				LobbyStatusText.Status = "A lobby already exists with this name!";
				join = false;
				Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
				return;
			}
			LobbyStatusText.Status = "Lobby created!";
			Utilities.Logger.Write("Joined channel '{0}'",args.Channel);
			if(scene != null)
				Scene.SwitchTo(scene);
		}

		public void OnActivate()
		{
			join = false;
			Name = "";
			extra = "";
			input = -1;
			backspace = -1;
			repeat = -1;
			DualityApp.Keyboard.KeyDown += KeyDown;
			DualityApp.Keyboard.KeyUp += KeyUp;
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseJoinChannel += OnChannelJoin;
			}
		}

		public void OnDeactivate()
		{
			DualityApp.Keyboard.KeyDown -= KeyDown;
			DualityApp.Keyboard.KeyUp -= KeyUp;
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseJoinChannel -= OnChannelJoin;
			}
		}
	}

	public class LoadToGame : Component, ICmpInitializable, ICmpUpdatable
	{
		private bool hascode = false;
		string code = null;
		public ContentRef<Scene> Lobby { get; set; }
		public ContentRef<Scene> Continue { get; set; }
		public void OnActivate()
		{
			hascode = false;
			code = null;
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseJoinChannel += Event_JoinChannel;
				Core.Client.Event.ResponseLeaveChannel += Event_LeaveChannel;
				if (!Core.Client.IsMaster)
				{
					Core.Client.Event.TextMessage += Event_TextMessage;
					checkin = (int)(Time.MainTimer.TotalSeconds + 10);
				}
				else
				{
					checkin = (int)(Time.MainTimer.TotalSeconds + 3);
					hascode = true;
					code = Guid.NewGuid().ToString();
					Core.Client.SendTextChannelMessage(Core.Client.joinedChannels[0].Name, 3, code);
					Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
				}
			}
		}

		private void Event_LeaveChannel(object sender, EventResponseLeaveChannel e)
		{
			if (!hascode)
			{
				Scene.SwitchTo(Lobby);
			}
			else
			{
				checkin = -1;
				Core.Client.JoinChannel(code, true, false);
			}
		}

		private void Event_JoinChannel(object sender, EventResponseJoinChannel e)
		{
			checkin = -1;
			Scene.SwitchTo(Continue);
		}

		private void Event_TextMessage(object sender, EventTextMessage e)
		{
			if(e.SubChannel == 3)
			{
				hascode = true;
				code = e.Message;
				Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
			}
		}

		public void OnDeactivate()
		{
			if (Core.Client != null)
			{
				if (!Core.Client.IsMaster)
				{
					Core.Client.Event.TextMessage -= Event_TextMessage;
				}
				Core.Client.Event.ResponseJoinChannel -= Event_JoinChannel;
				Core.Client.Event.ResponseLeaveChannel -= Event_LeaveChannel;
			}
		}
		private int checkin = -1;
		public void OnUpdate()
		{
			if(checkin > -1)
			{
				if(checkin <= Time.MainTimer.TotalSeconds)
				{
					if (!hascode)
					{
						Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
						checkin = -1;
					}
					else
					{
						if (Core.Client.joinedChannels.Count > 0)
						{
							if (Core.Client.joinedChannels[0].Name != code)
								Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
							else
								checkin = -1;
						}
						else
						{
							Core.Client.JoinChannel(code, true, false);
						}
					}
				}
			}
		}
	}

	[RequiredComponent(typeof(SpriteAnimator)),RequiredComponent(typeof(SpriteRenderer))]
	public class GameOverBlip : Component, ICmpInitializable, ICmpUpdatable
	{
		[DontSerialize] private SpriteRenderer renderer = null;
		[DontSerialize] private SpriteAnimator animator = null;

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> BlipSound { get; set; }
		public void OnActivate()
		{
			renderer = GameObj.GetComponent<SpriteRenderer>();
			animator = GameObj.GetComponent<SpriteAnimator>();
			SoundManager.OnLoad += SoundManager_OnLoad;
			renderer.SpriteIndex = 0;
			renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
			animator.Paused = false;

		}

		private void SoundManager_OnLoad(object sender, SoundManager e)
		{
			e.StopAllSounds();
			e.PlaySound(BlipSound);
			SoundManager.OnLoad -= SoundManager_OnLoad;
		}

		public void OnDeactivate()
		{
			renderer = null;
			animator = null;
		}
		public void OnUpdate()
		{
			if (!animator.IsAnimationRunning)
			{
				renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
			}
		}
	}
	
	[RequiredComponent(typeof(SpriteAnimator)),RequiredComponent(typeof(SpriteRenderer))]
	public class JumpscareFreddy : Component, ICmpInitializable, ICmpUpdatable
	{
		[DontSerialize] private SpriteRenderer renderer = null;
		[DontSerialize] private SpriteAnimator animator = null;
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> DiedScreen { get; set; }
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> KillSound { get; set; }

		public void OnActivate()
		{
			SoundManager.OnLoad += SoundManager_OnLoad;
			renderer = GameObj.GetComponent<SpriteRenderer>();
			animator = GameObj.GetComponent<SpriteAnimator>();
			renderer.SpriteIndex = 0;
			renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
			animator.Paused = false;

		}

		private void SoundManager_OnLoad(object sender, SoundManager e)
		{
			e.StopAllSounds();
			e.PlaySound(KillSound);
			SoundManager.OnLoad -= SoundManager_OnLoad;
		}

		public void OnDeactivate()
		{
			renderer = null;
			animator = null;
		}
		public void OnUpdate()
		{
			if (!animator.IsAnimationRunning)
			{
				if (Core.Client != null && Core.Client.IsConnected)
					Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 28, (int)Core.Character.Freddy);
				renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
				Scene.SwitchTo(DiedScreen);
			}
		}
	}

	[RequiredComponent(typeof(SpriteAnimator)),RequiredComponent(typeof(SpriteRenderer))]
	public class GameOverScreen : Component, ICmpInitializable, ICmpUpdatable
	{
		[DontSerialize] private SpriteRenderer renderer = null;
		[DontSerialize] private SpriteAnimator animator = null;
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> Lobby { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> StaticSound { get; set; }
		private SoundEmitter.Source source = null;
		public void OnActivate()
		{
			renderer = GameObj.GetComponent<SpriteRenderer>();
			animator = GameObj.GetComponent<SpriteAnimator>();
			source = null;
			SoundManager.OnLoad += SoundManager_OnLoad;
			checkin = (int)(Time.MainTimer.TotalMilliseconds + 10000);
			renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
			animator.Paused = false;
			alpha = 255;

		}

		private void SoundManager_OnLoad(object sender, SoundManager e)
		{
			if(source == null)
				source = e.PlaySound(StaticSound);
			SoundManager.OnLoad -= SoundManager_OnLoad;
		}

		public void OnDeactivate()
		{
			renderer = null;
			animator = null;
			if (Core.Client != null)
			{
				if(Core.Client.joinedChannels.Count > 0)
					Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
			}
		}
		private int checkin = 0;
		private int alpha = 255;
		public void OnUpdate()
		{
			if(checkin <= Time.MainTimer.TotalMilliseconds)
			{
				if(renderer.ColorTint.A > 0)
				{
					animator.Paused = true;
					alpha -= 2;
					if (alpha < 0)
						alpha = 0;
					renderer.ColorTint = renderer.ColorTint.WithAlpha((byte)alpha);
					if(alpha == 0)
						checkin = (int)(Time.MainTimer.TotalMilliseconds + 10000);
				}
				else
				{
					if (Lobby != null)
						Scene.SwitchTo(Lobby);
					checkin = (int)(Time.MainTimer.TotalMilliseconds + 10000);
				}
			}
		}
	}
}
