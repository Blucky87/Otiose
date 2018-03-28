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
            //get the id of the input device the player owns
            Guid inputDeviceGuid = entity.getComponent<PlayerIndexComponent>().InputDeviceGuid;
            //use the id to get the input device from the input manager
            InputDevice inputDevice = InputManager.GetInputDevice(inputDeviceGuid);
            //get the device used for the action set attached
            InputDevice entityInputDevice = entity.getComponent<PlayerActionSetComponent>().PlayerActionSet.Device ?? InputDevice.Null;

            //check if the input device from the player does not matche the input device used for the action set attached
            if (inputDevice.Guid != entityInputDevice.Guid)
            {
                //set the action set input device to the input device of the player
                entity.getComponent<PlayerActionSetComponent>().PlayerActionSet.Device = inputDevice;
            }
            
        }
    }
}