using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickLeftIsPressed : ControllerCommand
    {
        public LeftStickLeftIsPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickLeft.IsPressed();
    }
}