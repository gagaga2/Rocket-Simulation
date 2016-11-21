using Microsoft.Xna.Framework;
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

        double rocketDistanceFromEarth = 0;
        float rocketRotationRelativeToEarth = 0;

        public UniverseManager(Rocket _rocket, Earth _earth, Moon _moon)
        {
            rocket = _rocket;
            earth = _earth;
            moon = _moon;
        }

        public float getRocketRotationRelativeToEarth()
        {
            float x = rocket.coords.X;
            float y = -rocket.coords.Y;
            float angle = 0;

            angle = (float)(Math.Atan2(y, x) * 180 / Math.PI);
            angle = angle % 360;

            if (angle < 0)
            {
                angle += 360;
            }

            Console.WriteLine(angle);
            return angle;
        }

        public double GetDistanceFromEarth()
        {
            float dx = this.rocket.coords.X - this.earth.position.X;
            float dy = this.rocket.coords.Y - this.earth.position.Y;

            return Math.Sqrt((dx * dx) + (dy * dy));   //osäker, borde funka, vill undvika math.* funktionerna pga performance
        }

        public double GetEarthAirDensity()
        {
            //retunera luftdensiteten utifrån tabellvärden baserat på GetDistanceFromEarth var 10:nde kilometr.
            int i = (int) Math.Round(GetDistanceFromEarth() / 10);
            return this.earth.AirDensity[i];
        }

        public void ApplyEarthGravity ()
        {
            double G = 6.674E-11;
            double F = G * ((rocket.mass * earth.mass) / Math.Pow(GetDistanceFromEarth(), 2));
        }

        public void ApplyAirResistance()
        {
            int a = this.rocket.rocketArea;
            double p = GetEarthAirDensity();
            float v = this.rocket.acceleration.Y;
            float c = this.rocket.dragCoefficient;

            float drag = (float) ((p * c * a * (v * v)) / 2);       //Drag Equation

            rocket.forces.Y -= drag;            //FUNGERAR BARA DÅ RAKETEN ÅKER "UPP", I Y LED.
        }                                            //orolig över all variabel casting/ olika typer. ska hålla koll på i framtiden då det kan brista här

        public void Update()
        {
            rocketDistanceFromEarth = GetDistanceFromEarth();
            rocketRotationRelativeToEarth = getRocketRotationRelativeToEarth();
        }

        public void Draw()
        {
            //rita värden av funktioner som text på skärmen
        }
    }
}
