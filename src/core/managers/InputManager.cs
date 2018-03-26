using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Console;
using Otiose.Input;

namespace Otiose
{
    public class InputManager : IUpdatableManager
    {
        
        public static event Action OnSetup;
        public static event Action OnUpdate;
        public static event Action OnReset;

        public static event Action<InputDevice> OnDeviceAttached;
        public static event Action<InputDevice> OnDeviceDetached;
        public static event Action<InputDevice> OnActiveDeviceChanged;

        internal static event Action OnUpdateDevices;
        internal static event Action OnCommitDevices;

        public static readonly List<InputDevice> devices = new List<InputDevice>();
        static List<InputDeviceManager> deviceManagers = new List<InputDeviceManager>();
        static Dictionary<Type, InputDeviceManager> deviceManagerTable = new Dictionary<Type, InputDeviceManager>();

        static InputDevice activeDevice = InputDevice.Null;

        /// <summary>
        /// A readonly collection of devices.
        /// Not every device in this list is guaranteed to be attached or even a controller.
        /// This collection should be treated as a pool from which devices may be selected.
        /// The collection is in no particular order and the order may change at any time.
        /// Do not treat this collection as a list of players.
        /// </summary>
        public static ReadOnlyCollection<InputDevice> Devices;

        /// <summary>
        /// Query whether a command button was pressed on any device during the last frame of input.
        /// </summary>
        public static bool MenuWasPressed { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Y axis should be inverted for
        /// two-axis (directional) controls. When false (default), the Y axis will be positive up,
        /// the same as Unity.
        /// </summary>
        public static bool InvertYAxis { get; set; }

        /// <summary>
        /// Gets a value indicating whether the InputManager is currently setup and running.
        /// </summary>
        public static bool IsSetup { get; private set; }

        internal static string Platform { get; private set; }

        
        public void Setup()
        {
            SetupInternal();
            
#if true
            SetupPCDevices();
#endif

//            SetupGamePadDevices();
        }

        private void SetupPCDevices()
        {
            //
        }

        private bool SetupInternal()
        {
            if (IsSetup)
            {
                return false;
            }

            deviceManagers.Clear();
            deviceManagerTable.Clear();
            activeDevice = InputDevice.Null;

            IsSetup = true;

            if (OnSetup != null)
            {
                OnSetup.Invoke();
                OnSetup = null;
            }

            return true;
        }

        public void Reset()
        {
            ResetInternal();
            Setup();
        }

        internal void ResetInternal()
        {
            if (OnReset != null)
            {
                OnReset.Invoke();
            }

            OnSetup = null;
            OnUpdate = null;
            OnReset = null;
            OnActiveDeviceChanged = null;
            OnDeviceAttached = null;
            OnDeviceDetached = null;
            OnUpdateDevices = null;
            OnCommitDevices = null;

            DestroyDeviceManagers();

            IsSetup = false;
        }


        //
        // BL: wrapper for adding to Nez's global manager
        //
        public void update()
        {
            UpdateInternal();
        }

        private void UpdateInternal()
        {
            AssertIsSetup();
            if (OnSetup != null)
            {
                OnSetup.Invoke();
                OnSetup = null;
            }

            UpdateDeviceManagers();
            CommitDeviceManagers();
            
            UpdateActiveDevice();

            if (OnUpdate != null)
            {
                OnUpdate.Invoke();
            }

        }

        private void CommitDeviceManagers()
        {
            foreach (InputDeviceManager inputDeviceManager in deviceManagers)
            {
                inputDeviceManager.Commit();
            }
        }

        static void AssertIsSetup()
        {
            if (!IsSetup)
            {
                throw new Exception("InputManager is not initialized. Call InputManager.Setup() first.");
            }
        }

        static void SetZeroTickOnAllControls()
        {
            foreach (InputDeviceManager inputDeviceManager in deviceManagers)
            {
                inputDeviceManager.SetZeroTick();
            }
        }


        /// <summary>
        /// Clears the state of input on all controls.
        /// The net result here should be that the state on all controls will return 
        /// zero/false for the remainder of the current tick, and during the next update 
        /// tick WasPressed, WasReleased, WasRepeated and HasChanged will return false.
        /// </summary>
        public static void ClearInputState()
        {/*
			int deviceCount = devices.Count;
			for (int i = 0; i < deviceCount; i++)
			{
				devices[i].ClearInputState();
			}

			int playerActionSetCount = playerActionSets.Count;
			for (int i = 0; i < playerActionSetCount; i++)
			{
				playerActionSets[i].ClearInputState();
			}*/
        }


        internal static void OnApplicationFocus(bool focusState)
        {
            if (!focusState)
            {
                SetZeroTickOnAllControls();
            }
        }


        internal static void OnApplicationPause(bool pauseState)
        {
        }


        internal static void OnApplicationQuit()
        {
        }


        internal static void OnLevelWasLoaded()
        {
            SetZeroTickOnAllControls();
        }


        /// <summary>
        /// Adds a device manager.
        /// Only one instance of a given type can be added. An error will be raised if
        /// you try to add more than one.
        /// </summary>
        /// <param name="inputDeviceManager">The device manager to add.</param>
        public void AddDeviceManager(InputDeviceManager deviceManager)
        {
            AssertIsSetup();

            var type = deviceManager.GetType();

            if (deviceManagerTable.ContainsKey(type))
            {
                return;
            }

            deviceManagers.Add(deviceManager);
            deviceManagerTable.Add(type, deviceManager);
        }


        /// <summary>
        /// Adds a device manager by type.
        /// </summary>
        /// <typeparam name="T">A subclass of InputDeviceManager.</typeparam>
        public void AddDeviceManager<T>() where T : InputDeviceManager, new()
        {
            AddDeviceManager(new T());
        }


        /// <summary>
        /// Get a device manager from the input manager by type if it one is present.
        /// </summary>
        /// <typeparam name="T">A subclass of InputDeviceManager.</typeparam>
        internal static T GetDeviceManager<T>() where T : InputDeviceManager
        {
            InputDeviceManager deviceManager;
            if (deviceManagerTable.TryGetValue(typeof(T), out deviceManager))
            {
                return deviceManager as T;
            }

            return null;
        }


        /// <summary>
        /// Query whether a device manager is present by type.
        /// </summary>
        /// <typeparam name="T">A subclass of InputDeviceManager.</typeparam>
        public bool HasDeviceManager<T>() where T : InputDeviceManager
        {
            return deviceManagerTable.ContainsKey(typeof(T));
        }

        private void UpdateDeviceManagers()
        {
            foreach (InputDeviceManager deviceManager in deviceManagers)
            {
                deviceManager.Update();
            }
        }


        static void DestroyDeviceManagers()
        {
            foreach (InputDeviceManager deviceManager in deviceManagers)
            {
                deviceManager.Destroy();
            }
           
            deviceManagers.Clear();
            deviceManagerTable.Clear();
        }

        private void UpdateActiveDevice()
        {
            InputDevice lastActiveDevice = ActiveDevice;

            foreach (InputDevice device in devices)
            {
                if (device.LastChangedAfter(ActiveDevice))
                {
                    ActiveDevice = device;
                }
            }

            if (lastActiveDevice != ActiveDevice)
            {
                if (OnActiveDeviceChanged != null)
                {
                    OnActiveDeviceChanged(ActiveDevice);
                }
            }
        }


        /// <summary>
        /// Attach a device to the input manager.
        /// </summary>
        /// <param name="inputDevice">The input device to attach.</param>
        internal static void AttachDevice(InputDevice inputDevice)
        {
            AssertIsSetup();

            if (!inputDevice.IsSupportedOnThisPlatform)
            {
                return;
            }

            if (devices.Contains(inputDevice))
            {
                inputDevice.IsAttached = true;
                return;
            }

            devices.Add(inputDevice);

            inputDevice.IsAttached = true;

            if (OnDeviceAttached != null)
            {
                OnDeviceAttached(inputDevice);
            }
        }


        /// <summary>
        /// Detach a device from the input manager.
        /// </summary>
        /// <param name="inputDevice">The input device to attach.</param>
        internal static void DetachDevice(InputDevice inputDevice)
        {
            if (!inputDevice.IsAttached)
            {
                return;
            }

            if (!IsSetup)
            {
                inputDevice.IsAttached = false;
                return;
            }

            if (!devices.Contains(inputDevice))
            {
                inputDevice.IsAttached = false;
                return;
            }

            devices.Remove(inputDevice);

            inputDevice.IsAttached = false;

            if (ActiveDevice == inputDevice)
            {
                ActiveDevice = InputDevice.Null;
            }

            if (OnDeviceDetached != null)
            {
                OnDeviceDetached(inputDevice);
            }
        }

        public static Guid GetPlayerDeviceGuid(PlayerIndex playerIndex)
        {
            Guid deviceGuid = Guid.Empty;

            GamePadInputDeviceManager deviceManager = GetDeviceManager<GamePadInputDeviceManager>();
            
            if (deviceManager != null)
            {
                deviceGuid = deviceManager.GetPlayerInputDeviceGuid(playerIndex);
            }
            
            Console.WriteLine($"{deviceGuid} Device GUID found for Player Index {playerIndex.ToString()}");

            return deviceGuid;
        }    

    

        public static InputDevice GetInputDevice(Guid guid)
        {
            foreach (InputDevice device in devices)
            {
                if (device.Guid == guid)
                {
                    return device;
                }
            }
            
            return InputDevice.Null;
        }


        /// <summary>
        /// Detects whether any (keyboard) key is currently pressed.
        /// For more flexibility, see <see cref="KeyCombo.Detect()"/>
        /// </summary>
        public static bool AnyKeyIsPressed => KeyCombo.Detect(true).Count > 0;


        /// <summary>
        /// Gets the currently active device if present, otherwise returns a null device which does nothing.
        /// The currently active device is defined as the last device that provided input events. This is
        /// a good way to query for a device in single player applications.
        /// </summary>
        public static InputDevice ActiveDevice
        {
            get => activeDevice ?? InputDevice.Null;

            private set => activeDevice = value ?? InputDevice.Null;
        }


        /// <summary>
        /// Enable XInput support (Windows only).
        /// When enabled on initialization, the input manager will first check
        /// whether XInput is supported on this platform and if so, it will add
        /// an XInputDeviceManager.
        /// </summary>
        public static bool EnableXInput { get; internal set; }


        /// <summary>
        /// Set the XInput background thread polling rate.
        /// When set to zero (default) it will equal the projects fixed updated rate.
        /// </summary>
        public static uint XInputUpdateRate { get; internal set; }


        /// <summary>
        /// Set the XInput buffer size. (Experimental)
        /// Usually you want this to be zero (default). Setting it higher will introduce 
        /// latency, but may smooth out input if querying input on FixedUpdate, which 
        /// tends to cluster calls at the end of a frame.
        /// </summary>
        public static uint XInputBufferSize { get; internal set; }


        /// <summary>
        /// Enable iCade support (iOS only).
        /// When enabled on initialization, the input manager will first check
        /// whether XInput is supported on this platform and if so, it will add
        /// an XInputDeviceManager.
        /// </summary>
        public static bool EnableICade { get; internal set; }

    }
}
