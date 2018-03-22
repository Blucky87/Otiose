using System.IO;
using Otiose.Input;

namespace Otiose.Devices
{
    public class MonoGamePadBindingSource : BindingSource
    {
        public override float GetValue(InputDevice inputDevice)
        {
            throw new System.NotImplementedException();
        }

        public override bool GetState(InputDevice inputDevice)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(BindingSource other)
        {
            throw new System.NotImplementedException();
        }

        public override string Name { get; }
        
        public override string DeviceName { get; }
        
        internal override BindingSourceType BindingSourceType { get; }
        
        internal override void Save(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }

        internal override void Load(BinaryReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}