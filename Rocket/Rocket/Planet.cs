using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class Planet
    {
        string name;
        int mass;
        int diameter;

        public Planet(string _name, int _mass, int _diameter)
        {
            name = _name;
            mass = _mass;
            diameter = _diameter;
        }
    }
}
