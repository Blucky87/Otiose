namespace Otiose.svelto.components
{
    public interface IMovementModifiersComponent : IComponent
    {
        float WalkSpeedModifier { get; set; }
        float RunSpeedModifier { get; set; }

    }
}