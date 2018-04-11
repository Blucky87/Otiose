using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickUpWasPressed : ControllerCommand
    {
        public LeftStickUpWasPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickUp.WasPressed();
    }
}