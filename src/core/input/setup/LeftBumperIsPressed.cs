using Core.input.setup;

namespace Otiose.Input.Setup {
    public class LeftBumperIsPressed : ControllerCommand
    {
        public LeftBumperIsPressed(ControllerProfile controllerProfile) : base(controllerProfile){
        }

        public override void Execute() => ControllerProfile.LeftBumper.IsPressed();
    }
}