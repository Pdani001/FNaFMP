using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Editor;
using Duality.Input;
using Duality.Resources;

namespace FNaFMP.Startup
{
	public class LoadTest : Component, ICmpInitializable, ICmpUpdatable
	{
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> Continue { get; set; }
		private bool Finished
		{
			get { return time > -1 && time + 1000 < Time.MainTimer.TotalMilliseconds; }
		}
		[DontSerialize] private bool printed = false;
		[DontSerialize] private long time = -1;
		public void OnActivate()
		{
			time = -1;
			printed = false;
			new Thread(() =>
			{
				if (Core.Config != null && Core.Config.Gamejolt != null && !Core.DEBUG)
				{
					if (Core.Config.Gamejolt.UserName != null && Core.Config.Gamejolt.Token != null)
					{
						GamejoltAuth gamejolt = SuperSecret.gamejoltAuth;
						AuthData auth = gamejolt.Login(Core.Config.Gamejolt.UserName, Base64.Decode(Core.Config.Gamejolt.Token));
						if (auth.success)
						{
							Core.Config.Gamejolt.UserName = auth.username;
							Logs.Core.Write("Logged in as {0}", Core.Config.Gamejolt.UserName);
							Core.Client.UserName = Core.Config.Gamejolt.UserName;
							Core.LoggedIn = true;
						}
					}
				}
				time = (long)Time.MainTimer.TotalMilliseconds;
			}).Start();
		}

		public void OnDeactivate()
		{
			
		}

		public void OnUpdate()
		{
			if (Finished && !printed)
			{
				printed = true;
				Logs.Core.Write("Loading finished!");
				Scene.SwitchTo(Continue);
			}
		}
	}
	[RequiredComponent(typeof(Renderer))]
	public class Splash : Component, ICmpUpdatable, ICmpInitializable
	{
		private int count = 0;
		private bool forward = true;
		private int time = 0;
		private List<ContentRef<Material>> renderers;
		public List<ContentRef<Material>> Renderers
		{
			get { return this.renderers; }
			set { this.renderers = value; }
		}
		private ContentRef<Scene> scene;
		public ContentRef<Scene> NextScene
		{
			get { return this.scene; }
			set { this.scene = value; }
		}
		private bool isKeyDown = false;
		private void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
		{
			isKeyDown = e.IsPressed && e.Key != Key.F2;
		}
		public void OnUpdate()
		{
			if(renderers.Count == count)
			{
				if(scene != null)
				{
					Scene.SwitchTo(NextScene);
				}
				return;
			}
			if (DualityApp.Mouse.ButtonPressed(MouseButton.Left) || isKeyDown)
			{
				if (scene != null)
				{
					Scene.SwitchTo(NextScene);
				}
				count = renderers.Count;
				return;
			}
			SpriteRenderer render = this.GameObj.GetComponent<SpriteRenderer>();
			ContentRef<Material> next = renderers[count];
			if (!render.SharedMaterial.Name.Equals(next.Name))
			{
				render.SharedMaterial = next;
				ColorRgba color = render.ColorTint;
				color.A = (byte)((count == 0) ? 255 : 0);
				render.ColorTint = color;
				Material mat = render.SharedMaterial.Res;
				Texture text = mat.MainTexture.Res;
				SpriteAnimator animate = this.GameObj.GetComponent<SpriteAnimator>();
				List<Rect> atlas = text.BasePixmap.Res.Atlas;
				float w = text.ContentWidth;
				float h = text.ContentHeight;
				animate.FrameCount = 1;
				if (atlas != null)
				{
					animate.FrameCount = atlas.Count;
					if(atlas.Count > 0)
					{
						w = 0;
						h = 0;
						foreach(var item in atlas)
						{
							if(item.W > w)
							{
								w = item.W;
							}
							if(item.H > h)
							{
								h = item.H;
							}
						}
					}
				}
				render.Rect = new Rect(-(w / 2), -(h / 2), w, h);
			}
			if(time == 0)
			{
				time = (int)Time.MainTimer.TotalSeconds;
			}
			if (forward)
			{
				if(render.ColorTint.A < 255)
				{
					ColorRgba color = render.ColorTint;
					int alpha = color.A;
					alpha += 4;
					if (alpha > 255)
						alpha = 255;
					color.A = (byte)alpha;
					render.ColorTint = color;
					time = (int)Time.MainTimer.TotalSeconds;
				} else
				{
					if(time == (int)Time.MainTimer.TotalSeconds-2)
					{
						forward = false;
					}
				}
			}
			else
			{
				if (render.ColorTint.A > 0)
				{
					ColorRgba color = render.ColorTint;
					int alpha = color.A;
					alpha -= 4;
					if (alpha < 0)
						alpha = 0;
					color.A = (byte)alpha;
					render.ColorTint = color;
					time = (int)Time.MainTimer.TotalSeconds;
				}
				else
				{
					 count++;
					 forward = true;
				}
			}
		}

