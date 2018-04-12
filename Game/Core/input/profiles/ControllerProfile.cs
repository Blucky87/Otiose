using Core.actions;

namespace Otiose.Input.Setup
{
    public class ControllerProfile
    {
        public IControlAction Action1;
        public IControlAction Action2;
        public IControlAction Action3;
        public IControlAction Action4;
        public IControlAction LeftStickUp;
        public IControlAction LeftStickDown;
        public IControlAction LeftStickLeft;
        public IControlAction LeftStickRight;
        public IControlAction RightStickUp;
        public IControlAction RightStickDown;
        public IControlAction RightStickLeft;
        public IControlAction RightStickRight;
        public IControlAction RightBumper;
        public IControlAction LeftBumper;
        
        public IControlAction LeftStick;
        public IControlAction RightStick;

        public ControllerProfile()
        {
            Action1 = new EmptyControlAction();
            Action2 = new EmptyControlAction();
            Action3 = new EmptyControlAction();
            Action4 = new EmptyControlAction();
            
            LeftStickUp = new EmptyControlAction();
            LeftStickDown = new EmptyControlAction();
            LeftStickLeft = new EmptyControlAction();
            LeftStickRight = new EmptyControlAction();
            
            RightBumper = new EmptyControlAction();
            LeftBumper = new EmptyControlAction();
            
            RightStickUp = new EmptyControlAction();
            RightStickDown = new EmptyControlAction();
            RightStickLeft = new EmptyControlAction();
            RightStickDown = new EmptyControlAction();
            
            LeftStick = new EmptyControlAction();
            RightStick = new EmptyControlAction();

        }

        public string Name { get; set; }

    }
}