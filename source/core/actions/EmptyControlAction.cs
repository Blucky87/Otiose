using Otiose.Input.Setup;

namespace Core.actions
{
    public class EmptyControlAction : IControlAction
    {
        public virtual void IsPressed()
        {
        }

        public virtual void WasReleased()
        {
        }

        public virtual void WasPressed()
        {
        }
    }
}