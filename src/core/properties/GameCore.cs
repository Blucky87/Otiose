

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

           
            Scene myScene = Scene.createWithDefaultRenderer();
            
            //Create component that will represent who owns the entity
            PlayerIndexComponent playerIndexComponent = new PlayerIndexComponent(PlayerIndex.One);

            //Create Action Set Component to hold link between binding device and binded action
            PlayerActionSetComponent actionSetComponent = new PlayerActionSetComponent();
            actionSetComponent.PlayerActionSet = new PlayerActionSet();
            actionSetComponent.PlayerActionSet.SetupDefaultBindings();
            actionSetComponent.PlayerActionSet.SetupDefaultKeebBindings();
            
            //Create controller profile component to hold behavior of actions
            ControllerProfileComponent controlProfileComponent = new ControllerProfileComponent();

            //create service to 
            Matcher matcher = new Matcher().all( typeof( PlayerActionSetComponent ), typeof( ControllerProfileComponent ) );
            ActionProfileRoutingSystem actionProfileRoutingSystem = new ActionProfileRoutingSystem(matcher);


            matcher = new Matcher().all(typeof(PlayerActionSetComponent));
            PlayerActionUpdateSystem playerActionUpdateSystem = new PlayerActionUpdateSystem(matcher);

            matcher = new Matcher().all(typeof(PlayerIndexComponent), typeof(PlayerActionSetComponent));
            PlayerDeviceToActionSetSystem playerDeviceToActionSet = new PlayerDeviceToActionSetSystem(matcher);

            
            Entity entity = myScene.createEntity("Hero");
            
            entity.addComponent(playerIndexComponent);
            entity.addComponent(actionSetComponent);
            entity.addComponent(controlProfileComponent);

            myScene.addEntityProcessor(playerDeviceToActionSet);
            myScene.addEntityProcessor(actionProfileRoutingSystem);
            myScene.addEntityProcessor(playerActionUpdateSystem);
           
            entity.getComponent<ControllerProfileComponent>().ControllerProfile = new RoamProfile(entity);
            
            scene = myScene;
            
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
