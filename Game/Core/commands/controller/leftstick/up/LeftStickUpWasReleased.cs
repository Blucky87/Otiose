using Otiose.Input.Setup;

namespace Core.input.setup
{
    public class LeftStickUpWasReleased : ControllerCommand 
    {
        public LeftStickUpWasReleased(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.LeftStickUp.WasReleased();
    }
}