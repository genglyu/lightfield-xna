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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;



namespace Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Camera
{
    public class Camera : Microsoft.Xna.Framework.GameComponent
    {
        public Matrix viewMatrix { get; protected set; }
        public Matrix projectionMatrix { get; protected set; }

        public Camera(Game game,
            Vector3 centre, 
            Vector3 direction, 
            Vector3 up,

            int pixelPositionX,
            int pixelPositionY,
            float pixelWidth,
            float pixelHeight,
            float widthBetween,

            int subViewportWidth,
            int subViewportHeight,

            int displayzoneWidth, int displayzoneHeight)
            : base(game)
        {
            float factor_HW = (float)displayzoneWidth / (float)displayzoneHeight;

            viewMatrix = Matrix.CreateLookAt(centre, centre + direction, up);            
            Matrix orthographicProjectionMatrix = Matrix.CreateOrthographic( 2f*factor_HW, 2f, -100f, 3000f);
                       
            Matrix obliqueProjection = new Matrix(
                                      1, 0, 0, 0,
                                      0, 1, 0, 0,
                                      (((float)pixelPositionX + 0.5f) - ((float)subViewportWidth / 2)) * pixelWidth / widthBetween, 
                                                      (((float)subViewportHeight / 2) - ((float)pixelPositionY + 0.5f)) * pixelHeight / widthBetween,
                                                                    1,0,                                  
                                      0, 0, 0, 1);  

            projectionMatrix = obliqueProjection * orthographicProjectionMatrix; 
            
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            base.Update(gameTime);
        }
    }
}
