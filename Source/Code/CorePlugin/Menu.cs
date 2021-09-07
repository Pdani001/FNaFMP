using Duality;
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
using System.Threading;
using Duality.Audio;

namespace FNaFMP.Menu
{
	#region Global Menu
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
			//SplashText.IsLast = false;
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
		private SoundInstance source = null;
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
						{
							source = SM.PlayGlobalSound(RareMusic, true);
						}
						else
							nosound = true;
						break;
					case 5:
						if (ThemeTune != null)
						{
							source = SM.PlayGlobalSound(ThemeTune, false);
						}
						else
							nosound = true;
						break;
					default:
						if (Ambience != null)
						{
							source = SM.PlayGlobalSound(Ambience, false);
						}
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
						if (!SM.IsPlaying(ThemeTune,true))
						{
							music = Randomizer.Random(2, 4);
							source = null;
						}
						break;
					default:
						if (!SM.IsPlaying(Ambience,true))
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
			if (Core.MenuBGM != null)
			{
				source = Core.MenuBGM;
				music = SplashText.IsLast ? 1 : source.Sound.Name == Ambience.Name ? 2 : 5;
			}
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
			Core.MenuBGM = source;
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

	public class MenuBackButton : Component, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> BackScene { get; set; }

		private Point2 location = new Point2(0, 0);
		public Point2 ButtonLocation
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
			canvas.Begin(device);

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = font;

			string display = "Back";
			Vector2 size = canvas.MeasureText(display);
			canvas.DrawText(display, location.X - (size.X / 2), location.Y - (size.Y / 2));

			canvas.End();

