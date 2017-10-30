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
    /// 基底 Game クラスから派生した、ゲームのメイン クラスです。
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MenuComponent menuCompo;
        PlayComponent playCompo;

        //private GraphicsDeviceManager graphicsDeviceManager;

        enum GameMode
        {
            Menu,
            Play
        }

        GameMode mode;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1980;
            graphics.PreferredBackBufferHeight = 1020;
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// ゲームが実行を開始する前に必要な初期化を行います。
        /// ここで、必要なサービスを照会して、関連するグラフィック以外のコンテンツを
        /// 読み込むことができます。base.Initialize を呼び出すと、使用するすべての
        /// コンポーネントが列挙されるとともに、初期化されます。
        /// </summary>
        protected override void Initialize()
        {
            // TODO: ここに初期化ロジックを追加します。

            

            menuCompo = new MenuComponent(this);
            playCompo = new PlayComponent(this);
            if (!Components.Contains(menuCompo))
            {
                Components.Add(menuCompo);
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent はゲームごとに 1 回呼び出され、ここですべてのコンテンツを
        /// 読み込みます。
        /// </summary>
        protected override void LoadContent()
        {
            // 新規の SpriteBatch を作成します。これはテクスチャーの描画に使用できます。
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: this.Content クラスを使用して、ゲームのコンテンツを読み込みます。
        }

        /// <summary>
        /// UnloadContent はゲームごとに 1 回呼び出され、ここですべてのコンテンツを
        /// アンロードします。
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: ここで ContentManager 以外のすべてのコンテンツをアンロードします。
        }

        /// <summary>
        /// ワールドの更新、衝突判定、入力値の取得、オーディオの再生などの
        /// ゲーム ロジックを、実行します。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲームの終了条件をチェックします。
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)==true)
                this.Exit();

            // TODO: ここにゲームのアップデート ロジックを追加します。

            switch(mode)
            {
                case GameMode.Menu:
                    
                    //メニューが選択された場合
                    if(menuCompo.IsSelected())
                    {
                        switch(menuCompo.selectedMenu)
                        {
                            case MenuComponent.Menu.Start:
                                Components.Remove(menuCompo);
                                Components.Add(playCompo);

                                mode = GameMode.Play;
                                break;

                            case MenuComponent.Menu.Exit:
                                Exit(); //アプリ終了
                                break;
                        }
                    }
                    break;

                case GameMode.Play:
                    //ゲーム中の処理を追加
                    if (PlayerInput.StartButton(PlayerIndex.One))
                    { }
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// ゲームが自身を描画するためのメソッドです。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: ここに描画コードを追加します。
            

            base.Draw(gameTime);
        }
    }
}
