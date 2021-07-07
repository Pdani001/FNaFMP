using System;
using System.Collections.Generic;

using Duality;
using Duality.Components;
using Duality.Resources;
using Duality.Drawing;
using FNaFMP.Office;
using Duality.Components.Renderers;

namespace FNaFMP.Utility
{
	
	public class Randomizer
    {
		public static int Random(int val)
        {
			return new Random().Next(0, val+1);
		}
		public static int Random(int min, int max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException("min value is greater than max value.");
			return new Random().Next(min, max + 1);
		}
	}
	public class Utilities
    {
		private static readonly Logger logger = new Logger("FNaF MP");
		public static Logger Logger
		{
			get { return logger; }
		}
	}
	public class Logger
    {
		public Logger(string prefix)
        {
			this.prefix = "[" + prefix + "/{0}]";
		}
		private readonly string prefix = "[Dualitor/{0}]";
		public void Write(string msg, params object[] obj)
        {
			Write(LogLevel.INFO, msg, obj);
        }
		public void Write(LogLevel level, string msg, params object[] obj)
        {
			string write = string.Format(prefix, LogLevelString[(int)level]) + " " + msg;
			switch (level)
            {
				case LogLevel.INFO:
					Logs.Game.Write(write,obj);
					break;
				case LogLevel.WARN:
					Logs.Game.WriteWarning(write, obj);
					break;
				case LogLevel.ERROR:
					Logs.Game.WriteError(write, obj);
					break;
            }
		}
		private string[] LogLevelString =
		{
			"INFO",
			"WARN",
			"ERR"
		};
		public enum LogLevel
        {
			INFO,
			WARN,
			ERROR
		}
    }
	[RequiredComponent(typeof(SoundEmitter))]
	public class SoundManager : Component, ICmpUpdatable
    {
		private static SoundEmitter emitter = null;
		private Transform transform = null;
		private static List<SoundEmitter.Source> list = null;
		private static readonly List<SoundEmitter.Source> nonloop = new List<SoundEmitter.Source>();
		public static bool IsPlaying(SoundEmitter.Source sound)
        {
			foreach(SoundEmitter.Source src in emitter.Sources)
            {
				if (src.Sound.Name.Equals(sound.Sound.Name))
					return true;
            }
			return false;
        }
		public static SoundEmitter.Source PlaySound(ContentRef<Sound> sound, bool loop = false)
        {
			if (sound == null)
				return null;
			var source = new SoundEmitter.Source(sound, loop);
			emitter.Sources.Add(source);
			return source;
        }
		public static void StopSound(SoundEmitter.Source sound)
        {
			if (sound == null)
				return;
			emitter.Sources.Remove(sound);
			sound.Volume = 0;
		}

		public static void StopAllSounds()
        {
			if (emitter == null)
				return;
			List<SoundEmitter.Source> clone = new List<SoundEmitter.Source>(emitter.Sources);
			foreach(SoundEmitter.Source source in clone)
            {
				StopSound(source);
            }
        }

		public static bool ToggleSound(String name, bool value)
        {
			if (list != null)
			foreach (var item in emitter.Sources)
			{
				ContentRef<Sound> sound = item.Sound;
                if (sound.Name.Equals(name))
                {
                    if (!item.Looped && !nonloop.Contains(item))
					{
						nonloop.Add(item);
					}
					item.Paused = !value;
					return true;
                }
			}
			foreach (var item in nonloop)
			{
				ContentRef<Sound> sound = item.Sound;
				if (sound.Name.Equals(name))
				{
					emitter.Sources.Add(item);
					return ToggleSound(name,value);
				}
			}
			return false;
		}
		public static bool ChangeVolume(String name, int value)
        {
			if (value > 200)
				value = 200;
			if (value < 0)
				value = 0;
			if (list != null)
			foreach (var item in emitter.Sources)
			{
				ContentRef<Sound> sound = item.Sound;
				if (sound.Name.Equals(name))
				{
					item.Volume = (float)value/100;
					return true;
				}
			}
			return false;
		}
		public static event EventHandler OnLoad;
		public void OnUpdate()
        {
			if (transform == null)
			{
				transform = this.GameObj.GetComponent<Transform>();
				emitter = null;
				list = null;
			}
			if (emitter == null)
			{
				emitter = this.GameObj.GetComponent<SoundEmitter>();
				list = null;
			}
			if (list == null && emitter != null)
			{
				list = emitter.Sources;
				OnLoad?.Invoke(this, null);
			}
			if (transform != null)
            {
				if(GameObj.Scene.Name.Equals("Office"))
				transform.Pos = DisplayController.Camera.FocusPos;
            }
		}
    }

