using Core.managers;
using Nez;
using Otiose.Input.Setup.Actions;

namespace Core.actions.movement
{
    public class DownMovementControlAction : EntityControlAction
    {
        public DownMovementControlAction(Entity entity) : base(entity)
        {
        }

        public override void IsPressed() => MovementManager.MoveDown(_entity);
    }
}