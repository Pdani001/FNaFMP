using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Drawing;
using Duality.Resources;
using System;
using System.Collections.Generic;
using FNaFMP.Utility;
using Alzaitu.Lacewing.Client.Packet.EventData;
using Alzaitu.Lacewing.Client.Packet;
using Duality.Editor;
using System.Timers;
using FNaFMP.Alzaitu.Lacewing.Client.Packet;

namespace FNaFMP.Office
{

	public class OfficeControllerValue
	{
		private Rect door = new Rect(0,0,0,0);
		private Rect light = new Rect(0,0,0,0);
		private DoorDirection direction = DoorDirection.None;
		private ContentRef<Sound> lightSound = null;
		private ContentRef<Sound> killedSound = null;
		private ContentRef<Material> open_nolight = null;
		private ContentRef<Material> open_light = null;
		private ContentRef<Material> closed_nolight = null;
		private ContentRef<Material> closed_light = null;
		private bool killed = false;
		public DoorDirection DoorDirection
		{
			get { return direction; }
			set { direction = value; }
		}
		public ContentRef<Sound> LightSound
		{
			get { return lightSound; }
			set { lightSound = value; }
		}
		public ContentRef<Sound> KilledSound
		{
			get { return killedSound; }
			set { killedSound = value; }
		}
		public ContentRef<Material> OpenWoLight
		{
			get { return open_nolight; }
			set { open_nolight = value; }
		}
		public ContentRef<Material> OpenWLight
		{
			get { return open_light; }
			set { open_light = value; }
		}
		public ContentRef<Material> ClosedWoLight
		{
			get { return closed_nolight; }
			set { closed_nolight = value; }
		}
		public ContentRef<Material> ClosedWLight
		{
			get { return closed_light; }
			set { closed_light = value; }
		}
		public Rect DoorArea
		{
			get { return door; }
			set
			{
				if (value == null)
					return;
				door = value;
			}
		}
		public Rect LightArea
		{
			get { return light; }
			set
			{
				if (value == null)
					return;
				light = value;
			}
		}
		public bool IsKilled
		{
			get { return killed; }
			set { killed = value; }
		}
	}

	[RequiredComponent(typeof(SpriteRenderer))]
	public class VisibilityController : Component, ICmpUpdatable
	{
		[DontSerialize] private SpriteRenderer render;
		public void OnUpdate()
		{
			if (render == null)
			{
				render = this.GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				if (JumpscareManager.Jumpscared)
				{
					render.ColorTint = render.ColorTint.WithAlpha(0);
					return;
				}
				switch (render.VisibilityGroup)
				{
					case VisibilityFlag.Group1:
						render.ColorTint = render.ColorTint.WithAlpha(CameraViewer.IsViewing ? 255 : 0);
						break;
					case VisibilityFlag.Group0:
						render.ColorTint = render.ColorTint.WithAlpha(!CameraViewer.IsViewing ? 255 : 0);
						break;
					default:
						break;
				}
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer))]
	public class OfficeFan : Component, ICmpUpdatable
	{
		[DontSerialize] private SpriteRenderer render;
		public void OnUpdate()
		{
			if (render == null)
			{
				render = this.GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				if (JumpscareManager.Jumpscared || CameraViewer.IsViewing || GameController.Power <= 0)
				{
					render.ColorTint = render.ColorTint.WithAlpha(0);
				}
				else
				{
					render.ColorTint = render.ColorTint.WithAlpha(255);
				}
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer))]
	public class DisabledCamera : Component, ICmpUpdatable
	{
		[DontSerialize] private SpriteRenderer render;
		public void OnUpdate()
		{
			if (render == null)
			{
				render = this.GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				render.ColorTint = render.ColorTint.WithAlpha(CameraViewer.ViewNumber == 9 && CameraViewer.IsViewing ? 255 : 0);
			}
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(SpriteAnimator))]
	public class BlipAnimator : Component, ICmpUpdatable
	{
		[DontSerialize] private static bool play = false;
		private ContentRef<Sound> sound = null;
		public ContentRef<Sound> BlipSound
		{
			get { return sound; }
			set { sound = value; }
		}
		public static void PlayBlip()
		{
			if (renderer == null)
				return;
			play = true;
		}
		[DontSerialize] private static SpriteRenderer renderer;
		[DontSerialize] private SpriteAnimator animator;
		public void OnUpdate()
		{
			if (renderer == null || animator == null)
			{
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
			}
			if(!animator.IsAnimationRunning && renderer.ColorTint.A == 255)
			{
				renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
				animator.Paused = true;
				animator.AnimTime = 0;
				renderer.SpriteIndex = 0;
			}
			if (CameraViewer.IsViewing)
			{
				if (renderer.SpriteIndex == 0 && play) {
					play = false;
					renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
					animator.Paused = false;
					if(BlipSound != null)
					{
						GameController.SM.PlaySound(BlipSound, false);
					}
				}
			} else
			{
				animator.Paused = true;
				animator.AnimTime = 0;
				renderer.SpriteIndex = 0;
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer))]
	public class FlipButton : Component, ICmpUpdatable
	{
		public static bool Disabled { get; set; }
		[DontSerialize] private SpriteRenderer renderer;
		public void OnUpdate()
		{
			if (renderer == null)
			{
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				ColorRgba color = renderer.ColorTint;
				color.A = (byte)(Disabled ? 0 : 255);
				renderer.ColorTint = color;
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer)),RequiredComponent(typeof(SpriteAnimator))]
	public class CameraAnimator : Component, ICmpUpdatable, ICmpInitializable
	{
		[DontSerialize] private bool start = false;
		[DontSerialize] private static bool force = false;
		public static bool ForceCamera
		{
			get { return force; }
			set { force = value; }
		}
		[DontSerialize] private static bool disable = false;
		public static bool DisableCamera
		{
			get { return disable; }
			set { disable = value; }
		}
		[DontSerialize] private static bool open;
		public static bool IsOpening
		{
			get { return open; }
		}
		[DontSerialize] private static bool close;
		public static bool IsClosing
		{
			get { return close; }
		}
		[DontSerialize] private bool hover = false;
		[DontSerialize] private SpriteRenderer renderer;
		[DontSerialize] private SpriteAnimator animator;
		private Rect area = new Rect(0,0,0,0);
		private ContentRef<Material> up = null;
		public ContentRef<Material> AnimUp
		{
			get { return up; }
			set { up = value; }
		}
		private ContentRef<Material> down = null;
		public ContentRef<Material> AnimDown
		{
			get { return down; }
			set { down = value; }
		}
		private SoundEmitter.Source up_source = null;
		private ContentRef<Sound> up_sound = null;
		public ContentRef<Sound> SoundUp
		{
			get { return up_sound; }
			set { up_sound = value; }
		}
		private SoundEmitter.Source down_source = null;
		private ContentRef<Sound> down_sound = null;
		public ContentRef<Sound> SoundDown
		{
			get { return down_sound; }
			set { down_sound = value; }
		}
		public Rect MouseArea
		{
			get { return area; }
			set { area = value; }
		}
		public void OnUpdate()
		{
			if (up == null || down == null || area == null)
				return;
			up.EnsureLoaded();
			down.EnsureLoaded();
			if (!start)
			{
				return;
			}
			open = animator.IsAnimationRunning && renderer.SharedMaterial.Name.Equals(up.Name);
			close = animator.IsAnimationRunning && renderer.SharedMaterial.Name.Equals(down.Name);
			if (!animator.IsAnimationRunning && renderer.ColorTint.A == 255)
			{
				renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
				animator.Paused = true;
				animator.AnimTime = 0;
				renderer.SpriteIndex = 0;
				if (renderer.SharedMaterial.Name.Equals(up.Name))
				{
					CameraViewer.IsViewing = true;
					renderer.SharedMaterial = down;
					BlipAnimator.PlayBlip();
					if (Core.SelfCharacter == Core.Character.Guard)
					{
						GameController.SendStatus();
					}
				} else
				{
					renderer.SharedMaterial = up;
				}
			}
			if (ForceCamera && !animator.IsAnimationRunning && !FlipButton.Disabled)
			{
				if (CameraViewer.IsViewing)
				{
					renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
					animator.Paused = false;
					CameraViewer.IsViewing = false;
					if (down_sound != null)
					{
						down_source = GameController.SM.PlaySound(down_sound, false);
					}
					if (Core.SelfCharacter == Core.Character.Guard)
					{
						GameController.SendStatus();
					}
				}
				ForceCamera = false;
			}
			Vector2 mousePos = DualityApp.Mouse.Pos;
			if((mousePos.X > area.X && mousePos.X < area.X + area.W && mousePos.Y > area.Y && mousePos.Y < area.Y + area.H) && !FlipButton.Disabled)
			{
				if (!hover && !DisableCamera)
				{
					hover = true;
					renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
					animator.Paused = false;
					if (CameraViewer.IsViewing)
					{
						CameraViewer.IsViewing = false;
						if (up_source != null)
						{
							GameController.SM.StopSound(up_source);
							up_source = null;
						}
						if (down_sound != null)
						{
							down_source = GameController.SM.PlaySound(down_sound, false);
						}
						if (Core.SelfCharacter == Core.Character.Guard)
						{
							GameController.SendStatus();
						}
					} else
					{
						if (up_sound != null)
						{
							up_source = GameController.SM.PlaySound(up_sound, false);
						}
						if (down_source != null)
						{
							GameController.SM.StopSound(down_source);
							down_source = null;
						}
					}
				}
			} else
			{
				if(!animator.IsAnimationRunning)
					hover = false;
			}
		}

		public void OnActivate()
		{
			if (renderer == null)
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
			if (animator == null)
				animator = this.GameObj.GetComponent<SpriteAnimator>();
			if (!renderer.SharedMaterial.Name.Equals(up.Name))
				renderer.SharedMaterial = up;
			start = true;
		}

