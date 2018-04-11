using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickDownWasPressed : ControllerCommand
    {
        public LeftStickDownWasPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickDown.WasPressed();
    }
}