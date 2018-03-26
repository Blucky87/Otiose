using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Otiose.Input.Setup
{
    public sealed class PlayerInputManager : Component, IUpdatable {

        public enum ControlProfile
        {

            Roam,
            Targeting,
            RingMenu

        }

        public PlayerInputManager(PlayerIndex playerIndex)
        {
//            //InputDevice inputDevice = InputManager.Devices[(int) playerIndex]; 
//            playerManager = null; 
//            playerCommandList = new List<CommandInvoker>();
//            CharacterActions = new InputActionSet(inputDevice);
//            controllerProfileStack = new Stack<ControllerProfile>();
//            EnterControlProfile(ControlProfile.Roam);
//            BindControls();
        }

        public Stack<ControllerProfile> controllerProfileStack;
        public ControllerProfile ControllerProfile => controllerProfileStack.Peek();

//        public List<CommandInvoker> playerCommandList;
        public PlayerActionSet CharacterActions;

        public override void onAddedToEntity () {
            
        }
//
//        public void CheckInput()
//        {
//            Command _command;
//            CommandInvoker _invoker;
//            
//            
//            //////////////////////////////////////////////
//            //               Action 1  (Attack)         //
//            //////////////////////////////////////////////
//            if(CharacterActions.PlayerAction1.WasPressed)
//            {
//                _command = new Action1WasPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//                
//            }
//            if (CharacterActions.PlayerAction1.WasReleased)
//            {
//                _command = new Action1WasReleased(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.PlayerAction1.IsPressed)
//            {
//                _command = new Action1IsPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            ///////////////////////////////////////////////
//            //               Action 2 (Run)              //
//            ///////////////////////////////////////////////
//            if (CharacterActions.PlayerAction2.WasPressed)
//            {
//                _command = new Action2WasPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.PlayerAction2.WasReleased)
//            {
//                _command = new Action2WasReleased(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.PlayerAction2.IsPressed)
//            {
//                _command = new Action2IsPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//
//            ///////////////////////////////////////////////
//            //               Right Bumper                //
//            ///////////////////////////////////////////////
//            if (CharacterActions.RightBumper.WasPressed)
//            {
//                _command = new RightBumperWasPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.RightBumper.WasReleased)
//            {
//                
//                _command = new RightBumperWasReleased(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.RightBumper.IsPressed)
//            {
//                _command = new RightBumperIsPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//
//            ///////////////////////////////////////////////
//            //               Left Bumper                 //
//            ///////////////////////////////////////////////
//            if (CharacterActions.LeftBumper.WasPressed)
//            {
//                _command = new LeftBumperWasPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.LeftBumper.WasReleased)
//            {
//                _command = new LeftBumperWasReleased(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.LeftBumper.IsPressed)
//            {
//                _command = new LeftBumperIsPressed(ControllerProfile);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//
//            //////////////////////////////////////////////
//            //        Left Stick (LS) Movement         //
//            /////////////////////////////////////////////
//            if (CharacterActions.LSMove.WasPressed)
//            {
//                //_playerManager.setFacingDirection(CharacterActions.LSMove.Value+_playerManager.RigidBody.position);
//                _command = new LeftStickWasPressed(ControllerProfile, CharacterActions.LSMove);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.LSMove.IsPressed)
//            {
//                //_playerManager.setFacingDirection(CharacterActions.LSMove.Value + _playerManager.RigidBody.position);
//                _command = new LeftStickIsPressed(ControllerProfile, CharacterActions.LSMove);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.LSMove.WasReleased)
//            {
//
//                _command = new LeftStickWasReleased(ControllerProfile, CharacterActions.LSMove);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//
//            //////////////////////////////////////////////
//            //            Right Stick Movement          //
//            //////////////////////////////////////////////
//            if (CharacterActions.RSMove.WasPressed)
//            {
//                //_playerManager.setFacingDirection(CharacterActions.LSMove.Value+_playerManager.RigidBody.position);
//                _command = new RightStickWasPressed(ControllerProfile, CharacterActions.RSMove);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.RSMove.IsPressed)
//            {
//                //_playerManager.setFacingDirection(CharacterActions.LSMove.Value + _playerManager.RigidBody.position);
//                _command = new RightStickIsPressed(ControllerProfile, CharacterActions.RSMove);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//            if (CharacterActions.RSMove.WasReleased)
//            {
//                _command = new RightStickWasReleased(ControllerProfile, CharacterActions.RSMove);
//                _invoker = new CommandInvoker(_command);
//                playerCommandList.Add(_invoker);
//            }
//
//            if (playerCommandList.Count > 0)
//            {
//                foreach (CommandInvoker item in playerCommandList)
//                {
//                    item.Init();
//                    
//                }
//            }
//            playerCommandList.Clear();
//        }

        public void EnterControlProfile(ControlProfile profile)
        {
            switch (profile)
            {
                case ControlProfile.Roam:
                    break;

                default:
                    break;
            }
            
        }

        public void ExitControlProfile()
        {
            
            controllerProfileStack.Pop();
        }

        public void update()
        {
//            CheckInput();
//            CharacterActions.Update(Game1.ticks, Game1.delta);
        }

        private void BindControls()
        {
//            CharacterActions.Device = InputManager.ActiveDevice;
            CharacterActions.LeftStickLeft.AddDefaultBinding(Keys.Left);
            CharacterActions.LeftStickLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
            CharacterActions.LeftStickRight.AddDefaultBinding(Keys.Right);
            CharacterActions.LeftStickRight.AddDefaultBinding(InputControlType.LeftStickRight);
            CharacterActions.LeftStickUp.AddDefaultBinding(Keys.Up);
            CharacterActions.LeftStickUp.AddDefaultBinding(InputControlType.LeftStickUp);
            CharacterActions.LeftStickDown.AddDefaultBinding(Keys.Down);
            CharacterActions.LeftStickDown.AddDefaultBinding(InputControlType.LeftStickDown);
            CharacterActions.RightStickUp.AddDefaultBinding(Keys.I);
            CharacterActions.RightStickUp.AddDefaultBinding(InputControlType.RightStickUp);
            CharacterActions.RightStickDown.AddDefaultBinding(Keys.K);
            CharacterActions.RightStickDown.AddDefaultBinding(InputControlType.RightStickDown);
            CharacterActions.RightStickLeft.AddDefaultBinding(Keys.J);
            CharacterActions.RightStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
            CharacterActions.RightStickRight.AddDefaultBinding(Keys.L);
            CharacterActions.RightStickRight.AddDefaultBinding(InputControlType.RightStickRight);
            CharacterActions.Action1.AddDefaultBinding(Keys.Q);
            CharacterActions.Action1.AddDefaultBinding(InputControlType.Action1);
            CharacterActions.Action2.AddDefaultBinding(Keys.W);
            CharacterActions.Action2.AddDefaultBinding(InputControlType.Action2);
            CharacterActions.RightBumper.AddDefaultBinding(InputControlType.RightBumper);
            CharacterActions.RightBumper.AddDefaultBinding(Keys.E);
            CharacterActions.LeftBumper.AddDefaultBinding(InputControlType.LeftBumper);
        }

    }
}
