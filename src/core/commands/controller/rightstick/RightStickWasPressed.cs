using Core.input.setup;

namespace Otiose.Input.Setup {
    public class RightStickWasPressed : ControllerCommand {
        public RightStickWasPressed(ControllerProfile controllerProfile) : base(controllerProfile){
        }
        public override void Execute() => ControllerProfile.RightStick.WasPressed();
    }
}