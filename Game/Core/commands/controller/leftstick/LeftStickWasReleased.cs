using Core.input.setup;
namespace Otiose.Input.Setup {
    public class LeftStickWasReleased : ControllerCommand {
        public LeftStickWasReleased(ControllerProfile controllerProfile) : base(controllerProfile) {
        }
        public override void Execute() => ControllerProfile.LeftStick.WasReleased();
    }
}