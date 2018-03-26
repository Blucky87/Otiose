using Core.input.setup;

namespace Otiose.Input.Setup {
    public class RightBumperWasReleased : ControllerCommand {
        public RightBumperWasReleased(ControllerProfile controllerProfile) : base(controllerProfile) {
        }
        public override void Execute() => ControllerProfile.RightBumper.WasReleased();
    }
}