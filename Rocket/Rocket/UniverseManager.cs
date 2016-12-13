using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class UniverseManager
    {
        public Rocket rocket;
        public Launchpad launchpad;
        public float zoom = 1f;
        public float timeScale = 1;
        public Dictionary<string, Planet> planets = new Dictionary<string, Planet>();
        public double seconds;

        public UniverseManager(string[] args)
        {
            float PositionRadians = -MathHelper.ToRadians(int.Parse(args[0]));
            float rocketRadians = (float)(PositionRadians + MathHelper.PiOver2);
            double rocketAltitude = double.Parse(args[1]);
            double rocketFuel = double.Parse(args[2]);
            double rocketMass = double.Parse(args[3]);
            double rocketEfficency = double.Parse(args[4]);
            double rocketArea = double.Parse(args[5]);
            float engineMaxPower = float.Parse(args[6]);

            planets.Add("earthAtmosphere", new Atmosphere(this, 0, 6411200, Color.SkyBlue, Color.Yellow));
            planets.Add("earth", new Earth(this));
            planets.Add("moon", new Moon(this));

            float rocketPositionHeight = (float) (GetPlanet("earth").radian + rocketAltitude);
            Vector2 rocketPosition = new Vector2();
            rocketPosition.X = (float) Math.Cos(PositionRadians);
            rocketPosition.Y = (float) Math.Sin(PositionRadians);
            rocketPosition *= rocketPositionHeight;


            Console.WriteLine(rocketPosition);
            launchpad = new Launchpad(rocketPosition, rocketRadians, this);
            rocket = new Rocket(rocketPosition, rocketArea, rocketMass, rocketFuel, rocketEfficency, rocketRadians, engineMaxPower);
        }

        public Dictionary<string, Planet> GetPlanets()
        {
            return planets;
        }

        public Planet GetPlanet(string planet)
        {
            return planets[planet];
        }


        public void Update(float timeStep)
        {
            
            rocket.Update(this, (timeStep * timeScale));

            seconds += (timeStep * timeScale);

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Z))
            {
                //kommer aldrig bli mindre än 0, vilket är bra
                zoom *= 0.9f;
            }
            if (state.IsKeyDown(Keys.X))
            {
                zoom *= 1.1f;
            }

            if (state.IsKeyDown(Keys.A))
            {
                //kommer aldrig bli mindre än 0, vilket är bra
                timeScale -= 1f;
                timeScale = MathHelper.Clamp(timeScale, 1f, 30f);
            }
            if (state.IsKeyDown(Keys.S))
            {
                timeScale += 1f;
                timeScale = MathHelper.Clamp(timeScale, 1f, 30f);
            }

        }

        public void Draw(SpriteBatch spritebatch, GraphicsDevice graphics)
        {
            // TODO: Add your drawing code here

            foreach(KeyValuePair<string, Planet> p in planets)
            {
                p.Value.Draw(graphics, zoom);
            }

            launchpad.Draw(spritebatch, graphics, zoom);
            rocket.Draw(spritebatch, graphics, zoom);
            
            //rita värden av funktioner som text på skärmen
        }
    }
}
