using System.Collections.Generic;
using System.ComponentModel.Design;
using Nez;
using Otiose.Input.Setup;

namespace Core.components
{
    public class GameSystem : IUpdatableManager
    {
        private static List<Command> gameCommandBuffer;

        public static void AddCommand(Command command)
        {
            gameCommandBuffer.Add(command);
        }
       
        public void update()
        {
            foreach (Command command in gameCommandBuffer)
            {
                command.Execute();
            }
        }
    }
}