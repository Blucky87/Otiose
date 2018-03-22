

using Microsoft.Xna.Framework;

using Nez;

using Otiose.Input;
using Otiose.Input.Setup;



namespace Otiose
{
    public class Game1 : Nez.Core
    {


        
        protected override void Initialize()
        {
            
            InputManager.Setup();
            
            registerGlobalManager(new InputManager());
            
            //Window.ClientSizeChanged += Core;
            
            Window.AllowUserResizing = true;
            
            InputManager.Setup();
            InputManager.AddDeviceManager(new XInputDeviceManager());


            
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
            InputManager.Update();

//          if (Nez.Input.leftMouseButtonDown)
//          {
//            Debug.log(Nez.Input.scaledMousePosition);
//          }

/*            if(Input.isKeyDown(Keys.A)) {
                var img2 = otherScene.contentManager.Load<Texture2D>("DownBreathing");
                var entity2 = otherScene.createEntity("first-sprite");


                entity2.transform.position = new Vector2(100, 100);
                var subtextures2 = Subtexture.subtexturesFromAtlas(img2, 64, 64);
                var spriteAnimation2 = new SpriteAnimation(subtextures2)
                {
                    loop = true,
                    fps = 10
                };

                Sprite<int> sprite2 = new Sprite<int>(0, spriteAnimation2);
                sprite2.renderLayer = -1;
                sprite2.addAnimation(0, spriteAnimation2);
                entity2.addComponent(sprite2);
                entity2.getComponent<Sprite<int>>().play(0);
                Core.scene = otherScene;
            }
*/
            base.Update(gametime);
        }

    }
}
