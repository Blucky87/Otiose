﻿
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Console;
using Nez.Textures;
using Nez.Sprites;
using Nez.UI;
using Otiose.Input.Setup;
using Otiose.Sprites;


namespace Otiose
{
    public class Game1 : Core
    {
        public Game1() : base() {
            
        }

        Scene otherScene;
        public static ulong ticks = 0;
        public static float delta = 0;
        
        protected override void Initialize()
        {
            
            //Window.ClientSizeChanged += Core;
            
            Window.AllowUserResizing = true;
            InputManager.Setup();
            
            // create our Scene with the DefaultRenderer and a clear color of CornflowerBlue
            var myScene = Scene.createWithDefaultRenderer();
            
            Entity entity = myScene.createEntity("Entity1");
            entity.transform.position = new Vector2( 300, 300 );
            
            string scmlpath = "GreyGuy/player";
            
            entity.addComponent(new PlayerInputManager());
            
            //entity.getComponent<SpriteAnimator>().play("walk");
            // set the scene so Nez can take over
            Core.scene = myScene;
            
            base.Initialize();
        }


        protected override void Update(GameTime gametime) {

          if(Nez.Input.currentKeyboardState.IsKeyDown(Keys.A))
          {
            Console.WriteLine("ah yo");
          }
            
            ticks++;
            delta = gametime.ElapsedGameTime.Milliseconds;
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
