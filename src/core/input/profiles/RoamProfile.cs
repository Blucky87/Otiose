using Core.actions.movement;
using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class RoamProfile : ControllerProfile
    {
        public RoamProfile(Entity owner)
        {
//            LeftStick = new RunAction(owner);
//            RightStick = new RunAction(owner);

            Action1 = new RunControlAction(owner);
            LeftStick = new MovementControlAction(owner);
            LeftStickUp = new UpMovementControlAction(owner);
            LeftStickDown = new DownMovementControlAction(owner);
            LeftStickLeft = new LeftMovementControlAction(owner);
            LeftStickRight = new RightMovementControlAction(owner);
            
        }
    }
}