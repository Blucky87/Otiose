

using System.ComponentModel.DataAnnotations;
using Core.components;
using Microsoft.Xna.Framework;

using Nez;

using Otiose.Input;
using Otiose.Input.Setup;
using Otiose.Input.Setup.Actions;


namespace Otiose
{
    public class GameCore : Nez.Core
    {
        protected override void Initialize()
        {
            SetupWindow();
            SetupGameCommandManager();
            SetupInput();

           
            var mainScene = Scene.createWithDefaultRenderer();
            
            //Create component that will represent who owns the entity
            var playerIndexComponent = new PlayerIndexComponent(PlayerIndex.One);

            //Create Action Set Component to hold link between binding device and binded action
            var actionSetComponent = new PlayerActionSetComponent();
            actionSetComponent.PlayerActionSet = new PlayerActionSet();
            actionSetComponent.PlayerActionSet.SetupDefaultBindings();
            actionSetComponent.PlayerActionSet.SetupDefaultKeebBindings();
            
            //Create controller profile component to hold behavior of actions
            var controlProfileComponent = new ControllerProfileComponent();
            
            var movementComponent = new MovementComponent();

            //create service to 
            var matcher = new Matcher().all( typeof( PlayerActionSetComponent ), typeof( ControllerProfileComponent ) );
            var playerActionSetToControllerProfileSystem = new PlayerActionSetToControllerProfileSystem(matcher);


            matcher = new Matcher().all(typeof(PlayerActionSetComponent));
            var playerActionUpdateSystem = new PlayerActionUpdateSystem(matcher);

            matcher = new Matcher().all(typeof(PlayerIndexComponent), typeof(PlayerActionSetComponent));
            var playerDeviceToActionSet = new PlayerDeviceToActionSetSystem(matcher);

            
            var entityHero = mainScene.createEntity("Hero");
            
            entityHero.addComponent(playerIndexComponent);
            entityHero.addComponent(actionSetComponent);
            entityHero.addComponent(controlProfileComponent);
            entityHero.addComponent(movementComponent);

            mainScene.addEntityProcessor(playerDeviceToActionSet);
            mainScene.addEntityProcessor(playerActionSetToControllerProfileSystem);
            mainScene.addEntityProcessor(playerActionUpdateSystem);
           
            entityHero.getComponent<ControllerProfileComponent>().ControllerProfile = new RoamProfile(entityHero);
            
            scene = mainScene;
            
            base.Initialize();
        }
        
        protected override void Update(GameTime gametime) {
           
            base.Update(gametime);
        }

        
        private void SetupWindow()
        {
            Window.AllowUserResizing = true;
        }
        
        private void SetupGameCommandManager()
        {
            GameCommandManager gameCommandManager = new GameCommandManager();
            
            registerGlobalManager(gameCommandManager);
        }

        void SetupInput()
        {
            InputManager inputManager = new InputManager();
            GamePadInputDeviceManager gamePadInputDeviceManager = new GamePadInputDeviceManager();
            
            inputManager.Setup();
            inputManager.AddDeviceManager(gamePadInputDeviceManager);
            
            registerGlobalManager(inputManager);
        }
    }
}

