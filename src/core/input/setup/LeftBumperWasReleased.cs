using Core.input.setup;

namespace Otiose.Input.Setup {
    public class LeftBumperWasReleased : ControllerCommand
    {
        public LeftBumperWasReleased(ControllerProfile controllerProfile)  : base(controllerProfile){
        }
        public override void Execute() => ControllerProfile.LeftBumper.WasReleased();
    }
}