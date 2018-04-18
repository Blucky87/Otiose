using Otiose.svelto.components;

namespace Otiose.svelto.implementors
{
    public class MovementModifiersImplementor : IImplementor, IMovementModifiersComponent
    {
        public float WalkSpeedModifier { get; set; }
        public float RunSpeedModifier { get; set; }
    }
}