		public void OnActivate()
		{
			count = 0;
			forward = true;
			time = 0;
			DualityApp.Keyboard.KeyDown += Keyboard_KeyDown;
			if(Core.Client != null && Core.Client.IsConnected)
			{
				Core.Reset();
			}
		}

		public void OnDeactivate()
		{
			DualityApp.Keyboard.KeyDown -= Keyboard_KeyDown;
		}
	}
	public class SplashText : Component, ICmpRenderer, ICmpInitializable
	{
		private ContentRef<Font> font = null;
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		public ContentRef<Font> Font
		{
			get { return this.font; }
			set { this.font = value; }
		}

		private List<string> texts = new List<string>();
		public List<string> Messages
		{
			get { return texts; }
			set
			{
				if (value == null)
					return;
				texts = value;
			}
		}
		private string display = null;
		private string[] lines = null;
		private static bool islast = false;
		public static bool IsLast
		{
			get { return islast; }
			set { islast = value; }
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
			canvas.State.TextFont = this.font;

			Point2 window = Core.MaxWindowSize;
			if (window.X == 0 || window.Y == 0)
			{
				canvas.End();
				return;
			}
			if (display != null)
			{
				Vector2 size = canvas.MeasureText(display);
				float height = size.Y;
				if (size.X > window.X)
				{
					if (lines == null)
					{
						List<string> build = new List<string>();
						List<string> list = new List<string>();
						size = new Vector2(0, 0);
						int i = 0;
						string[] split = display.Split(' ');
						while (i < split.Length)
						{
							while (size.X < window.X)
							{
								build.Add(split[i]);
								i++;
								size = canvas.MeasureText(string.Join(" ", build.ToArray()));
								if (i == split.Length)
									break;
							}
							if (i < split.Length)
							{
								i -= 2;
								if (build.Count > 0)
								{
									build.RemoveAt(build.Count - 1);
									build.RemoveAt(build.Count - 1);
								}
							}
							list.Add(string.Join(" ", build.ToArray()));
							size = new Vector2(0, 0);
							build.Clear();
						}
						lines = list.ToArray();
					}
					else
					{
						height = lines.Length * size.Y;
						for(int i = 0; i < lines.Length; i++)
						{
							size = canvas.MeasureText(lines[i]);
							canvas.DrawText(lines[i], (window.X / 2) - (size.X / 2), window.Y - height);
							height -= size.Y;
						}
					}
				}
				else
				{
					canvas.DrawText(display, (window.X / 2) - (size.X / 2), window.Y - height);
				}
			}
			

			this.canvas.End();
		}

		public void OnActivate()
		{
			lines = null;
			islast = false;
			if (texts.Count > 0)
			{
				Random random = new Random();
				int n = random.Next(texts.Count);
				islast = n == texts.Count - 1;
				display = texts[n];
			}
		}

		public void OnDeactivate()
		{
			display = null;
			lines = null;
		}
	}
}
