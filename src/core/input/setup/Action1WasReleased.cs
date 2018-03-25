using Core.input.setup;

namespace Otiose.Input.Setup {
    public class Action1WasReleased : ControllerCommand
    {
        public Action1WasReleased(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.Action1.WasReleased();
    }
}