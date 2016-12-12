﻿using Microsoft.Xna.Framework;
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
            launchpad = new Launchpad();
            rocket = new Rocket();
            planets.Add("earth", new Earth(this));
            planets.Add("moon", new Moon(this));
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
                timeScale = MathHelper.Clamp(timeScale, 1f, 10f);
            }
            if (state.IsKeyDown(Keys.S))
            {
                timeScale += 1f;
                timeScale = MathHelper.Clamp(timeScale, 1f, 10f);
            }

        }

        public void Draw(SpriteBatch spritebatch, GraphicsDevice graphics)
        {
            // TODO: Add your drawing code here

            foreach(KeyValuePair<string, Planet> p in planets)
            {
                p.Value.Draw(graphics, zoom);
            }
            rocket.Draw(spritebatch, graphics, zoom);

            //rita värden av funktioner som text på skärmen
        }
    }
}
