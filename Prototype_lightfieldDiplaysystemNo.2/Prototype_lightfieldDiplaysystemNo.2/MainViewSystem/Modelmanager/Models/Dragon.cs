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
    public class Dragon : BasicModel
    {
        //Matrix rotation = Matrix.CreateRotationY(MathHelper.Pi / 4) * Matrix.CreateRotationX(MathHelper.Pi / 8);
        //Matrix rotation = Matrix.CreateRotationY(MathHelper.Pi);
        //Matrix rotation = Matrix.CreateRotationY(0);
        Matrix rotation;
        Matrix scale;
        Matrix position;

        public Dragon(Model m)
            : base(m)
        {            
            rotation = Matrix.CreateRotationY(MathHelper.Pi / 6);
            scale = Matrix.CreateScale(0.004f);
            position = Matrix.CreateTranslation(-5.5f, 12.3f, -149f);
            //position = Matrix.CreateTranslation(-5.5f, 12.3f, -148.9f);     
        }

        public override void Update()
        {
            //rotation *= Matrix.CreateRotationY(MathHelper.Pi / 360);
        }

        public override Matrix GetWorld()
        {
            return world * scale * rotation * position;
        }
    }


}
