using Nez;

namespace Otiose.Input.Setup
{
    public class ControllerProfile
    {

        public ControlBehavior Action1;
        public ControlBehavior Action2;
        public ControlBehavior RightBumper;
        public ControlBehavior LeftBumper;
        public TwoAxisControlBehavior LeftStick;
        public TwoAxisControlBehavior RightStick;

        protected ControllerProfile(Entity owner)
        {

        }

        public string Name { get; set; }

    }
}