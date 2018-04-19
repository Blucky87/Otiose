using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Otiose.svelto.engines
{
    public struct MovementInfo
    {
        public EGID EntityMovementId { get; private set; }
        public Vector2 Position { get; set; }
        public Vector2 MovementVector { get; set; }
        public float RunSpeed { get; set; }
        public float WalkSpeed { get; set; }
        public Vector2 AimVector { get; set; }

        public MovementInfo(EGID entityMovementId, Vector2 movementVector, Vector2 aimVector, float walkSpeed, float runSpeed )
        {
            EntityMovementId = entityMovementId;
            MovementVector = movementVector;
            AimVector = aimVector;
            WalkSpeed = walkSpeed;
            RunSpeed = runSpeed;
            Position = Vector2.Zero;
        }


    }
}