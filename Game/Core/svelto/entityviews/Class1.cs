using System;
using System.Collections.Generic;
using System.Text;
using Core.svelto.components;
using Svelto.ECS;

namespace Core.svelto.entityviews
{
    class PhysicsEntityView : EntityView
    {
        public IRigidBodyComponent RigidBody;
        public IPhysicsForceComponent Force;
        public IPhysicsImpulseComponent Impulse;
        public IPhysicsTorqueComponent Torque;
    }
}
