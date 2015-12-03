using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Modelmanager.Models;
using Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Camera;
using Prototype_lightfieldDiplaysystemNo2.MainViewSystem;


namespace Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Modelmanager
{
    public class Modelmanager : DrawableGameComponent
    {
        List<BasicModel> models = new List<BasicModel>();

        public Modelmanager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Add models to list
            
            //models.Add(new Spaceship(Game.Content.Load<Model>(@"model\spaceship")));
            models.Add(new Dragon(Game.Content.Load<Model>(@"model\Dragon")));
            //models.Add(new Cube20(Game.Content.Load<Model>(@"model\cube20")));
             
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // Loop through all models and call Update
            for (int i = 0; i < models.Count; ++i)
            {
                models[i].Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Loop through and draw each model
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            foreach (BasicModel bm in models)
            {
                bm.Draw(((Prototype_LightfieldDisplaySystemII)Game).currentCamera);
            }
            base.Draw(gameTime);
        }

    }
}
