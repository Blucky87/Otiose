using Microsoft.Xna.Framework;
using Otiose.svelto.engines;
using Svelto.ECS;
using VelcroPhysics.Dynamics;

namespace Otiose
{
    public class GameCore2 : Nez.Core
    {
        private EnginesRoot gameEnginesRoot;
        private IEntityFactory gameEngineEntityFactory;
        private IEntityFunctions gameEngineEntityFunctions;
        private World world;

        protected override void Initialize()
        {
            base.Initialize();

            world = new World(Vector2.Zero);

            BuildEngines();
        }

        private void BuildEngines()
        {
            BootstrapEnginesRoot();
        }

        private void BootstrapEnginesRoot()
        {
            gameEnginesRoot = new EnginesRoot(new MonoGameNezUpdateScheduler());
            gameEngineEntityFactory = gameEnginesRoot.GenerateEntityFactory();
            gameEngineEntityFunctions = gameEnginesRoot.GenerateEntityFunctions();
        }

        protected override void Update(GameTime gametime)
        {
            base.Update(gametime);
        }


    }
}