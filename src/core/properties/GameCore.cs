

using Microsoft.Xna.Framework;

using Nez;

using Otiose.Input;
using Otiose.Input.Setup;



namespace Otiose
{
    public class GameCore : Nez.Core
    {
        protected override void Initialize()
        {
            //set up input managers
            SetupInput();

            
            //Window.ClientSizeChanged += Core;
            
            Window.AllowUserResizing = true;
            
            
            // create our Scene with the DefaultRenderer and a clear color of CornflowerBlue
            var myScene = Scene.createWithDefaultRenderer();
            
            Entity entity = myScene.createEntity("Entity1");
            
            entity.addComponent(new PlayerInputManager(PlayerIndex.One));
            
            //entity.getComponent<SpriteAnimator>().play("walk");
            // set the scene so Nez can take over

            scene = myScene;
            
            base.Initialize();
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
