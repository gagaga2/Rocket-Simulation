using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rocket
{
    class Earth : Planet
    {
        public Earth(UniverseManager universe)
        {
            this.universe = universe;

            innerColor = Color.Green;
            outerColor = Color.Blue;
            mass = 5.972E+24;
            radian = 6371200; //Meters
            position = new Vector3(0, 0, 0);
        }

        public override double GetAirDensity(double altitude)
        {
            //  Console.WriteLine(AirDensity[(int)(Math.Truncate((altitude / 50000)))] + " a:" + altitude + " " + (Math.Truncate(altitude / 50000)));   //Det blir rätt...

            if (altitude < 20000 && altitude > 1)
            {

                double h = altitude;    //Altituden över havsytan
                double p0 = 101.325E+3;  //Luftryck vid havsnivå. Pascal
                double T0 = 288.15;     //Temperatur vid hasvsnivå. Kelvin
                double g = 9.80665;     //Gravitationsaccelerationen vid havsnivå. m/s2
                double L = 0.0065;      //Temperature "Lapsrate". K/m
                double R = 8.31447;     //Ideala Gas-konstanten. J/(mol * K)
                double M = 0.0289644;   //Molmassan för torr luft. kg/mol 

                //Lufttrycket som en funktion av h (altituden)
                double p = p0 * Math.Pow((1 - ((L * h) / T0)), ((g * M) / (R * L)));

                //Temperaturen som en funktion av h (altituden)
                double T = (T0 - (L * h));

                //Luftdensiteten som en funktion av h (altituden)
                double density = ((p * M) / (R * T));

                https://en.wikipedia.org/wiki/Density_of_air
                return density;
            }
            else
            {
                return 0;
            }
        }
    }
}