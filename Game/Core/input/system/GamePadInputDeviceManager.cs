using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Svelto.Tasks;

namespace Otiose.Input
{
    public class GamePadInputDeviceManager : InputDeviceManager
    {
        bool[] deviceConnected;

        public const int maxDevices = 4;
        RingBuffer<GamePadState>[] gamePadState;
        Thread thread;
        int timeStep;
        int bufferSize;

        private ITaskRoutine _taskRoutine;

        public GamePadInputDeviceManager()
        {
            gamePadState = new RingBuffer<GamePadState>[maxDevices];
            deviceConnected = new bool[maxDevices];

            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(GamePadStateEnqueue());

            if (InputManager.XInputUpdateRate == 0)
            {
                timeStep = Mathf.floorToInt(Time.deltaTime * 1000.0f);
            }
            else
            {
                timeStep = Mathf.floorToInt(1.0f / InputManager.XInputUpdateRate * 1000.0f);
            }

            bufferSize = (int)Math.Max(InputManager.XInputBufferSize, 1);

            for (int deviceIndex = 0; deviceIndex < maxDevices; deviceIndex++)
            {
                gamePadState[deviceIndex] = new RingBuffer<GamePadState>(bufferSize);
            }

            for (int deviceIndex = 0; deviceIndex < maxDevices; deviceIndex++)
            {
                GamePadInputDevice gamePad = new GamePadInputDevice(deviceIndex, this);
                devices.Add(gamePad);
            }

            _taskRoutine.Start();
        }


        IEnumerator GamePadStateEnqueue()
        {
            while (true)
            {
                for (int deviceIndex = 0; deviceIndex < devices.Count; deviceIndex++)
                {
                    gamePadState[deviceIndex].Enqueue(GamePad.GetState((PlayerIndex) deviceIndex));
                }

                yield return null;

                Thread.Sleep(timeStep);
            }
        }

        internal GamePadState GetState(int deviceIndex)
        {
            return gamePadState[deviceIndex].Dequeue();
        }


        public Guid GetPlayerInputDeviceGuid(PlayerIndex playerIndex)
        {
            return devices[(int)playerIndex].Guid;
        }

        public override void Update()
        {
            foreach (InputDevice inputDevice in devices)
            {
                var device = (GamePadInputDevice) inputDevice;
                if (!device.IsConnected)
                {
                    device.GetState();
                }
                
                if (device.IsConnected != deviceConnected[device.DeviceIndex])
                {
                    if (device.IsConnected)
                    {
                        InputManager.AttachDevice(device);
                    }
                    else
                    {
                        InputManager.DetachDevice(device);
                    }

                    deviceConnected[device.DeviceIndex] = device.IsConnected;
                }
                
                //hacky way to update the devices
                devices.FindAll(x => x.IsAttached).ForEach(x => x.Update());
            }
            
        }


        public override void Destroy()
        {
            _taskRoutine.Stop();

            foreach (InputDevice device in devices)
            {
                device.StopVibration();
                
            }
            
            devices.Clear();
        }


        public static bool CheckPlatformSupport(ICollection<string> errors)
        {
            return true;
        }


        internal static void Enable()
        {
            var errors = new List<string>();
            if (CheckPlatformSupport(errors))
            {

                
            }
            else
            {
                foreach (var error in errors)
                {
                    Console.Write(error);
                }
            }
        }
    }

}
