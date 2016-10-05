using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class UniverseManager
    {

        Planet[] bodies;

        public UniverseManager() { }

        public void CreateUniverse()
        {
            bodies[0] = new Planet("Earth", 2000, 100);
            bodies[1] = new Planet("Moon", 500, 50);
        }

        public void ApplyGravitationalPull(Rocket r)
        {
            foreach (Planet p in bodies)
            {
                //distanceFrom(r) * p.mass
            }
        }

        public void Draw()
        {
            foreach(Planet p in bodies)
            {
                //rita
            }
        }
    }
}
