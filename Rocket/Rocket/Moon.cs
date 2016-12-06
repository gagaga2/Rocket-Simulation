using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class Moon : Planet
    {
        public Moon(UniverseManager universe)
        {
            this.universe = universe;

            innerColor = Color.Red;
            outerColor = Color.Yellow;
            mass = 7.34767309E+22;
            radian = 1739337; //Meters 1739337
            position = new Vector3(0, 6371200, 0);  //6371200
        }
    }
}
