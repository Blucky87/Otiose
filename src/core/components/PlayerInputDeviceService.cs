using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;

namespace Core.components
{
    public class PlayerInputDeviceService : EntityProcessingSystem
    {
        public PlayerInputDeviceService(Matcher matcher) : base(matcher)
        {
        }

        public override void process(Entity entity)
        {
//            PlayerIndex playerIndex = entity.getComponents<PlayerIndexComponent>();
        }
    }
}