
using Core.input.setup;
namespace Otiose.Input.Setup {

    public class Action2WasPressed : ControllerCommand
    {
        public Action2WasPressed(ControllerProfile controllerProfile) : base(controllerProfile) { }

        public override void Execute() => ControllerProfile.Action2.WasPressed();
    }
}

