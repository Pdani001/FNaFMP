using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Editor;
using Duality.Input;
using Duality.Resources;
using Alzaitu.Lacewing.Client.Packet.EventData;
using Alzaitu.Lacewing.Client.Packet;
using Alzaitu.Lacewing.Client;

namespace FNaFMP.Select
{
	public class BGTasks : Component, ICmpInitializable, ICmpUpdatable
    {
		private List<int> Players = new List<int>();
		public ContentRef<Scene> LobbyScene { get; set; }
		public ContentRef<Scene> LoadingScene { get; set; }
		private static Dictionary<Core.Character, Checkmark> Checkmarks = new Dictionary<Core.Character, Checkmark>();
		private static Dictionary<int, Core.Character> Peers = new Dictionary<int, Core.Character>();
		private static List<Core.Character> Ready = new List<Core.Character>();
		public static void LoadCheckmark(Checkmark mark)
        {
			if (mark == null || mark.Character == Core.Character.None)
				return;
			Checkmarks[mark.Character] = mark;
        }
		public static Checkmark GetCheckmark(Core.Character c)
        {
			if (c == Core.Character.None)
				return null;
			return Checkmarks[c];
        }
		public static void SetReady(Core.Character c, bool value)
        {
            if (value)
            {
				if (!Ready.Contains(c))
					Ready.Add(c);
            } else
            {
				Ready.Remove(c);
            }
        }

		public static bool IsReady(Core.Character c)
        {
			return Ready.Contains(c);
        }

        public void OnActivate()
        {
			if (Core.DRPC != null)
			{
				DiscordRPC.RichPresence presence = Core.DRPC.CurrentPresence;
				Core.DRPC.SetPresence(Core.BuildPresence("In Lobby","Selecting",presence.Party.ID,5,presence.Party.Size));
			}
			Ready.Clear();
			Peers.Clear();
            if(Core.Client != null)
            {
                if (!Core.Client.IsConnected)
                {
					return;
                }
				Utility.Utilities.Logger.Write("Character select screen is ready!");
				Players.Add(Core.Client.ID);
                Core.Client.Event.ResponseLeaveChannel += Event_LeaveChannel;
                Core.Client.Event.Peer += Event_Peer;
                Core.Client.Event.BinaryMessage += Event_BinaryMessage;
                Core.Client.Event.NumberMessage += Event_NumberMessage;
                if (!Core.Client.IsMaster)
                {
					Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 21, new Random().Next());
					foreach(ClientPeer peer in Core.Client.joinedChannels[0]){
						Players.Add(peer.Id);
                    }
                }
            }
        }

