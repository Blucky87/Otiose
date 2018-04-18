using Microsoft.Xna.Framework;
using Otiose.Input;
using Otiose.Input.Setup;
using Otiose.svelto.components;

namespace Otiose.svelto.implementors
{
    public sealed class PlayerRightStickImplementor : IImplementor, IAimInputComponent
    {
        private readonly PlayerTwoAxisAction _playerTwoAxisAction;

        public float X => _playerTwoAxisAction.X;
        public float Y => _playerTwoAxisAction.Y;
        public Vector2 Vector => _playerTwoAxisAction.Vector;
        public float AngleDeg => _playerTwoAxisAction.Angle;

        public PlayerRightStickImplementor(PlayerActionSet playerActionSet)
        {
            _playerTwoAxisAction = playerActionSet.RightStick;
        }

    }
}