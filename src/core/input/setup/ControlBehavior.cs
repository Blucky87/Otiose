namespace Otiose.Input.Setup
{
    public abstract class ControlBehavior
    {

        public abstract void IsPressed();
        public abstract void WasReleased();
        public abstract void WasPressed();
    }

}