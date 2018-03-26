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
            
        }

        public override void WasReleased()
        {
            Console.WriteLine($"{_entity.getComponent<PlayerIndexComponent>().PlayerIndex.ToString()} Just Released Running");
        }

        public override void WasPressed()
        {
            Console.WriteLine($"{_entity.getComponent<PlayerIndexComponent>().PlayerIndex.ToString()} Just Pressed Running");   
        }
    }
}