using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickDownIsPressed : ControllerCommand
    {
        public LeftStickDownIsPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickDown.IsPressed();
    }
}