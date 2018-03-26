using Nez;
using Otiose.Input.Setup.Actions;

namespace Otiose.Input.Setup
{
    public class ControllerProfile
    {
        public ControlBehavior Action1;
        public ControlBehavior Action2;
        public ControlBehavior Action3;
        public ControlBehavior Action4;
        public ControlBehavior LeftStickUp;
        public ControlBehavior LeftStickDown;
        public ControlBehavior LeftStickLeft;
        public ControlBehavior LeftStickRight;
        public ControlBehavior RightStickUp;
        public ControlBehavior RightStickDown;
        public ControlBehavior RightStickLeft;
        public ControlBehavior RightStickRight;
        public ControlBehavior RightBumper;
        public ControlBehavior LeftBumper;
        
        public ControlBehavior LeftStick;
        public ControlBehavior RightStick;

        public ControllerProfile()
        {
            Action1 = new EmptyAction();
            Action2 = new EmptyAction();
            Action3 = new EmptyAction();
            Action4 = new EmptyAction();
            
            LeftStickUp = new EmptyAction();
            LeftStickDown = new EmptyAction();
            LeftStickLeft = new EmptyAction();
            LeftStickRight = new EmptyAction();
            
            RightBumper = new EmptyAction();
            LeftBumper = new EmptyAction();
            
            RightStickUp = new EmptyAction();
            RightStickDown = new EmptyAction();
            RightStickLeft = new EmptyAction();
            RightStickDown = new EmptyAction();
            
            LeftStick = new EmptyAction();
            RightStick = new EmptyAction();

        }

        public string Name { get; set; }

    }
}