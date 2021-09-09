using System;
using System.Collections.Generic;
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
using FNaFMP.Utility;
using FNaFMP.Alzaitu.Lacewing.Client.Packet;
using System.Text;
using System.Text.RegularExpressions;

namespace FNaFMP.Select
{
	public class BGTasks : Component, ICmpInitializable, ICmpUpdatable
	{
		public static string Password = "";
		public static SoundManager SM { get; private set; }
		private List<int> Players = new List<int>();
		public ContentRef<Scene> LobbyScene { get; set; }
		public ContentRef<Scene> LoadingScene { get; set; }
		[DontSerialize] private static Dictionary<Core.Character, Checkmark> Checkmarks = new Dictionary<Core.Character, Checkmark>();
		[DontSerialize] private static Dictionary<int, Core.Character> Peers = new Dictionary<int, Core.Character>();
		[DontSerialize] private static List<Core.Character> Ready = new List<Core.Character>();
		public static void LoadCheckmark(Checkmark mark)
		{
			if (mark == null || mark.Character == Core.Character.None)
				return;
			Checkmarks[mark.Character] = mark;
		}
		public static Checkmark GetCheckmark(Core.Character c)
		{
			if (c == Core.Character.None || !Checkmarks.ContainsKey(c))
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

		private bool WasMaster = false;
		public void OnActivate()
		{
			Core.DiscordJoinLobby = null;
			WasMaster = false;
			SoundManager.OnLoad += SoundManager_OnLoad;
			if (Core.DRPC != null)
			{
				DiscordRPC.RichPresence presence = Core.DRPC.CurrentPresence;
				Core.DRPC.UpdateState("Selecting");
				Core.DRPC.UpdateDetails("In Lobby");
				Core.DRPC.UpdateParty(new DiscordRPC.Party
				{
					ID = presence.Party.ID,
					Max = 5,
					Size = presence.Party.Size,
					Privacy = DiscordRPC.Party.PrivacySetting.Public
				});
			}
			kicked = false;
			Startup.SplashText.IsLast = false;
			Core.MenuBGM = null;
			Password = "";
			AllowReady = true;
			countdown = -1;
			nextcount = -1;
			Ready.Clear();
			Peers.Clear();
			Players.Clear();
			if(Core.Client != null)
			{
				if (!Core.Client.IsConnected)
				{
					Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "Connection the the server was interrupted, returning to lobby...");
					Scene.SwitchTo(LobbyScene);
					return;
				}
				Utilities.Logger.Write("Character select screen is ready!");
				Players.Add(Core.Client.ID);
				Core.Client.Event.ResponseLeaveChannel += Event_LeaveChannel;
				Core.Client.Event.Peer += Event_Peer;
				Core.Client.Event.BinaryMessage += Event_BinaryMessage;
				Core.Client.Event.NumberMessage += Event_NumberMessage;
				Core.Client.Event.Disconnect += Event_Disconnect;
				if (!Core.Client.IsMaster)
				{
					Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 21, new Random().Next());
					foreach(ClientPeer peer in Core.Client.joinedChannels[0]){
						Players.Add(peer.Id);
					}
				}
				else
				{
					JoinRequestUser = null;
					WasMaster = true;
					Core.Client.Event.TextMessage += Event_TextMessage;
					Core.DRPC.OnJoinRequested += DRPC_OnJoinRequested;
				}
			}
		}

		private static DiscordRPC.Message.JoinRequestMessage JoinRequestUser { get; set; }
		private static long JoinRequestTimeout = -1;
		private void DRPC_OnJoinRequested(object sender, DiscordRPC.Message.JoinRequestMessage msg)
		{
			ChatBox.AddChat($"[Discord] {msg.User.Username} requested to join the game. Type in '/accept' to accept the request. The request times out in 30 seconds",new ColorRgba(114, 137, 218));
			JoinRequestUser = msg;
			JoinRequestTimeout = (long)(Time.MainTimer.TotalMilliseconds + 30000);
		}
		public static bool AcceptJoinRequest()
		{
			if (JoinRequestUser == null || JoinRequestTimeout <= Time.MainTimer.TotalMilliseconds)
				return false;
			Core.DRPC.Respond(JoinRequestUser, true);
			return true;
		}

