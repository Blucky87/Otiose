using System;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Microsoft.Xna.Framework;
using Otiose;
using Otiose.Input;
using Otiose.Input.Setup;
using Otiose.svelto;
using Otiose.svelto.components;

namespace Core.svelto.implementors
{
    class MovementDriverComponent : IMovementDriverComponent, IImplementor
    {

        public float X { get; set; }

        public float Y { get; set; }
    }


}
