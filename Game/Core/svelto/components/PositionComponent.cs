namespace Otiose.svelto.components
{
    public interface IPositionComponent : IComponent
    {
        float X { get; set; }
        float Y { get; set; }
        int PhysicalLayer { get; set; }
        int RenderLayer { get; set; }
    }
}