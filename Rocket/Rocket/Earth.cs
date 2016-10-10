using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rocket
{
    class Earth
    {
        double mass { get; set; }                        //TODO, kolla upp hur exponenter fungerar då 10^24 är långt större än vad en long ens klarar att bära, det här borde dock fungera...
        int radian { get; set; }
        Vector2 position { get; set; }                   //position (0, 0)
        float scale { get; set; }                        //for zoomign purposes


        double[] AirDensity = new double[19];           //tabell med luftdensitetsvärden hämtad från (finns också i dokumentationen) http://ccmc.gsfc.nasa.gov/modelweb/models/msis_vitmo.php

        public Earth()
        {
            this.mass = 5.34E+24;  //kg
            this.radian = 6371000; //m
            this.position = Vector2.Zero;  //ska sättas till "mitten av skärmen" och inte hörnet som nu


            //AirDensity[0] = abababab; Atmosfärens tabell ska fyllas i vid skapelse av planeten
            //AirDensity[1] = bcbcbcbc;
            //Airdensity[2].....
        }

        public float GetDistance(Rocket r)
        {
            return r.coords.X + r.coords.Y; //TODO
        }
        
        public float GetAirDensity(Rocket r)
        {
            //retunera luftdensiteten utifrån tabellvärden baserat på GetDistance var femtionde kilometr.
            return GetDistance(r) % 50;     //TODO

        }

        public void Draw(SpriteBatch spritebatch)
        {

        }
    }
}
