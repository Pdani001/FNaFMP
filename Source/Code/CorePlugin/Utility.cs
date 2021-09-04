using System;
using System.Collections.Generic;

using Duality;
using Duality.Components;
using Duality.Resources;
using Duality.Drawing;
using FNaFMP.Office;
using Duality.Components.Renderers;
using System.Reflection;
using System.Text.RegularExpressions;
using Duality.Audio;

namespace FNaFMP.Utility
{
	
	public class Randomizer
	{
		private static Random GlobalRandom;
		private static void Init()
		{
			if(GlobalRandom == null)
			{
				var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
				GlobalRandom = new Random(seed);
			}
		}
		private static Random RandomClass()
		{
			Init();
			var seed2 = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
			return new Random((int)(seed2 * GlobalRandom.NextDouble()));
		}
		public static int Random(int val)
		{
			return RandomClass().Next(0, val + 1);
		}
		public static int Random(int min, int max)
		{
			if (min > max)
				throw new ArgumentOutOfRangeException("min","min value is greater than max value.");
			return RandomClass().Next(min, max + 1);
		}
	}
	public class Utilities
	{
		private static readonly DualityLogger logger = new DualityLogger("FNaF MP");
		public static DualityLogger Logger
		{
			get { return logger; }
		}
	}
	public class DualityLogger
	{
		public DualityLogger(string prefix)
		{
			this.prefix = "[{1}] [" + prefix + "/{0}]";
		}
		private readonly string prefix = "[{1}] [Dualitor/{0}]";
		public void Write(string msg, params object[] obj)
		{
			Write(LogLevel.INFO, msg, obj);
		}
		public void Write(LogLevel level, string msg, params object[] obj)
		{
			
			string time = DateTime.Now.ToString("HH:mm:ss");
			string write = string.Format(prefix, level.GetStringValue(), time) + " " + msg;
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
		public enum LogLevel
		{
			[StringValue("INFO")]
			INFO,
			[StringValue("WARN")]
			WARN,
			[StringValue("ERR")]
			ERROR
		}
	}
	[RequiredComponent(typeof(SoundEmitter))]
	public class SoundManager : Component, ICmpUpdatable, ICmpInitializable
	{
		private SoundEmitter emitter = null;
		private Transform transform = null;
		private List<SoundEmitter.Source> list = null;
		private readonly List<SoundEmitter.Source> LocalNonloop = new List<SoundEmitter.Source>();
		private readonly List<SoundInstance> GlobalNonloop = new List<SoundInstance>();
		private static readonly List<SoundInstance> GlobalSources = new List<SoundInstance>();
		public bool IsPlaying(SoundEmitter.Source sound)
		{
			if (sound != null)
			{
				foreach (SoundEmitter.Source src in emitter.Sources)
				{
					if (src.Sound.Name.Equals(sound.Sound.Name))
						return true;
				}
			}
			return false;
		}
		public bool IsPlaying(ContentRef<Sound> sound, bool global = false)
		{
			if (sound != null)
			{
				if (!global)
				{
					foreach (SoundEmitter.Source src in emitter.Sources)
					{
						if (src.Sound.Name.Equals(sound.Name))
							return true;
					}
				}
				else
				{
					foreach (SoundInstance src in GlobalSources)
					{
						if (src.Sound.Name.Equals(sound.Name))
							return true;
					}
				}
			}
			return false;
		}
		public SoundEmitter.Source PlaySound(ContentRef<Sound> sound, bool loop = false)
		{
			if (sound == null)
				return null;
			var source = new SoundEmitter.Source(sound, loop);
			emitter.Sources.Add(source);
			return source;
		}

		public SoundInstance PlayGlobalSound(ContentRef<Sound> sound, bool loop = false)
		{
			if (sound == null)
				return null;
			var source = DualityApp.Sound.PlaySound(sound);
			source.Looped = loop;
			GlobalSources.Add(source);
			return source;
		}

		public void StopSound(SoundEmitter.Source sound)
		{
			if (sound == null)
				return;
			sound.Volume = 0;
			emitter.Sources.Remove(sound);
		}

		public void StopGlobalSound(SoundInstance sound)
		{
			sound.Volume = 0;
			sound.Stop();
			GlobalSources.Remove(sound);
		}

		public void StopAllSounds(bool global = false)
		{
			if (emitter == null)
				return;
			if (!global)
			{
				List<SoundEmitter.Source> clone = new List<SoundEmitter.Source>(emitter.Sources);
				foreach (SoundEmitter.Source source in clone)
				{
					StopSound(source);
				}
			}
			else
			{
				DualityApp.Sound.StopAll();
			}
		}

