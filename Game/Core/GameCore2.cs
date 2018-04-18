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
            BuildEngines();
            
        }

        private void BuildEngines()
        {
            BootstrapEnginesRoot();

            var movementSequence = new Sequencer();
            var movementCheckEngine = new MovementCheckEngine(movementSequence);
            var movementCalculationEngine = new MovementCalculationEngine();
            var movementPlacementEngine = new MovementPlacementEngine();
            var noMoveEngine = new NoMoveEngine();
        

            movementSequence.SetSequence(
                new Steps
                {
                    {
                        movementCheckEngine,
                        new To
                        {
                            { MovementCondition.CanMove, new IStep[]{ movementPlacementEngine } },
                            { MovementCondition.CanNotMove, new IStep[] { noMoveEngine } }
                        }
                    }
                });
            

            


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