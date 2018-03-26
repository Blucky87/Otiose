using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class UpMovementAction : ControlBehavior
    {
        private Entity _entity;

        public UpMovementAction(Entity entity)
        {
            _entity = entity;
        }
        
        public override void IsPressed()
        {
            MovementManager.MoveUp(_entity);
        }

        public override void WasReleased()
        {
        }

        public override void WasPressed()
        {
        }
    }
}