		public bool ToggleSound(string name, bool value)
		{

			foreach (var item in emitter.Sources)
			{
				ContentRef<Sound> sound = item.Sound;
				if (sound.Name.Equals(name))
				{
					if (!item.Looped && !LocalNonloop.Contains(item))
					{
						LocalNonloop.Add(item);
					}
					item.Paused = !value;
					return true;
				}
			}
			foreach (var item in LocalNonloop)
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
		public bool ToggleGlobalSound(string name, bool value)
		{

			foreach (var item in DualityApp.Sound.Playing)
			{
				ContentRef<Sound> sound = item.Sound;
				if (sound.Name.Equals(name))
				{
					if (!item.Looped && !GlobalNonloop.Contains(item))
					{
						GlobalNonloop.Add(item);
					}
					item.Paused = !value;
					return true;
				}
			}
			foreach (var item in GlobalNonloop)
			{
				ContentRef<Sound> sound = item.Sound;
				if (sound.Name.Equals(name))
				{
					DualityApp.Sound.PlaySound(sound);
					return true;
				}
			}
			return false;
		}
		public bool ChangeVolume(string name, int value, bool global = false)
		{
			if (value > 200)
				value = 200;
			if (value < 0)
				value = 0;
			if (!global)
			{
				foreach (var item in emitter.Sources)
				{
					ContentRef<Sound> sound = item.Sound;
					if (sound.Name.Equals(name))
					{
						item.Volume = value / 100f;
						return true;
					}
				}
			}
			else
			{
				foreach (var item in DualityApp.Sound.Playing)
				{
					ContentRef<Sound> sound = item.Sound;
					if (sound.Name.Equals(name))
					{
						item.Volume = value / 100f;
						return true;
					}
				}
			}
			return false;
		}
		public static event EventHandler<SoundManager> OnLoad;
		public void OnUpdate()
		{
			if (transform != null)
			{
				if (GameObj.Scene.Name.Equals("Office"))
					transform.Pos = DisplayController.Camera.FocusPos;
			}
		}

		public void OnActivate()
		{
			list = null;
			transform = GameObj.Transform;
			emitter = GameObj.GetComponent<SoundEmitter>();
			if (emitter != null)
			{
				list = emitter.Sources;
				OnLoad?.Invoke(this, this);
			}
			List<SoundInstance> global = new List<SoundInstance>(DualityApp.Sound.Playing);
			List<SoundInstance> clone = new List<SoundInstance>(GlobalSources);
			foreach (var source in clone)
			{
				if (!global.Contains(source))
				{
					GlobalSources.Remove(source);
				}
			}
		}

		public void OnDeactivate()
		{
		}
	}

	public class HudRenderer : Component, ICmpRenderer, ICmpInitializable
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
				if (this.GameObj.Scene.Name.Equals("Office"))
				{
					if (SixAM.Started || JumpscareManager.Jumpscared)
						return;
				}
				this.canvas.Begin(device);

				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.Green;
				canvas.State.TextFont = this.font;

				string cursorText = string.Format("{0}, {1}", (int)DualityApp.Mouse.Pos.X, (int)DualityApp.Mouse.Pos.Y);
				string cursorBottomText = string.Format("{0}, {1}", Core.MaxWindowSize.X, Core.MaxWindowSize.Y);

				float top_x = DualityApp.Mouse.Pos.X - (canvas.MeasureText(cursorText).X/2);
				float top_end_x = DualityApp.Mouse.Pos.X + (canvas.MeasureText(cursorText).X/2);
				float top_y = DualityApp.Mouse.Pos.Y - 20;

				float bot_x = DualityApp.Mouse.Pos.X - (canvas.MeasureText(cursorBottomText).X / 2);
				float bot_end_x = DualityApp.Mouse.Pos.X + (canvas.MeasureText(cursorBottomText).X / 2);
				float bot_y = DualityApp.Mouse.Pos.Y + 20;

				if (top_x < 0)
				{
					top_x = 0;
				}
				if(top_end_x > Core.MaxWindowSize.X)
				{
					top_x = Core.MaxWindowSize.X - (cursorText.Length * 8);
				}
				if(top_y < 0)
				{
					top_y = 0;
				}
				if(top_y > Core.MaxWindowSize.Y - 40)
				{
					top_y = Core.MaxWindowSize.Y - canvas.MeasureText(cursorText).Y - 20;
				}

