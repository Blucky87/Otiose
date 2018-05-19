using Otiose.svelto;
using VelcroPhysics.Factories;
using Microsoft.Xna.Framework;
using VelcroPhysics.Dynamics;

namespace Core.svelto.components
{
    public interface IRigidBodyComponent : IComponent
    {
        Body Body { get; set; }
    }

    public interface IPhysicsForceComponent : IComponent
    {
        Vector2 Force { get; set; }
    }

    public interface IPhysicsImpulseComponent : IComponent
    {
        Vector2 Impulse { get; set; }
    }

    public interface IPhysicsTorqueComponent : IComponent
    {
        float Torque { get; set; }
    }

}
