using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class RightMovementAction : ControlBehavior
    {
        private Entity _entity;

        public RightMovementAction(Entity entity)
        {
            _entity = entity;
        }
        
        public override void IsPressed()
        {
            MovementManager.MoveRight(_entity);
        }

        public override void WasReleased()
        {
        }

        public override void WasPressed()
        {
        }
    }
}