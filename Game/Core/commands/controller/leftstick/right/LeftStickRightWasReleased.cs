using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickRightWasReleased : ControllerCommand
    {
        public LeftStickRightWasReleased(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickRight.WasReleased();
    }
}