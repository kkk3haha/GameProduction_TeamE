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
    public class PlayComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        BasicEffect basicEffect;

        private float fogStart;
        private float fogEnd;
        private Model model;

        Model boxModel;
        Model yukaModel;

        Texture2D EnemyHPbarLayeredTexture_Under1;
        Texture2D EnemyHPbarLayeredTexture_Middle1;
        Texture2D EnemyHPbarLayeredTexture_Top1;

        //int ShowUpDamageValue;

        Vector3 cameraPosition;
        Matrix view;
        Matrix projection;

        Matrix boxMatrix;

        public enum PauseMenu
        {
            Resume,
            Back
        }

        PauseMenu PMenu = PauseMenu.Resume;


        public PlayComponent(Game game)
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

            base.Initialize();
        }
        protected override void LoadContent()
        {
            string a = "Battle/UI/EnemyStatus/02_tekiHP_sita";

            EnemyHPbarLayeredTexture_Under1 = Game.Content.Load<Texture2D>(a);
            EnemyHPbarLayeredTexture_Middle1 = Game.Content.Load<Texture2D>("Battle/UI/EnemyStatus/02_tekihp_bar");
            EnemyHPbarLayeredTexture_Top1 = Game.Content.Load<Texture2D>("Battle/UI/EnemyStatus/02_tekihp_ue");

            model = Game.Content.Load<Model>("Model");
            yukaModel = Game.Content.Load<Model>("yuka");

            cameraPosition = new Vector3(0.0f, 200.0f, 100.0f);

            fogStart = cameraPosition.Z;
            fogEnd = fogStart + 60.0f;

            view = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), GraphicsDevice.Viewport.AspectRatio, 1.0f, 10000.0f);

            boxModel = Game.Content.Load<Model>("Battle/Model/O_Cube1");

            boxMatrix = Matrix.Identity;
        }

        /// <summary>
        /// ゲーム コンポーネントが自身を更新するためのメソッドです。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: ここにアップデートのコードを追加します。
            

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            


            DrawModel(boxModel, boxMatrix);
            //PoseMenu(model);

            base.Draw(gameTime);
        }
        private void DrawModel(Model model, Matrix world)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    effect.View = view;
                    effect.Projection = projection;
                    effect.World = world;
                    /*
                    effect.FogEnabled = true;
                    effect.FogColor = Vector3.Zero;
                    effect.FogStart = fogStart;
                    effect.FogEnd = fogEnd;
                     */
                }

                mesh.Draw();
            }
        }
        
        private void Pause(Model model)
        {
            
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.FogEnabled = true;
                    effect.FogColor = Vector3.Zero;
                    effect.FogStart = fogStart;
                    effect.FogEnd = fogEnd;
                }
            }

            
        }
        private PauseMenu SelectedPauseMenu
        {
            get { return PMenu; }
        }


    }
}
