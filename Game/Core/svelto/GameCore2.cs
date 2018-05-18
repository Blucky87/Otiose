using Microsoft.Xna.Framework;
using Otiose.svelto.engines;
using Svelto.ECS;

namespace Otiose
{
    public class GameCore2 : Nez.Core
    {
        private EnginesRoot gameEnginesRoot;
        private IEntityFactory gameEngineEntityFactory;
        private IEntityFunctions gameEngineEntityFunctions;

        protected override void Initialize()
        {
            base.Initialize();

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