
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
		private SpriteRenderer render;
		public void OnUpdate()
		{
			if (render == null)
			{
				render = this.GameObj.GetComponent<SpriteRenderer>();
			}
			else
			{
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
	public class DisabledCamera : Component, ICmpUpdatable
	{
		private SpriteRenderer render;
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
		private static bool play = false;
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
		private static SpriteRenderer renderer;
		private SpriteAnimator animator;
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
						SoundManager.PlaySound(BlipSound, false);
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
		public static bool Disabled = true;
		private SpriteRenderer renderer;
		public void OnUpdate()
		{
			if (renderer == null)
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
			else
			{
				ColorRgba color = renderer.ColorTint;
				color.A = (byte)(Disabled ? 0 : 255);
				renderer.ColorTint = color;
			}
		}
	}

	[RequiredComponent(typeof(SpriteRenderer)),RequiredComponent(typeof(SpriteAnimator))]
	public class CameraAnimator : Component, ICmpUpdatable
	{
		private static bool force = false;
		public static bool ForceCamera
		{
			get { return force; }
			set { force = value; }
		}
		private static bool disable = false;
		public static bool DisableCamera
		{
			get { return disable; }
			set { disable = value; }
		}
		private static bool open;
		public static bool IsOpening
		{
			get { return open; }
		}
		private static bool close;
		public static bool IsClosing
		{
			get { return close; }
		}
		private bool hover = false;
		private SpriteRenderer renderer;
		private SpriteAnimator animator;
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
			if(renderer == null)
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
			if(animator == null)
				animator = this.GameObj.GetComponent<SpriteAnimator>();
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
							SoundManager.StopSound(up_source);
							up_source = null;
						}
						if (down_sound != null)
						{
							down_source = SoundManager.PlaySound(down_sound, false);
						}
					} else
					{
						if (up_sound != null)
						{
							up_source = SoundManager.PlaySound(up_sound, false);
						}
						if (down_source != null)
						{
							SoundManager.StopSound(down_source);
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
	public class DoorAnimator : Component, ICmpUpdatable
	{
		private DoorDirection direction = DoorDirection.None;
		public DoorDirection DoorDirection
		{
			get { return direction; }
			set { direction = value; }
		}
		private bool anim = false;
		/*
		 * 0 => open
		 * 1 => closing
		 * 2 => closed
		 * 3 => opening
		 */
		private int state = 0;
		private Transform transform = null;
		private SpriteRenderer renderer = null;
		private SpriteAnimator animator = null;
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
						SoundManager.PlaySound(sound, false);
					}
					break;
				default:
					break;
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
			
			if(direction == DoorDirection.Left)
			{
				if(DoorController.LeftDoor == null)
					DoorController.LeftDoor = this;
			}
			if (direction == DoorDirection.Right)
			{
				if(DoorController.RightDoor == null)
					DoorController.RightDoor = this;
			}
			if (renderer == null || transform == null || animator == null)
			{
				transform = this.GameObj.Transform;
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				animator = this.GameObj.GetComponent<SpriteAnimator>();
				state = 0;
				open.EnsureLoaded();
				opening.EnsureLoaded();
				close.EnsureLoaded();
				closing.EnsureLoaded();
				if (sound != null)
				{
					sound.EnsureLoaded();
				}
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
	}
	[RequiredComponent(typeof(SpriteRenderer))]
	public class CameraButtonText : Component, ICmpUpdatable
	{
		private SpriteRenderer renderer = null;
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
						renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
					}
				}
			}
		}
	}
	[RequiredComponent(typeof(SpriteRenderer)), RequiredComponent(typeof(SpriteAnimator)), RequiredComponent(typeof(Transform))]
	public class CameraButton : Component, ICmpUpdatable
	{
		private Transform transform = null;
		private SpriteRenderer renderer = null;
		private SpriteAnimator animator = null;
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
						renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
					}
				}
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
						Positions.SetPosition(Core.SelfCharacter, ViewNumber);
						MovementControl.Buttons.Clear();
						MovementControl.SelfTime = MovementControl.GetRandomMoveTime(Core.SelfCharacter);
						if(Core.Client != null && Core.Client.IsConnected && Core.Client.joinedChannels.Count > 0)
						{
							List<byte> msg = new List<byte>
							{
								(byte)Core.SelfCharacter,
								(byte)ViewNumber
							};
							Core.Client.SendBinaryChannelMessage(Core.Client.joinedChannels[0].Name, 25, msg.ToArray());
						}
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
				nextmove = (int)(Time.MainTimer.TotalMilliseconds + (time * 1000));
			}
		}
		private static int time = -1;
		public static int NextMove
		{
			get { return nextmove; }
		}
		private static int nextmove = -1;
		private static Dictionary<Core.Character, List<Movement>> check = null;
		private static Dictionary<Core.Character, MoveTime> times = null;
		public static readonly List<int> Buttons = new List<int>();
		public static bool IsValid(int from, int to)
		{
			if (Core.SelfCharacter == Core.Character.Guard)
			{
				return true;
			}
			bool allow = (int)Math.Round((NextMove - Time.MainTimer.TotalMilliseconds) / 1000) <= 0;
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
		private static Random random = null;
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
			check = movements;
			times = mt;
			SelfTime = GetRandomMoveTime(Core.SelfCharacter);
			if(Core.Client != null)
			{
				Core.Client.Event.BinaryMessage += Event_BinaryMessage;
			}
			if (Core.SelfCharacter == Core.Character.Guard && Buttons.Count == 0)
			{
				Buttons.Add(-1);
			}
		}

		private void Event_BinaryMessage(object sender, EventBinaryMessage e)
		{
			if (e.Message == null)
				return;
			if(e.SubChannel == 25)
			{
				BinaryReader reader = new BinaryReader(e.Message);
				byte charbyte = reader.ReadByte();
				Core.Character character = (Core.Character)charbyte;
				byte position = reader.ReadByte();
				Positions.SetPosition(character, position);
			}
		}

		public void OnDeactivate()
		{
			random = null;
			check = null;
			times = null;
			if (Core.Client != null)
			{
				Core.Client.Event.BinaryMessage -= Event_BinaryMessage;
			}
		}

		public void OnUpdate()
		{
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
		private static Dictionary<Core.Character,int> pos = new Dictionary<Core.Character,int>();
		private static Dictionary<int, List<Core.Character>> cams = new Dictionary<int, List<Core.Character>>();
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
			pos[robot] = value;
			if (robot != Core.Character.Foxy && robot != Core.Character.Guard)
			{
				if (!cams.ContainsKey(value))
				{
					cams[value] = new List<Core.Character>() { robot };
				}
				else
				{
					List<Core.Character> characters = new List<Core.Character>(cams[value]);
					characters.Add(robot);
					Utilities.Logger.Write("ADD - There are {0} robots on cam {1}",characters.Count,value);
					cams[value] = characters;
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
		public static void Reset()
		{
			pos = new Dictionary<Core.Character, int>();
			cams = new Dictionary<int, List<Core.Character>>();
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
		private Transform transform = null;
		private SpriteRenderer renderer = null;
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
		private static bool random = false;
		public static bool IsRandom
		{
			get { return random; }
		}
		private int lastTime = 0;
		private Transform transform = null;
		private SpriteRenderer renderer = null;
		private SpriteAnimator animator = null;
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
							if (random && foxy != 3)
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
				TimeSpan span = Time.MainTimer;
				int seconds = (int)span.TotalSeconds;
				if (lastTime == seconds-1 || lastTime == 0)
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
		private bool startup = false;
		private Transform transform = null;
		private SpriteRenderer renderer = null;
		private SpriteAnimator animator = null;
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
			}
			else
			{
				if (!startup)
				{
					startup = true;
					ChangeView(def);
				}
				if (CameraViewer.IsViewing && Positions.GetPosition(Core.SelfCharacter) < 21)
				{
					return;
				}
				DoorDirection dir = Core.SelfCharacter == Core.Character.Guard ? DoorController.LightDirection : Core.SelfCharacter == Core.Character.Bonnie ? DoorDirection.Left : DoorDirection.Right;
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
									ChangeView(l.Material);
									break;
								}
							}
							else
							{
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
									ChangeView(l.Material);
									break;
								}
							}
							else
							{
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
		private bool started = false;
		private static bool disabled = false;
		public static bool IsDisabled
		{
			get { return disabled; }
			set { disabled = value; }
		}
		private static bool isViewing = false;
		public static bool IsViewing
		{
			get { return isViewing; }
			set { isViewing = value; }
		}
		private static int viewNumber = 0;
		public static int ViewNumber
		{
			get { return viewNumber; }
			set { viewNumber = value; }
		}
		private static float xPos = 0;
		public static float X
		{
			get { return xPos; }
		}
		private int lastTime = 0;
		private static bool forward = true;
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
			SoundManager.ChangeVolume("fan_sound", IsViewing ? 20 : 80);
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
		private bool started = false;
		private static float direction = 0;
		public static float OfficeDirection
		{
			get { return direction; }
		}
		private static float defaultX = float.NaN;
		public static float DefaultCamX
		{
			get { return defaultX; }
		}
		public static bool movement = true;
		private void SoundLoad(object sender, EventArgs args)
		{
			SoundManager.ToggleSound("fan_sound", true);
			SoundManager.OnLoad -= SoundLoad;
		}
		private static Camera camera = null;
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

			float half = DualityApp.WindowSize.X / 2;

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

			if (DualityApp.Mouse.IsAvailable && !CameraViewer.IsViewing && !CameraAnimator.IsOpening)
			{
				if (cursorPos.X < cancelStart && xPos > 0)
				{
					xPos--;
					int i = 1;
					while (cursorPos.X < cancelStart - (limit * i) && xPos > 0)
					{
						xPos -= i*2;
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
						xPos += i*2;
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
			Transform transform = this.GameObj.Transform;

			Vector3 targetPos = new Vector3(defaultX+xPos, camPos.Y, 0.0f - camera.FocusDist);
			transform.MoveTo(targetPos);
		}

		public void OnActivate()	// OFFICE STARTUP
		{
			if(Core.SelfCharacter == Core.Character.None)
			{
				if (DualityApp.ExecEnvironment != DualityApp.ExecutionEnvironment.Editor)
				{
					Scene.SwitchTo(DualityApp.AppData.StartScene);
					return;
				} else
				{
					Core.SelfCharacter = Core.Character.Freddy;
				}
			}
			direction = 0;
			defaultX = float.NaN;
			DoorController.LightDirection = DoorDirection.None;
			DoorController.LightFlicker = false;
			DoorController.LeftDoor = null;
			DoorController.RightDoor = null;
			CameraViewer.IsViewing = Core.SelfCharacter != Core.Character.Guard;
			Positions.Reset();
			Positions.SetPosition(Core.Character.Guard, 0);
			Positions.SetPosition(Core.Character.Freddy, 0);
			Positions.SetPosition(Core.Character.Bonnie, 0);
			Positions.SetPosition(Core.Character.Chica, 0);
			Positions.SetPosition(Core.Character.Foxy, 0);
			if(Core.SelfCharacter == Core.Character.Foxy)
			{
				CameraViewer.ViewNumber = Positions.GetPosition(Core.Character.Foxy) <= 2 ? 2 : Positions.GetPosition(Core.Character.Foxy) < 5 ? 3 : 21;
			}
			else
			{
				CameraViewer.ViewNumber = Positions.GetPosition(Core.SelfCharacter);
			}
			camera = this.GameObj.GetComponent<Camera>();
			SoundManager.OnLoad += SoundLoad;
			if (Core.DRPC != null)
			{
				DiscordRPC.RichPresence presence = Core.DRPC.CurrentPresence;
				Core.DRPC.SetPresence(Core.BuildPresence("In Game", Core.CharacterName[(int)Core.SelfCharacter], presence.Party.ID, 5, presence.Party.Size));
			}
			FlipButton.Disabled = Core.SelfCharacter != Core.Character.Guard;
			started = true;
		}

		public void OnDeactivate()
		{
			if(Core.Client != null && Core.Client.IsConnected)
			{
				if(!GameController.IsFinished)
					Core.Client.SendNumberChannelMessage(Core.Client.joinedChannels[0].Name,26,(byte)Core.SelfCharacter);
			}
			Core.SelfCharacter = Core.Character.None;
		}
	}
	[RequiredComponent(typeof(SpriteRenderer))]
	public class OfficeController : Component, ICmpUpdatable
	{
		private SoundEmitter.Source source = null;
		private bool started = false;
		private SpriteRenderer renderer = null;
		private OfficeControllerValue control = new OfficeControllerValue();
		private readonly Random random = new Random();
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
			if (renderer == null)
			{
				renderer = this.GameObj.GetComponent<SpriteRenderer>();
				control.OpenWLight.EnsureLoaded();
				control.OpenWoLight.EnsureLoaded();
				control.ClosedWLight.EnsureLoaded();
				control.ClosedWoLight.EnsureLoaded();
				if(control.LightSound != null)
				{
					control.LightSound.EnsureLoaded();
				}
				if(control.KilledSound != null)
				{
					control.KilledSound.EnsureLoaded();
				}
			}
			else
			{
				if (!started)
				{
					started = true;
					renderer.SharedMaterial = control.OpenWoLight;
					if (control.LightSound != null)
					{
						source = SoundManager.PlaySound(control.LightSound, true);
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
							}
						}
						else
						{
							SoundManager.PlaySound(control.KilledSound);
						}
					}
				}
				else
				{
					renderer.ColorTint = renderer.ColorTint.WithAlpha(0);
				}
			}
		}
	}

	public class Static : Component, ICmpUpdatable
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
		private int dark = 0;
		private readonly Random rnd = new Random();
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
			if (MousePosition.InRect(rect))
			{
				if (DualityApp.Mouse.ButtonHit(Duality.Input.MouseButton.Left) && !CameraViewer.IsViewing)
				{
					SoundManager.PlaySound(sound);
					limit = (int)Time.MainTimer.TotalMilliseconds + 200;
				}
			}
		}
	}

	public class ScreenText : Component, ICmpRenderer, ICmpInitializable
	{
		[DontSerialize] private readonly Canvas canvas = new Canvas();

		private ContentRef<Font> rfont = null;
		public ContentRef<Font> RobotFont
		{
			get { return this.rfont; }
			set { this.rfont = value; }
		}
		
		private ContentRef<Font> tfont = null;
		public ContentRef<Font> TimeFont
		{
			get { return this.tfont; }
			set { this.tfont = value; }
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
			info.Visibility = VisibilityFlag.Group2;
		}
		void ICmpRenderer.Draw(IDrawDevice device)
		{
			if (DualityApp.Keyboard.KeyHit(Duality.Input.Key.F5))
			{
				isDebug = !isDebug;
			}
			this.canvas.Begin(device);

			if(Core.SelfCharacter != Core.Character.Guard && Core.SelfCharacter != Core.Character.None)
			{
				canvas.State.SetMaterial(DrawTechnique.Mask);
				canvas.State.ColorTint = ColorRgba.White;
				canvas.State.TextFont = this.rfont;
				int time = (int)Math.Round((MovementControl.NextMove - Time.MainTimer.TotalMilliseconds)/1000);
				string CharacterText = string.Format("Playing as: {0}", Core.CharacterName[(int)Core.SelfCharacter]);
				Vector2 CharacterTextSize = canvas.MeasureText(CharacterText);
				string MoveTimeText = time <= 0 ? "You can move!" : string.Format("You can move in {0} second{1}", time, time > 1 ? "s" : "");
				Vector2 MoveTimeTextSize = canvas.MeasureText(MoveTimeText);

				canvas.DrawText(CharacterText, 24, DualityApp.WindowSize.Y - CharacterTextSize.Y - 24);
				canvas.DrawText(MoveTimeText, 24, DualityApp.WindowSize.Y - MoveTimeTextSize.Y - 24 - 24);
				this.canvas.End();
				this.canvas.Begin(device);
			}

			canvas.State.SetMaterial(DrawTechnique.Mask);
			canvas.State.ColorTint = ColorRgba.White;
			canvas.State.TextFont = this.tfont;

			string TimeText = string.Format("{0} AM", GameController.GameTime);
			Vector2 TimeTextSize = canvas.MeasureText(TimeText);
			canvas.DrawText(TimeText, DualityApp.WindowSize.X - TimeTextSize.X - 24, 24);

			this.canvas.End();
		}

		public void OnActivate()
		{
			isDebug = Core.DEBUG;
		}

		public void OnDeactivate()
		{

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

	internal class GameController
	{
		private static int time = 12;
		private static bool finished = false;
		public static bool IsFinished
		{
			get { return finished; }
		}
		public static int GameTime
		{
			get { return time; }
		}
	}
}
