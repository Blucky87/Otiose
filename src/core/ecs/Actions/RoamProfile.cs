using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class RoamProfile : ControllerProfile
    {
        public RoamProfile(Entity owner) : base()
        {
//            LeftStick = new RunAction(owner);
//            RightStick = new RunAction(owner);

            Action1 = new RunAction(owner);
//            Action2 = new BlankControllerActions.Action();
//            RightBumper = new BlankControllerActions.Action();
//            LeftBumper = new BlankControllerActions.Action();
        }
    }
}