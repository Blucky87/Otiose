using Core.managers;
using Nez;
using Otiose.Input.Setup.Actions;

namespace Core.actions.movement
{
    public class RunControlAction : EntityControlAction
    {
        public RunControlAction(Entity entity) : base(entity)
        {
        }
        
        public override void IsPressed() => MovementManager.Run(_entity);

        public override void WasReleased() => MovementManager.EndRun(_entity);

        public override void WasPressed() => MovementManager.BeginRun(_entity);
    }
}