using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Input;
using Duality.Resources;

namespace FNaFMP.Startup
{
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
			isKeyDown = e.IsPressed;
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
				time = (int)Time.MainTimer.TotalSeconds;
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

			Point2 window = DualityApp.WindowSize;
			if (display != null)
			{
				Vector2 size = canvas.MeasureText(display);
				canvas.DrawText(display,(window.X/2)-(size.X/2),window.Y-size.Y);
			}
			

			this.canvas.End();
		}

		public void OnActivate()
		{
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
		}
	}
}
