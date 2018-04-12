using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickRightWasPressed : ControllerCommand
    {
        public LeftStickRightWasPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickRight.WasPressed();
    }
}