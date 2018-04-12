using System;
using System.Collections.Generic;
using Nez;

namespace Otiose.Input
{
    public abstract class InputDeviceProfile
    {
        public string Name { get; protected set; }

        public string Meta { get; protected set; }

        public InputControlMapping[] AnalogMappings { get; protected set; }

        public InputControlMapping[] ButtonMappings { get; protected set; }
        
        public string[] SupportedPlatforms { get; protected set; }

        public string[] ExcludePlatforms { get; protected set; }

        static HashSet<Type> hideList = new HashSet<Type>();

        float sensitivity = 1.0f;
        float lowerDeadZone = 0.0f;
        float upperDeadZone = 1.0f;
        
        public abstract bool IsKnown { get; }
        public abstract bool IsJoystick { get; }
        public abstract bool HasJoystickName(string joystickName);
        public abstract bool HasLastResortRegex(string joystickName);
        public abstract bool HasJoystickOrRegexName(string joystickName);


        public InputDeviceProfile()
        {
            Name = "";
            Meta = "";

            AnalogMappings = new InputControlMapping[0];
            ButtonMappings = new InputControlMapping[0];

            SupportedPlatforms = new string[0];
            ExcludePlatforms = new string[0];
        }

        public float Sensitivity
        {
            get => sensitivity;
            protected set { sensitivity = Mathf.clamp01(value); }
        }

        public float LowerDeadZone
        {
            get => lowerDeadZone;
            protected set { lowerDeadZone = Mathf.clamp01(value); }
        }

        public float UpperDeadZone
        {
            get => upperDeadZone;
            protected set { upperDeadZone = Mathf.clamp01(value); }
        }

        public bool IsSupportedOnThisPlatform
        {
            get
            {
                if (ExcludePlatforms != null)
                {
                    foreach (string platform in ExcludePlatforms)
                    {
                        if (InputManager.Platform.Contains(platform.ToUpper()))
                        {
                            return false;
                        }
                    }
                }

                if (SupportedPlatforms == null || SupportedPlatforms.Length == 0)
                {
                    return true;
                }

                foreach (string platform in SupportedPlatforms)
                {
                    if (InputManager.Platform.Contains(platform.ToUpper()))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsNotJoystick => !IsJoystick;


        internal static void Hide(Type type)
        {
            hideList.Add(type);
        }

        internal bool IsHidden => hideList.Contains(GetType());

        public int AnalogCount => AnalogMappings.Length;

        public int ButtonCount => ButtonMappings.Length;

    }
}