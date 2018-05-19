

using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Input;

namespace Otiose.Input.Setup
{
    public class PlayerActionSet : ActionSet
    {

        public PlayerAction LeftStickUp;
        public PlayerAction LeftStickDown;
        public PlayerAction LeftStickLeft;
        public PlayerAction LeftStickRight;
        public PlayerTwoAxisAction LeftStick;

        public PlayerAction RightStickUp;
        public PlayerAction RightStickDown;
        public PlayerAction RightStickLeft;
        public PlayerAction RightStickRight;
        public PlayerTwoAxisAction RightStick;

        public PlayerAction Action1;
        public PlayerAction Action2;
        public PlayerAction Action3;
        public PlayerAction Action4;

        public PlayerAction RightBumper;
        public PlayerAction LeftBumper;

        public PlayerActionSet()
        {
            LeftStickUp = CreatePlayerAction("Left Stick Up");
            LeftStickDown = CreatePlayerAction("Left Stick Down");
            LeftStickLeft = CreatePlayerAction("Left Stick Left");
            LeftStickRight = CreatePlayerAction("Left Stick Right");
            LeftStick = CreateTwoAxisPlayerAction(LeftStickLeft, LeftStickRight, LeftStickDown, LeftStickUp);

            RightStickUp = CreatePlayerAction("Right Stick Up");
            RightStickDown = CreatePlayerAction("Right Stick Down");
            RightStickLeft = CreatePlayerAction("Right Stick Left");
            RightStickRight = CreatePlayerAction("Right Stick Right");
            RightStick = CreateTwoAxisPlayerAction(RightStickLeft, RightStickRight, RightStickDown, RightStickUp);

            Action1 = CreatePlayerAction("Player Action 1");
            Action2 = CreatePlayerAction("Player Action 2");
            Action3 = CreatePlayerAction("Player Action 3");
            Action4 = CreatePlayerAction("Player Action 4");
            RightBumper = CreatePlayerAction("Right Bumper");
            LeftBumper = CreatePlayerAction("Left Bumper");          
        }

        public void SetupDefaultBindings()
        {
            Console.WriteLine($"Setting Default Input Control Bindings for Input Action Set");

            LeftStickLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
            LeftStickRight.AddDefaultBinding(InputControlType.LeftStickRight);
            LeftStickUp.AddDefaultBinding(InputControlType.LeftStickUp);
            LeftStickDown.AddDefaultBinding(InputControlType.LeftStickDown);
            RightStickUp.AddDefaultBinding(InputControlType.RightStickUp);
            RightStickDown.AddDefaultBinding(InputControlType.RightStickDown);
            RightStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
            RightStickRight.AddDefaultBinding(InputControlType.RightStickRight);
            Action1.AddDefaultBinding(InputControlType.Action1);
            Action2.AddDefaultBinding(InputControlType.Action2);
            Action3.AddDefaultBinding(InputControlType.Action3);
            Action4.AddDefaultBinding(InputControlType.Action4);
            RightBumper.AddDefaultBinding(InputControlType.RightBumper);
            LeftBumper.AddDefaultBinding(InputControlType.LeftBumper);
        }

        public void SetupDefaultKeebBindings()
        {
            Console.WriteLine($"Setting Default Keyboard Bindings for Input Action Set");
            
            LeftStickLeft.AddDefaultBinding(Keys.H);
            LeftStickRight.AddDefaultBinding(Keys.L);
            LeftStickUp.AddDefaultBinding(Keys.K);
            LeftStickDown.AddDefaultBinding(Keys.J);
            Action1.AddDefaultBinding(Keys.Q);
            Action2.AddDefaultBinding(Keys.W);
            RightBumper.AddDefaultBinding(Keys.E);
        }
    }

}
