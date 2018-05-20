using System.Xml.Linq;
using Otiose.svelto;

namespace Core.svelto.components
{
    public interface IMovementDriverComponent : IComponent
    {
        float X { get; set; }
        float Y { get; set; }
    }


    public interface IAimDriverComponent : IComponent
    {
        float X { get; set; }
        float Y { get; set; }
    }
}