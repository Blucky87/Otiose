using Nez;
using Otiose.Input;

namespace Core.components
{
    public class InputService : EntityProcessingSystem
    {
        public InputService(Matcher matcher) : base(matcher)
        {
            
        }

        public override void process(Entity entity)
        {
            if (entity.getComponents<PlayerIndexComponent>().Count > 1)
            {
                
            }
        }
    }
}