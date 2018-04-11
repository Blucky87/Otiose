using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickLeftWasPressed : ControllerCommand
    {
        public LeftStickLeftWasPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickLeft.WasPressed();
    }
}