using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Project_X_s
{
    /// <summary>
    /// IUpdateable インターフェイスを実装したゲーム コンポーネントです。
    /// </summary>
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spritebacth;

        private Texture2D menuStartTexture;
        private Texture2D menuOptionTexture;
        private Texture2D menuExitTexture;

        private Texture2D menuStartSelectedTexture;
        private Texture2D menuOptionSelectedTexture;
        private Texture2D menuExitSelectedTexture;

        private Texture2D menuTitleLogoTexture;

        private Texture2D menuPushKeyTexture;
        private Texture2D menuPushkeyBlurTexture;

        Vector2 StartTextureCenterPos;
        Vector2 OptionTextureCenterPos;
        Vector2 ExitTextureCenterPos;

        Vector2 PushKeyTextureCenterPos;

        Vector2 position1;
        Vector2 position2;
        Vector2 position3;

        Vector2 TitlePosition;

        Vector2 PushKeyPosition;

        int BlurValue;

        public enum Menu
        {
            Start,
            Option,
            Exit
        }

        Menu menu = Menu.Start;

        bool KeyPushed = false;
        bool selected = false;
        bool isPlus = true;

        KeyboardState keyboardState;
        KeyboardState oldKeyboardState;

        GamePadState gamePadState;
        GamePadState oldGamePadState;

       
        public MenuComponent(Game game)
            : base(game)
        {
            // TODO: ここで子コンポーネントを作成します。
        }

        /// <summary>
        /// ゲーム コンポーネントの初期化を行います。
        /// ここで、必要なサービスを照会して、使用するコンテンツを読み込むことができます。
        /// </summary>
        public override void Initialize()
        {
            // TODO: ここに初期化のコードを追加します。

            //初期位置の初期化
            position1 = new Vector2(960.0f, 700.0f);
            position2 = new Vector2(960.0f, 820.0f);
            position3 = new Vector2(960.0f, 940.0f);

            TitlePosition = new Vector2(450.0f, 100.0f);

            PushKeyPosition = new Vector2(960.0f, 800.0f);

            
            //this.Enabled=false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spritebacth = new SpriteBatch(GraphicsDevice);

            menuStartTexture = Game.Content.Load<Texture2D>("Menu/01_title_start");
            menuOptionTexture = Game.Content.Load<Texture2D>("Menu/01_title_option");
            menuExitTexture = Game.Content.Load<Texture2D>("Menu/01_title_exit");

            menuStartSelectedTexture = Game.Content.Load<Texture2D>("Menu/01_title_start2");
            menuOptionSelectedTexture = Game.Content.Load<Texture2D>("Menu/01_title_option2");
            menuExitSelectedTexture = Game.Content.Load<Texture2D>("Menu/01_title_exit2");

            menuTitleLogoTexture = Game.Content.Load<Texture2D>("Menu/X's_Addon2");

            menuPushKeyTexture = Game.Content.Load<Texture2D>("Menu/01_title_push1");
            menuPushkeyBlurTexture = Game.Content.Load<Texture2D>("Menu/01_title_push2");

            StartTextureCenterPos = new Vector2(menuStartTexture.Width / 2, menuStartTexture.Height / 2);
            OptionTextureCenterPos = new Vector2(menuOptionTexture.Width / 2, menuOptionTexture.Height / 2);
            ExitTextureCenterPos = new Vector2(menuExitTexture.Width / 2, menuExitTexture.Height / 2);
            PushKeyTextureCenterPos = new Vector2(menuPushKeyTexture.Width / 2, menuPushKeyTexture.Height / 2);

        }


        /// <summary>
        /// ゲーム コンポーネントが自身を更新するためのメソッドです。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: ここにアップデートのコードを追加します。
            
            if (BlurValue <= 250 && isPlus)
            {
                BlurValue += 5;
                if(BlurValue==255)
                    isPlus = false;
            }
            else if(BlurValue>=5 && !isPlus)
            {
                BlurValue -= 5;
                if(BlurValue==0)
                    isPlus = true;
            }
            if (selected)
            {
                selected = false;
            }
            oldGamePadState = gamePadState;
            gamePadState = GamePad.GetState(PlayerIndex.One);

            oldKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyUp(Keys.Enter) && oldKeyboardState.IsKeyDown(Keys.Enter))
                KeyPushed = true;
            if (gamePadState.Buttons.Start == ButtonState.Pressed)
                KeyPushed = true;
                
            

            if (KeyPushed)
            {
                if (keyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
                {
                    if (Menu.Start < menu)
                    {
                        menu--;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down))
                {
                    if (menu < Menu.Exit)
                    {
                        menu++;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Enter) && oldKeyboardState.IsKeyUp(Keys.Enter))
                {
                    selected = true;
                }
            }

            base.Update(gameTime);
        }



        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spritebacth.Begin();

            spritebacth.Draw(menuTitleLogoTexture, TitlePosition, null, Color.White, 0.0f, Vector2.Zero, new Vector2(2.5f, 2.5f), SpriteEffects.None, 0.0f);


            if (KeyPushed)
            {
                switch (menu)
                {
                    case Menu.Start:
                        spritebacth.Draw(menuStartSelectedTexture, position1, null, Color.White, 0.0f, StartTextureCenterPos, new Vector2(1.2f, 1.2f), SpriteEffects.None, 0.0f);
                        spritebacth.Draw(menuOptionTexture, position2, null, Color.White, 0.0f, OptionTextureCenterPos, new Vector2(1.0f, 1.0f), SpriteEffects.None, 0.0f);
                        spritebacth.Draw(menuExitTexture, position3, null, Color.White, 0.0f, ExitTextureCenterPos, new Vector2(1.0f, 1.0f), SpriteEffects.None, 0.0f);
                        break;
                    case Menu.Option:
                        spritebacth.Draw(menuStartTexture, position1, null, Color.White, 0.0f, StartTextureCenterPos, new Vector2(1.0f, 1.0f), SpriteEffects.None, 0.0f);
                        spritebacth.Draw(menuOptionSelectedTexture, position2, null, Color.White, 0.0f, OptionTextureCenterPos, new Vector2(1.2f, 1.2f), SpriteEffects.None, 0.0f);
                        spritebacth.Draw(menuExitTexture, position3, null, Color.White, 0.0f, ExitTextureCenterPos, new Vector2(1.0f, 1.0f), SpriteEffects.None, 0.0f);
                        break;
                    case Menu.Exit:
                        spritebacth.Draw(menuStartTexture, position1, null, Color.White, 0.0f, StartTextureCenterPos, new Vector2(1.0f, 1.0f), SpriteEffects.None, 0.0f);
                        spritebacth.Draw(menuOptionTexture, position2, null, Color.White, 0.0f, OptionTextureCenterPos, new Vector2(1.0f, 1.0f), SpriteEffects.None, 0.0f);
                        spritebacth.Draw(menuExitSelectedTexture, position3, null, Color.White, 0.0f, ExitTextureCenterPos, new Vector2(1.2f, 1.2f), SpriteEffects.None, 0.0f);
                        break;
                }
            }
            else
            {
                spritebacth.Draw(menuPushKeyTexture, PushKeyPosition, null, new Color(255,255,255,255), 0.0f, PushKeyTextureCenterPos, new Vector2(1.5f, 1.5f), SpriteEffects.None, 0.0f);
                spritebacth.Draw(menuPushkeyBlurTexture, PushKeyPosition, null, new Color(255, 255, 255, BlurValue), 0.0f, PushKeyTextureCenterPos, new Vector2(1.5f, 1.5f), SpriteEffects.None, 0.0f);
            }

            spritebacth.End();


            base.Draw(gameTime);
        }
        public Menu selectedMenu
        {
            get { return menu; }
        }
        public bool IsSelected()
        {
            return selected;
        }
    }
}
