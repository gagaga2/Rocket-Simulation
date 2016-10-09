using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class UniverseManager
    {

        Rocket rocket;
        Earth earth;
        Moon moon;

        int distanceFromEarth;
        int distanceFromMoon;

        public UniverseManager(Rocket r, Earth e, Moon m)
        {
            this.rocket = r;
            this.earth = e;
            this.moon = m;
        }

        public void Update()
        {
            //update rockets distance
        }


        public void Draw()
        {

        }
    }
}
