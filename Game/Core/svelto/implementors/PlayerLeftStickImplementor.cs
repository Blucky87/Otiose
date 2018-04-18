using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Otiose.Input;
using Otiose.Input.Setup;
using Otiose.svelto.components;

namespace Otiose.svelto.implementors
{
    public sealed class PlayerLeftStickImplementor : IImplementor, IMovementInputComponent
    {
        private readonly PlayerTwoAxisAction _playerTwoAxisAction;

        public float X => _playerTwoAxisAction.X;
        public float Y => _playerTwoAxisAction.Y;
        public Vector2 Vector => _playerTwoAxisAction.Vector;
        public float AngleDeg => _playerTwoAxisAction.Angle;
        

        public PlayerLeftStickImplementor(PlayerActionSet playerActionSet)
        {
            _playerTwoAxisAction = playerActionSet.LeftStick;
        }

    }
}