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


        public UniverseManager(Rocket r, Earth e, Moon m)
        {
            this.rocket = r;
            this.earth = e;
            this.moon = m;
        }

        public void ApplyAirResistance(Rocket r, Earth e)
        {
            r.forces.Y += (r.rocketArea * e.GetAirDensity(r));
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
