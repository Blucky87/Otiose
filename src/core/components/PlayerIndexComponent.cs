using Microsoft.Xna.Framework;
using Nez;
using Otiose.Input;

namespace Core.components
{
    ///    <summary>Holds the index of the player attached</summary>
    public class PlayerIndexComponent : Component
    {
        public PlayerIndex PlayerIndex;

        public PlayerIndexComponent(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}