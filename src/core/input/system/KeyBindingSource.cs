using System;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Otiose.Input
{
    public class KeyBindingSource : BindingSource
    {
        public KeyCombo Control { get; protected set; }


        internal KeyBindingSource()
        {
            
        }


        public KeyBindingSource(KeyCombo keyCombo)
        {
            Console.WriteLine("Creating Key Binding Source from keycombo");
            Control = keyCombo;
        }


        public KeyBindingSource(params Keys[] keys)
        {
            Console.WriteLine("Creating Key Binding Source from key array");
            foreach (var key in keys)
            {
                Console.WriteLine(key.ToString());
            }
            Control = new KeyCombo(keys);
        }


        public override float GetValue(InputDevice inputDevice)
        {
            Console.WriteLine("Getting Value from Key Binding Source");
            return GetState(inputDevice) ? 1.0f : 0.0f;
        }


        public override bool GetState(InputDevice inputDevice)
        {
            Console.WriteLine("Getting State from Key Binding Source");
            return Control.IsPressed;
        }


        public override string Name
        {
            get
            {
                return Control.ToString();
            }
        }


        public override string DeviceName
        {
            get
            {
                return "Keyboard";
            }
        }


        public override bool Equals(BindingSource other)
        {
            if (other == null)
            {
                return false;
            }

            var bindingSource = other as KeyBindingSource;
            if (bindingSource != null)
            {
                return Control == bindingSource.Control;
            }

            return false;
        }


        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            var bindingSource = other as KeyBindingSource;
            if (bindingSource != null)
            {
                return Control == bindingSource.Control;
            }

            return false;
        }


        public override int GetHashCode()
        {
            return Control.GetHashCode();
        }


        internal override BindingSourceType BindingSourceType
        {
            get
            {
                return BindingSourceType.KeyBindingSource;
            }
        }


        internal override void Load(BinaryReader reader)
        {
            // Have to do this because it's a struct property? Weird.
            var temp = new KeyCombo();
            temp.Load(reader);
            Control = temp;
        }


        internal override void Save(BinaryWriter writer)
        {
            Control.Save(writer);
        }
    }
}