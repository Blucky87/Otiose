using System;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Microsoft.Xna.Framework;
using Otiose.svelto;
using VelcroPhysics.Dynamics;

namespace Core.svelto.implementors
{
    class RigidBodyComponentImplementor : IRigidBodyComponent, IImplementor
    {
        public Body Body { get; set; }
    }

    class PhysicsForceComponent : IPhysicsForceComponent, IImplementor
    {
        public Vector2 Force { get; set; }
    }

    class PhysicsImpulseComponent : IPhysicsImpulseComponent, IImplementor
    {
        public Vector2 Impulse { get; set; }
    }

    class PhysicsTorqueComponent : IPhysicsTorqueComponent, IImplementor
    {
        public float Torque { get; set; }
    }
}