        private void Event_NumberMessage(object sender, EventNumberMessage e)
        {
            if(e.SubChannel == 21)
            {
				if (Core.Client.IsMaster)
				{
					Utility.Utilities.Logger.Write("Status request from {0}",e.PeerID);
					foreach (Core.Character cr in Checkmarks.Keys)
					{
						Checkmark check = Checkmarks[cr];
						if (check.Peer > -1)
						{
							List<byte> message = new List<byte>();
							message.Add((byte)cr);
							message.AddRange(BitConverter.GetBytes((ushort)check.Peer));
							message.Add((byte)(check.Ready ? 2 : 1));
							Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 2, message.ToArray());
						}
					}
					Core.DRPC.UpdatePartySize(Players.Count);
				}
				else
				{
					Players.Add(e.PeerID);
					Core.DRPC.UpdatePartySize(Players.Count);
				}
			}
        }

        private void Event_BinaryMessage(object sender, EventBinaryMessage e)
        {
			if (e.Message == null)
			{
				Utility.Utilities.Logger.Write(Utility.Logger.LogLevel.ERROR, "Binary message was null!!");
				return;
			}
			BinaryReader reader = new BinaryReader(e.Message);
            switch (e.SubChannel)
            {
				case 2:
					byte cb = reader.ReadByte();
					ushort peerId = reader.ReadUShort();
					Core.Character c = (Core.Character)cb;
					if (Enum.IsDefined(typeof(Core.Character), c))
					{
						byte status = reader.ReadByte();
						Checkmark check = Checkmarks[c];
                        switch (status)
                        {
							case 0:
								check.Peer = -1;
								check.Checked = false;
								break;
							case 1:
								check.Peer = peerId;
								check.Checked = true;
								check.Ready = false;
								Ready.Remove(c);
								break;
							case 2:
								check.Ready = true;
								Ready.Add(c);
								break;
							default:
								break;
                        }
					}
					break;
				case 12:
                    if (Core.Client.IsMaster)
                    {
						Utility.Utilities.Logger.Write("Lobby join request from {0}",e.PeerID);
						ClientChannel channel = Core.Client.joinedChannels[0];
						int count = channel.Count;
						string version = reader.ReadText();
						List<byte> msg = new List<byte>();
						ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);
						if(version != Core.VERSION)
                        {
							msg.Add(0);
							msg.AddRange(Encoding.UTF8.GetBytes("Version mismatch"));
							msg.Add(0);
							peer.SendBinaryMessage(Core.Client, 12, channel, msg.ToArray());
							break;
                        }
						if(Players.Count > 5)
                        {
							msg.Add(0);
							msg.AddRange(Encoding.UTF8.GetBytes("Lobby is full"));
							msg.Add(0);
							peer.SendBinaryMessage(Core.Client, 12, channel, msg.ToArray());
							break;
                        }
						Players.Add(e.PeerID);
						msg.Add(1);
						msg.Add((byte)Players.Count);
						msg.Add(0);
						msg.AddRange(BitConverter.GetBytes(Core.PartyID.ToString().Length));
						msg.AddRange(Encoding.UTF8.GetBytes(Core.PartyID.ToString()));
						peer.SendBinaryMessage(Core.Client, 12, channel, msg.ToArray());
					}
					break;
				default:
					break;
            }
        }

        private void Event_Peer(object sender, EventPeer e)
        {
            switch (e.Action)
            {
				case EventPeer.PeerAction.Left:
					bool left = Players.Remove(e.PeerID);
                    if (left)
                    {
						Core.DRPC.UpdatePartySize(Players.Count);
					}
					foreach (Core.Character c in Checkmarks.Keys)
					{
						Checkmark check = Checkmarks[c];
						if (check.Peer == e.PeerID)
						{
							check.Checked = false;
							check.Ready = false;
							check.Peer = -1;
							break;
						}
					}
					break;
				/*case EventPeer.PeerAction.Join:
                    if (Core.Client.IsMaster)
                    {
						foreach (Core.Character c in Checkmarks.Keys)
						{
							Checkmark check = Checkmarks[c];
							if(check.Peer > -1)
                            {
								List<byte> message = new List<byte>();
								message.Add((byte)c);
								message.AddRange(BitConverter.GetBytes((ushort)check.Peer));
								message.Add((byte)(check.Ready ? 2 : 1));
								Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 2, message.ToArray());
							}
						}
					}
					break;*/
				default:
					break;
			}
        }

        private void Event_LeaveChannel(object sender, EventResponseLeaveChannel e)
        {
			Core.SelfCharacter = Core.Character.None;
			if(LobbyScene != null)
            {
				Scene.SwitchTo(LobbyScene);
            }
			else
            {
				Utility.Utilities.Logger.Write(Utility.Logger.LogLevel.ERROR, "Couldn't find the lobby screen!");
				Scene.SwitchTo(DualityApp.AppData.StartScene);
			}
        }

        public void OnDeactivate()
        {
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseLeaveChannel -= Event_LeaveChannel;
				Core.Client.Event.Peer -= Event_Peer;
                Core.Client.Event.BinaryMessage -= Event_BinaryMessage;
				Core.Client.Event.NumberMessage -= Event_NumberMessage;
			}
		}
		private int countdown = -1;
		private int nextcount = -1;
        public void OnUpdate()
        {
            if(Core.Client != null)
            {
				if (!Core.Client.IsConnected)
				{
					Core.SelfCharacter = Core.Character.None;
					if (LobbyScene != null)
					{
						Scene.SwitchTo(LobbyScene);
					}
					else
					{
						Scene.SwitchTo(DualityApp.AppData.StartScene);
					}
					return;
				}
				if(Ready.Contains(Core.Character.Guard) && Ready.Count >= 2 && Ready.Count == Players.Count)
                {
					if(nextcount == -1 && countdown == -1)
                    {
						countdown = 6;
                    }
					if (nextcount > -1 && countdown == (Core.Client.IsMaster ? -1 : 0))
					{
						if (LoadingScene != null)
						{
							Scene.SwitchTo(LoadingScene);
						}
						else
						{
							Utility.Utilities.Logger.Write(Utility.Logger.LogLevel.ERROR, "Couldn't find the loading screen!");
							Scene.SwitchTo(DualityApp.AppData.StartScene);
						}
					}
					if(nextcount <= Time.MainTimer.TotalSeconds)
                    {
						ChatBox.AddChat($"[Game] Starting in {countdown} second(s)...");
						nextcount = (int)(Time.MainTimer.TotalSeconds + 1);
						countdown--;
                    }
                } else
                {
					if(nextcount > -1)
                    {
						ChatBox.AddChat($"[Game] Starting aborted.");
					}
					countdown = -1;
					nextcount = -1;
                }
			} else
            {
				Utility.Utilities.Logger.Write(Utility.Logger.LogLevel.ERROR, "There was no Lacewing client on the character select menu!");
				Utility.Utilities.Logger.Write(Utility.Logger.LogLevel.ERROR, "If you see this, it means something went horribly wrong.");
				Scene.SwitchTo(DualityApp.AppData.StartScene);
			}
        }
    }
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class Checkmark : Component, ICmpUpdatable
    {
		private Transform transform = null;
		private SpriteRenderer renderer = null;
		private Point2 Size = Point2.Zero;
		[EditorHintFlags(MemberFlags.ReadOnly)]
		public bool Checked { get; set; }
		[EditorHintFlags(MemberFlags.ReadOnly)]
		public bool Ready { get; set; }
		private int peer = -1;
		[EditorHintFlags(MemberFlags.ReadOnly)]
		public int Peer
        {
			get { return peer; }
			set { peer = value; }
        }
		public Core.Character Character { get; set; }
		private uint nextclick = 0;
		public void OnUpdate()
        {
			if (Character == Core.Character.None)
				return;
			if (renderer == null || transform == null)
			{
				transform = GameObj.Transform;
				renderer = GameObj.GetComponent<SpriteRenderer>();
				Checked = false;
				Ready = false;
				BGTasks.LoadCheckmark(this);
			}
			else
			{
				if (Size == Point2.Zero)
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
					Size = text.Size;
				}
				ColorRgba color = renderer.ColorTint;
				color.A = (byte)(!Checked ? 0 : !Ready ? 127 : 255);
				renderer.ColorTint = color;
				Vector3 pos = transform.Pos;
				Vector2 mouse = DualityApp.Mouse.Pos;
				if (Core.Client == null || !Core.Client.IsConnected)
					return;
				if (DualityApp.Mouse.ButtonHit(MouseButton.Left))
				{
					bool onbox = (mouse.X > pos.X && mouse.X < pos.X + Size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + Size.Y);
                    if (onbox)
                    {
						if (nextclick > Time.MainTimer.TotalMilliseconds)
							return;
						nextclick = (uint)(Time.MainTimer.TotalMilliseconds + 500);
						if (!Checked)
                        {
							if (Core.SelfCharacter != Core.Character.None)
								return;
							Checked = true;
							Peer = Core.Client.ID;
							List<byte> message = new List<byte>();
							message.Add((byte)Character);
							message.AddRange(BitConverter.GetBytes(Core.Client.ID));
							message.Add(1);
							Core.SelfCharacter = Character;
							Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 2, message.ToArray());
                        }
                        else
                        {
							if (Core.SelfCharacter == Character && !Ready)
							{
								Checked = false;
								Peer = -1;
								List<byte> message = new List<byte>();
								message.Add((byte)Character);
								message.AddRange(BitConverter.GetBytes(Core.Client.ID));
								message.Add(0);
								Core.SelfCharacter = Core.Character.None;
								Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 2, message.ToArray());
							}
						}
                    }
				}
			}
		}
    }

	public class BackButton : Component, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		//public ContentRef<Scene> LobbyScene { get; set; }
		private Point2 location = new Point2(0, 0);
		public Point2 ButtonLocation
        {
			get { return location; }
			set { location = value; }
        }
		private bool leave = false;

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

			Point2 window = DualityApp.WindowSize;
			string display = "Back";
			Vector2 size = canvas.MeasureText(display);
			canvas.DrawText(display, location.X - (size.X / 2), location.Y - (size.Y / 2));

			this.canvas.End();

			Vector2 mouse = DualityApp.Mouse.Pos;
			if (DualityApp.Mouse.ButtonHit(MouseButton.Left) && !leave)
			{
				if (mouse.X > location.X - (size.X / 2) && mouse.X < location.X + size.X + (size.X/2) && mouse.Y > location.Y - (size.Y / 2) && mouse.Y < location.X + size.Y + (size.Y / 2))
				{
					leave = true;
					Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
				}
			}

		}
	}

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class ReadyButton : Component, ICmpUpdatable
	{
		private uint nextclick = 0;
		private Transform transform = null;
		private SpriteRenderer renderer = null;
		private Point2 Size = Point2.Zero;
		public void OnUpdate()
		{
			if (renderer == null || transform == null)
			{
				transform = GameObj.Transform;
				renderer = GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				Checkmark check = BGTasks.GetCheckmark(Core.SelfCharacter);
				if(check == null)
                {
					return;
                }
				if (Size == Point2.Zero)
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
					Size = text.Size;
				}
				Vector3 pos = transform.Pos;
				Vector2 mouse = DualityApp.Mouse.Pos;
				if (Core.Client == null || !Core.Client.IsConnected)
					return;
				if (DualityApp.Mouse.ButtonHit(MouseButton.Left))
				{
					bool onbox = (mouse.X > pos.X && mouse.X < pos.X + Size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + Size.Y);
					if (onbox)
					{
						if (nextclick > Time.MainTimer.TotalMilliseconds)
							return;
						nextclick = (uint)(Time.MainTimer.TotalMilliseconds + 500);
						List<byte> message = new List<byte>();
						message.Add((byte)Core.SelfCharacter);
						message.AddRange(BitConverter.GetBytes(Core.Client.ID));
						message.Add((byte)(check.Ready ? 1 : 2));
						Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 2, message.ToArray());
						check.Ready = !check.Ready;
						BGTasks.SetReady(Core.SelfCharacter, check.Ready);
						Core.DRPC.UpdateState(check.Ready ? "Ready" : "Selecting");
					}
				}
			}
		}
	}

	public class CharacterText : Component, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		//public ContentRef<Scene> LobbyScene { get; set; }
		private Point2 location = new Point2(0, 0);
		public Point2 TextLocation
		{
			get { return location; }
			set { location = value; }
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

			Point2 window = DualityApp.WindowSize;
			string display = $"You selected: {Core.CharacterName[(int)Core.SelfCharacter]}";
			Vector2 size = canvas.MeasureText(display);
			canvas.DrawText(display, location.X, location.Y);

			this.canvas.End();
		}
	}

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class ChatBox : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private static List<string> Chat = new List<string>();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		private int maxlength = 128;
		[EditorHintRange(10, 128)]
		public int MaxLength
		{
			get { return maxlength; }
			set { maxlength = value; }
		}

		private int cutlength = 32;
		public int CutLength
		{
			get { return cutlength; }
			set { cutlength = value; }
		}

		private uint lines = 10;
		public uint MaxLines
		{
			get { return lines; }
			set { lines = value; }
		}

		private Point2 chatpos = new Point2(0,0);
		public Point2 ChatPosition
		{
			get { return chatpos; }
			set { chatpos = value; }
		}

		private Transform transform = null;
		private SpriteRenderer renderer = null;

		private string Text = "";
		private string extra = "";

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			staticcut = cutlength;
			this.canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.Black;
			canvas.State.TextFont = this.font;

			if (input > -1 && input <= Time.MainTimer.TotalMilliseconds)
			{
				if (extra == "")
					extra = "|";
				else
					extra = "";
				input = (int)Time.MainTimer.TotalMilliseconds + 500;
			}

			if (transform != null)
			{
				if(Text.Length > cutlength)
					canvas.DrawText(Text.Substring(Text.Length-cutlength) + extra, transform.Pos.X + 5, transform.Pos.Y + 3);
				else
					canvas.DrawText(Text + extra, transform.Pos.X + 6, transform.Pos.Y + 3);
			}

			this.canvas.End();

			if (backspace > -1 && backspace < Time.MainTimer.TotalMilliseconds)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 50;
				if (Text.Length > 0)
				{
					Text = Text.Substring(0, Text.Length - 1);
				}
			}
			if (repeat > -1 && repeat < Time.MainTimer.TotalMilliseconds)
			{
				repeat = (int)Time.MainTimer.TotalMilliseconds + 50;
				if (Text.Length < maxlength)
					Text += c;
			}
			// CHAT DISPLAY
			this.canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = this.font;

			int start = (int)(Chat.Count <= lines ? 0 : Chat.Count - lines);
			int space = 0;
			for(int i = start; i < Chat.Count; i++)
            {
				canvas.DrawText(Chat[i], chatpos.X, chatpos.Y + (font.Res.Height*space));
				space++;
            }

			this.canvas.End();

			// TEXT BOX
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
					canvas.State.ColorTint = ColorRgba.White;
					canvas.State.TextFont = this.font;

					string create = "Press enter";
					Vector2 textSize = canvas.MeasureText(create);

					canvas.DrawText(create, pos.X + size.X, pos.Y + size.Y - textSize.Y);

					this.canvas.End();
				}
			}
		}

		private int nextchat = -1;
		private int input = -1;
		private int backspace = -1;
		private int repeat = -1;
		private string c = "";
		private void KeyDown(object sender, KeyboardKeyEventArgs args)
		{
			if (input == -1)
				return;
			if (args.Key == Key.BackSpace)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 500;
				if (Text.Length > 0)
				{
					Text = Text.Substring(0, Text.Length - 1);
				}
			}
			else if (args.Key == Key.Enter || args.Key == Key.KeypadEnter)
			{
				if (input > -1)
				{
					if (Text.Replace(" ","").Length <= 0)
						return;
					if (nextchat > Time.MainTimer.TotalSeconds)
						return;
					nextchat = (int)(Time.MainTimer.TotalSeconds + 2);
					SendMessage();
				}
			}
			else if (args.Key == Key.Escape)
			{
				input = -1;
				extra = "";
			}
			else
			{
				if (Text.Length >= maxlength)
					return;
				c = DualityApp.Keyboard.CharInput;
				if (!c.Equals(""))
				{
					Text += c;
					repeat = (int)Time.MainTimer.TotalMilliseconds + 500;
				}
				else
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

		private void SendMessage()
        {
			List<byte> msg = new List<byte>();
			msg.Add((byte)Core.SelfCharacter);
			msg.AddRange(BitConverter.GetBytes(Text.Length));
			msg.AddRange(Encoding.UTF8.GetBytes(Text));
			Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 15, msg.ToArray());
			string display = Core.Client.UserName + ": " + Text;
			AddChat(display);
			Text = "";
        }

		private static int staticcut = 0;
		public static void AddChat(string display)
        {
			if (display.Length > staticcut)
			{
				int cut = (int)Math.Floor(display.Length / (float)staticcut);
				for (int i = 0; i <= cut; i++)
				{
					int max = staticcut;
					int min = i * staticcut;
					if (min + max > display.Length)
						max = display.Length - min;
					if (Chat.Count > int.MaxValue)
						Chat.RemoveAt(0);
					Chat.Add(display.Substring(min, max));
				}
			}
			else
			{
				if (Chat.Count > int.MaxValue)
					Chat.RemoveAt(0);
				Chat.Add(display);
			}
		}

		private void Event_BinaryMessage(object sender, EventBinaryMessage e)
        {
			if (e.Message == null)
				return;
			if(e.SubChannel == 15)
            {
				ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);
				BinaryReader reader = new BinaryReader(e.Message);
				Core.Character c = (Core.Character)reader.ReadByte();
				int length = reader.ReadInt();
				string text = reader.ReadText(length);
				string display = peer.Name + ": " + text;
				AddChat(display);
            }
        }

		public void OnActivate()
		{
			Chat.Clear();
			AddChat("Welcome to Fazbear Multiplayer!");
			DualityApp.Keyboard.KeyDown += KeyDown;
			DualityApp.Keyboard.KeyUp += KeyUp;
			if (Core.Client != null)
			{
                Core.Client.Event.BinaryMessage += Event_BinaryMessage;
			}
		}

        public void OnDeactivate()
		{
			DualityApp.Keyboard.KeyDown -= KeyDown;
			DualityApp.Keyboard.KeyUp -= KeyUp;
			if (Core.Client != null)
			{
				Core.Client.Event.BinaryMessage -= Event_BinaryMessage;
			}
		}
	}
}
