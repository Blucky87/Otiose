using System.Net.NetworkInformation;
using Nez;
using Otiose.Input;
using Otiose.Input.Setup;

namespace Core.components
{
    public class ActionProfileRoutingSystem : EntityProcessingSystem
    {
        public ActionProfileRoutingSystem(Matcher matcher) : base(matcher)
        {
        }

        public override void process(Entity entity)
        {
            PlayerActionSet actionSet = entity.getComponent<PlayerActionSetComponent>().PlayerActionSet;
            ControllerProfile controllerProfile =
                entity.getComponent<ControllerProfileComponent>().ControllerProfile;
            
            
            Detect(actionSet, controllerProfile);
        }

        private void Detect(PlayerActionSet ActionSet, ControllerProfile  controllerProfile)
        {
            if(ActionSet.Action1.WasPressed)
            {
               GameCommandManager.AddCommand(new Action1WasPressed(controllerProfile));
            }
            if (ActionSet.Action1.WasReleased)
            {
                GameCommandManager.AddCommand(new Action1WasReleased(controllerProfile));
            }
            if (ActionSet.Action1.IsPressed)
            {
                GameCommandManager.AddCommand(new Action1IsPressed(controllerProfile));
            }
        }
    }
}