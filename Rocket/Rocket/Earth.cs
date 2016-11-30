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

        public double[] AirDensity = new double[9];       //tabell med luftdensitetsvärden hämtad från (finns också i dokumentationen) http://ccmc.gsfc.nasa.gov/modelweb/models/msis_vitmo.php

        public Earth()
        {
            mass = 5.972E+24;
            radian = 6371200; //Meters
            position = new Vector3(0, 0, 0);

            //AirDensity[0] = abababab; Atmosfärens tabell ska fyllas i vid skapelse av planeten
            //AirDensity[1] = bcbcbcbc;
            //Airdensity[2].....
        }
    }
}