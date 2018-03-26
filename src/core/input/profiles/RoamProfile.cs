using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class RoamProfile : ControllerProfile
    {
        public RoamProfile(Entity owner)
        {
//            LeftStick = new RunAction(owner);
//            RightStick = new RunAction(owner);

            Action1 = new RunAction(owner);
            LeftStick = new MovementAction(owner);
            LeftStickUp = new UpMovementAction(owner);
            LeftStickDown = new DownMovementAction(owner);
            LeftStickLeft = new LeftMovementAction(owner);
            LeftStickRight = new RightMovementAction(owner);
            
        }
    }
}