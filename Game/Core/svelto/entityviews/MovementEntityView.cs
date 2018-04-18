using Otiose.svelto.components;
using Svelto.ECS;

namespace Otiose.svelto.entityviews
{
    public class MovementEntityView : EntityView
    {
        public IMovementInputComponent MovementInputComponent;
        public IAimInputComponent AimInputComponent;
        public IMovementModifiersComponent MovementModifiersComponent;
        public IPositionComponent PositionComponent;
    }
}