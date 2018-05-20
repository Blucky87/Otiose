using Core.svelto.components;
using Otiose.svelto.components;
using Svelto.ECS;

namespace Otiose.svelto.entityviews
{
    public class MovementEntityView : EntityView
    {
        public IMovementDriverComponent MovementDriver;
        public IPlayerActionLeftStickComponent PlayerActionLeftStick;
    }


}