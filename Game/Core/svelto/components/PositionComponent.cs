namespace Otiose.svelto.components
{
    public interface IPositionComponent : IComponent
    {
        int X { get; set; }
        int Y { get; set; }
        int PhysicalLayer { get; set; }
        int RenderLayer { get; set; }
    }
}