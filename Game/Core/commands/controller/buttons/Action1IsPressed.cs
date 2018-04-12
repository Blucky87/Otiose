using Core.input.setup;

namespace Otiose.Input.Setup {
    public class Action1IsPressed : ControllerCommand
    {
        public Action1IsPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.Action1.IsPressed();
    }
}