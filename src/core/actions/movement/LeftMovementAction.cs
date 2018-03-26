using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class LeftMovementAction : ControlBehavior
    {
        private Entity _entity;

        public LeftMovementAction(Entity entity)
        {
            _entity = entity;
        }

        public override void IsPressed()
        {
            MovementManager.MoveLeft(_entity);
        }

        public override void WasReleased()
        {
        }

        public override void WasPressed()
        {
        }
    }
}