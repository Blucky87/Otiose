using Core.input.setup;

namespace Otiose.Input.Setup {
    public class RightBumperWasPressed : ControllerCommand {
        public RightBumperWasPressed(ControllerProfile controllerProfile) : base(controllerProfile) {
        }
        public override void Execute() => ControllerProfile.RightBumper.WasPressed();
    }
}