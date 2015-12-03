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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


using Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Modelmanager.Models;

namespace Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Modelmanager.Models
{
    public class Spaceship : BasicModel
    {
        float speed = 1f;
        //Matrix rotation = Matrix.CreateRotationY(MathHelper.Pi / 4) * Matrix.CreateRotationX(MathHelper.Pi / 8);
        //Matrix rotation = Matrix.CreateRotationY(MathHelper.Pi);
        //Matrix rotation = Matrix.CreateRotationY(0);
        
        Matrix rotation;
        Matrix scale;
        Matrix position;
        
        /*
        Matrix rotation = Matrix.CreateRotationY(MathHelper.Pi / 8);
        Matrix scale = Matrix.CreateScale(0.1f);
        Matrix position = Matrix.CreateTranslation(0f, 0f, 0.0f);
        */
        public Spaceship(Model m)
            : base(m)
        {
            rotation = Matrix.CreateRotationY(MathHelper.Pi / 8);
            scale = Matrix.CreateScale(0.1f);
            position = Matrix.CreateTranslation(0f, 0f, -1f);
            
        }

        public override void Update()
        {
           // rotation *= Matrix.CreateRotationY(MathHelper.Pi / 360);
        }

        public override Matrix GetWorld()
        {
            return world * scale * rotation * position;            
        }
    }    
}
