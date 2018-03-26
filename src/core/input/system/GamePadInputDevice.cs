using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Otiose.Input
{
    public class GamePadInputDevice : InputDevice
    {
        const float LowerDeadZone = 0.2f;
        const float UpperDeadZone = 0.9f;

        GamePadInputDeviceManager owner;
        GamePadState state;

        public int DeviceIndex { get; private set; }


        public GamePadInputDevice(int deviceIndex, GamePadInputDeviceManager owner)
            : base("GamePad Input Device")
        {
            this.owner = owner;

            DeviceIndex = deviceIndex;
            SortOrder = deviceIndex;

            Meta = "Gamepad Input Device #" + deviceIndex;

            AddControl(InputControlType.LeftStickLeft, "Left Stick Left", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.LeftStickRight, "Left Stick Right", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.LeftStickUp, "Left Stick Up", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.LeftStickDown, "Left Stick Down", LowerDeadZone, UpperDeadZone);

            AddControl(InputControlType.RightStickLeft, "Right Stick Left", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.RightStickRight, "Right Stick Right", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.RightStickUp, "Right Stick Up", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.RightStickDown, "Right Stick Down", LowerDeadZone, UpperDeadZone);

            AddControl(InputControlType.LeftTrigger, "Left Trigger", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.RightTrigger, "Right Trigger", LowerDeadZone, UpperDeadZone);

            AddControl(InputControlType.DPadUp, "DPad Up", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.DPadDown, "DPad Down", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.DPadLeft, "DPad Left", LowerDeadZone, UpperDeadZone);
            AddControl(InputControlType.DPadRight, "DPad Right", LowerDeadZone, UpperDeadZone);

            AddControl(InputControlType.Action1, "A");
            AddControl(InputControlType.Action2, "B");
            AddControl(InputControlType.Action3, "X");
            AddControl(InputControlType.Action4, "Y");

            AddControl(InputControlType.LeftBumper, "Left Bumper");
            AddControl(InputControlType.RightBumper, "Right Bumper");

            AddControl(InputControlType.LeftStickButton, "Left Stick Button");
            AddControl(InputControlType.RightStickButton, "Right Stick Button");

            AddControl(InputControlType.Start, "Start");
            AddControl(InputControlType.Back, "Back");
            
            //get initial state 
            GetState();
        }


        public override void Update()
        {
            GetState();

            UpdateLeftStickWithValue(state.ThumbSticks.Left);
            UpdateRightStickWithValue(state.ThumbSticks.Right);

            UpdateWithValue(InputControlType.LeftTrigger, state.Triggers.Left);
            UpdateWithValue(InputControlType.RightTrigger, state.Triggers.Right);

            UpdateWithState(InputControlType.DPadUp, state.DPad.Up == ButtonState.Pressed);
            UpdateWithState(InputControlType.DPadDown, state.DPad.Down == ButtonState.Pressed);
            UpdateWithState(InputControlType.DPadLeft, state.DPad.Left == ButtonState.Pressed);
            UpdateWithState(InputControlType.DPadRight, state.DPad.Right == ButtonState.Pressed);

            UpdateWithState(InputControlType.Action1, state.Buttons.A == ButtonState.Pressed);
            UpdateWithState(InputControlType.Action2, state.Buttons.B == ButtonState.Pressed);
            UpdateWithState(InputControlType.Action3, state.Buttons.X == ButtonState.Pressed);
            UpdateWithState(InputControlType.Action4, state.Buttons.Y == ButtonState.Pressed);

            UpdateWithState(InputControlType.LeftBumper, state.Buttons.LeftShoulder == ButtonState.Pressed);
            UpdateWithState(InputControlType.RightBumper, state.Buttons.RightShoulder == ButtonState.Pressed);

            UpdateWithState(InputControlType.LeftStickButton, state.Buttons.LeftStick == ButtonState.Pressed);
            UpdateWithState(InputControlType.RightStickButton, state.Buttons.RightStick == ButtonState.Pressed);

            UpdateWithState(InputControlType.Start, state.Buttons.Start == ButtonState.Pressed);
            UpdateWithState(InputControlType.Back, state.Buttons.Back == ButtonState.Pressed);
            
        }


        public override void Vibrate(float leftMotor, float rightMotor)
        {
            GamePad.SetVibration((PlayerIndex)DeviceIndex, leftMotor, rightMotor);
        }


        internal void GetState()
        {
            state = owner.GetState(DeviceIndex);
        }


        public bool IsConnected
        {
            get { return state.IsConnected; }
        }
    }
}

