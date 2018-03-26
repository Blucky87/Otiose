using Core.managers;
using Nez;
using Otiose.Input.Setup.Actions;

namespace Core.actions.movement
{
    public class MovementControlAction : EntityControlAction
    {
        public MovementControlAction(Entity entity) : base(entity)
        {
        }

        public override void IsPressed() => MovementManager.updateFacingAngle(_entity);

        public override void WasReleased() => MovementManager.updateFacingAngle(_entity);

        public override void WasPressed() => MovementManager.updateFacingAngle(_entity);
    }
}