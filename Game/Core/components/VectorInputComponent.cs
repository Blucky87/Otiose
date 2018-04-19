using Microsoft.Xna.Framework;
using Nez;

namespace Core.components
{
    public interface VectorInputComponent :
    {
        public Vector2 Vector { get; protected set; }
    }
}