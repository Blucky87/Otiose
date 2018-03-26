using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class MovementAction : ControlBehavior
    {
        private Entity _entity;
        
        public MovementAction(Entity entity)
        {
            _entity = entity;
        }
        
        public override void IsPressed()
        {
            MovementManager.updateFacingAngle(_entity);
        }

        public override void WasReleased()
        {
            MovementManager.updateFacingAngle(_entity);
        }

        public override void WasPressed()
        {
            MovementManager.updateFacingAngle(_entity);
        }
    }
}