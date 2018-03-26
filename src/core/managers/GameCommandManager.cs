using System.Collections.Generic;
using System.ComponentModel.Design;
using Core.input.setup;
using Nez;
using Otiose.Input.Setup;

namespace Core.components
{
    public class GameCommandManager : IUpdatableManager
    {
        private static List<Command> _gameCommandBuffer;
        private static List<ControllerCommand> _controllerCommands;

        public GameCommandManager()
        {
            _gameCommandBuffer = new List<Command>();
            _controllerCommands = new List<ControllerCommand>();
        }

        public static void AddCommand<T>(T command) where T : Command
        {

            _gameCommandBuffer.Add(command);

        }
       
        public void update()
        {
            foreach (ControllerCommand command in _controllerCommands)
            {
                command.Execute();
            }
            
            _controllerCommands.Clear();
            
            foreach (Command command in _gameCommandBuffer)
            {
                command.Execute();
            }
            
            _gameCommandBuffer.Clear();
        }
    }
}