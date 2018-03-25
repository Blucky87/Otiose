using Core.input.setup;
namespace Otiose.Input.Setup {
    public class RightStickIsPressed : ControllerCommand {
        public RightStickIsPressed(ControllerProfile controllerProfile) : base(controllerProfile){
        }
        public override void Execute() => ControllerProfile.RightStick.IsPressed();
    }
}