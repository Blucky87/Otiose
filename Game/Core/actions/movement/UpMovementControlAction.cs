using Core.managers;
using Nez;

namespace Core.actions.movement
{
    public class UpMovementControlAction : EntityControlAction
    {          
        public UpMovementControlAction(Entity entity) : base(entity)
        {
        }
        
        public override void IsPressed() => MovementManager.MoveUp(_entity);
    }
}