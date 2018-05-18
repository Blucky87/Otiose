using Otiose.svelto.components;

namespace Otiose.svelto.implementors
{
    public class PositionImplementor : IImplementor, IPositionComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int PhysicalLayer { get; set; }
        public int RenderLayer { get; set; }
        float IPositionComponent.X { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        float IPositionComponent.Y { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}