				if (bot_x < 0)
				{
					bot_x = 0;
				}
				if (bot_end_x > Core.MaxWindowSize.X)
				{
					bot_x = Core.MaxWindowSize.X - (cursorBottomText.Length * 8);
				}
				if(bot_y > Core.MaxWindowSize.Y - 20)
				{
					bot_y = Core.MaxWindowSize.Y - canvas.MeasureText(cursorBottomText).Y;
				}
				canvas.DrawText(cursorText, top_x, top_y);
				canvas.DrawText(cursorBottomText, bot_x, bot_y);
				canvas.DrawText("FPS: " + Time.Fps, 0, 0);
				canvas.DrawText("Client: " + (Core.Client != null && Core.Client.IsConnected ? "connected" : "not connected"), 0, 32);

				if (this.GameObj.Scene.Name.Equals("Office"))
				{
					if (SixAM.Started || JumpscareManager.Jumpscared)
						return;
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

						float half = Core.MaxWindowSize.X / 2;

						float limit = (half / 4);

						float cancelStart = half - limit;
						float cancelEnd = half + limit;

						if (!CameraAnimator.IsOpening)
						{
							canvas.DrawLine(cancelStart, 0, cancelStart, Core.MaxWindowSize.Y);
							canvas.DrawLine(cancelEnd, 0, cancelEnd, Core.MaxWindowSize.Y);

							int i = 1;
							while (cancelStart - (limit * i) > 0)
							{
								canvas.DrawLine(cancelStart - (limit * i), 0, cancelStart - (limit * i), Core.MaxWindowSize.Y);
								i++;
							}
							i = 1;
							while (cancelEnd + (limit * i) < Core.MaxWindowSize.X)
							{
								canvas.DrawLine(cancelEnd + (limit * i), 0, cancelEnd + (limit * i), Core.MaxWindowSize.Y);
								i++;
							}
						}
					}
					else
					{
						canvas.DrawText("2A dark: "+(CameraRenderer.IsRandom ? "yes":"no"), 0,50);
						if(Core.SelfCharacter != Core.Character.Guard)
							canvas.DrawRect(AttackButton.box.X, AttackButton.box.Y, AttackButton.box.W, AttackButton.box.H);
					}
				}

				this.canvas.End();
			}
		}

		public void OnActivate()
		{
			isDebug = Core.DEBUG;
		}

		public void OnDeactivate()
		{
			
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

	#region Code helper

	#region StringValue
	public class StringValueAttribute : Attribute
	{

		#region Properties

		/// <summary>
		/// Holds the stringvalue for a value in an enum.
		/// </summary>
		public string StringValue { get; protected set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor used to init a StringValue Attribute
		/// </summary>
		/// <param name="value"></param>
		public StringValueAttribute(string value)
		{
			this.StringValue = value;
		}

		#endregion

	}

	public static class StringValueReflector
	{
		/// <summary>
		/// Will get the string value for a given enums value, this will
		/// only work if you assign the StringValue attribute to
		/// the items in your enum.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetStringValue(this Enum value)
		{
			// Get the type
			Type type = value.GetType();

			// Get fieldinfo for this type
			FieldInfo fieldInfo = type.GetField(value.ToString());

			// Get the stringvalue attributes
			StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
				typeof(StringValueAttribute), false) as StringValueAttribute[];

			// Return the first if there was a match.
			return attribs.Length > 0 ? attribs[0].StringValue : null;
		}
	}
	#endregion

	#region StringListValue
	public class StringListValueAttribute : Attribute
	{

		#region Properties

		/// <summary>
		/// Holds the stringvalue for a value in an enum.
		/// </summary>
		public string[] StringValue { get; protected set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor used to init a StringValue Attribute
		/// </summary>
		/// <param name="value"></param>
		public StringListValueAttribute(params string[] value)
		{
			this.StringValue = value;
		}

		#endregion

	}

	
	public static class StringListValueReflector
	{
		/// <summary>
		/// Will get the string value for a given enums value, this will
		/// only work if you assign the StringListValue attribute to
		/// the items in your enum.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		public static string GetStringValue(this Enum value, int pos)
		{
			// Get the type
			Type type = value.GetType();

			// Get fieldinfo for this type
			FieldInfo fieldInfo = type.GetField(value.ToString());

			// Get the stringvalue attributes
			StringListValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
				typeof(StringListValueAttribute), false) as StringListValueAttribute[];

			string[] list = attribs.Length > 0 ? attribs[0].StringValue : null;
			if (list == null)
				return null;
			if (list.Length <= pos)
				return list[list.Length - 1];
			return list[pos];
		}
	}
	#endregion

	public static class StringExtensionMethods
	{
		public static string ReplaceFirst(this string text, string search, string replace)
		{
			int pos = text.IndexOf(search);
			if (pos < 0)
			{
				return text;
			}
			return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}
		public static string ReplaceLast(this string text, string search, string replace)
		{
			int pos = text.LastIndexOf(search);
			if (pos < 0)
			{
				return text;
			}
			return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}
	}

	#endregion
}
