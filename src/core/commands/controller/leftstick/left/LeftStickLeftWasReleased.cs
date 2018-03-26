using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickLeftWasReleased : ControllerCommand
    {
        public LeftStickLeftWasReleased(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickLeft.WasReleased();
    }
}