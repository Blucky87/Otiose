using System;
using Core.components;
using Nez;

namespace Otiose.Input.Setup.Actions
{
    public class RunAction : ControlBehavior
    {
        private Entity _entity;

        public RunAction(Entity entity)
        {
            _entity = entity;
        }
        
        public override void IsPressed()
        {
            MovementManager.Run(_entity);
        }

        public override void WasReleased()
        {
            MovementManager.EndRun(_entity);
        }

        public override void WasPressed()
        {
            MovementManager.BeginRun(_entity);
        }
    }
}