using System.Collections.Generic;
using Core.components;
using Core.svelto.components;
using Core.svelto.engines;
using Core.svelto.entityviews;
using Core.svelto.implementors;
using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;
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

            var playerActionSetContext = new PlayerActionContextComponent();
            var playerActionSetComponent = new PlayerActionSetComponent(input.playerActionSetOne);

            var playerActionLeftStickComponent = new PlayerTwoAxisActionComponent(input.playerActionSetOne.LeftStick);
            var playerActionRightStickComponent = new PlayerTwoAxisActionComponent(input.playerActionSetOne.RightStick);
            var playerActionOneComponent = new PlayerActionComponent(input.playerActionSetOne.Action1);
            var playerActionTwoComponent = new PlayerActionComponent(input.playerActionSetOne.Action2);

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

            gameEnginesRoot.AddEngine(movementDriverEngine);
            gameEnginesRoot.AddEngine(playerActionSetUpdateEngine);
            gameEnginesRoot.AddEngine(playerActionLeftStickUpdateEngine);

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




//        private void genUi()
//        {
//            UICanvas
//            // tables are very flexible and make good candidates to use at the root of your UI. They work much like HTML tables but with more flexibility.
//            var table = stage.addElement(new Table());
//
//            // tell the table to fill all the available space. In this case that would be the entire screen.
//            table.setFillParent(true);
//
//            // add a ProgressBar
//            var bar = new ProgressBar(0, 1, 0.1f, false, ProgressBarStyle.create(Color.Black, Color.White));
//            table.add(bar);
//
//            // this tells the table to move on to the next row
//            table.row();
//
//            // add a Slider
//            var slider = new Slider(0, 1, 0.1f, false, SliderStyle.create(Color.DarkGray, Color.LightYellow));
//            table.add(slider);
//            table.row();
//
//            // if creating buttons with just colors (PrimitiveDrawables) it is important to explicitly set the minimum size since the colored textures created
//            // are only 1x1 pixels
//            var button = new Button(ButtonStyle.create(Color.Black, Color.DarkGray, Color.Green));
//            table.add(button).setMinWidth(100).setMinHeight(30);
//        }

    }
}