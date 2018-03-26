namespace Core.actions
{
    public interface IControlAction
    {
        void IsPressed();
        void WasReleased();
        void WasPressed();
    }
}