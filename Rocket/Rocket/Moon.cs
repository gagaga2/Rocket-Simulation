using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class Moon
    {
        double mass { get; set; }                        //
        int radian { get; set; }
        Vector2 position { get; set; }                   //position (?,???)
        float scale { get; set; }                        //for zoomign purposes

        public Moon()
        {
            this.mass = 7.342E+22;
            this.radian = 1737;
        }

        public int GetDistance(Rocket r) //WIP
        {
            return 0;
        }

        public void Draw(SpriteBatch spritebatch)
        {

            
        }

    }
}
