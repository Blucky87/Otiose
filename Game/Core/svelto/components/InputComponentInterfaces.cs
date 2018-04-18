using System.ComponentModel;
using Microsoft.Xna.Framework;
using Nez;

namespace Otiose.svelto.components
{
    public interface ITwoAxisInput : IComponent
    {
        float X { get; }
        float Y { get; }
        Vector2 Vector { get; }
        float AngleDeg { get; }
    }

    public interface IMovementInputComponent : ITwoAxisInput
    {
        
    }

    public interface IAimInputComponent : ITwoAxisInput
    {

    }


}