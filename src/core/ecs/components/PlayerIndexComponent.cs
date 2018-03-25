using System;
using Microsoft.Xna.Framework;
using Nez;
using Otiose;

namespace Core.components
{
    ///    <summary>Holds the index of the player attached</summary>
    public class PlayerIndexComponent : Component
    {
        public PlayerIndex PlayerIndex;
        public Guid InputDeviceGuid;

        public PlayerIndexComponent(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
            InputDeviceGuid = InputManager.GetPlayerDeviceGuid(playerIndex);
        }
    }
}