			Vector2 mouse = DualityApp.Mouse.Pos;
			if (DualityApp.Mouse.ButtonHit(MouseButton.Left))
			{
				if (mouse.X > location.X - (size.X / 2) && mouse.X < location.X + size.X + (size.X / 2) && mouse.Y > location.Y - (size.Y / 2) && mouse.Y < location.X + size.Y + (size.Y / 2))
				{
					if(BackScene != null)
					{
						Scene.SwitchTo(BackScene);
					}
				}
			}

		}
	}
	#endregion

	#region Main Menu
	internal class MenuButton
	{
		private readonly string Text;
		private readonly ContentRef<Scene> Scene;
		public MenuButton(string text, ContentRef<Scene> scene)
		{
			Text = text;
			Scene = scene;
		}
		public string GetText()
		{
			return Text;
		}

		public ContentRef<Scene> GetScene()
		{
			return Scene;
		}
	}
	public class MenuButtonDisplay : Component, ICmpInitializable, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();
		[DontSerialize] private readonly List<MenuButton> Buttons = new List<MenuButton>();

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> Font { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> PlayScene { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> Settings { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> Credits { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private Point2 Position { get; set; }

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups | VisibilityFlag.ScreenOverlay;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			canvas.Begin(device);
			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = Font;

			string Selected = ">> ";
			Vector2 SelectedLength = canvas.MeasureText(Selected);

			int i = 0;
			foreach(MenuButton button in Buttons)
			{
				Vector2 ZoneStart = new Vector2(Position.X + SelectedLength.X, Position.Y + (i * SelectedLength.Y * 2));
				Vector2 TextSize = canvas.MeasureText(button.GetText());
				Vector2 MPos = DualityApp.Mouse.Pos;
				bool IsSelected = MPos.X > ZoneStart.X && MPos.X < ZoneStart.X + TextSize.X && MPos.Y > ZoneStart.Y && MPos.Y < ZoneStart.Y + TextSize.Y;
				canvas.DrawText((IsSelected ? Selected : "") + button.GetText(), Position.X + (IsSelected ? 0 : SelectedLength.X), Position.Y + (i * SelectedLength.Y * 2));
				if (IsSelected && DualityApp.Mouse.ButtonHit(MouseButton.Left))
				{
					if(button.GetScene() != null)
						Scene.SwitchTo(button.GetScene());
				}
				i++;
			}

			canvas.End();
		}

		public void OnActivate()
		{
			Buttons.Add(new MenuButton("Play Online",PlayScene));
			Buttons.Add(new MenuButton("Settings",Settings));
			Buttons.Add(new MenuButton("Credits",Credits));
			if (Core.Client != null && Core.Client.IsConnected)
			{
				Core.Client.Disconnect();
			}
		}

		public void OnDeactivate()
		{
			Buttons.Clear();
		}
	}
	public class CreditsDisplay : Component, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> Font { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private Point2 Position { get; set; }

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups | VisibilityFlag.ScreenOverlay;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			canvas.Begin(device);
			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = Font;

			Vector2 step = canvas.MeasureText("[]");

			canvas.DrawText("Five Nights at Freddy's created by and Copyright", Position.X, Position.Y);
			canvas.DrawText("    Scott Cawthon", Position.X, Position.Y + step.Y);

			canvas.DrawText("This multiplayer game was created by", Position.X, Position.Y + (step.Y * 3));
			canvas.DrawText("    Dániel 'Pdani' Pécsi", Position.X, Position.Y + (step.Y * 4));
			canvas.DrawText("    Brawlbox", Position.X, Position.Y + (step.Y * 5));

			canvas.DrawText("Helped test the game", Position.X, Position.Y + (step.Y * 7));
			canvas.DrawText("    Balint817", Position.X, Position.Y + (step.Y * 8));
			canvas.DrawText("    RockandRoll64", Position.X, Position.Y + (step.Y * 9));

			canvas.End();
		}
	}
	#endregion

	#region Settings
	public class SettingsDisplay : Component, ICmpInitializable, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> Font { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> GamejoltScene { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private Point2 Position { get; set; }

		private int Selecting = -1;

		private Action<int> change = null;

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups | VisibilityFlag.ScreenOverlay;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			canvas.Begin(device);
			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = Font;

			if(Selecting != -1)
			{
				string display = "Press a key, or press ESC to cancel!";
				Vector2 size = canvas.MeasureText(display);
				canvas.DrawText(display, DualityApp.WindowSize.X - size.X, 0);
			}

			int i = 0;
			AddText(i, out i, "Gamejolt Login", ()=>{
				if (GamejoltScene != null)
					Scene.SwitchTo(GamejoltScene);
			});
			i++;
			AddText(i, out i, "Fullscreen: "+(Selecting == i ? "..." : ((Key)Core.Config.Settings.FullscreenButton).ToString()), ()=>{
				if (Selecting != -1)
					return;
				Selecting = i;
				change = (k) =>
				{
					if (Core.PreventKeys.Contains(k))
						return;
					if (Core.Config.Settings.FullscreenButton == k)
						Core.PreventButtonPress();
					if(k != 50)
						Core.Config.Settings.FullscreenButton = k;
					change = null;
					Selecting = -1;
				};
			});

			canvas.End();
		}

		private void AddText(int i, out int o, string text, Action action = null)
		{
			string Selected = ">> ";
			Vector2 SelectedLength = canvas.MeasureText(Selected);
			Vector2 ZoneStart = new Vector2(Position.X + SelectedLength.X, Position.Y + (i * SelectedLength.Y * 2));
			Vector2 TextSize = canvas.MeasureText(text);
			Vector2 MPos = DualityApp.Mouse.Pos;
			bool IsSelected = MPos.X > ZoneStart.X && MPos.X < ZoneStart.X + TextSize.X && MPos.Y > ZoneStart.Y && MPos.Y < ZoneStart.Y + TextSize.Y;
			canvas.DrawText((IsSelected ? Selected : "") + text, Position.X + (IsSelected ? 0 : SelectedLength.X), Position.Y + (i * SelectedLength.Y * 2));
			if (IsSelected && DualityApp.Mouse.ButtonHit(MouseButton.Left))
			{
				if (action != null)
					action.Invoke();
			}
			i++;
			o = i;
		}

		public void OnActivate()
		{
			DualityApp.Keyboard.KeyDown += KeyDown;
		}

		private void KeyDown(object sender, KeyboardKeyEventArgs e)
		{
			if(Selecting != -1)
			{
				if(change != null)
				{
					change.Invoke((int)e.Key);
				}
				else
				{
					Selecting = -1;
				}
			}
		}

		public void OnDeactivate()
		{
			DualityApp.Keyboard.KeyDown -= KeyDown;
		}
	}

	public enum GamejoltEventType
	{
		Login,
		Logout
	}

	public class GamejoltEventData
	{
		public GamejoltEventType type { get; set; }
		public string username { get; set; }
	}

	public class GamejoltMenu : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> Font { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private Point2 ButtonPosition { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private Point2 InfoPosition { get; set; }

		public static string Username { get; set; }
		public static string Token { get; set; }

		private static string Status = "";

		/// <summary>
		/// Returns wether a login is in progress at the moment
		/// </summary>
		/// <returns><b>true</b> if a login is in progress, <b>false</b> otherwise</returns>
		public static bool Login { get; private set; }

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups | VisibilityFlag.ScreenOverlay;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			canvas.Begin(device);
			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = Font;

			string selected = "> ";
			Vector2 selectedLength = canvas.MeasureText(selected);
			string text = "";
			Vector2 MPos = DualityApp.Mouse.Pos;
			if (Core.LoggedIn)
			{
				text = "Logout";
			}
			else
			{
				text = "Login";
				if (Login)
					text = "Logging in...";
			}
			Vector2 textLength = canvas.MeasureText(text);
			bool IsSelected = MPos.X > ButtonPosition.X + selectedLength.X && MPos.X < ButtonPosition.X + textLength.X + selectedLength.X && MPos.Y > ButtonPosition.Y && MPos.Y < ButtonPosition.Y + textLength.Y;
			if (IsSelected)
			{
				if (DualityApp.Mouse.ButtonHit(MouseButton.Left))
				{
					if (Core.LoggedIn)
					{
						Username = "";
						Token = "";
						Core.Config.Gamejolt = new Configuration.Gamejolt();
						Core.LoggedIn = false;
						GamejoltEvent?.Invoke(instance, new GamejoltEventData
						{
							type = GamejoltEventType.Logout
						});
						Status = "";
					}
					else
					{
						if (!Login)
						{
							DoLogin();
						}
					}
				}
			}
			canvas.DrawText((IsSelected && !Login ? selected : "") + text,ButtonPosition.X + (IsSelected && !Login ? 0 : selectedLength.X),ButtonPosition.Y);
			canvas.End();

			canvas.Begin(device);
			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = null;

			canvas.DrawText(Status, InfoPosition.X, InfoPosition.Y);

			canvas.End();
		}

		private static Thread thread = null;

		public static void DoLogin()
		{
			if (Username != null && Username.Length > 0 && Token != null && Token.Length > 0)
			{
				Login = true;
				Status = "";
				thread = new Thread(() => {
					GamejoltAuth auth = SuperSecret.gamejoltAuth;
					AuthData data = auth.Login(Username, Token);
					if (data.success)
					{
						Username = data.username;
						Core.Config.Gamejolt = new Configuration.Gamejolt
						{
							UserName = Username,
							Token = Base64.Encode(Token)
						};
						Status = "Successful login!";
						Core.LoggedIn = true;
						Core.Client.UserName = Username;
						GamejoltEvent?.Invoke(instance, new GamejoltEventData
						{
							type = GamejoltEventType.Login,
							username = Username
						});
					}
					else
					{
						Status = "Login failed: " + data.message;
					}
					Login = false;
					thread = null;
				});
				thread.Start();
			}
			else
			{
				Status = "Please fill out all the fields!";
			}
		}

		public static EventHandler<GamejoltEventData> GamejoltEvent;
		private static GamejoltMenu instance;

		public void OnActivate()
		{
			instance = this;
			Status = "";
			Login = false;
			if (Core.Config != null && Core.Config.Gamejolt != null)
			{
				Username = Core.Config.Gamejolt.UserName;
				if (Username == null)
					Username = "";
				Token = Core.Config.Gamejolt.Token;
				if (Token == null)
					Token = "";
				else
					Token = Base64.Decode(Token);
			}
		}

		public void OnDeactivate()
		{
			if(thread != null)
				thread.Abort();
			thread = null;
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class GamejoltNameText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		private Transform transform = null;
		private SpriteRenderer renderer = null;

		private string Name = "";
		private string extra = "";

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

			if (input > -1 && input <= Time.MainTimer.TotalMilliseconds)
			{
				if (extra == "")
					extra = "|";
				else
					extra = "";
				input = (int)Time.MainTimer.TotalMilliseconds + 500;
			}

			if (transform != null)
				canvas.DrawText(Name + extra, transform.Pos.X + 5, transform.Pos.Y + 3);

			this.canvas.End();

			if (backspace > -1 && backspace < Time.MainTimer.TotalMilliseconds)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 50;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			if (repeat > -1 && repeat < Time.MainTimer.TotalMilliseconds)
			{
				repeat = (int)Time.MainTimer.TotalMilliseconds + 50;
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
					if (!Core.LoggedIn && !GamejoltMenu.Login)
					{
						bool onbox = (mouse.X > pos.X && mouse.X < pos.X + size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + size.Y);
						input = onbox ? (int)Time.MainTimer.TotalMilliseconds + 500 : -1;
						extra = onbox ? "|" : "";
					}
					else
					{
						input = -1;
						extra = "";
					}
				}

				if (input > -1)
				{
					GamejoltMenu.Username = Name;
				}

				this.canvas.Begin(device);

				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.White;
				canvas.State.TextFont = this.font;

				Vector2 textSize = canvas.MeasureText("Username:");
				canvas.DrawText("Username:",transform.Pos.X - 2 - textSize.X, transform.Pos.Y);

				this.canvas.End();
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
			if (args.Key == Key.BackSpace)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 500;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			else if (args.Key == Key.Enter || args.Key == Key.KeypadEnter)
			{
				if (input > -1)
				{
					if (Name.Replace(" ", "").Length > 0)
					{
						input = -1;
						extra = "";
						GamejoltMenu.DoLogin();
					}
				}
			}
			else if (args.Key == Key.Escape)
			{
				input = -1;
				extra = "";
			}
			else
			{
				c = DualityApp.Keyboard.CharInput;
				if (!c.Equals(""))
				{
					Name += c;
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

		private void GamejoltEvent(object sender, GamejoltEventData data)
		{
			if(data.type == GamejoltEventType.Logout)
			{
				Name = "";
			}
			else
			{
				Name = data.username;
			}
		}

		public void OnActivate()
		{
			if(Core.Config != null && Core.Config.Gamejolt != null)
				Name = Core.Config.Gamejolt.UserName;
			if (Name == null)
				Name = "";
			extra = "";
			input = -1;
			backspace = -1;
			repeat = -1;
			DualityApp.Keyboard.KeyDown += KeyDown;
			DualityApp.Keyboard.KeyUp += KeyUp;
			GamejoltMenu.GamejoltEvent += GamejoltEvent;
		}

		public void OnDeactivate()
		{
			DualityApp.Keyboard.KeyDown -= KeyDown;
			DualityApp.Keyboard.KeyUp -= KeyUp;
			GamejoltMenu.GamejoltEvent -= GamejoltEvent;
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class GamejoltTokenText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		private Transform transform = null;
		private SpriteRenderer renderer = null;

		private string Name = "";
		private string extra = "";

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

			if (input > -1 && input <= Time.MainTimer.TotalMilliseconds)
			{
				if (extra == "")
					extra = "|";
				else
					extra = "";
				input = (int)Time.MainTimer.TotalMilliseconds + 500;
			}

			string display = "";
			for(int i = 0; i < Name.Length; i++)
			{
				display += "*";
			}

			if (transform != null)
				canvas.DrawText(display + extra, transform.Pos.X + 5, transform.Pos.Y + 3);

			this.canvas.End();

			if (backspace > -1 && backspace < Time.MainTimer.TotalMilliseconds)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 50;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			if (repeat > -1 && repeat < Time.MainTimer.TotalMilliseconds)
			{
				repeat = (int)Time.MainTimer.TotalMilliseconds + 50;
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
					if (!Core.LoggedIn && !GamejoltMenu.Login)
					{
						bool onbox = (mouse.X > pos.X && mouse.X < pos.X + size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + size.Y);
						input = onbox ? (int)Time.MainTimer.TotalMilliseconds + 500 : -1;
						extra = onbox ? "|" : "";
					}
					else
					{
						input = -1;
						extra = "";
					}
				}

				if (input > -1)
				{
					GamejoltMenu.Token = Name;
				}

				this.canvas.Begin(device);

				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.White;
				canvas.State.TextFont = this.font;

				Vector2 textSize = canvas.MeasureText("Token:");
				canvas.DrawText("Token:", transform.Pos.X - 2 - textSize.X, transform.Pos.Y);

				this.canvas.End();
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
			if (args.Key == Key.BackSpace)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 500;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			else if (args.Key == Key.Enter || args.Key == Key.KeypadEnter)
			{
				if (input > -1)
				{
					if (Name.Replace(" ", "").Length > 0)
					{
						input = -1;
						extra = "";
						GamejoltMenu.DoLogin();
					}
				}
			}
			else if (args.Key == Key.Escape)
			{
				input = -1;
				extra = "";
			}
			else
			{
				c = DualityApp.Keyboard.CharInput;
				if (!c.Equals(""))
				{
					Name += c;
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

		private void GamejoltEvent(object sender, GamejoltEventData data)
		{
			if (data.type == GamejoltEventType.Logout)
			{
				Name = "";
			}
		}

		public void OnActivate()
		{
			if (Core.Config != null && Core.Config.Gamejolt != null && Core.Config.Gamejolt.Token != null)
				Name = Base64.Decode(Core.Config.Gamejolt.Token);
			if (Name == null)
				Name = "";
			extra = "";
			input = -1;
			backspace = -1;
			repeat = -1;
			DualityApp.Keyboard.KeyDown += KeyDown;
			DualityApp.Keyboard.KeyUp += KeyUp;
			GamejoltMenu.GamejoltEvent += GamejoltEvent;
		}

		public void OnDeactivate()
		{
			DualityApp.Keyboard.KeyDown -= KeyDown;
			DualityApp.Keyboard.KeyUp -= KeyUp;
			GamejoltMenu.GamejoltEvent -= GamejoltEvent;
		}
	}
	#endregion

	#region Lobby List
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

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> SelectScene { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> PasswordScene { get; set; }


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
						bool password = reader.ReadByte() == 1;
						int party_length = reader.ReadInt();
						string party = reader.ReadText(party_length);
						Core.DRPC.UpdateParty(new DiscordRPC.Party()
						{
							ID = party,
							Max = 5,
							Size = count,
							Privacy = DiscordRPC.Party.PrivacySetting.Public
						});
						if (!password)
						{
							if (SelectScene != null)
								Scene.SwitchTo(SelectScene);
						}
						else
						{
							if (PasswordScene != null)
								Scene.SwitchTo(PasswordScene);
						}
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
						connect("lekkit.hopto.org");
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
	#endregion

	#region InGame
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
	#endregion

	#region Pre-Login state
	public class PasswordMenu : Component, ICmpInitializable, ICmpRenderer
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> font = null;
		public ContentRef<Font> Font
		{
			get { return font; }
			set { font = value; }
		}

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> LobbyScene { get; set; }
		
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> SelectScene { get; set; }

		private Transform transform = null;
		private SpriteRenderer renderer = null;

		private string Name = "";
		private string extra = "";

		private bool Sending = false;

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

			if (input > -1 && input <= Time.MainTimer.TotalMilliseconds)
			{
				if (extra == "")
					extra = "|";
				else
					extra = "";
				input = (int)Time.MainTimer.TotalMilliseconds + 500;
			}

			string display = "";
			for (int i = 0; i < Name.Length; i++)
			{
				display += "*";
			}

			if (transform != null)
				canvas.DrawText(display + extra, transform.Pos.X + 5, transform.Pos.Y + 3);

			this.canvas.End();

			if (backspace > -1 && backspace < Time.MainTimer.TotalMilliseconds)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 50;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			if (repeat > -1 && repeat < Time.MainTimer.TotalMilliseconds)
			{
				repeat = (int)Time.MainTimer.TotalMilliseconds + 50;
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
					if (!Sending)
					{
						bool onbox = (mouse.X > pos.X && mouse.X < pos.X + size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + size.Y);
						input = onbox ? (int)Time.MainTimer.TotalMilliseconds + 500 : -1;
						extra = onbox ? "|" : "";
					}
					else
					{
						input = -1;
						extra = "";
					}
				}


				this.canvas.Begin(device);

				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.White;
				canvas.State.TextFont = this.font;

				if (input > -1)
				{
					string create = "Press enter!";
					Vector2 createSize = canvas.MeasureText(create);

					canvas.DrawText(create, pos.X + size.X - createSize.X, pos.Y + size.Y);
				}
				
				if (Sending)
				{
					string create = "Communicating...";
					Vector2 createSize = canvas.MeasureText(create);

					canvas.DrawText(create, pos.X + size.X - createSize.X, pos.Y + size.Y);
				}

				Vector2 textSize = canvas.MeasureText("Password:");
				canvas.DrawText("Password:", transform.Pos.X, transform.Pos.Y - 2 - textSize.Y);

				this.canvas.End();
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
			if (args.Key == Key.BackSpace)
			{
				backspace = (int)Time.MainTimer.TotalMilliseconds + 500;
				if (Name.Length > 0)
				{
					Name = Name.Substring(0, Name.Length - 1);
				}
			}
			else if (args.Key == Key.Enter || args.Key == Key.KeypadEnter)
			{
				if (input > -1)
				{
					if (Name.Replace(" ", "").Length > 0)
					{
						input = -1;
						extra = "";
						Sending = true;
						Core.Client.joinedChannels[0].ChannelMaster.SendTextMessage(Core.Client, 13, Core.Client.joinedChannels[0], Name);
					}
				}
			}
			else if (args.Key == Key.Escape)
			{
				input = -1;
				extra = "";
			}
			else
			{
				c = DualityApp.Keyboard.CharInput;
				if (!c.Equals(""))
				{
					Name += c;
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

		public void OnActivate()
		{
			Sending = false;
			Name = "";
			extra = "|";
			input = (int)Time.MainTimer.TotalMilliseconds + 500;
			backspace = -1;
			repeat = -1;
			DualityApp.Keyboard.KeyDown += KeyDown;
			DualityApp.Keyboard.KeyUp += KeyUp;
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseLeaveChannel += Event_LeaveChannel;
				Core.Client.Event.NumberMessage += Event_NumberMessage;
				if (!Core.Client.IsConnected && LobbyScene != null)
					Scene.SwitchTo(LobbyScene);
			}
		}

		private void Event_LeaveChannel(object sender, EventResponseLeaveChannel e)
		{
			if (LobbyScene != null)
				Scene.SwitchTo(LobbyScene);
		}

		private void Event_NumberMessage(object sender, EventNumberMessage e)
		{
			if(e.Type == MessageEventType.Peer && e.SubChannel == 13)
			{
				if(e.PeerID == Core.Client.joinedChannels[0].ChannelMaster.Id)
				{
					if(e.Message == 0)
					{
						Core.LeaveReason = "Invalid password.";
						Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
					}
					else
					{
						if (SelectScene != null)
							Scene.SwitchTo(SelectScene);
					}
				}
			}
		}

		public void OnDeactivate()
		{
			DualityApp.Keyboard.KeyDown -= KeyDown;
			DualityApp.Keyboard.KeyUp -= KeyUp;
			if (Core.Client != null)
			{
				Core.Client.Event.ResponseLeaveChannel -= Event_LeaveChannel;
				Core.Client.Event.NumberMessage -= Event_NumberMessage;
			}
		}
	}
	#endregion
}
