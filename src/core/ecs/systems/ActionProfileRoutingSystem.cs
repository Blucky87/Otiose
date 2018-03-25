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
            InputActionSet actionSet = entity.getComponent<PlayerActionSetComponent>().PlayerActionSet;
            ControllerProfile controllerProfile =
                entity.getComponent<PlayerControllerProfileComponent>().ControllerProfile;
            
            
            Detect(actionSet, controllerProfile);
            
          
        }

        private void Detect(InputActionSet CharacterActions, ControllerProfile  controllerProfile)
        {
            
            //////////////////////////////////////////////
            //               Action 1  (Attack)         //
            //////////////////////////////////////////////
            
            if(CharacterActions.PlayerAction1.WasPressed)
            {
               GameSystem.AddCommand(new Action1WasPressed(controllerProfile));
            }
            if (CharacterActions.PlayerAction1.WasReleased)
            {
                GameSystem.AddCommand(new Action1WasReleased(controllerProfile));
            }
            if (CharacterActions.PlayerAction1.IsPressed)
            {
                GameSystem.AddCommand(new Action1IsPressed(controllerProfile));
            }

        }
        
    }
}