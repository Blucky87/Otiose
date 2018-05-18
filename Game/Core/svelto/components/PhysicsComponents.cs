using System;
using System.Collections.Generic;
using System.Text;
using Nez.AI.GOAP;
using Otiose.svelto;
using VelcroPhysics.MonoGame.Factories;
using Microsoft.Xna.Framework;
using VelcroPhysics.Dynamics;

namespace Core.svelto.components
{
    interface IRigidBodyComponent : IComponent
    {
        Body Body { get; set; }
    }

    interface IPhysicsForceComponent : IComponent
    {
        Vector2 Force { get; set; }
    }

    interface IPhysicsImpulseComponent : IComponent
    {
        Vector2 Impulse { get; set; }
    }

    interface IPhysicsTorqueComponent : IComponent
    {
        float Torque { get; set; }
    }

}
