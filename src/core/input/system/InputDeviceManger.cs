using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Otiose.Input
{
    public abstract class InputDeviceManager
    {
        protected List<InputDevice> devices = new List<InputDevice>();

        public abstract InputDevice GetPlayerInputDevice(PlayerIndex playerIndex);

        public abstract void Update();

        public void Commit()
        {
            foreach (InputDevice inputDevice in devices)
            {
                inputDevice.Commit();
            }
        }

        public void SetZeroTick()
        {
            foreach (InputDevice inputDevice in devices)
            {
                foreach (InputControl control in inputDevice.Controls)
                {
                    control.SetZeroTick();
                }
            }
        }
        
        public virtual void Destroy()
        {
        }
    }
}
