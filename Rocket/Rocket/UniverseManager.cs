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

        public double GetDistanceFromEarth()
        {
            float dx = this.rocket.coords.X - this.earth.position.X;
            float dy = this.rocket.coords.Y - this.earth.position.Y;

            return (dx * dx) + (dy * dy);   //osäker, borde funka, vill undvika math.* funktionerna pga performance
        }

        public double GetEarthAirDensity()
        {
            //retunera luftdensiteten utifrån tabellvärden baserat på GetDistanceFromEarth var 10:nde kilometr.
            int i = (int) Math.Round(GetDistanceFromEarth() / 10);
            return this.earth.AirDensity[i];
        }

        public void ApplyAirResistance()
        {
            int a = this.rocket.rocketArea;
            double p = GetEarthAirDensity();
            float v = this.rocket.acceleration.Y;
            float c = this.rocket.dragCoefficient;

            float drag = (float) ((p * c * a * (v * v)) / 2);       //Drag Equation

            this.rocket.forces.Y -= drag;            //FUNGERAR BARA DÅ RAKETEN ÅKER "UPP", I Y LED.
        }                                            //orolig över all variabel casting/ olika typer. ska hålla koll på i framtiden då det kan brista här

        public void Update()
        {
            //update rockets distance
        }

        public void Draw()
        {
            //rita värden av funktioner som text på skärmen
        }
    }
}
