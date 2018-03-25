
using Microsoft.Xna.Framework;

namespace Otiose.Input.Setup
{
    public abstract class TwoAxisControlBehavior
    {
        public abstract void IsPressed();
        public abstract void WasReleased();
        public abstract void WasPressed();
    }
}