		private void Event_TextMessage(object sender, EventTextMessage e)
		{
			if(e.Type == MessageEventType.Peer && e.SubChannel == 13)
			{
				ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);
				if(e.Message == Password)
				{
					peer.SendNumberMessage(Core.Client, 13, Core.Client.joinedChannels[0], 1);
				}
				else
				{
					peer.SendNumberMessage(Core.Client, 13, Core.Client.joinedChannels[0], 0);
				}
			}
		}

		private void SoundManager_OnLoad(object sender, SoundManager e)
		{
			SM = e;
			SM.StopAllSounds(true);
			SoundManager.OnLoad -= SoundManager_OnLoad;
		}

		private void Event_Disconnect(object sender, EventDisconnect e)
		{
			Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "Disconnected from server: {0}", e.Reason);
			Scene.SwitchTo(LobbyScene);
		}

		private void Event_NumberMessage(object sender, EventNumberMessage e)
		{
			if(e.SubChannel == 21)
			{
				ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);
				ChatBox.AddChat(string.Format("[Game] {0} joined",peer.Name), ColorRgba.Grey);
				if (Core.Client.IsMaster)
				{
					Utilities.Logger.Write("Status request from {0}",e.PeerID);
					foreach (Core.Character cr in Checkmarks.Keys)
					{
						Checkmark check = Checkmarks[cr];
						List<byte> message = new List<byte>();
						message.Add((byte)cr);
						message.AddRange(BinaryData.GetData((ushort)check.Peer));
						if (check.Peer > -1)
						{
							message.Add((byte)(check.Ready ? 2 : 1));
						}
						else
						{
							continue;
						}
						peer.SendBinaryMessage(Core.Client, 2, Core.Client.joinedChannels[0], message.ToArray());
					}
					SendExtraLobbyInfo(peer);
					Core.DRPC.UpdatePartySize(Players.Count);
				}
				else
				{
					Players.Add(e.PeerID);
					Core.DRPC.UpdatePartySize(Players.Count);
				}
			}
			if(e.SubChannel == 14)
			{
				if(e.PeerID == Core.Client.joinedChannels[0].ChannelMaster.Id)
				{
					kicked = true;
					Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
				}
			}
		}

		public static void SendExtraLobbyInfo(ClientPeer peer = null)
		{
			if (!Core.Client.IsMaster)
				return;
			List<byte> message = new List<byte>();

			message.Add((byte)Core.Difficulty);

			if (peer != null)
				peer.SendBinaryMessage(Core.Client, 18, Core.Client.joinedChannels[0], message.ToArray());
			else
				Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 18, message.ToArray());
		}

		private void Event_BinaryMessage(object sender, EventBinaryMessage e)
		{
			if (e.Message == null)
			{
				Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "Binary message was null!!");
				return;
			}
			BinaryReader reader = new BinaryReader(e.Message);
			switch (e.SubChannel)
			{
				case 2:
					byte cb = reader.ReadByte();
					int peerId = reader.ReadUShort();
					Core.Character c = (Core.Character)cb;
					if (Enum.IsDefined(typeof(Core.Character), c))
					{
						byte status = reader.ReadByte();
						Checkmark check = Checkmarks[c];
						switch (status)
						{
							case 0:
								if (e.Type == MessageEventType.Channel)
								{
									ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);
									ChatBox.AddChat(string.Format("[Game] {0} deselected {1}", peer.Name,check.Character.GetStringValue()), ColorRgba.Green);
								}
								check.Peer = -1;
								check.Checked = false;
								check.Ready = false;
								Ready.Remove(c);
								break;
							case 1:
								if (e.Type == MessageEventType.Channel)
								{
									ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);
									if(!check.Checked)
										ChatBox.AddChat(string.Format("[Game] {0} selected {1}", peer.Name, check.Character.GetStringValue()), ColorRgba.Green);
									else
										ChatBox.AddChat(string.Format("[Game] {0} is no longer ready", check.Character.GetStringValue()), ColorRgba.Green);
								}
								check.Peer = peerId;
								check.Checked = true;
								check.Ready = false;
								Ready.Remove(c);
								break;
							case 2:
								if (e.Type == MessageEventType.Channel)
								{
									/*ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);*/
									ChatBox.AddChat(string.Format("[Game] {0} is ready", check.Character.GetStringValue()), ColorRgba.Green);
								}
								check.Peer = peerId;
								check.Checked = true;
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
						Utilities.Logger.Write("Lobby join request from {0}",e.PeerID);
						ClientChannel channel = Core.Client.joinedChannels[0];
						int count = channel.Count;
						int length = reader.ReadInt();
						string version = reader.ReadText(length);
						List<byte> msg = new List<byte>();
						ClientPeer peer = ClientPeer.GetPeer(Core.Client, (ushort)e.PeerID);
						if(version != Core.VERSION)
						{
							Utilities.Logger.Write(DualityLogger.LogLevel.WARN, "Join request from {0} denied: Version mismatch",e.PeerID);
							Utilities.Logger.Write(DualityLogger.LogLevel.WARN, "Received version: '{0}', current version: '{1}'",version,Core.VERSION);
							msg.Add(0); // FAIL
							msg.AddRange(BinaryData.GetData("Version mismatch"));
							peer.SendBinaryMessage(Core.Client, 12, channel, msg.ToArray());
							break;
						}
						if(Players.Count >= 5)
						{
							Utilities.Logger.Write(DualityLogger.LogLevel.WARN,"Join request from {0} denied: Lobby is full",e.PeerID);
							msg.Add(0); // FAIL
							msg.AddRange(BinaryData.GetData("Lobby is full"));
							peer.SendBinaryMessage(Core.Client, 12, channel, msg.ToArray());
							break;
						}
						Utilities.Logger.Write("Join request from {0} accepted",e.PeerID);
						Players.Add(e.PeerID);
						msg.Add(1);	// SUCCESS
						msg.Add((byte)Players.Count);
						msg.Add((byte)(Password == "" ? 0 : 1));
						msg.AddRange(BinaryData.GetData(Core.PartyID.ToString()));
						peer.SendBinaryMessage(Core.Client, 12, channel, msg.ToArray());
					}
					break;
				case 18:
					if(e.PeerID == Core.Client.joinedChannels[0].ChannelMaster.Id)
					{
						byte difficulty = reader.ReadByte();
						if(difficulty != (byte)Core.Difficulty)
						{
							Core.Difficulty = (Core.GameDifficulty)difficulty;
							if(e.Type == MessageEventType.Channel)
								ChatBox.AddChat($"[Game] Difficulty changed to '{Core.Difficulty.GetStringValue()}'", new ColorRgba(255, 208, 0));
							if(e.Type == MessageEventType.Peer)
								ChatBox.AddChat($"[Game] Difficulty is '{Core.Difficulty.GetStringValue()}'", new ColorRgba(255, 208, 0));
						}
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
						ChatBox.AddChat(string.Format("[Game] {0} left",e.Name), ColorRgba.Grey);
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
				default:
					break;
			}
		}

		private bool kicked = false;
		private void Event_LeaveChannel(object sender, EventResponseLeaveChannel e)
		{
			if (!kicked)
			{
				if (BackButton.leave)
				{
					Core.LeaveReason = "You left the lobby.";
				}
				else
				{
					Core.LeaveReason = "The lobby owner left.";
				}
			}
			else
				Core.LeaveReason = "You were kicked from the lobby.";
			Core.SelfCharacter = Core.Character.None;
			if(LobbyScene != null)
			{
				Utilities.Logger.Write("Channel left, returning to lobby list...");
				Scene.SwitchTo(LobbyScene);
			}
			else
			{
				Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "Couldn't find the lobby screen!");
				Scene.SwitchTo(DualityApp.AppData.StartScene);
			}
		}

		public void OnDeactivate()
		{
			SM.StopAllSounds();
			Checkmarks = new Dictionary<Core.Character, Checkmark>();
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseLeaveChannel -= Event_LeaveChannel;
				Core.Client.Event.Peer -= Event_Peer;
				Core.Client.Event.BinaryMessage -= Event_BinaryMessage;
				Core.Client.Event.NumberMessage -= Event_NumberMessage;
				Core.Client.Event.Disconnect -= Event_Disconnect;
				if (WasMaster)
				{
					Core.DRPC.OnJoinRequested -= DRPC_OnJoinRequested;
					Core.Client.Event.TextMessage -= Event_TextMessage;
				}
			}
		}
		public static bool AllowReady { get; private set; }
		[DontSerialize] private int countdown = -1;
		[DontSerialize] private int nextcount = -1;
		[DontSerialize] private bool leaving = false;
		public void OnUpdate()
		{
			if(JoinRequestTimeout > -1)
			{
				if(JoinRequestTimeout <= Time.MainTimer.TotalMilliseconds)
				{
					JoinRequestTimeout = -1;
					ChatBox.AddChat($"[Discord] The join request from {JoinRequestUser.User.Username} timed out.", new ColorRgba(114, 137, 218));
					JoinRequestUser = null;
				}
			}
			if(Core.Client != null)
			{
				if (!Core.Client.IsConnected)
				{
					if (!leaving)
					{
						Core.SelfCharacter = Core.Character.None;
						leaving = true;
						if (LobbyScene != null)
						{
							Scene.SwitchTo(LobbyScene);
						}
						else
						{
							Scene.SwitchTo(DualityApp.AppData.StartScene);
						}
					}
					return;
				}
				if(Ready.Contains(Core.Character.Guard) && Ready.Count >= 2 && Ready.Count == Players.Count)
				{
					if(nextcount == -1 && countdown == -1)
					{
						countdown = 6;
					}
					if (nextcount > -1 && countdown == 0)
						AllowReady = false;
					if (nextcount > -1 && countdown == (Core.Client.IsMaster ? -1 : 0))
					{
						if (LoadingScene != null)
						{
							nextcount = -1;
							countdown = -1;
							Ready.Clear();
							Scene.SwitchTo(LoadingScene);
						}
						else
						{
							Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "Couldn't find the loading screen!");
							Scene.SwitchTo(DualityApp.AppData.StartScene);
						}
					}
					if(nextcount <= Time.MainTimer.TotalMilliseconds)
					{
						ChatBox.AddChat($"[Game] Starting in {countdown} second(s)...", ColorRgba.Red);
						nextcount = (int)(Time.MainTimer.TotalMilliseconds + 1000);
						countdown--;
					}
				} else
				{
					if(nextcount > -1)
					{
						ChatBox.AddChat($"[Game] Starting aborted.", ColorRgba.Red);
					}
					AllowReady = true;
					countdown = -1;
					nextcount = -1;
				}
			} else
			{
				Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "There was no Lacewing client on the character select menu!");
				Utilities.Logger.Write(DualityLogger.LogLevel.ERROR, "If you see this, it means something went horribly wrong.");
				Scene.SwitchTo(DualityApp.AppData.StartScene);
			}
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class Checkmark : Component, ICmpUpdatable, ICmpInitializable
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

		public void OnActivate()
		{
			BGTasks.LoadCheckmark(this);
		}

		public void OnDeactivate()
		{
			peer = -1;
			Ready = false;
			Checked = false;
		}

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
						/*if(Character == Core.Character.Foxy)
						{
							ChatBox.AddChat("Foxy is not yet playable.", new ColorRgba(143, 9, 9));
							return;
						}*/
						if (nextclick > Time.MainTimer.TotalMilliseconds)
							return;
						nextclick = (uint)(Time.MainTimer.TotalMilliseconds + 500);
						if (!Checked)
						{
							if (Core.SelfCharacter != Core.Character.None)
								return;
							ChatBox.AddChat("[Game] You selected " + Character.GetStringValue(), ColorRgba.Green);
							Checked = true;
							Peer = Core.Client.ID;
							List<byte> message = new List<byte>();
							message.Add((byte)Character);
							message.AddRange(BinaryData.GetData(Core.Client.ID));
							message.Add(1);
							Core.SelfCharacter = Character;
							Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 2, message.ToArray());
						}
						else
						{
							if (Core.SelfCharacter == Character && !Ready)
							{
								ChatBox.AddChat("[Game] You deselected " + Character.GetStringValue(), ColorRgba.Green);
								Checked = false;
								Peer = -1;
								List<byte> message = new List<byte>();
								message.Add((byte)Character);
								message.AddRange(BinaryData.GetData(Core.Client.ID));
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

	public class BackButton : Component, ICmpRenderer, ICmpInitializable
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
		public static bool leave { get; private set; }

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
					Utilities.Logger.Write("Leaving the lobby...");
				}
			}

		}

		public void OnActivate()
		{
			leave = false;
		}

		public void OnDeactivate()
		{
			leave = false;
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
					if (onbox && BGTasks.AllowReady)
					{
						if (nextclick > Time.MainTimer.TotalMilliseconds)
							return;
						nextclick = (uint)(Time.MainTimer.TotalMilliseconds + 500);
						List<byte> message = new List<byte>();
						message.Add((byte)Core.SelfCharacter);
						message.AddRange(BinaryData.GetData(Core.Client.ID));
						message.Add((byte)(check.Ready ? 1 : 2));
						Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 2, message.ToArray());
						check.Ready = !check.Ready;

						if (check.Ready)
							ChatBox.AddChat("[Game] You are ready", ColorRgba.Green);
						else
							ChatBox.AddChat("[Game] You are no longer ready", ColorRgba.Green);
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
			string display = $"You selected: {Core.SelfCharacter.GetStringValue()}";
			Vector2 size = canvas.MeasureText(display);
			canvas.DrawText(display, location.X, location.Y);

			this.canvas.End();
		}
	}

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class ChatBox : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		[DontSerialize] private static List<ChatLine> Chat = new List<ChatLine>();

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
			if(Chat.Count == 0)
			{
				Chat.Add(new ChatLine
				{
					Text = "Welcome to Fazbear Multiplayer!",
					Color = new ColorRgba(255, 208, 0)
				});
				if(Core.Client != null)
				{
					Chat.Add(new ChatLine
					{
						Text = "Playing as: " + Core.Client.UserName,
						Color = new ColorRgba(255, 208, 0)
					});
					if (!Core.Client.IsMaster)
					{
						StringBuilder builder = new StringBuilder();
						foreach(ClientPeer peer in Core.Client.joinedChannels[0])
						{
							if (builder.Length > 0)
								builder.Append(", ");
							builder.Append(peer.Name);
						}
						AddChat("Current players: " + builder.ToString(), new ColorRgba(255, 208, 0));
					}
				}
			}

			this.canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = this.font;

			int start = (int)(Chat.Count <= lines ? 0 : Chat.Count - lines);
			int space = 0;
			for(int i = start; i < Chat.Count; i++)
			{
				ChatLine line = Chat[i];
				ColorRgba color = line.Color;
				if (color == null)
					color = ColorRgba.White;
				if(color != canvas.State.ColorTint)
				{
					this.canvas.End();
					this.canvas.Begin(device);

					canvas.State.SetMaterial(DrawTechnique.Mask);
					canvas.State.ColorTint = color;
					canvas.State.TextFont = this.font;
				}
				canvas.DrawText(line.Text, chatpos.X, chatpos.Y + (font.Res.Height*space));
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
					if (nextchat > Time.MainTimer.TotalMilliseconds)
						return;
					nextchat = (int)(Time.MainTimer.TotalMilliseconds + 2000);
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

		private const string ChatFormat = "{0}{1}{2}: {3}";

		private void SendMessage()
		{
			if (Text.StartsWith("/"))
			{
				var cmd = Text.ReplaceFirst("/", "");
				string[] args = new string[0];
				if (cmd.Contains(" "))
					args = cmd.Split(' ');
				if (args.Length > 0)
				{
					cmd = args[0];
					string[] temp = args;
					args = new string[temp.Length - 1];
					for (int i = 1; i < temp.Length; i++)
					{
						args[i - 1] = temp[i];
					}
				}
				nextchat = (int)Time.MainTimer.TotalMilliseconds + 20;
				var result = CommandManager.RunCommand(cmd,args);
				if (!result)
				{
					AddChat("Unknown command.", ColorRgba.DarkGrey);
				}
				Text = "";
				return;
			}
			List<byte> msg = new List<byte>();
			msg.Add((byte)Core.SelfCharacter);
			msg.AddRange(BinaryData.GetData(Text));
			Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 15, msg.ToArray());
			string display = string.Format(ChatFormat, "", Core.Client.UserName, Core.SelfCharacter == Core.Character.None ? "" : " (" + Core.SelfCharacter.GetStringValue() + ")", Text);
			if(Core.Client.UserName != "Pdani" && Core.Client.UserName != "Brawlbox")
				AddChat(display);
			else
				AddChat(display,new ColorRgba(235, 52, 198));
			Text = "";
		}

		private static int staticcut = 0;
		public static void AddChat(string display)
		{
			AddChat(display, ColorRgba.White);
		}
		public static void AddChat(string display, ColorRgba color)
		{
			if (display.Length > staticcut)
			{
				int start = 0;
				int cut = (int)Math.Floor(display.Length / (float)staticcut);
				for (int i = 0; i <= cut; i++)
				{
					int max = staticcut;
					int min = i * staticcut - start;
					start = 0;
					if (min >= display.Length)
						break;
					if (min + max > display.Length)
						max = display.Length - min;
					if (Chat.Count > int.MaxValue)
						Chat.RemoveAt(0);
					while(!display.Substring(min, max).EndsWith(" ") && start < 5)
					{
						max--;
						if (start == 0)
							cut++;
						start++;
					}
					Chat.Add(new ChatLine {
						Text = display.Substring(min, max),
						Color = color
					});
				}
			}
			else
			{
				if (Chat.Count > int.MaxValue)
					Chat.RemoveAt(0);
				Chat.Add(new ChatLine
				{
					Text = display,
					Color = color
				});
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
				string display = string.Format(ChatFormat, "", peer.Name, c == Core.Character.None ? "" : " ("+c.GetStringValue()+")", text);
				if (peer.Name != "Pdani" && peer.Name != "Brawlbox")
					AddChat(display);
				else
					AddChat(display, new ColorRgba(235, 52, 198));
			}
		}

		public void OnActivate()
		{
			if(Chat.Count > 0)
				Chat.Clear();
			DualityApp.Keyboard.KeyDown += KeyDown;
			DualityApp.Keyboard.KeyUp += KeyUp;
			if (Core.Client != null)
			{
				Core.Client.Event.BinaryMessage += Event_BinaryMessage;
			}
		}

		public void OnDeactivate()
		{
			Chat.Clear();
			DualityApp.Keyboard.KeyDown -= KeyDown;
			DualityApp.Keyboard.KeyUp -= KeyUp;
			if (Core.Client != null)
			{
				Core.Client.Event.BinaryMessage -= Event_BinaryMessage;
			}
		}
	}
	internal class ChatLine
	{
		public string Text { get; set; }
		public ColorRgba Color { get; set; }
	}

	public class CommandManager
	{
		/// <summary>
		/// Run the specified command to run, with the given arguments, then return if the command was found or not
		/// </summary>
		/// <param name="command">the command to run, case in-sensitive</param>
		/// <param name="args">command arguments</param>
		/// <returns>true if the command was found, false otherwise</returns>
		public static bool RunCommand(string command, string[] args)
		{
			if (command == null)
				return false;
			if (args == null)
				args = new string[0];
			ColorRgba color = new ColorRgba(52, 235, 155);
			ColorRgba masterColor = new ColorRgba(99, 190, 50);
			switch (command.ToLower())
			{
				case "help":
					ChatBox.AddChat("/help - Displays this list",color);
					ChatBox.AddChat("/list - List all players in the lobby",color);
					ChatBox.AddChat("/difficulty - Print the current difficulty",color);
					if (Core.Client.IsMaster)
					{
						ChatBox.AddChat("/difficulty [0-4] - Change the difficulty", color);
						ChatBox.AddChat("/password [text] - Change/remove the current password",color);
						ChatBox.AddChat("To remove the password, just type in the command without parameters.", masterColor);
						ChatBox.AddChat("/kick <user id> - Kicks the specified user from the lobby",color);
					}
					return true;
				case "list":
					ChatBox.AddChat("List of players: ",color);
					ChatBox.AddChat($"- {Core.Client.UserName} (You)",color);
					foreach(ClientPeer peer in Core.Client.joinedChannels[0])
					{
						ChatBox.AddChat($"- {peer.Name} {(peer.ChannelMaster ? " (Master)" : "")}{(Core.Client.IsMaster ? $" #{peer.Id}" : "")}", color);
					}
					return true;
				case "difficulty":
					if (!Core.Client.IsMaster || args.Length == 0)
					{
						ChatBox.AddChat($"Current difficulty: '{Core.Difficulty.GetStringValue()}'",color);
					}
					if(Core.Client.IsMaster && args.Length > 0)
					{
						try
						{
							int i = int.Parse(args[0]);
							Core.GameDifficulty c = (Core.GameDifficulty)i;
							if (Enum.IsDefined(typeof(Core.GameDifficulty), c))
							{
								Core.Difficulty = c;
								ChatBox.AddChat($"Difficulty changed to '{c.GetStringValue()}'", masterColor);
								BGTasks.SendExtraLobbyInfo();
							}
							else
							{
								ChatBox.AddChat("Invalid difficulty index! Valid values: 0-4", masterColor);
							}
						}
						catch (Exception)
						{
							ChatBox.AddChat("Invalid number given!", masterColor);
						}
						
					}
					return true;
				case "password":
					if (Core.Client.IsMaster)
					{
						if(args.Length == 0)
						{
							if(BGTasks.Password != "")
							{
								BGTasks.Password = "";
								ChatBox.AddChat("Password removed.", masterColor);
							}
							else
							{
								ChatBox.AddChat("Usage: /password [text]", masterColor);
							}
						}
						else
						{
							ChatBox.AddChat("Password " + (BGTasks.Password == "" ? "set" : "changed"), masterColor);
							BGTasks.Password = string.Join(" ", args);
						}
						return true;
					}
					break;
				case "kick":
					if (Core.Client.IsMaster)
					{
						if(args.Length == 0)
						{
							ChatBox.AddChat("Usage: /kick <user id>", masterColor);
							ChatBox.AddChat("User IDs are the numbers displayed in the '/list' command next to usernames", masterColor);
						}
						else
						{
							ClientPeer target = null;
							string rawid = args[0];
							int id = -1;
							try
							{
								if (rawid.StartsWith("#"))
									id = int.Parse(rawid.ReplaceFirst("#", ""));
								else
									id = int.Parse(rawid);
								if (id != Core.Client.ID)
								{
									foreach (ClientPeer peer in Core.Client.joinedChannels[0])
									{
										if (peer.Id == id)
										{
											target = peer;
											peer.SendNumberMessage(Core.Client, 14, Core.Client.joinedChannels[0], id);
											break;
										}
									}
									if (target != null)
										ChatBox.AddChat("Kicking user from lobby...", masterColor);
									else
										ChatBox.AddChat("User not found.", masterColor);
								}
								else
								{
									ChatBox.AddChat("You can't kick yourself!", masterColor);
								}
							}
							catch (Exception)
							{
								ChatBox.AddChat("Invalid number given!", masterColor);
							}
						}
						return true;
					}
					break;
				case "accept":
					if (Core.Client.IsMaster)
					{
						bool result = BGTasks.AcceptJoinRequest();
						if (!result)
						{
							ChatBox.AddChat("[Discord] No join request, or last request timed out", new ColorRgba(218, 114, 114));
						}
						else
						{
							ChatBox.AddChat("[Discord] Join request accepted", new ColorRgba(138, 218, 114));
						}
						return true;
					}
					break;
			}
			return false;
		}
	}
}
