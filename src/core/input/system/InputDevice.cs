using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Otiose.Input
{
    public class InputDevice
    {
        public static readonly  InputDevice Null = new InputDevice("Null");
        internal int SortOrder = int.MaxValue;

        public string Name { get; protected set; }
        public string Meta { get; protected set; }

        public ulong LastChangeTick { get; protected set; }

        public InputControl[] Controls { get; protected set; }

        public OneAxisInputControl LeftStickX { get; protected set; }
        public OneAxisInputControl LeftStickY { get; protected set; }
        public TwoAxisInputControl LeftStick { get; protected set; }

        public OneAxisInputControl RightStickX { get; protected set; }
        public OneAxisInputControl RightStickY { get; protected set; }
        public TwoAxisInputControl RightStick { get; protected set; }

        public OneAxisInputControl DPadX { get; protected set; }
        public OneAxisInputControl DPadY { get; protected set; }
        public TwoAxisInputControl DPad { get; protected set; }

        public InputControl Command { get; protected set; }

        public bool IsAttached { get; internal set; }

        internal bool RawSticks { get; set; }

        public readonly Guid Guid;


        public InputDevice(string name)
        {
            Name = name;
            Meta = "";
            Guid = Guid.NewGuid();
            
            LastChangeTick = 0;

            const int numInputControlTypes = (int)InputControlType.Count + 1;
            Controls = new InputControl[numInputControlTypes];

            LeftStickX = new OneAxisInputControl();
            LeftStickY = new OneAxisInputControl();
            LeftStick = new TwoAxisInputControl();

            RightStickX = new OneAxisInputControl();
            RightStickY = new OneAxisInputControl();
            RightStick = new TwoAxisInputControl();

            DPadX = new OneAxisInputControl();
            DPadY = new OneAxisInputControl();
            DPad = new TwoAxisInputControl();

            Command = AddControl(InputControlType.Command, "Command");
//            AddControl(InputControlType.Action1, "Action1");
        }


        public bool HasControl(InputControlType inputControlType)
        {
            return Controls[(int)inputControlType] != null;
        }


        public InputControl GetControl(InputControlType inputControlType)
        {
            var control = Controls[(int)inputControlType];
            return control ?? InputControl.Null;
        }


        // Warning: this is super inefficient. Don't use it unless you have to, m'kay?
        public static InputControlType GetInputControlTypeByName(string inputControlName)
        {
            return (InputControlType)Enum.Parse(typeof(InputControlType), inputControlName);
        }


        // Warning: this is super inefficient. Don't use it unless you have to, m'kay?
        public InputControl GetControlByName(string inputControlName)
        {
            var inputControlType = GetInputControlTypeByName(inputControlName);
            return GetControl(inputControlType);
        }


        public InputControl AddControl(InputControlType inputControlType, string handle)
        {
            var inputControl = new InputControl(handle, inputControlType);
            Controls[(int)inputControlType] = inputControl;
            return inputControl;
        }


        public InputControl AddControl(InputControlType inputControlType, string handle, float lowerDeadZone, float upperDeadZone)
        {
            var inputControl = AddControl(inputControlType, handle);
            inputControl.LowerDeadZone = lowerDeadZone;
            inputControl.UpperDeadZone = upperDeadZone;
            return inputControl;
        }


        public void ClearInputState()
        {
            LeftStickX.ClearInputState();
            LeftStickY.ClearInputState();
            LeftStick.ClearInputState();

            RightStickX.ClearInputState();
            RightStickY.ClearInputState();
            RightStick.ClearInputState();

            DPadX.ClearInputState();
            DPadY.ClearInputState();
            DPad.ClearInputState();

            var controlCount = Controls.Length;
            for (int i = 0; i < controlCount; i++)
            {
                var control = Controls[i];
                if (control != null)
                {
                    control.ClearInputState();
                }
            }
        }


        internal void UpdateWithState(InputControlType inputControlType, bool state)
        {
            GetControl(inputControlType).UpdateWithState(state);
        }


        internal void UpdateWithValue(InputControlType inputControlType, float value)
        {
            GetControl(inputControlType).UpdateWithValue(value);
        }


        internal void UpdateLeftStickWithValue(Vector2 value)
        {
            LeftStickLeft.UpdateWithValue(Math.Max(0.0f, -value.X));
            LeftStickRight.UpdateWithValue(Math.Max(0.0f, value.X));

            if (InputManager.InvertYAxis)
            {
                LeftStickUp.UpdateWithValue(Math.Max(0.0f, -value.Y));
                LeftStickDown.UpdateWithValue(Math.Max(0.0f, value.Y));
            }
            else
            {
                LeftStickUp.UpdateWithValue(Math.Max(0.0f, value.Y));
                LeftStickDown.UpdateWithValue(Math.Max(0.0f, -value.Y));
            }
        }


        internal void UpdateLeftStickWithRawValue(Vector2 value)
        {
            LeftStickLeft.UpdateWithRawValue(Math.Max(0.0f, -value.X));
            LeftStickRight.UpdateWithRawValue(Math.Max(0.0f, value.X));

            if (InputManager.InvertYAxis)
            {
                LeftStickUp.UpdateWithRawValue(Math.Max(0.0f, -value.Y));
                LeftStickDown.UpdateWithRawValue(Math.Max(0.0f, value.Y));
            }
            else
            {
                LeftStickUp.UpdateWithRawValue(Math.Max(0.0f, value.Y));
                LeftStickDown.UpdateWithRawValue(Math.Max(0.0f, -value.Y));
            }
        }


        internal void CommitLeftStick()
        {
            LeftStickUp.Commit();
            LeftStickDown.Commit();
            LeftStickLeft.Commit();
            LeftStickRight.Commit();
        }


        internal void UpdateRightStickWithValue(Vector2 value)
        {
            RightStickLeft.UpdateWithValue(Math.Max(0.0f, -value.X));
            RightStickRight.UpdateWithValue(Math.Max(0.0f, value.Y));

            if (InputManager.InvertYAxis)
            {
                RightStickUp.UpdateWithValue(Math.Max(0.0f, -value.Y));
                RightStickDown.UpdateWithValue(Math.Max(0.0f, value.Y));
            }
            else
            {
                RightStickUp.UpdateWithValue(Math.Max(0.0f, value.Y));
                RightStickDown.UpdateWithValue(Math.Max(0.0f, -value.Y));
            }
        }


        internal void UpdateRightStickWithRawValue(Vector2 value)
        {
            RightStickLeft.UpdateWithRawValue(Math.Max(0.0f, -value.X));
            RightStickRight.UpdateWithRawValue(Math.Max(0.0f, value.X));

            if (InputManager.InvertYAxis)
            {
                RightStickUp.UpdateWithRawValue(Math.Max(0.0f, -value.Y));
                RightStickDown.UpdateWithRawValue(Math.Max(0.0f, value.Y));
            }
            else
            {
                RightStickUp.UpdateWithRawValue(Math.Max(0.0f, value.Y));
                RightStickDown.UpdateWithRawValue(Math.Max(0.0f, -value.Y));
            }
        }


        internal void CommitRightStick()
        {
            RightStickUp.Commit();
            RightStickDown.Commit();
            RightStickLeft.Commit();
            RightStickRight.Commit();
        }


        public virtual void Update()
        {
            // Implemented by subclasses.
        }


        bool AnyCommandControlIsPressed()
        {
            for (int i = (int)InputControlType.Back; i <= (int)InputControlType.Power; i++)
            {
                var control = Controls[i];
                if (control != null && control.IsPressed)
                {
                    return true;
                }
            }

            return false;
        }


        internal void ProcessLeftStick()
        {
            var x = Utility.ValueFromSides(LeftStickLeft.NextRawValue, LeftStickRight.NextRawValue);
            var y = Utility.ValueFromSides(LeftStickDown.NextRawValue, LeftStickUp.NextRawValue, InputManager.InvertYAxis);

            Vector2 v;
            if (RawSticks)
            {
                v = new Vector2(x, y);
            }
            else
            {
                var lowerDeadZone = Utility.Max(LeftStickLeft.LowerDeadZone, LeftStickRight.LowerDeadZone, LeftStickUp.LowerDeadZone, LeftStickDown.LowerDeadZone);
                var upperDeadZone = Utility.Min(LeftStickLeft.UpperDeadZone, LeftStickRight.UpperDeadZone, LeftStickUp.UpperDeadZone, LeftStickDown.UpperDeadZone);
                v = Utility.ApplyCircularDeadZone(x, y, lowerDeadZone, upperDeadZone);
            }

            LeftStick.Raw = true;
            LeftStick.UpdateWithAxes(v.X, v.Y);

            LeftStickX.Raw = true;
            LeftStickX.CommitWithValue(v.X);

            LeftStickY.Raw = true;
            LeftStickY.CommitWithValue(v.Y);

            LeftStickLeft.SetValue(LeftStick.Left.Value);
            LeftStickRight.SetValue(LeftStick.Right.Value);
            LeftStickUp.SetValue(LeftStick.Up.Value);
            LeftStickDown.SetValue(LeftStick.Down.Value);
        }


        internal void ProcessRightStick()
        {
            var x = Utility.ValueFromSides(RightStickLeft.NextRawValue, RightStickRight.NextRawValue);
            var y = Utility.ValueFromSides(RightStickDown.NextRawValue, RightStickUp.NextRawValue, InputManager.InvertYAxis);

            Vector2 v;
            if (RawSticks)
            {
                v = new Vector2(x, y);
            }
            else
            {
                var lowerDeadZone = Utility.Max(RightStickLeft.LowerDeadZone, RightStickRight.LowerDeadZone, RightStickUp.LowerDeadZone, RightStickDown.LowerDeadZone);
                var upperDeadZone = Utility.Min(RightStickLeft.UpperDeadZone, RightStickRight.UpperDeadZone, RightStickUp.UpperDeadZone, RightStickDown.UpperDeadZone);
                v = Utility.ApplyCircularDeadZone(x, y, lowerDeadZone, upperDeadZone);
            }

            RightStick.Raw = true;
            RightStick.UpdateWithAxes(v.X, v.Y);

            RightStickX.Raw = true;
            RightStickX.CommitWithValue(v.X);

            RightStickY.Raw = true;
            RightStickY.CommitWithValue(v.Y);

            RightStickLeft.SetValue(RightStick.Left.Value);
            RightStickRight.SetValue(RightStick.Right.Value);
            RightStickUp.SetValue(RightStick.Up.Value);
            RightStickDown.SetValue(RightStick.Down.Value);
        }


        internal void ProcessDPad()
        {
            var lowerDeadZone = Utility.Max(DPadLeft.LowerDeadZone, DPadRight.LowerDeadZone, DPadUp.LowerDeadZone, DPadDown.LowerDeadZone);
            var upperDeadZone = Utility.Min(DPadLeft.UpperDeadZone, DPadRight.UpperDeadZone, DPadUp.UpperDeadZone, DPadDown.UpperDeadZone);

            var x = Utility.ValueFromSides(DPadLeft.NextRawValue, DPadRight.NextRawValue);
            var y = Utility.ValueFromSides(DPadDown.NextRawValue, DPadUp.NextRawValue, InputManager.InvertYAxis);
            var v = Utility.ApplyCircularDeadZone(x, y, lowerDeadZone, upperDeadZone);

            DPad.Raw = true;
            DPad.UpdateWithAxes(v.X, v.Y);

            DPadX.Raw = true;
            DPadX.CommitWithValue(v.X);

            DPadY.Raw = true;
            DPadY.CommitWithValue(v.Y);

            DPadLeft.SetValue(DPad.Left.Value);
            DPadRight.SetValue(DPad.Right.Value);
            DPadUp.SetValue(DPad.Up.Value);
            DPadDown.SetValue(DPad.Down.Value);
        }


        public void Commit()
        {
            // We need to do some processing to ensure all the various objects
            // holding directional values are calculated optimally with circular 
            // deadzones and then set properly everywhere.
            ProcessLeftStick();
            ProcessRightStick();
            ProcessDPad();

            // Next, commit all control values.
            int controlCount = Controls.Length;
            for (int i = 0; i < controlCount; i++)
            {
                var control = Controls[i];
                if (control != null)
                {
                    control.Commit();

                    if (control.HasChanged)
                    {
                        LastChangeTick = Time.frameCount;
                    }
                }
            }

            // Calculate the "Command" control for known controllers and commit it.
            if (IsKnown)
            {
                Command.CommitWithState(AnyCommandControlIsPressed());
            }
        }


        public bool LastChangedAfter(InputDevice otherDevice)
        {
            return LastChangeTick > otherDevice.LastChangeTick;
        }


        internal void RequestActivation()
        {
            LastChangeTick = Time.frameCount;
        }


        public virtual void Vibrate(float leftMotor, float rightMotor)
        {
        }


        public void Vibrate(float intensity)
        {
            Vibrate(intensity, intensity);
        }


        public void StopVibration()
        {
            Vibrate(0.0f);
        }


        public virtual bool IsSupportedOnThisPlatform => true;


        public virtual bool IsKnown => true;


        public bool IsUnknown => !IsKnown;


        public bool MenuWasPressed => GetControl(InputControlType.Command).WasPressed;


        public InputControl AnyButton
        {
            get
            {
                int controlCount = Controls.GetLength(0);
                for (int i = 0; i < controlCount; i++)
                {
                    var control = Controls[i];
                    if (control != null && control.IsButton && control.IsPressed)
                    {
                        return control;
                    }
                }

                return InputControl.Null;
            }
        }

        public InputControl LeftStickUp => GetControl(InputControlType.LeftStickUp);
        public InputControl LeftStickDown => GetControl(InputControlType.LeftStickDown);
        public InputControl LeftStickLeft => GetControl(InputControlType.LeftStickLeft);
        public InputControl LeftStickRight => GetControl(InputControlType.LeftStickRight);

        public InputControl RightStickUp => GetControl(InputControlType.RightStickUp);
        public InputControl RightStickDown => GetControl(InputControlType.RightStickDown);
        public InputControl RightStickLeft => GetControl(InputControlType.RightStickLeft);
        public InputControl RightStickRight => GetControl(InputControlType.RightStickRight);

        public InputControl DPadUp => GetControl(InputControlType.DPadUp);
        public InputControl DPadDown => GetControl(InputControlType.DPadDown);
        public InputControl DPadLeft => GetControl(InputControlType.DPadLeft);
        public InputControl DPadRight => GetControl(InputControlType.DPadRight);

        public InputControl Action1 => GetControl(InputControlType.Action1);
        public InputControl Action2 => GetControl(InputControlType.Action2);
        public InputControl Action3 => GetControl(InputControlType.Action3);
        public InputControl Action4 => GetControl(InputControlType.Action4);

        public InputControl LeftTrigger => GetControl(InputControlType.LeftTrigger);
        public InputControl RightTrigger => GetControl(InputControlType.RightTrigger);

        public InputControl LeftBumper => GetControl(InputControlType.LeftBumper);
        public InputControl RightBumper => GetControl(InputControlType.RightBumper);

        public InputControl LeftStickButton => GetControl(InputControlType.LeftStickButton);
        public InputControl RightStickButton => GetControl(InputControlType.RightStickButton);


        public TwoAxisInputControl Direction => DPad.UpdateTick > LeftStick.UpdateTick ? DPad : LeftStick;


        public static implicit operator bool(InputDevice device)
        {
            return device != null;
        }
    }
}
