using Core.input.setup;
namespace Otiose.Input.Setup {
    public class RightBumperIsPressed : ControllerCommand {
        public RightBumperIsPressed(ControllerProfile controllerProfile) : base(controllerProfile) {
        }
        public override void Execute() => ControllerProfile.RightBumper.IsPressed();
    }
}