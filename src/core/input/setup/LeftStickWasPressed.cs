using Core.input.setup;

namespace Otiose.Input.Setup {
    public class LeftStickWasPressed : ControllerCommand {
        public LeftStickWasPressed(ControllerProfile controllerProfile) : base(controllerProfile) {
        }

        public override void Execute() => ControllerProfile.LeftStick.WasPressed();
    }
}