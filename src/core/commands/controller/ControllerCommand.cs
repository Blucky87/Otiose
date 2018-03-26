using Otiose.Input.Setup;

namespace Core.input.setup
{
    public abstract class ControllerCommand : Command
    {
        protected ControllerProfile ControllerProfile;

        public ControllerCommand(ControllerProfile controllerProfile) {
            ControllerProfile = controllerProfile;
        }
    }
}