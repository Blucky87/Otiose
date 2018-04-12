using Core.input.setup;
namespace Otiose.Input.Setup {
    public class LeftBumperWasPressed : ControllerCommand
    {
        public LeftBumperWasPressed(ControllerProfile controllerProfile) : base(controllerProfile) {
        }

        public override void Execute() => ControllerProfile.LeftBumper.WasPressed();
    }
}