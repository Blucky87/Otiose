using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class DownMovementAction : ControlBehavior
    {
        private Entity _entity;

        public DownMovementAction(Entity entity)
        {
            _entity = entity;
        }

        public override void IsPressed()
        {
            MovementManager.MoveDown(_entity);
        }

        public override void WasReleased()
        {
        }

        public override void WasPressed()
        {
        }
    }
}