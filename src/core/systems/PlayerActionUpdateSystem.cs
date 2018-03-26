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
            ActionSet actionSet = entity.getComponent<PlayerActionSetComponent>().PlayerActionSet;
            
            actionSet.Update();
        }
    }
}