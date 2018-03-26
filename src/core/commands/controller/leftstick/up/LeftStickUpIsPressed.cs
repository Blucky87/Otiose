using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickUpIsPressed : ControllerCommand
    {
        public LeftStickUpIsPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickUp.IsPressed();
    }
}