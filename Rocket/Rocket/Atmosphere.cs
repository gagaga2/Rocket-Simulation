using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class Atmosphere : Planet
    {
        public Atmosphere(UniverseManager universe, double mass, int radian, Color outerColor, Color innerColor)
        {
            this.position = new Vector3(0, 0, 1);
            this.universe = universe;
            this.mass = mass;
            this.radian = radian;
            this.outerColor = outerColor;
            this.innerColor = innerColor;
        }
    }
}
