using Core.input.setup;
using Microsoft.Xna.Framework;
namespace Otiose.Input.Setup {
    public class LeftStickIsPressed : ControllerCommand
    {
        public LeftStickIsPressed(ControllerProfile controllerProfile) : base(controllerProfile){
        }
        public override void Execute() => ControllerProfile.LeftStick.IsPressed();
    }
}