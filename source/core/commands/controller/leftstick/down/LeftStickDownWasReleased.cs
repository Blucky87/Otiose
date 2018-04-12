using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickDownWasReleased : ControllerCommand
    {
        public LeftStickDownWasReleased(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickDown.WasReleased();
    }
}