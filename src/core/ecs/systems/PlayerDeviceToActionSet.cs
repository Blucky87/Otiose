using System;
using Microsoft.Xna.Framework;
using Nez;
using Otiose;
using Otiose.Input;

namespace Core.components
{
    /// 
    /// <summary>
    /// Requires PlayerIndexComponent, PlayerActionSetComponent
    /// matches the player input device to the player action set's device 
    /// </summary>
    /// 
    public class PlayerDeviceToActionSetSystem : EntityProcessingSystem
    {
        public PlayerDeviceToActionSetSystem(Matcher matcher) : base(matcher)
        {
        }

        public override void process(Entity entity)
        {
            Guid inputDeviceGuid = entity.getComponent<PlayerIndexComponent>().InputDeviceGuid;
            InputDevice inputDevice = InputManager.GetInputDevice(inputDeviceGuid);

            entity.getComponent<PlayerActionSetComponent>().PlayerActionSet.Device = inputDevice;
        }
    }
}