		public void OnDeactivate()
		{
			start = false;
		}
	}
	public enum DoorDirection
	{
		None,
		Left,
		Right
	}
	public class DoorController
	{
		private static DoorDirection lightDir = DoorDirection.None;
		public static DoorDirection LightDirection
		{
			get { return lightDir; }
			set { lightDir = value; }
		}
		private static bool flicker = false;
		public static bool LightFlicker
		{
			get { return flicker; }
			set { flicker = value; }
		}
		public static DoorAnimator LeftDoor = null;
		public static DoorAnimator RightDoor = null;
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(SpriteAnimator)), RequiredComponent(typeof(Transform))]
	public class DoorAnimator : Component, ICmpUpdatable, ICmpInitializable
	{
		private DoorDirection direction = DoorDirection.None;
		public DoorDirection DoorDirection
		{
			get { return direction; }
			set { direction = value; }
		}
		[DontSerialize] private bool anim = false;
		/*
		 * 0 => open
		 * 1 => closing
		 * 2 => closed
		 * 3 => opening
		 */
		[DontSerialize] private int state = 0;
		[DontSerialize] private Transform transform = null;
		[DontSerialize] private SpriteRenderer renderer = null;
		[DontSerialize] private SpriteAnimator animator = null;
		private ContentRef<Sound> sound = null;
		public ContentRef<Sound> DoorSound
		{
			get { return sound; }
			set { sound = value; }
		}
		private ContentRef<Material> open = null;
		public ContentRef<Material> Open
		{
			get { return open; }
			set { open = value; }
		}
		private ContentRef<Material> opening = null;
		public ContentRef<Material> AnimOpen
		{
			get { return opening; }
			set { opening = value; }
		}
		private ContentRef<Material> close = null;
		public ContentRef<Material> Closed
		{
			get { return close; }
			set { close = value; }
		}
		private ContentRef<Material> closing = null;
		public ContentRef<Material> AnimClose
		{
			get { return closing; }
			set { closing = value; }
		}
		public int GetState()
		{
			return state;
		}
		public bool IsOpen()
		{
			return state == 0 || state >= 3;
		}
		public void ToggleDoor()
		{
			switch (state)
			{
				case 0:
				case 2:
					state++;
					anim = true;
					if (sound != null)
					{
						GameController.SM.PlaySound(sound, false);
					}
					break;
				default:
					break;
			}
			if (Core.SelfCharacter == Core.Character.Guard)
			{
				GameController.SendStatus();
			}
		}
		public Vector3 GetPos()
		{
			if (transform == null)
				return new Vector3();
			return transform.Pos;
		}
		public void OnUpdate()
		{
			if (open == null || opening == null || close == null || closing == null || direction == 0)
				return;

			open.EnsureLoaded();
			opening.EnsureLoaded();
			close.EnsureLoaded();
			closing.EnsureLoaded();
			if (sound != null)
			{
				sound.EnsureLoaded();
			}

			if (renderer == null || transform == null || animator == null)
			{
				
			}
			else
			{
				if (anim)
				{
					anim = false;
					renderer.SpriteIndex = 0;
					animator.AnimTime = 0;
					animator.Paused = false;
				}
				switch (state)
				{
					case 0:
						renderer.SharedMaterial = open;
						break;
					case 1:
						renderer.SharedMaterial = closing;
						animator.FrameCount = closing.Res.MainTexture.Res.BasePixmap.Res.Atlas.Count;
						if (!animator.IsAnimationRunning)
						{
							state++;
							animator.Paused = true;
						}
						break;
					case 2:
						renderer.SharedMaterial = close;
						break;
					case 3:
						renderer.SharedMaterial = opening;
						animator.FrameCount = closing.Res.MainTexture.Res.BasePixmap.Res.Atlas.Count;
						if (!animator.IsAnimationRunning)
						{
							state++;
							animator.Paused = true;
						}
						break;
					case 4:
						state = 0;
						break;
					default:
						break;
				}
			}
		}

		public void OnActivate()
		{
			if (direction == DoorDirection.Left)
			{
				DoorController.LeftDoor = this;
			}
			if (direction == DoorDirection.Right)
			{
				DoorController.RightDoor = this;
			}
			if (renderer == null || transform == null || animator == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
				state = 0;
			}
		}

		public void OnDeactivate()
		{
		}
	}
	[RequiredComponent(typeof(SpriteRenderer))]
	public class CameraButtonText : Component, ICmpUpdatable
	{
		[DontSerialize] private SpriteRenderer renderer = null;
		private Int32 number = -1;
		public Int32 ViewNumber
		{
			get { return number; }
			set { number = value; }
		}
		public void OnUpdate()
		{
			if (number < 0)
				return;
			if (renderer == null)
			{
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
				if (CameraViewer.ViewNumber == ViewNumber)
				{
					renderer.ColorTint = renderer.ColorTint.WithAlpha(CameraViewer.IsViewing ? 255 : 0);
				}
				else
				{
					renderer.SpriteIndex = 0;
					if (MovementControl.Buttons.Contains(-1) || MovementControl.Buttons.Contains(ViewNumber))
					{
						renderer.ColorTint = renderer.ColorTint.WithAlpha(CameraViewer.IsViewing ? 255 : 0);
					}
					else
					{
						renderer.ColorTint = renderer.ColorTint.WithAlpha(127);
					}
				}
			}
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(SpriteAnimator)), RequiredComponent(typeof(Transform))]
	public class CameraButton : Component, ICmpUpdatable
	{
		[DontSerialize] private Transform transform = null;
		[DontSerialize] private SpriteRenderer renderer = null;
		[DontSerialize] private SpriteAnimator animator = null;
		private Int32 number = -1;
		public Int32 ViewNumber
		{
			get { return number; }
			set { number = value; }
		}
		public void OnUpdate()
		{
			if (number < 0)
				return;
			if (renderer == null || transform == null || animator == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
			} else
			{
				Material mat = renderer.SharedMaterial.Res;
				if (mat == null)
				{
					return;
				}
				Texture text = mat.MainTexture.Res;
				if(text == null)
				{
					return;
				}
				if(CameraViewer.ViewNumber == ViewNumber)
				{
					animator.Paused = false;
					renderer.ColorTint = renderer.ColorTint.WithAlpha(CameraViewer.IsViewing ? 255 : 0);
				} else
				{
					animator.Paused = true;
					animator.AnimTime = 0;
					renderer.SpriteIndex = 0;
					if (MovementControl.Buttons.Contains(-1) || MovementControl.Buttons.Contains(ViewNumber))
					{
						renderer.ColorTint = renderer.ColorTint.WithAlpha(CameraViewer.IsViewing ? 255 : 0);
					}
					else
					{
						renderer.ColorTint = renderer.ColorTint.WithAlpha(127);
					}
				}
				if (GameController.Power <= 0 || SixAM.Started)
					return;
				Point2 size = text.Size;
				Vector3 pos = transform.Pos;
				Vector2 mouse = DualityApp.Mouse.Pos;
				if(mouse.X > pos.X && mouse.X < pos.X+(size.X/2) && mouse.Y > pos.Y && mouse.Y < pos.Y + size.Y)
				{
					if (DualityApp.Mouse.ButtonHit(Duality.Input.MouseButton.Left) && CameraViewer.IsViewing && MovementControl.IsValid(CameraViewer.ViewNumber,ViewNumber))
					{
						renderer.SpriteIndex = 1;
						animator.AnimTime = animator.AnimDuration / 2;
						CameraViewer.ViewNumber = ViewNumber;
						BlipAnimator.PlayBlip();
						Positions.SetPosition(Core.SelfCharacter, Core.SelfCharacter != Core.Character.Foxy ? ViewNumber : Positions.GetPosition(Core.SelfCharacter)+1);
						if(Core.SelfCharacter != Core.Character.Guard)
							MovementControl.Buttons.Clear();
						MovementControl.SelfTime = MovementControl.GetRandomMoveTime(Core.SelfCharacter);
						if(Core.Client != null && Core.Client.IsConnected && Core.Client.joinedChannels.Count > 0)
						{
							List<byte> msg = new List<byte>
							{
								(byte)Core.SelfCharacter,
								(byte)Positions.GetPosition(Core.SelfCharacter)
							};
							Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 25, msg.ToArray());
							if(Core.SelfCharacter == Core.Character.Guard)
							{
								GameController.SendStatus();
							}
						}
					}
				}
			}
		}
	}
	public class AttackButton : Component, ICmpUpdatable
	{
		[EditorHintFlags(MemberFlags.Visible)]
		private Rect Position { get; set; }
		public static Rect box { get; private set; }
		public void OnUpdate()
		{
			box = Position;
			Vector2 size = Position.Size;
			Vector2 pos = Position.Pos;
			Vector2 mouse = DualityApp.Mouse.Pos;
			if (mouse.X > pos.X && mouse.X < pos.X + size.X && mouse.Y > pos.Y && mouse.Y < pos.Y + size.Y)
			{
				if (DualityApp.Mouse.ButtonHit(Duality.Input.MouseButton.Left) && CameraViewer.IsViewing && MovementControl.IsValid(CameraViewer.ViewNumber, 21))
				{
					int target = 21;
					if ((Core.SelfCharacter != Core.Character.Bonnie && GameController.Guard.RightDoorClosed) || (Core.SelfCharacter == Core.Character.Bonnie && GameController.Guard.LeftDoorClosed))
					{
						target = 1;
					}
					CameraViewer.ViewNumber = target;
					BlipAnimator.PlayBlip();
					Positions.SetPosition(Core.SelfCharacter, target);
					MovementControl.Buttons.Clear();
					MovementControl.SelfTime = MovementControl.GetRandomMoveTime(Core.SelfCharacter);
					if (Core.Client != null && Core.Client.IsConnected && Core.Client.joinedChannels.Count > 0)
					{
						List<byte> msg = new List<byte>
						{
							(byte)Core.SelfCharacter,
							(byte)target
						};
						Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 25, msg.ToArray());
					}
				}
			}
		}
	}
	public class MovePrevent
	{
		public enum Operation
		{
			Equal,
			NotEqual,
			Lower,
			LowerOrEqual,
			Higher,
			HigherOrEqual
		}
		public int Position { get; set; }
		private Operation op = Operation.Equal;
		public Operation PreventOperation {
			get { return op; }
			set { op = value; }
		}
	}
	public class Movement
	{
		[EditorHintRange(0,int.MaxValue)]
		public int From { get; set; }
		[EditorHintRange(0, int.MaxValue)]
		public int To { get; set; }
		private Dictionary<Core.Character, List<MovePrevent>> prevent = new Dictionary<Core.Character, List<MovePrevent>>();
		public Dictionary<Core.Character, List<MovePrevent>> Prevent
		{
			get { return prevent; }
			set { if (value != null) prevent = value; }
		}
	}
	public class MoveTime
	{
		public int Min { get; set; }
		public int Max { get; set; }
	}
	public class MovementControl : Component, ICmpInitializable, ICmpUpdatable
	{
		private Dictionary<Core.Character, List<Movement>> movements = new Dictionary<Core.Character, List<Movement>>();
		public Dictionary<Core.Character, List<Movement>> Movements
		{
			get { return movements; }
			set { if (value != null) movements = value; }
		}
		private Dictionary<Core.Character, MoveTime> mt = new Dictionary<Core.Character, MoveTime>();
		public Dictionary<Core.Character, MoveTime> MoveTimes
		{
			get { return mt; }
			set { if (value != null) mt = value; }
		}
		public static int SelfTime
		{
			get { return time; }
			set
			{
				time = value;
				nextmove = (int)(Time.GameTimer.TotalMilliseconds + (time * 1000));
			}
		}
		[DontSerialize] private static int time = -1;
		public static int NextMove
		{
			get { return nextmove; }
		}
		[DontSerialize] private static int nextmove = -1;
		[DontSerialize] private static Dictionary<Core.Character, List<Movement>> check = null;
		[DontSerialize] private static Dictionary<Core.Character, MoveTime> times = null;
		[DontSerialize] public static readonly List<int> Buttons = new List<int>();
		public static bool IsValid(int from, int to)
		{
			if (Core.SelfCharacter == Core.Character.Guard)
			{
				return to != 21;
			}
			bool allow = (int)Math.Round((NextMove - Time.GameTimer.TotalMilliseconds) / 1000) <= 0;
			if (GameController.Power <= 0 || SixAM.Started)
				allow = false;
			if (!allow)
			{
				return false;
			}
			if(check != null && check.ContainsKey(Core.SelfCharacter))
			{
				List<Movement> moves = check[Core.SelfCharacter];
				foreach(var m in moves)
				{
					if (m.From == from && m.To == to)
					{
						if(m.Prevent.Count > 0)
						{
							foreach(Core.Character pc in m.Prevent.Keys)
							{
								if (pc == Core.Character.Guard && !GameController.Guard.IsViewing)
									continue;
								foreach (MovePrevent prev in m.Prevent[pc])
								{
									switch (prev.PreventOperation)
									{
										case MovePrevent.Operation.Equal:
											if (Positions.GetPosition(pc) == prev.Position)
												return false;
											break;
										case MovePrevent.Operation.NotEqual:
											if (Positions.GetPosition(pc) != prev.Position)
												return false;
											break;
										case MovePrevent.Operation.Lower:
											if (Positions.GetPosition(pc) < prev.Position)
												return false;
											break;
										case MovePrevent.Operation.LowerOrEqual:
											if (Positions.GetPosition(pc) <= prev.Position)
												return false;
											break;
										case MovePrevent.Operation.Higher:
											if (Positions.GetPosition(pc) > prev.Position)
												return false;
											break;
										case MovePrevent.Operation.HigherOrEqual:
											if (Positions.GetPosition(pc) >= prev.Position)
												return false;
											break;
									}
								}
							}
						}
						return true;
					}
				}
			}
			return false;
		}
		[DontSerialize] private static Random random = null;
		public static int GetRandomMoveTime(Core.Character character)
		{
			if (character == Core.Character.Guard || times == null || !times.ContainsKey(character))
				return 0;
			MoveTime time = times[character];
			if (time.Min > time.Max)
				return 1;
			return random.Next(time.Min, time.Max);
		}
		public void OnActivate()
		{
			random = new Random();
			random = new Random((int)(random.NextDouble() * Time.StartupTime.Ticks));
			check = movements;
			times = mt;
			SelfTime = GetRandomMoveTime(Core.SelfCharacter);
			Buttons.Clear();
			if (Core.SelfCharacter == Core.Character.Guard && Buttons.Count == 0)
			{
				Buttons.Add(-1);
			}
		}

		public void OnDeactivate()
		{
			random = null;
			check = null;
			times = null;
		}


		public void OnUpdate()
		{
			if(Core.SelfCharacter != Core.Character.Guard)
			{
				if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.M) && HudRenderer.IsDebug)
					SelfTime = 0;
				if (!GameController.Guard.Active)
				{
					nextmove = (int)(Time.GameTimer.TotalMilliseconds + (time * 1000));
				}
			}
			if (Buttons.Count == 0)
			{
				if (check != null && check.ContainsKey(Core.SelfCharacter))
				{
					List<Movement> moves = check[Core.SelfCharacter];
					foreach (var m in moves)
					{
						if (m.From == Positions.GetPosition(Core.SelfCharacter))
						{
							Buttons.Add(m.To);
						}
					}
				}
			}
		}
	}
	public class Positions
	{
		[DontSerialize] private static Dictionary<Core.Character,int> pos = new Dictionary<Core.Character,int>();
		[DontSerialize] private static Dictionary<Core.Character,int> users = new Dictionary<Core.Character,int>();
		[DontSerialize] private static Dictionary<int, List<Core.Character>> cams = new Dictionary<int, List<Core.Character>>();
		public static List<Core.Character> GetRobots(int camera)
		{
			List<Core.Character> characters = new List<Core.Character>();
			if (cams.ContainsKey(camera))
				characters = cams[camera];
			return characters;
		}
		public static int GetPosition(Core.Character robot)
		{
			if (pos.ContainsKey(robot))
			{
				return pos[robot];
			}
			return -1;
		}
		public static void SetPosition(Core.Character robot, int value)
		{
			int old;
			if (!pos.TryGetValue(robot, out old))
			{
				old = -1;
			}
			if (value != -1)
				pos[robot] = value;
			else
				pos.Remove(robot);
			if (robot != Core.Character.Guard)
			{
				if (robot == Core.Character.Foxy)
				{
					switch (value)
					{
						case 0:
						case 1:
						case 2:
							value = 2;
							break;
						case 3:
						case 4:
							value = 3;
							break;
					}
					switch (old)
					{
						case 0:
						case 1:
						case 2:
							old = 2;
							break;
						case 3:
						case 4:
							old = 3;
							break;
					}
				}
				if (value != -1)
				{
					if (!cams.ContainsKey(value))
					{
						cams[value] = new List<Core.Character>() { robot };
					}
					else
					{
						List<Core.Character> characters = new List<Core.Character>(cams[value]);
						characters.Add(robot);
						Utilities.Logger.Write("ADD - There are {0} robots on cam {1}", characters.Count, value);
						cams[value] = characters;
					}
				}
				if (cams.ContainsKey(old))
				{
					List<Core.Character> characters = new List<Core.Character>(cams[old]);
					characters.Remove(robot);
					Utilities.Logger.Write("DEL - There are {0} robots on cam {1}", characters.Count, value);
					cams[old] = characters;
				}
			}
		}
		public static void SetUser(Core.Character robot, int user)
		{
			if (user != -1)
				users[robot] = user;
			else
				users.Remove(robot);
		}
		public static Core.Character GetUserCharacter(int user)
		{
			foreach(Core.Character c in users.Keys)
			{
				if (users[c] == user)
					return c;
			}
			return Core.Character.None;
		}
		public static void Reset()
		{
			pos = new Dictionary<Core.Character, int>();
			cams = new Dictionary<int, List<Core.Character>>();
			users = new Dictionary<Core.Character, int>();
		}
	}
	
	public class CameraView
	{
		private List<Core.Character> robots = new List<Core.Character>();
		public List<Core.Character> RobotList
		{
			get { return robots; }
			set { robots = value; }
		}
		private ContentRef<Material> mat = null;
		public ContentRef<Material> Material
		{
			get { return mat; }
			set { mat = value; }
		}
		private int extra = -1;
		public int Extra
		{
			get { return extra; }
			set { extra = value; }
		}
		private bool move = true;
		public bool AllowMovement
		{
			get { return move; }
			set { move = value; }
		}
		private float duration = 0;
		public float AnimDuration
		{
			get { return duration; }
			set { duration = value; }
		}
		private SpriteAnimator.LoopMode mode = SpriteAnimator.LoopMode.Once;
		public SpriteAnimator.LoopMode AnimLoopMode
		{
			get { return mode; }
			set { mode = value; }
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class LocationRenderer : Component, ICmpUpdatable
	{
		[DontSerialize] private Transform transform = null;
		[DontSerialize] private SpriteRenderer renderer = null;
		private List<ContentRef<Material>> list = new List<ContentRef<Material>>();
		public List<ContentRef<Material>> CameraList
		{
			get { return list; }
			set { list = value; }
		}
		public void OnUpdate()
		{
			if (list == null || list.Count < 1)
				return;
			if (renderer == null || transform == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				foreach (var item in list)
				{
					if (item == null)
						continue;
					item.EnsureLoaded();
				}
			}
			else
			{
				if (CameraViewer.IsViewing)
				{
					if (list.Count > CameraViewer.ViewNumber)
					{
						ContentRef<Material> item = list[CameraViewer.ViewNumber];
						if (item != null)
						{
							renderer.SharedMaterial = item;
						}
						Point2 size = renderer.SharedMaterial.Res.MainTexture.Res.ContentSize;
						renderer.Rect = new Rect(0,0, size.X, size.Y);
					}
				}
				else
				{
				}
			}
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(SpriteAnimator)), RequiredComponent(typeof(Transform))]
	public class CameraRenderer : Component, ICmpUpdatable
	{
		[DontSerialize] private static bool random = false;
		public static bool IsRandom
		{
			get { return random; }
		}
		[DontSerialize] private int lastTime = 0;
		[DontSerialize] private Transform transform = null;
		[DontSerialize] private SpriteRenderer renderer = null;
		[DontSerialize] private SpriteAnimator animator = null;
		private List<List<CameraView>> list = new List<List<CameraView>>();
		public List<List<CameraView>> CameraList
		{
			get { return list; }
			set { list = value; }
		}
		private CameraView DoLeave(List<CameraView> items, int view)
		{
			int foxy = Positions.GetPosition(Core.Character.Foxy);
			List<CameraView> check = new List<CameraView>(items);
			CameraView cv = null;
			foreach (var sub in items)
			{
				switch (view)
				{
					case 2:
						if ((foxy > -1 && foxy != sub.Extra && foxy <= 2) ||
							(foxy == -1 && sub.Extra != 0) ||
							(foxy > 2 && sub.Extra != 3))
						{
							continue;
						}
						cv = sub;
						break;
					case 3:
						if (sub.Extra != 1)
						{
							if (sub.RobotList != null && sub.RobotList.Contains(Core.Character.Foxy) && foxy == 4)
								continue;
							if (random)
							{
								check.Remove(sub);
								continue;
							}
						}
						else
						{
							if (!random)
							{
								check.Remove(sub);
								continue;
							}
						}
						cv = DoLeave(check, 99);
						break;
					default:
						if (sub.RobotList != null && sub.RobotList.Count > 0)
						{
							List<Core.Character> robots = Positions.GetRobots(CameraViewer.ViewNumber);
							if (sub.RobotList.Count < robots.Count)
								continue;
							bool doit = false;
							foreach (Core.Character a in sub.RobotList)
							{
								if (!robots.Contains(a))
								{
									doit = true;
									break;
								}
							}
							if (doit)
								continue;
							cv = sub;
						} else
						{
							cv = sub;
						}
						break;
				}
			}
			return cv;
		}
		public void OnUpdate()
		{
			if (list == null || list.Count < 1)
				return;
			if (renderer == null || transform == null || animator == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
				foreach(var item in list)
				{
					if(item != null)
					{
						foreach(var sub in item)
						{
							if(sub != null && sub.Material != null)
							{
								sub.Material.EnsureLoaded();
							}
						}
					}
				}
			}
			else
			{
				if (Core.SelfCharacter != Core.Character.Guard && GameController.Power <= 0)
					return;
				TimeSpan span = Time.MainTimer;
				int seconds = (int)span.TotalSeconds;
				if (lastTime <= seconds-1 || lastTime == 0)
				{
					random = Randomizer.Random(1) == 1;
					lastTime = seconds;
				}
				if (CameraViewer.IsViewing && Positions.GetPosition(Core.SelfCharacter) < 21)
				{
					if(list.Count > CameraViewer.ViewNumber)
					{
						bool move = DisplayController.movement;
						List<CameraView> item = list[CameraViewer.ViewNumber];
						if (item != null && item.Count > 0)
						{
							var sub = DoLeave(item,CameraViewer.ViewNumber);
							if (sub != null && sub.Material != null)
							{
								if (renderer.SharedMaterial.Name != sub.Material.Name)
								{
									renderer.SharedMaterial = sub.Material;
									renderer.SpriteIndex = 0;
								}
								animator.AnimDuration = sub.AnimDuration;
								animator.AnimLoopMode = sub.AnimLoopMode;
								move = sub.AllowMovement;
							}
						}
						List<Rect> atlas = renderer.SharedMaterial.Res.MainTexture.Res.BasePixmap.Res.Atlas;
						if(atlas != null && atlas.Count > 0)
						{
							animator.FrameCount = atlas.Count;
							if(animator.AnimLoopMode != SpriteAnimator.LoopMode.Once || (animator.AnimLoopMode == SpriteAnimator.LoopMode.Once && renderer.SpriteIndex == 0))
								animator.Paused = false;
						} else
						{
							animator.Paused = true;
							animator.AnimTime = 0;
							animator.FrameCount = 1;
							renderer.SpriteIndex = 0;
						}
						DisplayController.movement = move;
					}
				} else
				{
				}
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(SpriteAnimator)), RequiredComponent(typeof(Transform))]
	public class OfficeLightRenderer : Component, ICmpUpdatable
	{
		[DontSerialize] private bool startup = false;
		[DontSerialize] private Transform transform = null;
		[DontSerialize] private SpriteRenderer renderer = null;
		[DontSerialize] private SpriteAnimator animator = null;
		private ContentRef<Material> def = null;
		public ContentRef<Material> Default
		{
			get { return def; }
			set { def = value; }
		}
		private List<CameraView> left = null;
		public List<CameraView> LeftLight
		{
			get { return left; }
			set { left = value; }
		}
		private List<CameraView> right = null;
		public List<CameraView> RightLight
		{
			get { return right; }
			set { right = value; }
		}

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> ScareSound { get; set; }

		private void ChangeView(ContentRef<Material> mat)
		{
			if(mat == null || DoorController.LightFlicker)
				renderer.SharedMaterial = def;
			else
				renderer.SharedMaterial = mat;
			Vector3 pos = transform.Pos;
			pos.X = 0;
			transform.Pos = pos;
		}

		[DontSerialize] private Dictionary<Core.Character, int> appeard = new Dictionary<Core.Character, int>();
		public void OnUpdate()
		{
			if (def == null)
			{
				Scene.SwitchTo(DualityApp.AppData.StartScene);
				return;
			}
			if (renderer == null || transform == null || animator == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
				appeard = new Dictionary<Core.Character, int>();
				if (ScareSound != null)
					ScareSound.EnsureLoaded();
				foreach (var sub in LeftLight)
				{
					if (sub != null && sub.Material != null)
					{
						sub.Material.EnsureLoaded();
					}
				}
				foreach (var sub in RightLight)
				{
					if (sub != null && sub.Material != null)
					{
						sub.Material.EnsureLoaded();
					}
				}
			}
			else
			{
				if (!startup)
				{
					startup = true;
					ChangeView(def);
				}
				if (GameController.Power <= 0)
					return;
				if (Core.SelfCharacter == Core.Character.Guard && JumpscareManager.Jumpscared)
					return;
				if (CameraViewer.IsViewing && Positions.GetPosition(Core.SelfCharacter) < 21)
				{
					return;
				}
				DoorDirection dir = Core.SelfCharacter == Core.Character.Guard ? DoorController.LightDirection : (Core.SelfCharacter == Core.Character.Bonnie || Core.SelfCharacter == Core.Character.Foxy) ? DoorDirection.Left : DoorDirection.Right;
				switch (dir)
				{
					case DoorDirection.Left:
						if(left == null || left.Count == 0)
						{
							ChangeView(def);
							break;
						}
						foreach(CameraView l in left)
						{
							if (l == null)
								continue;
							if (Positions.GetPosition(Core.Character.Bonnie) == 21)
							{
								if (l.RobotList == null || l.RobotList.Count == 0)
									continue;
								if (l.RobotList[0] == Core.Character.Bonnie)
								{
									if (!appeard.ContainsKey(Core.Character.Bonnie))
									{
										appeard.Add(Core.Character.Bonnie, Time.FrameCount);
										if (ScareSound != null)
											GameController.SM.PlaySound(ScareSound);
									}
									ChangeView(l.Material);
									break;
								}
							}
							else
							{
								appeard.Remove(Core.Character.Bonnie);
								if (l.RobotList != null && l.RobotList.Count > 0)
									continue;
								ChangeView(l.Material);
								break;
							}
						}
						break;
					case DoorDirection.Right:
						if (right == null || right.Count == 0)
						{
							ChangeView(def);
							break;
						}
						foreach (CameraView l in right)
						{
							if (l == null)
								continue;
							if (Positions.GetPosition(Core.Character.Chica) == 21)
							{
								if (l.RobotList == null || l.RobotList.Count == 0)
									continue;
								if (l.RobotList[0] == Core.Character.Chica)
								{
									if (!appeard.ContainsKey(Core.Character.Chica))
									{
										appeard.Add(Core.Character.Chica, Time.FrameCount);
										if (ScareSound != null)
											GameController.SM.PlaySound(ScareSound);
									}
									ChangeView(l.Material);
									break;
								}
							}
							else
							{
								appeard.Remove(Core.Character.Chica);
								if (l.RobotList != null && l.RobotList.Count > 0)
									continue;
								ChangeView(l.Material);
								break;
							}
						}
						break;
					default:
						ChangeView(def);
						break;
				}
			}
		}
	}
	public class CameraViewer : Component, ICmpUpdatable
	{
		[DontSerialize] private bool started = false;
		[DontSerialize] private static bool disabled = false;
		public static bool IsDisabled
		{
			get { return disabled; }
			set { disabled = value; }
		}
		[DontSerialize] private static bool isViewing = false;
		public static bool IsViewing
		{
			get { return isViewing; }
			set { isViewing = value; }
		}
		[DontSerialize] private static int viewNumber = 0;
		public static int ViewNumber
		{
			get { return viewNumber; }
			set { viewNumber = value; }
		}
		[DontSerialize] private static float xPos = 0;
		public static float X
		{
			get { return xPos; }
		}
		[DontSerialize] private int lastTime = 0;
		[DontSerialize] private static bool forward = true;
		public static bool IsForward
		{
			get { return forward; }
		}
		public void OnUpdate()
		{
			if (!started)
			{
				started = true;
				xPos = 0;
				disabled = false;
				forward = true;
				return;
			}
			if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.Up))
			{
				disabled = !disabled;
			}
			if (SixAM.Started)
				return;
			GameController.SM.ChangeVolume("fan_sound", IsViewing ? 20 : 80);
			TimeSpan span = Time.MainTimer;
			int seconds = (int)span.TotalSeconds;
			if (seconds - 3 >= lastTime)
			{
				forward = (xPos == 0);
			}
			if (forward && xPos < 320)
			{
				lastTime = seconds;
				xPos+= 2;
			}
			if(!forward && xPos > 0)
			{
				lastTime = seconds;
				xPos-= 2;
			}
		}
	}

	[RequiredComponent(typeof(Camera))]
	public class DisplayController : Component, ICmpUpdatable, ICmpInitializable
	{
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> FanSound { get; set; }
		[DontSerialize] private bool started = false;
		[DontSerialize] private static float direction = 0;
		public static float OfficeDirection
		{
			get { return direction; }
		}
		[DontSerialize] private static float defaultX = float.NaN;
		public static float DefaultCamX
		{
			get { return defaultX; }
		}
		[DontSerialize] public static bool movement = true;
		private void SoundLoad(object sender, SoundManager e)
		{
			if(!e.IsPlaying(FanSound))
				e.PlaySound(FanSound, true);
			SoundManager.OnLoad -= SoundLoad;
		}
		[DontSerialize] private static Camera camera = null;
		public static Camera Camera
		{
			get { return camera; }
		}
		public void OnUpdate()
		{
			if (!started)
				return;
			Vector2 cursorPos = DualityApp.Mouse.Pos;
			Vector3 camPos = camera.FocusPos;

			float half = Core.MaxWindowSize.X / 2;

			float limit = (half / 4);

			float cancelStart = half - limit;
			float cancelEnd = half + limit;

			float xPos;
			if (float.IsNaN(defaultX))
			{
				defaultX = camPos.X;
			}

			if (CameraViewer.IsViewing)
			{
				xPos = movement ? CameraViewer.X : 0;
			}
			else
			{
				xPos = direction;
			}

			if (JumpscareManager.Jumpscared && Core.SelfCharacter == Core.Character.Guard && JumpscareManager.AfterCamera)
			{
				xPos = JumpscareManager.Direction;
			}
			
			if (DualityApp.Mouse.IsAvailable && !CameraViewer.IsViewing && !CameraAnimator.IsOpening && !CameraAnimator.DisableCamera)
			{
				if (cursorPos.X < cancelStart && xPos > 0)
				{
					xPos--;
					int i = 1;
					while (cursorPos.X < cancelStart - (limit * i) && xPos > 0)
					{
						xPos -= i*4;
						i++;
					}
					direction = xPos;
					if (direction < 0)
					{
						direction = 0;
						xPos = 0;
					}
				}
				else if (cursorPos.X > cancelEnd && xPos < 320)
				{
					xPos++;
					int i = 1;
					while (cursorPos.X > cancelEnd + (limit * i) && xPos < 320)
					{
						xPos += i*4;
						i++;
					}
					direction = xPos;
					if(direction > 320)
					{
						direction = 320;
						xPos = 320;
					}
				}
			}
			if(xPos > 320)
			{
				xPos = 320;
			}
			Transform transform = this.GameObj.Transform;

			Vector3 targetPos = new Vector3(defaultX+xPos, camPos.Y, 0.0f - camera.FocusDist);
			transform.MoveTo(targetPos);

			if (SixAM.Started)
			{
				if (!SixAM.Visible)
					camera.VisibilityMask = VisibilityFlag.All;
				else
					camera.VisibilityMask = VisibilityFlag.Group4;
			}
		}

		public void OnActivate()	//																							<- OFFICE STARTUP
		{
			bool test = false;
			if(Core.SelfCharacter == Core.Character.None)
			{
				if (DualityApp.ExecEnvironment != DualityApp.ExecutionEnvironment.Editor)
				{
					Scene.SwitchTo(DualityApp.AppData.StartScene);
					return;
				} else
				{
					test = true;
					Core.SelfCharacter = Core.Character.Guard;
				}
			}
			SoundManager.OnLoad += SoundLoad;
			direction = 0;
			defaultX = Core.MaxWindowSize.X / 2;
			DoorController.LightDirection = DoorDirection.None;
			DoorController.LightFlicker = false;
			CameraViewer.IsViewing = Core.SelfCharacter != Core.Character.Guard;
			FlipButton.Disabled = Core.SelfCharacter != Core.Character.Guard;
			CameraAnimator.DisableCamera = false;

			Positions.Reset();
			Positions.SetPosition(Core.Character.Guard, 0);
			Positions.SetPosition(Core.Character.Freddy, 0);

			if(Core.SelfCharacter == Core.Character.Bonnie)
				Positions.SetPosition(Core.Character.Bonnie, 0);

			if(Core.SelfCharacter == Core.Character.Chica)
				Positions.SetPosition(Core.Character.Chica, 0);

			if(Core.SelfCharacter == Core.Character.Foxy)
				Positions.SetPosition(Core.Character.Foxy, 0);

			if (test)
			{
				//Positions.SetPosition(Core.Character.Bonnie, 22);
				Positions.SetPosition(Core.Character.Chica, 22);
			}

			if (Core.SelfCharacter == Core.Character.Foxy)
			{
				CameraViewer.ViewNumber = Positions.GetPosition(Core.Character.Foxy) <= 2 ? 2 : Positions.GetPosition(Core.Character.Foxy) < 21 ? 3 : 21;
			}
			else
			{
				CameraViewer.ViewNumber = Positions.GetPosition(Core.SelfCharacter);
			}

			List<byte> msg = new List<byte>
							{
								(byte)Core.SelfCharacter,
								(byte)Positions.GetPosition(Core.SelfCharacter)
							};
			if(Core.Client != null && Core.Client.joinedChannels.Count > 0)
				Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 25, msg.ToArray());

			MovementControl.SelfTime = MovementControl.GetRandomMoveTime(Core.SelfCharacter);

			camera = this.GameObj.GetComponent<Camera>();
			VisibilityFlag flags = VisibilityFlag.AllFlags | (VisibilityFlag.AllGroups & ~VisibilityFlag.Group4);
			camera.VisibilityMask = flags;
			GameObj.Transform.MoveTo(new Vector3(defaultX, Core.MaxWindowSize.Y/2, 0.0f - camera.FocusDist));
			if (Core.DRPC != null)
			{
				DiscordRPC.RichPresence presence = Core.DRPC.CurrentPresence;
				Core.DRPC.SetPresence(Core.BuildPresence("In Game", Core.SelfCharacter.GetStringValue(), presence.Party.ID, 5, presence.Party.Size));
			}
			FlipButton.Disabled = Core.SelfCharacter != Core.Character.Guard;
			started = true;
		}	//																														END OF OFFICE STARTUP

		public void OnDeactivate()
		{
			Core.SelfCharacter = Core.Character.None;
		}
	}
	[RequiredComponent(typeof(SpriteRenderer))]
	public class OfficeController : Component, ICmpUpdatable, ICmpInitializable
	{
		[DontSerialize] private SoundEmitter.Source source = null;
		[DontSerialize] private bool started = false;
		[DontSerialize] private SpriteRenderer renderer = null;
		private OfficeControllerValue control = new OfficeControllerValue();
		[DontSerialize] private readonly Random random = new Random();
		public OfficeControllerValue ControlValue
		{
			get { return control; }
			set
			{
				if (value == null)
					return;
				control = value;
			}
		}
		public void OnUpdate()
		{
			if(control.OpenWLight == null || control.OpenWoLight == null || control.ClosedWLight == null || control.ClosedWoLight == null || control.DoorDirection == 0)
			{
				return;
			}
			control.OpenWLight.EnsureLoaded();
			control.OpenWoLight.EnsureLoaded();
			control.ClosedWLight.EnsureLoaded();
			control.ClosedWoLight.EnsureLoaded();
			if (control.LightSound != null)
			{
				control.LightSound.EnsureLoaded();
			}
			if (control.KilledSound != null)
			{
				control.KilledSound.EnsureLoaded();
			}
			if (renderer == null)
			{
				
			}
			else
			{
				if (GameController.Power <= 0)
				{
					renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
					return;
				}
				if (!started)
				{
					started = true;
					renderer.SharedMaterial = control.OpenWoLight;
					if (control.LightSound != null)
					{
						source = GameController.SM.PlaySound(control.LightSound, true);
						source.Volume = 0;
					}
				} else
				{
					bool isopen = true;
					switch (control.DoorDirection)
					{
						case DoorDirection.Left:
							if (DoorController.LeftDoor != null)
							{
								isopen = DoorController.LeftDoor.IsOpen();
							}
							break;
						case DoorDirection.Right:
							if (DoorController.RightDoor != null)
							{
								isopen = DoorController.RightDoor.IsOpen();
							}
							break;
						default:
							break;
					}
					if(control.DoorDirection == DoorDirection.Left && Positions.GetPosition(Core.Character.Bonnie) == 22)
					{
						control.IsKilled = true;
					}
					if (control.DoorDirection == DoorDirection.Right && Positions.GetPosition(Core.Character.Chica) == 22)
					{
						control.IsKilled = true;
					}
					bool islight = DoorController.LightDirection == control.DoorDirection;
					if(islight && control.IsKilled)
					{
						DoorController.LightDirection = DoorDirection.None;
						islight = false;
					}
					if (isopen)
					{
						renderer.SharedMaterial = islight ? control.OpenWLight : control.OpenWoLight;
					} else
					{
						renderer.SharedMaterial = islight ? control.ClosedWLight : control.ClosedWoLight;
					}
					if(source != null)
					{
						DoorController.LightFlicker = random.Next(1, 10) <= 1;
						source.Volume = islight && !DoorController.LightFlicker ? 1 : 0;
					}
				}
				if (CameraAnimator.IsOpening)
				{
					DoorController.LightDirection = DoorDirection.None;
				}
				if (!CameraViewer.IsViewing)
				{
					if (SixAM.Started || GameController.Power <= 0)
						return;
					renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
					bool isDoorHit = MousePosition.InRect(control.DoorArea);
					bool isLightHit = MousePosition.InRect(control.LightArea);
					if (DualityApp.Mouse.ButtonHit(Duality.Input.MouseButton.Left) && (isDoorHit || isLightHit))
					{
						if (!control.IsKilled)
						{
							if (isDoorHit)
							{
								switch (control.DoorDirection)
								{
									case DoorDirection.Left:
										if (DoorController.LeftDoor != null)
										{
											DoorController.LeftDoor.ToggleDoor();
										}
										break;
									case DoorDirection.Right:
										if (DoorController.RightDoor != null)
										{
											DoorController.RightDoor.ToggleDoor();
										}
										break;
									default:
										break;
								}
							}
							else
							{
								if (DoorController.LightDirection == control.DoorDirection)
								{
									DoorController.LightDirection = DoorDirection.None;
								}
								else
								{
									DoorController.LightDirection = control.DoorDirection;
								}
								if (Core.SelfCharacter == Core.Character.Guard)
								{
									GameController.SendStatus();
								}
							}
						}
						else
						{
							GameController.SM.PlaySound(control.KilledSound);
						}
					}
				}
				else
				{
					renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
				}
			}
		}

		public void OnActivate()
		{
			if (renderer == null)
			{
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
			}
			control.IsKilled = false;
		}

		public void OnDeactivate()
		{
		}
	}

	public class Static : Component, ICmpUpdatable
	{
		[DontSerialize] private static int opacity = 0;
		private static int Opacity
		{
			get { return opacity; }
			set { opacity = value; }
		}
		public static int GetOpacity()
		{
			return Opacity;
		}

		[DontSerialize] private int lastTime = 0;
		[DontSerialize] private int dark = 0;
		[DontSerialize] private readonly Random rnd = new Random();
		public void OnUpdate()
		{
			bool isViewing = CameraViewer.IsViewing;
			SpriteRenderer render = this.GameObj.GetComponent<SpriteRenderer>();
			ColorRgba color = render.ColorTint;
			TimeSpan span = Time.MainTimer;
			int seconds = (int)span.TotalSeconds;
			if (seconds - 1 >= lastTime)
			{
				dark = rnd.Next(3);
				lastTime = seconds;
			}
			Opacity = 50 + rnd.Next(50) + (dark * 15);
			color.A = isViewing ? (byte)Opacity : (byte)0;
			if (CameraViewer.IsDisabled && color.A > 0)
			{
				color.A = 255;
			}
			render.ColorTint = color;
		}
	}

	public class FreddyPoster : Component, ICmpUpdatable
	{
		private ContentRef<Sound> sound = null;
		public ContentRef<Sound> NoseSound
		{
			get { return sound; }
			set { sound = value; }
		}
		private Rect rect = new Rect();
		public Rect Area
		{
			get { return rect; }
			set
			{
				if (value != null)
					rect = value;
			}
		}
		private int limit = 0;
		public void OnUpdate()
		{
			if (limit > Time.MainTimer.TotalMilliseconds)
				return;
			if (SixAM.Started || FreddyMusicbox.DarkenedOffice)
				return;
			if (MousePosition.InRect(rect))
			{
				if (DualityApp.Mouse.ButtonHit(Duality.Input.MouseButton.Left) && !CameraViewer.IsViewing)
				{
					GameController.SM.PlaySound(sound);
					limit = (int)Time.MainTimer.TotalMilliseconds + 200;
				}
			}
		}
	}

	public class ScreenText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> TextFont { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> TimeFont { get; set; }

		[DontSerialize] private static bool isDebug = false;
		public static bool IsDebug
		{
			get { return isDebug; }
		}

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.Group2;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.F5))
			{
				isDebug = !isDebug;
			}
			if (SixAM.Started)
				return;

			this.canvas.Begin(device);

			if(Core.SelfCharacter != Core.Character.Guard && Core.SelfCharacter != Core.Character.None)
			{
				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.White;
				canvas.State.TextFont = this.TextFont;
				int time = (int)Math.Round((MovementControl.NextMove - Time.GameTimer.TotalMilliseconds)/1000);
				if (GameController.Power <= 0)
					time = 999;
				string CharacterText = string.Format("Playing as: {0}", Core.SelfCharacter.GetStringValue());
				Vector2 CharacterTextSize = canvas.MeasureText(CharacterText);
				string MoveTimeText = time <= 0 ? "You can move!" : string.Format("You can move in {0} second{1}", time, time > 1 ? "s" : "");
				if((Core.SelfCharacter != Core.Character.Foxy && Positions.GetPosition(Core.SelfCharacter) >= 21) || (Core.SelfCharacter == Core.Character.Foxy && Positions.GetPosition(Core.SelfCharacter) >= 3))
				{
					MoveTimeText = "Attack in progress...";
				}
				Vector2 MoveTimeTextSize = canvas.MeasureText(MoveTimeText);

				if(time <= 0 && CameraViewer.ViewNumber == 21)
				{
					switch(Core.SelfCharacter)
					{
						case Core.Character.Chica:
						case Core.Character.Bonnie:
							Attack();
							break;
						default:
							break;
					}
				}

				canvas.DrawText(CharacterText, 24, Core.MaxWindowSize.Y - CharacterTextSize.Y - 24);
				if(GameController.Power > 0)
					canvas.DrawText(MoveTimeText, 24, Core.MaxWindowSize.Y - MoveTimeTextSize.Y - 24 - 24);
				this.canvas.End();
				this.canvas.Begin(device);
			}

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = this.TimeFont;

			string TimeText = string.Format("{0} AM", GameController.GameTime);
			Vector2 TimeTextSize = canvas.MeasureText(TimeText);
			if(!JumpscareManager.Jumpscared && GameController.Power > 0)
				canvas.DrawText(TimeText, Core.MaxWindowSize.X - TimeTextSize.X - 24, 24);

			this.canvas.End();
		}

		private void Attack()
		{
			int target = 22;
			if ((Core.SelfCharacter != Core.Character.Bonnie && GameController.Guard.RightDoorClosed) || (Core.SelfCharacter == Core.Character.Bonnie && GameController.Guard.LeftDoorClosed))
			{
				target = 1;
			}
			CameraViewer.ViewNumber = target;
			BlipAnimator.PlayBlip();
			Positions.SetPosition(Core.SelfCharacter, target);
			MovementControl.Buttons.Clear();
			MovementControl.SelfTime = MovementControl.GetRandomMoveTime(Core.SelfCharacter);
			if (Core.Client != null && Core.Client.IsConnected && Core.Client.joinedChannels.Count > 0)
			{
				List<byte> msg = new List<byte>
						{
							(byte)Core.SelfCharacter,
							(byte)target
						};
				Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 25, msg.ToArray());
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

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform))]
	public class GuardText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Font> TextFont { get; set; }

		[DontSerialize] private SpriteRenderer renderer;
		[DontSerialize] private Transform transform;

		[DontSerialize] private static bool isDebug = false;
		public static bool IsDebug
		{
			get { return isDebug; }
		}

		void ICmpRenderer.GetCullingInfo(out CullingInfo info)
		{
			info.Position = Vector3.Zero;
			info.Radius = float.MaxValue;
			info.Visibility = VisibilityFlag.Group2;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.F5))
			{
				isDebug = !isDebug;
			}

			if (renderer == null || transform == null)
				return;

			if (Core.SelfCharacter == Core.Character.Guard && !JumpscareManager.Jumpscared && !SixAM.Started && GameController.Power > 0)
			{
				renderer.ColorTint = renderer.ColorTint.WithAlpha(255);
				canvas.Begin(device);
				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.White;
				canvas.State.TextFont = TextFont;

				string PowerText = string.Format("Power left: {0}%", GameController.Power/10);
				Vector2 PowerTextSize = canvas.MeasureText(PowerText);
				string UsageText = "Usage: ";
				Vector2 UsageTextSize = canvas.MeasureText(UsageText);

				renderer.SpriteIndex = GameController.PowerUsage - 1;

				canvas.DrawText(UsageText, 34, transform.Pos.Y);
				canvas.DrawText(PowerText, 34, transform.Pos.Y - 40);
				canvas.End();
			}
			else
			{
				renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
			}
		}

		public void OnActivate()
		{
			transform = this.GameObj.Transform;
			renderer = this.GameObj.GetComponent<SpriteRenderer>();
			isDebug = Core.DEBUG;
		}

		public void OnDeactivate()
		{

		}
	}

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(Transform)), RequiredComponent(typeof(SpriteAnimator))]
	public class JumpscareManager : Component, ICmpUpdatable, ICmpInitializable
	{
		[EditorHintFlags(MemberFlags.Visible)]
		private Dictionary<Core.Character, CameraView> jumpscare { get; set; }
		[EditorHintFlags(MemberFlags.Visible)]
		private Dictionary<Core.Character, int> jumpscaretime { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> AfterJump { get; set; }
		
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> JumpscareSound { get; set; }

		[DontSerialize] private SpriteRenderer renderer;
		[DontSerialize] private Transform transform;
		[DontSerialize] private SpriteAnimator animator;

		[DontSerialize] private Core.Character killer = Core.Character.None;

		[DontSerialize] private bool finished = false;
		[DontSerialize] private bool start = false;
		[DontSerialize] private static int jumped = -1;
		public static bool Jumpscared { get { return jumped > -1; } }
		public static bool AfterCamera { get; private set; }

		public static int Direction { get; private set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private List<ContentRef<Sound>> VoiceSounds { get; set; }
		[DontSerialize] private SoundEmitter.Source VoiceSource = null;

		public void OnActivate()
		{
			killer = Core.Character.None;
			Direction = 0;
			if(Core.Client != null)
			{
				Core.Client.Event.NumberMessage += Event_NumberMessage;
			}
			AfterCamera = false;
			finished = false;
			start = false;
			jumped = -1;
			if(renderer == null || transform == null || animator == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
			}
		}

		private void Event_NumberMessage(object sender, EventNumberMessage e)
		{
			if(e.SubChannel == 27)
			{
				killer = (Core.Character)e.Message;
				jumped = (int)Time.MainTimer.TotalMilliseconds;
				if (Core.SelfCharacter == Core.Character.Guard)
				{
					if (CameraViewer.IsViewing)
					{
						AfterCamera = true;
						CameraAnimator.ForceCamera = true;
					}
					CameraAnimator.DisableCamera = true;
					BeginJumpscare(killer);
				}
				else
				{
					GameController.SM.PlaySound(JumpscareSound);
				}
			}
			if(e.SubChannel == 28 && Core.SelfCharacter != Core.Character.Guard)
			{
				finished = true;
				if (AfterJump != null)
				{
					Scene.SwitchTo(AfterJump);
				}
			}
		}

		public void OnDeactivate()
		{
			if (Core.Client != null)
			{
				Core.Client.Event.NumberMessage -= Event_NumberMessage;
			}
		}

		private void BeginJumpscare(Core.Character killer)
		{
			if (!jumpscare.ContainsKey(killer))
			{
				finished = true;
				Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 28, (int)killer);
				if (AfterJump != null)
				{
					Scene.SwitchTo(AfterJump);
				}
			}
			else
			{
				CameraView view = jumpscare[killer];
				GameController.SM.PlaySound(JumpscareSound);
				if (view.Extra > -1)
				{
					Direction = view.Extra;
				}
				else
				{
					Direction = 0;
				}
				renderer.SpriteIndex = 0;
				animator.FrameCount = view.Material.Res.MainTexture.Res.BasePixmap.Res.Atlas.Count;
				animator.AnimLoopMode = view.AnimLoopMode;
				animator.AnimDuration = view.AnimDuration;
				animator.AnimTime = 0;
				animator.Paused = false;
			}
			if(!CameraViewer.IsViewing)
				FlipButton.Disabled = true;
		}

		public void OnUpdate()
		{
			if (!start)
			{
				start = true;
				if (jumpscare != null)
				{
					foreach (Core.Character c in jumpscare.Keys)
					{
						CameraView view = jumpscare[c];
						if (view.Material != null)
						{
							view.Material.EnsureLoaded();
						}
					}
				}
			}
			if(Core.SelfCharacter != Core.Character.Guard)
			{
				int time = (int)Math.Round((MovementControl.NextMove - Time.MainTimer.TotalMilliseconds) / 1000);
				if(time <= 0 && CameraViewer.ViewNumber == 22 && !Jumpscared)
				{
					jumped = (int)Time.MainTimer.TotalMilliseconds;
					Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 27, (int)Core.SelfCharacter);
				}
				if (Positions.GetPosition(Core.Character.Freddy) == 21 && !GameController.Guard.IsViewing)
				{
					killer = Core.Character.Freddy;
					jumped = (int)Time.MainTimer.TotalMilliseconds;
				}
				if (Positions.GetPosition(Core.Character.Foxy) == 21)
				{
					killer = Core.Character.Foxy;
					jumped = (int)Time.MainTimer.TotalMilliseconds;
				}
			}
			else
			{
				if (GameController.Power <= 0)
					return;
				if (!Jumpscared)
				{
					if (Positions.GetPosition(Core.Character.Freddy) == 21 && !CameraViewer.IsViewing)
					{
						killer = Core.Character.Freddy;
						jumped = (int)Time.MainTimer.TotalMilliseconds;
						CameraAnimator.DisableCamera = true;
						BeginJumpscare(killer);
					}
					if (Positions.GetPosition(Core.Character.Foxy) == 21)
					{
						if (CameraViewer.IsViewing)
						{
							CameraAnimator.ForceCamera = true;
							AfterCamera = true;
						}
						killer = Core.Character.Foxy;
						jumped = (int)Time.MainTimer.TotalMilliseconds;
						CameraAnimator.DisableCamera = true;
						BeginJumpscare(killer);
					}
					if(CameraViewer.IsViewing)
					{
						if (killer == Core.Character.None)
						{
							if (Positions.GetPosition(Core.Character.Bonnie) == 22)
							{
								killer = Core.Character.Bonnie;
								if(VoiceSounds != null && VoiceSounds.Count > 0)
								{
									VoiceSource = GameController.SM.PlaySound(VoiceSounds[Randomizer.Random(VoiceSounds.Count-1)]);
								}
							}
							if (Positions.GetPosition(Core.Character.Chica) == 22)
							{
								killer = Core.Character.Chica;
								if(VoiceSounds != null && VoiceSounds.Count > 0)
								{
									VoiceSource = GameController.SM.PlaySound(VoiceSounds[Randomizer.Random(VoiceSounds.Count-1)]);
								}
							}
						}
					}
					else
					{
						if(killer != Core.Character.None)
						{
							AfterCamera = true;
							jumped = (int)Time.MainTimer.TotalMilliseconds;
							CameraAnimator.DisableCamera = true;
							BeginJumpscare(killer);
						}
					}
				}
				if (Jumpscared && !finished)
				{
					if (GameController.SM.IsPlaying(VoiceSource))
					{
						GameController.SM.StopSound(VoiceSource);
						VoiceSource = null;
					}
					if (!CameraViewer.IsViewing)
						FlipButton.Disabled = true;
					if (jumpscare.ContainsKey(killer))
					{
						CameraView view = jumpscare[killer];
						renderer.SharedMaterial = view.Material;
					}
					if (jumpscaretime.ContainsKey(killer))
					{
						int time = jumpscaretime[killer];
						if(jumped+(time*1000) > Time.MainTimer.TotalMilliseconds)
						{
							return;
						}
					}
					else
					{
						if(animator.IsAnimationRunning && animator.AnimLoopMode != SpriteAnimator.LoopMode.Loop)
						{
							return;
						}
					}
					finished = true;
					Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 28, (int)killer);
					if (AfterJump != null)
					{
						Scene.SwitchTo(AfterJump);
					}
				}
			}
		}
	}

	public class FoxyListener : Component, ICmpUpdatable, ICmpInitializable
	{
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> FoxyRun { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> FoxyDoorBang { get; set; }

		public void OnActivate()
		{
			if (Core.Client != null)
			{
				Core.Client.Event.NumberMessage += Event_NumberMessage;
			}
		}

		private void Event_NumberMessage(object sender, EventNumberMessage e)
		{
			if (e.SubChannel == 29 && Core.SelfCharacter != Core.Character.Guard)
			{
				Positions.SetPosition(Core.Character.Foxy, e.Message);
				if(e.Message == 4)
				{
					if (FoxyRun != null)
						GameController.SM.PlaySound(FoxyRun);
				}
				if(e.Message < 4)
				{
					if (FoxyDoorBang != null)
						GameController.SM.PlaySound(FoxyDoorBang).Volume = (40 + Randomizer.Random(50)) / 100f;
				}
				if(Core.SelfCharacter == Core.Character.Foxy)
				{
					CameraViewer.ViewNumber = Positions.GetPosition(Core.Character.Foxy) <= 2 ? 2 : Positions.GetPosition(Core.Character.Foxy) < 21 ? 3 : 21;
				}
			}
		}

		public void OnDeactivate()
		{
			if (Core.Client != null)
			{
				Core.Client.Event.NumberMessage -= Event_NumberMessage;
			}
		}

		private int attack = -1;

		public void OnUpdate()
		{
			if (Core.SelfCharacter != Core.Character.Guard)
				return;
			int foxy = Positions.GetPosition(Core.Character.Foxy);
			if(foxy > -1)
			{
				switch (foxy)
				{
					case 3:
						if(CameraViewer.ViewNumber == 3)
						{
							BlipAnimator.PlayBlip();
							attack = (int)Time.MainTimer.TotalMilliseconds;
							Positions.SetPosition(Core.Character.Foxy, 4);
							Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 29, 4);
							if (FoxyRun != null)
								GameController.SM.PlaySound(FoxyRun);
							break;
						}
						if(attack == -1)
						{
							attack = (int)Time.MainTimer.TotalMilliseconds;
						}
						if(attack + 10000 <= Time.MainTimer.TotalMilliseconds)
						{
							attack = -1;
							Positions.SetPosition(Core.Character.Foxy, DoorController.LeftDoor.IsOpen() ? 21 : Randomizer.Random(2));
							Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 29, Positions.GetPosition(Core.Character.Foxy));
							if(!DoorController.LeftDoor.IsOpen() && FoxyDoorBang != null)
								GameController.SM.PlaySound(FoxyDoorBang).Volume = (40 + Randomizer.Random(50)) / 100f;
						}
						break;
					case 4:
						if(attack + 1700 <= Time.MainTimer.TotalMilliseconds)
						{
							attack = -1;
							Positions.SetPosition(Core.Character.Foxy, DoorController.LeftDoor.IsOpen() ? 21 : Randomizer.Random(2));
							Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 29, Positions.GetPosition(Core.Character.Foxy));
							if (!DoorController.LeftDoor.IsOpen() && FoxyDoorBang != null)
								GameController.SM.PlaySound(FoxyDoorBang).Volume = (40 + Randomizer.Random(50)) / 100f;
						}
						break;
				}
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(SpriteAnimator)), RequiredComponent(typeof(Transform))]
	public class FreddyMusicbox : Component, ICmpInitializable, ICmpUpdatable
	{
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> MusicBox { get; set; }
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> LightSound { get; set; }
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> PowerDownSound { get; set; }
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> DeepSteps { get; set; }

		private SoundEmitter.Source source { get; set; }
		[DontSerialize] private bool FreddyInOffice = false;

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Material> DarkOffice { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Material> DarkOfficeFreddy { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Material> BlackScreen { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> FreddyScene { get; set; }


		[DontSerialize] private SpriteRenderer renderer;
		[DontSerialize] private Transform transform;
		[DontSerialize] private SpriteAnimator animator;

		public void OnActivate()
		{
			DarkenedOffice = false;
			FreddyInOffice = false;
			state = 0;
			PowerDown = -1;
			flash = -1;
			jump = 0;
			if(Core.Client != null)
			{
				Core.Client.Event.NumberMessage += Event_NumberMessage;
			}
			if (renderer == null || transform == null || animator == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
			}
		}

		private void Event_NumberMessage(object sender, EventNumberMessage e)
		{
			if(e.SubChannel == 30 && Core.SelfCharacter != Core.Character.Guard)
			{
				PowerDown = -1;
				state = e.Message;
				FreddyInOffice = true;
			}
		}

		public void OnDeactivate()
		{
			if (Core.Client != null)
			{
				Core.Client.Event.NumberMessage -= Event_NumberMessage;
			}
		}

		[DontSerialize] private int state = 0;
		[DontSerialize] private int PowerDown = -1;
		[DontSerialize] private int flash = -1;
		[DontSerialize] private int jump = 0;
		public static bool DarkenedOffice { get; private set; }
		public void OnUpdate()
		{
			if (MusicBox == null || DarkOffice == null || DarkOfficeFreddy == null || LightSound == null || FreddyScene == null || PowerDownSound == null || BlackScreen == null || DeepSteps == null)
				return;
			MusicBox.EnsureLoaded();
			LightSound.EnsureLoaded();
			PowerDownSound.EnsureLoaded();
			DeepSteps.EnsureLoaded();
			DarkOffice.EnsureLoaded();
			DarkOfficeFreddy.EnsureLoaded();
			BlackScreen.EnsureLoaded();
			if (GameController.Power > 0)
			{
				if (Positions.GetPosition(Core.Character.Freddy) == -1)
					return;
				if (Positions.GetPosition(Core.Character.Freddy) == 9)
				{
					if (!GameController.SM.IsPlaying(source))
					{
						source = GameController.SM.PlaySound(MusicBox);
					}
				}
				else
				{
					if (GameController.SM.IsPlaying(source))
					{
						GameController.SM.StopSound(source);
					}
					source = null;
				}
				if(source != null)
				{
					if (CameraViewer.IsViewing)
					{
						if (CameraViewer.ViewNumber == 9)
							source.Volume = 1.0f;
						else
							source.Volume = 0.5f;
					}
					else
					{
						source.Volume = 0.3f;
					}
				}
			}
			else
			{
				if(!FreddyInOffice)
				{
					if (Core.SelfCharacter == Core.Character.Guard)
					{
						if (PowerDown == -1)
						{
							renderer.SharedMaterial = DarkOffice;
							PowerDown = (int)Time.MainTimer.TotalMilliseconds;
							Timer mb = new Timer(5000);
							mb.Elapsed += (object sender, ElapsedEventArgs e) =>
							{
								if (FreddyInOffice)
								{
									mb.Stop();
									mb.Close();
									return;
								}
								FreddyInOffice = Randomizer.Random(5) + 1 == 1;
							};
							mb.AutoReset = true;
							mb.Enabled = true;
							GameController.SM.StopAllSounds();
							GameController.SM.PlaySound(PowerDownSound);
							if (CameraViewer.IsViewing)
							{
								CameraAnimator.ForceCamera = true;
							}
							if (!DoorController.LeftDoor.IsOpen())
								DoorController.LeftDoor.ToggleDoor();
							if (!DoorController.RightDoor.IsOpen())
								DoorController.RightDoor.ToggleDoor();
							DoorController.LightDirection = DoorDirection.None;
						}
						if (!CameraViewer.IsViewing)
						{
							FlipButton.Disabled = true;
						}
						if (PowerDown > -1 && PowerDown + 20000 <= Time.MainTimer.TotalMilliseconds)
						{
							FreddyInOffice = true;
						}
					}
					else
					{
						if(PowerDown == -1)
						{
							renderer.SharedMaterial = DarkOffice;
							PowerDown = (int)Time.MainTimer.TotalMilliseconds;
							GameController.SM.PlaySound(PowerDownSound);
						}
					}
					if (GameController.SM.IsPlaying(source))
					{
						GameController.SM.StopSound(source);
					}
					source = null;
				}
				else
				{
					switch (state)
					{
						case 0:
							PowerDown = -1;
							state++;
							if(Core.Client != null && Core.Client.IsConnected)
								Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 30, state);
							break;
						case 1:
							if (PowerDown == -1)
							{
								GameController.SM.PlaySound(MusicBox);
								PowerDown = (int)Time.MainTimer.TotalMilliseconds;
								if (Core.SelfCharacter == Core.Character.Guard)
								{
									Timer mb = new Timer(5000);
									mb.Elapsed += (object sender, ElapsedEventArgs e) =>
									{
										if (state != 1)
										{
											mb.Stop();
											mb.Close();
											return;
										}
										if (Randomizer.Random(5) + 1 == 1)
										{
											state++;
											if (Core.Client != null && Core.Client.IsConnected)
												Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 30, state);
											PowerDown = -1;
										}
									};
									mb.AutoReset = true;
									mb.Enabled = true;
								}

							}
							if(flash + 50 <= Time.MainTimer.TotalMilliseconds)
							{
								flash = (int)Time.MainTimer.TotalMilliseconds;
								if(Randomizer.Random(4) + 1 == 1)
								{
									renderer.SharedMaterial = DarkOffice;
								}
								else
								{
									renderer.SharedMaterial = DarkOfficeFreddy;
								}
							}
							if (PowerDown > -1 && PowerDown + 20000 <= Time.MainTimer.TotalMilliseconds && Core.SelfCharacter == Core.Character.Guard)
							{
								state++;
								if (Core.Client != null && Core.Client.IsConnected)
									Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 30, state);
								PowerDown = -1;
							}
							break;
						case 2:
							if(PowerDown == -1)
							{
								PowerDown = (int)Time.MainTimer.TotalMilliseconds;
								GameController.SM.StopAllSounds();
								source = GameController.SM.PlaySound(LightSound);
							}
							if(Randomizer.Random(2)+1 == 1)
							{
								if (source != null)
									source.Volume = 0.25f;
								renderer.SharedMaterial = DarkOffice;
							}
							else
							{
								if (source != null)
									source.Volume = 0f;
								renderer.SharedMaterial = BlackScreen;
							}
							jump--;
							if(jump < -20)
							{
								PowerDown = -1;
								state++;
								source = null;
								GameController.SM.StopAllSounds();
							}
							break;
						case 3:
							if (PowerDown == -1)
							{
								DarkenedOffice = true;
								renderer.SharedMaterial = BlackScreen;
								PowerDown = (int)Time.MainTimer.TotalMilliseconds;
								GameController.SM.PlaySound(DeepSteps);
								if(Core.SelfCharacter == Core.Character.Guard)
								{
									Timer mb = new Timer(5000);
									mb.Elapsed += (object sender, ElapsedEventArgs e) =>
									{
										if (state != 3)
										{
											mb.Stop();
											mb.Close();
											return;
										}
										if (Randomizer.Random(5) + 1 == 1)
											state++;
									};
									mb.AutoReset = true;
									mb.Enabled = true;
								}
							}
							if (PowerDown > -1 && PowerDown + 20000 <= Time.MainTimer.TotalMilliseconds && Core.SelfCharacter == Core.Character.Guard)
							{
								state++;
								PowerDown = -1;
							}
							break;
						case 4:
							if (PowerDown == -1)
							{
								PowerDown = 1;
								Scene.SwitchTo(FreddyScene);
							}
							break;
					}
				}
			}
		}
	}

	internal class MousePosition
	{
		public static bool InRect(Rect rect)
		{
			Vector2 mPos = DualityApp.Mouse.Pos;
			mPos.X += DisplayController.Camera.FocusPos.X - DisplayController.DefaultCamX;
			if (mPos.X > rect.X && mPos.Y > rect.Y && mPos.X < rect.X + rect.W && mPos.Y < rect.Y + rect.H)
			{
				return true;
			}
			return false;
		}
	}

	public class GuardStatus
	{
		/// <summary>
		/// Returns the guards current light direction
		/// <br/>
		/// 0 = not using lights, 1 = left, 2 = right
		/// </summary>
		public byte Light { get; set; }

		/// <summary>
		/// Returns wether the left door is closed
		/// </summary>
		/// <returns>
		/// true if the left door is closed, false otherwise
		/// </returns>
		public bool LeftDoorClosed { get; set; }

		/// <summary>
		/// Returns wether the right door is closed
		/// </summary>
		/// <returns>
		/// true if the right door is closed, false otherwise
		/// </returns>
		public bool RightDoorClosed { get; set; }

		/// <summary>
		/// Returns wether the guard is looking at the camera
		/// </summary>
		/// <returns>
		/// true if the guard is viewing the camera, false otherwise
		/// </returns>
		public bool IsViewing { get; set; }

		/// <summary>
		/// Returns the current camera position of the guard
		/// </summary>
		/// <remarks>
		/// This should be used while also checking if the guard is viewing the camera or not. <see cref="IsViewing"/>
		/// </remarks>
		public byte Position { get; set; }

		/// <summary>
		/// Returns wether the guard is active or not
		/// </summary>
		/// <returns>
		/// true if the guard is active, false otherwise
		/// </returns>
		public bool Active { get; set; }
	}

	public class GameController : Component, ICmpInitializable, ICmpUpdatable
	{
		public static SoundManager SM { get; private set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Scene> Menu { get; set; }

		[EditorHintFlags(MemberFlags.Visible)]
		private List<ContentRef<Sound>> MoveSounds { get; set; }

		[DontSerialize] private static int usage = 1;
		[DontSerialize] private static int power = 999;
		[DontSerialize] private Timer GuardTimer;
		[DontSerialize] private Timer PowerTimer;
		[DontSerialize] private Timer RobotTimer;

		[DontSerialize] private readonly List<int> Players = new List<int>();

		[DontSerialize] private static int time = 12;
		[DontSerialize] private static bool finished = false;
		public static bool IsFinished
		{
			get { return finished; }
		}
		public static int GameTime
		{
			get { return time; }
		}
		public static int PowerUsage
		{
			get { return usage; }
		}
		public static int Power
		{
			get { return power; }
		}
		public static GuardStatus Guard { get; private set; }

		private void SoundLoad(object sender, SoundManager e)
		{
			SM = e;
			SoundManager.OnLoad -= SoundLoad;
		}

		public static void SendStatus()
		{
			List<byte> msg = new List<byte>();
			if (!CameraViewer.IsViewing)
				msg.Add((byte)DoorController.LightDirection);
			else
				msg.Add(0);
			msg.Add((byte)(DoorController.LeftDoor.IsOpen() ? 0 : 1));
			msg.Add((byte)(DoorController.RightDoor.IsOpen() ? 0 : 1));
			msg.Add((byte)(!CameraViewer.IsViewing ? 0 : 1));
			msg.Add((byte)CameraViewer.ViewNumber);
			if(Guard.Light != (byte)DoorController.LightDirection)
			{
				byte last = Guard.Light;
				Guard.Light = (byte)DoorController.LightDirection;
				switch (Guard.Light)
				{
					case 0:
						usage--;
						break;
					case 1:
					case 2:
						if(last == 0)
							usage++;
						break;
				}
			}
			if(Guard.LeftDoorClosed != (!DoorController.LeftDoor.IsOpen()))
			{
				Guard.LeftDoorClosed = !DoorController.LeftDoor.IsOpen();
				if (Guard.LeftDoorClosed)
				{
					usage++;
				}
				else
				{
					usage--;
				}
			}
			if(Guard.RightDoorClosed != (!DoorController.RightDoor.IsOpen()))
			{
				Guard.RightDoorClosed = !DoorController.RightDoor.IsOpen();
				if (Guard.RightDoorClosed)
				{
					usage++;
				}
				else
				{
					usage--;
				}
			}
			if(Guard.IsViewing != CameraViewer.IsViewing)
			{
				Guard.IsViewing = CameraViewer.IsViewing;
				if (Guard.IsViewing)
				{
					usage++;
				}
				else
				{
					usage--;
				}
			}
			Guard.Position = (byte)CameraViewer.ViewNumber;
			Positions.SetPosition(Core.Character.Guard, Guard.Position);
			if (Core.Client == null || !Core.Client.IsConnected)
				return;
			Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 24, msg.ToArray());
		}

		public void OnActivate()
		{
			SoundManager.OnLoad += SoundLoad;
			lastmove = -1;
			finished = false;
			power = 999;
			usage = 1;
			time = 12;
			Guard = new GuardStatus();
			Players.Clear();
			if (Core.Client != null)
			{
				Core.Client.Event.BinaryMessage += Event_BinaryMessage;
				Core.Client.Event.NumberMessage += Event_NumberMessage;
				Core.Client.Event.Peer += Event_Peer;
				Core.Client.Event.Disconnect += Event_Disconnect;
				if (Core.SelfCharacter == Core.Character.Guard)
				{
					GuardTimer = new Timer(85*1000);
					GuardTimer.Elapsed += Guard_Timer;
					GuardTimer.AutoReset = true;
					GuardTimer.Enabled = true;
					PowerTimer = new Timer(1000);
					PowerTimer.Elapsed += Power_Timer;
					PowerTimer.AutoReset = true;
					PowerTimer.Enabled = true;
					List<byte> msg = new List<byte>(new byte[]{
						0,
						0,
						0,
						0,
						0
					});
					Guard.Light = 0;
					Guard.LeftDoorClosed = false;
					Guard.RightDoorClosed = false;
					Guard.IsViewing = false;
					Guard.Position = (byte)CameraViewer.ViewNumber;
					Guard.Active = true;
					if(Core.Client.IsConnected)
						Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 24, msg.ToArray());
				}
				else
				{
					if (Core.SelfCharacter == Core.Character.None || !Core.Client.IsConnected)
						return;
					RobotTimer = new Timer(2000);
					RobotTimer.Elapsed += Robot_Timer;
					RobotTimer.AutoReset = true;
					RobotTimer.Enabled = true;
					Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 23, (int)Core.SelfCharacter);
				}
			}
		}

		[DontSerialize] private bool disconnected = false;
		private void Event_Disconnect(object sender, EventDisconnect e)
		{
			disconnected = true;
			Core.LeaveReason = "Disconnected from the server";
			if (Menu != null)
				Scene.SwitchTo(Menu);
		}

		private void Robot_Timer(object sender, ElapsedEventArgs e)
		{
			if (!Guard.Active)
			{
				Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name, 23, (int)Core.SelfCharacter);
			}
			else
			{
				RobotTimer.Enabled = false;
			}
		}

		private void Event_Peer(object sender, EventPeer e)
		{
			if(e.Action == EventPeer.PeerAction.Left)
			{
				if (finished)
					return;
				Core.Character c = Positions.GetUserCharacter(e.PeerID);
				if (c == Core.Character.None)
					return;
				if(c != Core.Character.Guard)
				{
					Players.Remove(e.PeerID);
					Positions.SetUser(c, -1);
					Positions.SetPosition(c, -1);
					if(Players.Count == 0)
					{
						finished = true;
						Core.LeaveReason = "Game ended due to all players leaving";
						Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
						if (Menu != null)
							Scene.SwitchTo(Menu);
					}
				}
				else
				{
					finished = true;
					Core.LeaveReason = "Game ended due to the night guard leaving";
					Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
					if (Menu != null)
						Scene.SwitchTo(Menu);
				}
			}
		}

		private void Power_Timer(object sender, ElapsedEventArgs e)
		{
			if (finished)
			{
				List<byte> m = new List<byte>();
				m.Add(0);
				m.AddRange(BinaryData.GetData(power));
				Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 26, m.ToArray());
				PowerTimer.Enabled = false;
				return;
			}
			if(power > 0)
				power -= usage;
			
			if(power <= 0)
			{
				finished = true;
			}
			List<byte> msg = new List<byte>();
			msg.Add(0);
			msg.AddRange(BinaryData.GetData(power));
			Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 26, msg.ToArray(),true);
		}

		private void Guard_Timer(object sender, ElapsedEventArgs e)
		{
			switch (time)
			{
				case 12:
					time = 1;
					break;
				case 5:
					finished = true;
					time++;
					GuardTimer.Enabled = false;
					break;
				default:
					time++;
					break;
			}
			List<byte> msg = new List<byte>();
			msg.Add(1);
			msg.Add((byte)time);
			Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 26, msg.ToArray());
		}

		private void Event_NumberMessage(object sender, EventNumberMessage e)
		{
			if(e.SubChannel == 23)
			{
				Players.Add(e.PeerID);
				if(Core.SelfCharacter == Core.Character.Guard)
					SendStatus();
				else
				{
					List<byte> msg = new List<byte>
							{
								(byte)Core.SelfCharacter,
								(byte)Positions.GetPosition(Core.SelfCharacter)
							};
					Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 25, msg.ToArray());
					Positions.SetUser((Core.Character)e.Message, e.PeerID);
				}
			}
		}

		[DontSerialize] private int lastmove = -1;
		[DontSerialize] private SoundEmitter.Source movesource = null;

		private bool IsViewingFoxy()
		{
			int foxy = Positions.GetPosition(Core.Character.Foxy);
			return foxy <= 2 ? CameraViewer.ViewNumber == 2 : foxy < 21 && CameraViewer.ViewNumber == 3;
		}

		private void Event_BinaryMessage(object sender, EventBinaryMessage e)
		{
			if(e.SubChannel == 24 && Core.SelfCharacter != Core.Character.Guard)
			{
				Positions.SetUser(Core.Character.Guard, e.PeerID);
				BinaryReader reader = new BinaryReader(e.Message);
				Guard.Light = reader.ReadByte();
				Guard.LeftDoorClosed = reader.ReadByte() == 1;
				Guard.RightDoorClosed = reader.ReadByte() == 1;
				Guard.IsViewing = reader.ReadByte() == 1;
				Guard.Position = reader.ReadByte();
				if (!Guard.Active)
				{
					List<byte> msg = new List<byte>
							{
								(byte)Core.SelfCharacter,
								(byte)Positions.GetPosition(Core.SelfCharacter)
							};
					Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 25, msg.ToArray());
				}
				Guard.Active = true;
			}
			if(e.SubChannel == 26 && Core.SelfCharacter != Core.Character.Guard)
			{
				BinaryReader reader = new BinaryReader(e.Message);
				byte type = reader.ReadByte();
				switch (type)
				{
					case 0:
						power = reader.ReadInt();
						break;
					case 1:
						time = reader.ReadByte();
						break;
				}
				if(power <= 0)
				{
					finished = true;
				}
				if(time == 6)
				{
					finished = true;
				}
			}
			if (e.SubChannel == 25)
			{
				BinaryReader reader = new BinaryReader(e.Message);
				byte charbyte = reader.ReadByte();
				Core.Character character = (Core.Character)charbyte;
				byte position = reader.ReadByte();
				if (Core.SelfCharacter == Core.Character.Guard && CameraViewer.IsViewing && lastmove == -1)
				{
					if(position == CameraViewer.ViewNumber || (character != Core.Character.Foxy && Positions.GetPosition(character) == CameraViewer.ViewNumber) || (character == Core.Character.Foxy && IsViewingFoxy()))
					{
						CameraViewer.IsDisabled = true;
						lastmove = (int)Time.MainTimer.TotalMilliseconds;
						if(MoveSounds != null && MoveSounds.Count > 0)
						{
							movesource = SM.PlaySound(MoveSounds[new Random().Next(MoveSounds.Count)]);
						}
					}
				}
				Positions.SetPosition(character, position);
				Positions.SetUser(character, e.PeerID);
				if (!Players.Contains(e.PeerID))
					Players.Add(e.PeerID);
			}
		}

		public void OnDeactivate()
		{
			if (GuardTimer != null)
				GuardTimer.Close();

			if (PowerTimer != null)
				PowerTimer.Close();

			if (RobotTimer != null)
				RobotTimer.Close();

			if (Core.Client != null)
			{
				Core.Client.Event.BinaryMessage -= Event_BinaryMessage;
				Core.Client.Event.NumberMessage -= Event_NumberMessage;
				Core.Client.Event.Peer -= Event_Peer;
				Core.Client.Event.Disconnect -= Event_Disconnect;
			}
			if (disconnected)
			{
				Core.Reset();
				disconnected = false;
			}
		}

		public void OnUpdate()
		{
			if (Core.SelfCharacter == Core.Character.Guard)
			{
				if (JumpscareManager.Jumpscared)
					finished = true;
				if (DualityApp.Keyboard.KeyPressed(Duality.Input.Key.C))
				{
					if (DualityApp.Keyboard.KeyPressed(Duality.Input.Key.T))
					{
						if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.Number1))
						{
							if (time == 5)
								return;
							GuardTimer.Stop();
							GuardTimer.Start();
							if (time == 12)
								time = 1;
							else
								time++;
							List<byte> msg = new List<byte>();
							msg.Add(1);
							msg.Add((byte)time);
							Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 26, msg.ToArray());
						}
						if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.Number2))
						{
							if (time == 12)
								return;
							GuardTimer.Stop();
							GuardTimer.Start();
							if (time == 1)
								time = 12;
							else
								time--;
							List<byte> msg = new List<byte>();
							msg.Add(1);
							msg.Add((byte)time);
							Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 26, msg.ToArray());
						}
						if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.N))
						{
							GuardTimer.Stop();
							GuardTimer.Interval = 1000;
							GuardTimer.Start();
						}
					}
					if (DualityApp.Keyboard.KeyPressed(Duality.Input.Key.P))
					{
						if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.N))
						{
							power = 5;
						}
					}
				}
				if(lastmove > -1)
				{
					if(movesource != null)
					{
						if (!SM.IsPlaying(movesource))
							movesource = null;
					}
					else
					{
						CameraViewer.IsDisabled = false;
						lastmove = -1;
					}
				}
			}
			if (SixAM.Finished)
			{
				Core.Client.LeaveChannel(Core.Client.joinedChannels[0]);
				if (Menu != null)
					Scene.SwitchTo(Menu);
			}
		}
	}

	internal class GameObjectData
	{
		public GameObject GameObj { get; private set; }
		public SpriteRenderer Renderer { get; private set; }
		public GameObjectData(GameObject gameobj)
		{
			GameObj = gameobj;
			if(GameObj == null)
				throw new ArgumentNullException("GameObj");
			Renderer = GameObj.GetComponent<SpriteRenderer>();
		}
	}

	public class SixAM : Component, ICmpInitializable, ICmpUpdatable
	{
		public static bool Visible { get; private set; }
		public static bool Finished { get; private set; }
		public static bool Started { get { return begin; } }

		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> SixAMSound { get; set; }
		[EditorHintFlags(MemberFlags.Visible)]
		private ContentRef<Sound> ChildrenSound { get; set; }
		[DontSerialize] private bool children = false;

		[DontSerialize] private GameObjectData BG = null;
		[DontSerialize] private GameObjectData NumFive = null;
		[DontSerialize] private GameObjectData NumSix = null;
		[DontSerialize] private GameObjectData BlackUp = null;
		[DontSerialize] private GameObjectData BlackDown = null;
		[DontSerialize] private GameObjectData AM = null;
		[DontSerialize] private int alpha = 0;
		[DontSerialize] private int next = 0;
		[DontSerialize] private static bool begin = false;
		[DontSerialize] private bool docheck = true;

		private void DataCheck()
		{
			if (BG == null)
			{
				try
				{
					BG = new GameObjectData(GameObj.GetChildByName("BG"));
					BG.Renderer.ColorTint = BG.Renderer.ColorTint.WithAlpha(0);
					docheck = false;
				}
				catch (Exception) {
					docheck = true;
				}
			}
			if (NumFive == null)
			{
				try
				{
					NumFive = new GameObjectData(GameObj.GetChildByName("5"));
					NumFive.Renderer.ColorTint = NumFive.Renderer.ColorTint.WithAlpha(0);
					docheck = false;
				}
				catch (Exception)
				{
					docheck = true;
				}
			}
			if (NumSix == null)
			{
				try
				{
					NumSix = new GameObjectData(GameObj.GetChildByName("6"));
					NumSix.Renderer.ColorTint = NumSix.Renderer.ColorTint.WithAlpha(0);
					docheck = false;
				}
				catch (Exception)
				{
					docheck = true;
				}
			}
			if (BlackUp == null)
			{
				try
				{
					BlackUp = new GameObjectData(GameObj.GetChildByName("BlackUp"));
					BlackUp.Renderer.ColorTint = BlackUp.Renderer.ColorTint.WithAlpha(0);
					docheck = false;
				}
				catch (Exception)
				{
					docheck = true;
				}
			}
			if (BlackDown == null)
			{
				try
				{
					BlackDown = new GameObjectData(GameObj.GetChildByName("BlackDown"));
					BlackDown.Renderer.ColorTint = BlackDown.Renderer.ColorTint.WithAlpha(0);
					docheck = false;
				}
				catch (Exception)
				{
					docheck = true;
				}
			}
			if (AM == null)
			{
				try
				{
					AM = new GameObjectData(GameObj.GetChildByName("AM"));
					AM.Renderer.ColorTint = AM.Renderer.ColorTint.WithAlpha(0);
					docheck = false;
				}
				catch (Exception)
				{
					docheck = true;
				}
			}
		}

		public void OnActivate()
		{
			docheck = true;
			Visible = false;
			Finished = false;
			begin = false;
			children = false;
			alpha = 0;
			next = 0;
		}

		public void OnDeactivate()
		{
			AM = null;
			BG = null;
			NumFive = null;
			NumSix = null;
			BlackUp = null;
			BlackDown = null;
		}

		public void OnUpdate()
		{
			if(GameController.GameTime == 6)
			{
				if (docheck)
					DataCheck();
				if (Finished)
					return;
				if(AM.Renderer.ColorTint.A < 255)
				{
					if (!begin)
					{
						GameController.SM.StopAllSounds();
						begin = true;
						if(SixAMSound != null)
						{
							GameController.SM.PlaySound(SixAMSound);
						}
						CameraAnimator.DisableCamera = true;
						Vector3 pos = NumFive.GameObj.Transform.Pos;
						pos.Y = 0;
						NumFive.GameObj.Transform.MoveTo(pos);
						NumSix.GameObj.Transform.MoveTo(pos);
					}
					if (next == 0)
					{
						alpha+=2;
						if (alpha > 255)
							alpha = 255;
						BG.Renderer.ColorTint = BG.Renderer.ColorTint.WithAlpha((byte)alpha);
						NumFive.Renderer.ColorTint = NumFive.Renderer.ColorTint.WithAlpha((byte)alpha);
						AM.Renderer.ColorTint = AM.Renderer.ColorTint.WithAlpha((byte)alpha);
					}
					else
					{
						alpha--;
						if (alpha < 0)
							alpha = 0;
						NumSix.Renderer.ColorTint = NumSix.Renderer.ColorTint.WithAlpha((byte)alpha);
						AM.Renderer.ColorTint = AM.Renderer.ColorTint.WithAlpha((byte)alpha);
						Finished = alpha == 0;
					}
				}
				else
				{
					Visible = true;
					NumSix.Renderer.ColorTint = NumSix.Renderer.ColorTint.WithAlpha(255);
					BlackUp.Renderer.ColorTint = BlackUp.Renderer.ColorTint.WithAlpha(255);
					BlackDown.Renderer.ColorTint = BlackDown.Renderer.ColorTint.WithAlpha(255);
					if (NumFive.GameObj.Transform.Pos.Y > -110)
					{
						Vector3 pos = NumFive.GameObj.Transform.Pos;
						pos.Y--;
						NumFive.GameObj.Transform.MoveTo(pos);
						NumSix.GameObj.Transform.MoveTo(pos);
					}
					else
					{
						if (next < 200)
						{
							if (!children)
							{
								if (ChildrenSound != null)
									GameController.SM.PlaySound(ChildrenSound);
								NumFive.Renderer.ColorTint = NumFive.Renderer.ColorTint.WithAlpha(0);
								BlackUp.Renderer.ColorTint = BlackUp.Renderer.ColorTint.WithAlpha(0);
								BlackDown.Renderer.ColorTint = BlackDown.Renderer.ColorTint.WithAlpha(0);
								children = true;
							}
							next++;
						}
						else
						{
							alpha--;
							NumSix.Renderer.ColorTint = NumSix.Renderer.ColorTint.WithAlpha((byte)alpha);
							AM.Renderer.ColorTint = AM.Renderer.ColorTint.WithAlpha((byte)alpha);
						}
					}
				}
			}
		}
	}
}
