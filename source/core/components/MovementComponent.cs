using Nez;

namespace Core.components
{
    public class MovementComponent : Component
    {
        public bool CanMove = true;
        public float MovementSpeed = 1.0f;
        public float RunSpeedModifier = 2.0f;
        public bool IsRunning = false;
        public float FacingAngle = 0.0f;

    }
}