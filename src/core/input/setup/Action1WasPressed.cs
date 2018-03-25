using Core.input.setup;

namespace Otiose.Input.Setup {
    public class Action1WasPressed : ControllerCommand
    {
        public Action1WasPressed(ControllerProfile controllerProfile) : base(controllerProfile)
        {
        }

        public override void Execute() => ControllerProfile.Action1.WasPressed();
    }

}