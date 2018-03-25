

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
            
            //set up input managers
            SetupInput();

           
            var myScene = Scene.createWithDefaultRenderer();
            
            Entity entity = myScene.createEntity("Hero");
            entity.addComponent(new PlayerIndexComponent(PlayerIndex.One));

            var actionSet = new PlayerActionSetComponent();
            actionSet.PlayerActionSet = new InputActionSet();
            entity.addComponent(actionSet);
            
            var controlProfile = new PlayerControllerProfileComponent();
            controlProfile.ControllerProfile = new RoamProfile(entity);
            entity.addComponent(controlProfile);

            var matcher = new Matcher().all( typeof( PlayerActionSetComponent ), typeof( PlayerControllerProfileComponent ) );
            var actionProfileRoutingSystem = new ActionProfileRoutingSystem(matcher);


            matcher = new Matcher().all(typeof(PlayerActionSetComponent));
            var playerActionUpdateSystem = new PlayerActionUpdateSystem(matcher);

            matcher = new Matcher().all(typeof(PlayerIndexComponent), typeof(PlayerActionSetComponent));
            var playerDeviceToActionSet = new PlayerDeviceToActionSetSystem(matcher);



            myScene.addEntityProcessor(playerDeviceToActionSet);
            myScene.addEntityProcessor(actionProfileRoutingSystem);
            myScene.addEntityProcessor(playerActionUpdateSystem);
            
            
            
            //create plaeyraction set & attach it to entity
            

            
            
            
            scene = myScene;
            
            base.Initialize();
        }

        private void SetupWindow()
        {
             Window.AllowUserResizing = true;
        }


        protected override void Update(GameTime gametime) {
           
            base.Update(gametime);
        }




        void SetupInput()
        {
            InputManager inputManager = new InputManager();
            inputManager.Setup();

            var gamePadInputDeviceManager = new GamePadInputDeviceManager();
            
            InputManager.AddDeviceManager(gamePadInputDeviceManager);
            
            registerGlobalManager(inputManager);
        }

    }
}
