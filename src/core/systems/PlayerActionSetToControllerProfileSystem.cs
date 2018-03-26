using System;
using System.Net.NetworkInformation;
using Core.input.setup;
using Nez;
using Otiose.Input;
using Otiose.Input.Setup;

namespace Core.components
{
    public class PlayerActionSetToControllerProfileSystem : EntityProcessingSystem
    {
        public PlayerActionSetToControllerProfileSystem(Matcher matcher) : base(matcher)
        {
        }

        public override void process(Entity entity)
        {
            PlayerActionSet actionSet = entity.getComponent<PlayerActionSetComponent>().PlayerActionSet;
            ControllerProfile controllerProfile =
                entity.getComponent<ControllerProfileComponent>().ControllerProfile;
            
            
            Detect(actionSet, controllerProfile);
        }

        private void Detect(PlayerActionSet ActionSet, ControllerProfile  controllerProfile)
        {
            if(ActionSet.Action1.WasPressed)
            {
               GameCommandManager.AddCommand(new Action1WasPressed(controllerProfile));
            }
            if (ActionSet.Action1.WasReleased)
            {
                GameCommandManager.AddCommand(new Action1WasReleased(controllerProfile));
            }
            if (ActionSet.Action1.IsPressed)
            {
                GameCommandManager.AddCommand(new Action1IsPressed(controllerProfile));
            }

            if (ActionSet.LeftStick.WasPressed)
            {
                GameCommandManager.AddCommand(new LeftStickWasPressed(controllerProfile));
            }
            if (ActionSet.LeftStick.WasReleased)
            {
                GameCommandManager.AddCommand(new LeftStickWasReleased(controllerProfile));
            }
            if (ActionSet.LeftStick.IsPressed)
            {
                GameCommandManager.AddCommand(new LeftStickIsPressed(controllerProfile));
            }

            if (ActionSet.LeftStickUp.IsPressed)
            {
                GameCommandManager.AddCommand(new LeftStickUpIsPressed(controllerProfile));
            }
            if (ActionSet.LeftStickUp.WasPressed)
            {
                GameCommandManager.AddCommand(new LeftStickUpWasPressed(controllerProfile));
            }
            if (ActionSet.LeftStickUp.WasReleased)
            {
                GameCommandManager.AddCommand(new LeftStickUpWasReleased(controllerProfile));
            }

            if (ActionSet.LeftStickDown.IsPressed)
            {
                GameCommandManager.AddCommand(new LeftStickDownIsPressed(controllerProfile));
            }
            if (ActionSet.LeftStickDown.WasPressed)
            {
                GameCommandManager.AddCommand(new LeftStickDownWasPressed(controllerProfile));
            }
            if (ActionSet.LeftStickDown.WasReleased)
            {
                GameCommandManager.AddCommand(new LeftStickDownWasReleased(controllerProfile));
            }

            if (ActionSet.LeftStickLeft.IsPressed)
            {
                GameCommandManager.AddCommand(new LeftStickLeftIsPressed(controllerProfile));
            }
            if (ActionSet.LeftStickLeft.WasPressed)
            {
                GameCommandManager.AddCommand(new LeftStickLeftWasPressed(controllerProfile));
            }
            if (ActionSet.LeftStickLeft.WasReleased)
            {
                GameCommandManager.AddCommand(new LeftStickLeftWasReleased(controllerProfile));
            }

            if (ActionSet.LeftStickRight.IsPressed)
            {
                GameCommandManager.AddCommand(new LeftStickRightIsPressed(controllerProfile));
            }
            if (ActionSet.LeftStickRight.WasPressed)
            {
                GameCommandManager.AddCommand(new LeftStickRightWasPressed(controllerProfile));
            }
            if (ActionSet.LeftStickRight.WasReleased)
            {
                GameCommandManager.AddCommand(new LeftStickRightWasReleased(controllerProfile));
            }
            
        }
    }
}