using System.Collections.Generic;
using Core.components;
using Core.svelto.components;
using Core.svelto.engines;
using Core.svelto.entityviews;
using Core.svelto.implementors;
using Microsoft.Xna.Framework;
using Otiose.Input;
using Otiose.Input.Setup;
using Otiose.svelto;
using Otiose.svelto.engines;
using Svelto.ECS;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Factories;
using VelcroPhysics.Utilities;

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

            BuildEngines();
            var input = SetupInput();







            List<IImplementor> testEntityImplementors = new List<IImplementor>();
            world = new World(Vector2.Zero);

            var floor = BodyFactory.CreateBody(world);

            var body = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(64f), ConvertUnits.ToSimUnits(64f), 1f, Vector2.One, bodyType: BodyType.Dynamic);
            body.Mass = 1f;
            body.SetTransform(Vector2.Zero, 0f);
            

            var rigidBodyComponent = new RigidBodyComponentImplementor(body);
            var forceComponent = new PhysicsForceComponent();
            var impulseComponent = new PhysicsImpulseComponent();
            var torqueComponent = new PhysicsTorqueComponent();

            testEntityImplementors.Add(rigidBodyComponent);
            testEntityImplementors.Add(forceComponent);
            testEntityImplementors.Add(impulseComponent);
            testEntityImplementors.Add(torqueComponent);

            //add movement driver, the vector value inside 
            var movementDriverComponent = new MovementDriverComponent();

            var playerActionSetComponent = new PlayerActionSetComponent(input.playerActionSetOne);
            var playerActionSetContext = new PlayerActionContextComponent();
            var playerActionLeftStickComponent = new PlayerTwoAxisActionComponent();
            var playerActionRightStickComponent = new PlayerTwoAxisActionComponent();
            var playerActionOneComponent = new PlayerActionComponent();
            var playerActionTwoComponent = new PlayerActionComponent();

            testEntityImplementors.Add(movementDriverComponent);
            testEntityImplementors.Add(playerActionOneComponent);
            testEntityImplementors.Add(playerActionTwoComponent);
            testEntityImplementors.Add(playerActionSetComponent);
            testEntityImplementors.Add(playerActionLeftStickComponent);
            testEntityImplementors.Add(playerActionRightStickComponent);
            testEntityImplementors.Add(playerActionSetContext);
            

            var Joint = JointFactory.CreateFrictionJoint(world, floor, body);
            Joint.MaxForce = 80f;
            Joint.MaxTorque = 80f;



            var playerActionLeftStickSequencer = new Sequencer();

            var playerActionLeftStickUpdateEngine = new PlayerActionLeftStickUpdateEngine(playerActionLeftStickSequencer);
            var basicMoveEngine = new BasicMoveEngine();
            var physicsForceEngine = new PhysicsForceEngine();
            var movementDriverEngine = new MovementDriverEngine();
            var playerActionSetUpdateEngine = new PlayerActionSetUpdateEngine();

            var testEngine = new TestEngine();

            playerActionLeftStickSequencer.SetSequence(
                new Steps
                {
                    {
                        playerActionLeftStickUpdateEngine,
                        new To
                        {
                            {PlayerActionContext.Roam, new IStep[] {basicMoveEngine}},
                            {PlayerActionContext.UI, new IStep[] {basicMoveEngine}},

                        }
                    },
                    {
                        basicMoveEngine,
                        new To
                        {
                            new IStep[] { testEngine }
//                            {PlayerActionContext.Roam, new IStep[] {basicMoveEngine}},
//                            {PlayerActionContext.UI, new IStep[] {basicMoveEngine}},

                        }
                    }
                }

            );

            
            gameEnginesRoot.AddEngine(testEngine);
            gameEnginesRoot.AddEngine(basicMoveEngine);
            gameEnginesRoot.AddEngine(physicsForceEngine);
            gameEnginesRoot.AddEngine(playerActionLeftStickUpdateEngine);
            gameEnginesRoot.AddEngine(movementDriverEngine);
            gameEnginesRoot.AddEngine(playerActionSetUpdateEngine);


            gameEngineEntityFactory.BuildEntity<TestEntityDescriptor>(1, testEntityImplementors.ToArray());
        }

        private void BuildEngines()
        {
            BootstrapEnginesRoot();
        }

        private void BootstrapEnginesRoot()
        {
            var scheduler = new MonoGameNezUpdateScheduler();
            registerGlobalManager(scheduler.scheduler);
            gameEnginesRoot = new EnginesRoot(scheduler);


            gameEngineEntityFactory = gameEnginesRoot.GenerateEntityFactory();
            gameEngineEntityFunctions = gameEnginesRoot.GenerateEntityFunctions();
        }

        protected override void Update(GameTime gametime)
        {
            base.Update(gametime);

            world.Step((float)gametime.ElapsedGameTime.TotalMilliseconds * 0.001f);
            
        }


        private (PlayerActionSet playerActionSetOne, PlayerActionSet playerActionSetTwo) SetupInput()
        {
            InputManager inputManager = new InputManager();
            GamePadInputDeviceManager gamePadInputDeviceManager = new GamePadInputDeviceManager();

            inputManager.Setup();
            inputManager.AddDeviceManager(gamePadInputDeviceManager);

            var playerActionSetOne = new PlayerActionSet();
            playerActionSetOne.SetupDefaultBindings();
            playerActionSetOne.SetupDefaultKeebBindings();
//            playerActionSetOne.Device = InputManager.devices[(int)PlayerIndex.One];
//
            var playerActionSetTwo = new PlayerActionSet();
//            playerActionSetTwo.Device = InputManager.devices[(int)PlayerIndex.Two];




            registerGlobalManager(inputManager);

            return (playerActionSetOne, playerActionSetTwo);
        }

    }
}