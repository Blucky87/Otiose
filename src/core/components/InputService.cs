using Microsoft.Xna.Framework;
using Nez;
using Otiose;
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
            PlayerIndex playerIndex = entity.getComponent<PlayerIndexComponent>().PlayerIndex;
            InputDevice inputDevice = InputManager.Devices 
        }
    }
}