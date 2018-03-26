using System;
using Nez;
using Otiose.Input.Setup;

namespace Core.components
{
    public class ControllerProfileComponent : Component
    {
        public ControllerProfile ControllerProfile;

        public override void initialize()
        {
            ControllerProfile = new ControllerProfile();
        }
    }
}