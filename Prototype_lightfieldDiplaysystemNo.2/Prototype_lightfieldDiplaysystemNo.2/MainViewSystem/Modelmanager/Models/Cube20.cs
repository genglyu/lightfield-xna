using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Modelmanager.Models;



namespace Prototype_lightfieldDiplaysystemNo2.MainViewSystem.Modelmanager.Models
{
    class Cube20: BasicModel
    {
        Matrix rotation = Matrix.CreateRotationY(MathHelper.Pi/6);
        Matrix scale = Matrix.CreateScale(0.025f);
        Matrix position = Matrix.CreateTranslation(0f, -0.4f, 0f);

        public Cube20(Model m)
            : base(m)
        {

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
