using Core.input.setup;

namespace Otiose.Input.Setup {
    public class Action2IsPressed : ControllerCommand
    {        
        public Action2IsPressed(ControllerProfile controllerProfile) : base(controllerProfile){ }

        public override void Execute() => ControllerProfile.Action2.IsPressed();
    }

}