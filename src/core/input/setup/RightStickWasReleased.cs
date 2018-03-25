using Core.input.setup;

namespace Otiose.Input.Setup {
    public class RightStickWasReleased : ControllerCommand {
        public RightStickWasReleased(ControllerProfile controllerProfile) : base(controllerProfile){
        }
        public override void Execute() => ControllerProfile.RightStick.WasReleased();
    }
}