	public class HudRenderer : Component, ICmpRenderer
	{
		private ContentRef<Font> font = null;
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		public ContentRef<Font> Font
		{
			get { return this.font; }
			set { this.font = value; }
		}
		private static bool isDebug = false;
		public static bool IsDebug
		{
			get { return isDebug; }
		}

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.AllGroups | VisibilityFlag.ScreenOverlay;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.F5))
			{
				isDebug = !isDebug;
			}
			if (IsDebug)
			{
				this.canvas.Begin(device);

				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.Green;
				canvas.State.TextFont = this.font;

				string cursorText = string.Format("{0}, {1}", (int)DualityApp.Mouse.Pos.X, (int)DualityApp.Mouse.Pos.Y);

				float x = DualityApp.Mouse.Pos.X - (canvas.MeasureText(cursorText).X/2);
				float end_x = DualityApp.Mouse.Pos.X + (canvas.MeasureText(cursorText).X/2);
				float y = DualityApp.Mouse.Pos.Y - 20;

				if(x < 0)
                {
					x = 0;
                }
				if(end_x > DualityApp.WindowSize.X)
                {
					x = DualityApp.WindowSize.X - (cursorText.Length * 8);
				}
				if(y < 0)
                {
					y = 0;
                }
				canvas.DrawText(cursorText, x, y);
				canvas.DrawText("FPS: " + Time.Fps, 0, 0);
				canvas.DrawText("Client: " + (Core.Client != null && Core.Client.IsConnected ? "connected" : "not connected"), 0, 32);

                if (this.GameObj.Scene.Name.Equals("Office"))
                {
                    if (!CameraViewer.IsViewing)
                    {
						float subX = DisplayController.Camera.FocusPos.X - DisplayController.DefaultCamX;
						if (DoorController.LeftDoor != null)
						{
							Vector3 left = DoorController.LeftDoor.GetPos();
							left.X -= subX;
							canvas.DrawText("State: " + DoorController.LeftDoor.GetState(), left.X, left.Y + 50);
						}
						if (DoorController.RightDoor != null)
						{
							Vector3 right = DoorController.RightDoor.GetPos();
							right.X -= subX;
							canvas.DrawText("State: " + DoorController.RightDoor.GetState(), right.X, right.Y + 50);
						}
					}
					else
                    {
						canvas.DrawText("2A dark: "+(CameraRenderer.IsRandom ? "yes":"no"), 0,50);
					}
                }

				this.canvas.End();
			}
		}
	}
	public class GlobalStatic : Component, ICmpUpdatable
	{
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

		private int lastTime = 0;
		private readonly Random rnd = new Random();
		public void OnUpdate()
		{
			SpriteRenderer render = this.GameObj.GetComponent<SpriteRenderer>();
			ColorRgba color = render.ColorTint;
			TimeSpan span = Time.MainTimer;
			int seconds = (int)span.TotalMilliseconds;
			if (lastTime + 80 < seconds)
			{
				Opacity = 50 + rnd.Next(100);
				lastTime = seconds;
			}
			color.A = (byte)(255-Opacity);
			render.ColorTint = color;
		}
	}
}
