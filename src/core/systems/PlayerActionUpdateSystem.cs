using Nez;
using Otiose.Input;

namespace Core.components
{
    public class PlayerActionUpdateSystem : EntityProcessingSystem
    {
        public PlayerActionUpdateSystem(Matcher matcher) : base(matcher)
        {
        }

        public override void process(Entity entity)
        {
            //get the entity's attached action set
            ActionSet actionSet = entity.getComponent<PlayerActionSetComponent>().PlayerActionSet;
            
            //update all the actions in the action set
            actionSet.Update();
        }
    }
}