using Core.managers;
using Nez;
using Otiose.Input.Setup.Actions;

namespace Core.actions.movement
{
    public class LeftMovementControlAction : EntityControlAction
    {
        public LeftMovementControlAction(Entity entity) : base(entity)
        {
        }

        public override void IsPressed() => MovementManager.MoveLeft(_entity);
    }
}