using Core.input.setup;
namespace Otiose.Input.Setup {
    public class Action2WasReleased : ControllerCommand
    {
        public Action2WasReleased(ControllerProfile controllerProfile) : base(controllerProfile) {
        }

        public override void Execute() => ControllerProfile.Action2.WasReleased();
    }
}