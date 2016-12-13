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

        public double[] AirDensity = new double[21];       //tabell med luftdensitetsvärden hämtad från (finns också i dokumentationen) http://ccmc.gsfc.nasa.gov/modelweb/models/msis_vitmo.php

        public Earth(UniverseManager universe)
        {
            this.universe = universe;

            innerColor = Color.Green;
            outerColor = Color.Blue;
            mass = 5.972E+24;
            radian = 6371200; //Meters
            position = new Vector3(0, 0, 0);

            AirDensity[0] = 1.340E-03;  //0km
            AirDensity[1] = 8.602E-07;  //50km
            AirDensity[2] = 5.357E-10;  //100km
            AirDensity[3] = 2.185E-12;  //150km
            AirDensity[4] = 3.127E-13;  //200km
            AirDensity[5] = 7.695E-14;  //250km
            AirDensity[6] = 2.396E-14;  //300km
            AirDensity[7] = 8.586E-15;  //350km
            AirDensity[8] = 3.373E-15;  //400km
            AirDensity[9] = 1.411E-15;  //450km
            AirDensity[10] = 6.195E-16; //500km
            AirDensity[11] = 2.849E-16; //550km
            AirDensity[12] = 1.382E-16; //600km
            AirDensity[13] = 7.163E-17; //650km
            AirDensity[14] = 4.025E-17; //700km
            AirDensity[15] = 2.473E-17; //750km
            AirDensity[16] = 1.658E-17; //800km
            AirDensity[17] = 1.195E-17; //850km
            AirDensity[18] = 9.107E-18; //900km
            AirDensity[19] = 7.206E-18; //950km
            AirDensity[20] = 5.845E-18; //1000km
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