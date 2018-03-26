using Core.managers;
using Nez;
using Otiose.Input.Setup.Actions;

namespace Core.actions.movement
{
    public class RightMovementControlAction : EntityControlAction
    {
        public RightMovementControlAction(Entity entity) : base(entity)
        {
        }
        
        public override void IsPressed() => MovementManager.MoveRight(_entity);
    }
}