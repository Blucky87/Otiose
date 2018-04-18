using Svelto.ECS;

namespace Otiose.svelto.engines
{
    public struct MovementInfo
    {
        public EGID EntityMovementId { get; private set; }

        public MovementInfo(EGID entityMovementId)
        {
            EntityMovementId = entityMovementId;
        }


    }
}