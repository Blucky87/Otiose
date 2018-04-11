using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickRightIsPressed : ControllerCommand
    {
        public LeftStickRightIsPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickRight.IsPressed();
    }
}