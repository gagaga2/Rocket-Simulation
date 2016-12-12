﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class GUI
    {
        SpriteFont font;
        UniverseManager universe;
        Texture2D compass;
        Texture2D arrow;

        public GUI()
        {

        }

        public void Load(SpriteFont font, UniverseManager universe, Texture2D compass, Texture2D arrow)
        {
            this.universe = universe;
            this.font = font;
            this.compass = compass;
            this.arrow = arrow;
        }

        public void Draw(SpriteBatch spritebatch, GraphicsDevice graphics)
        {
            Vector2 viewCenter = new Vector2(graphics.Viewport.Width / 2, graphics.Viewport.Height / 2);
            Planet earth = universe.GetPlanet("earth");
            Planet moon = universe.GetPlanet("moon");
            Rocket rocket = universe.rocket;

            //FUCK

            Matrix view = Matrix.CreateLookAt(new Vector3(rocket.position.X, -rocket.position.Y, 3), new Vector3(rocket.position.X, rocket.position.Y, 0), Vector3.UnitY) *
                          Matrix.CreateTranslation(new Vector3(0, 0, 0));

            //Statiska element
            spritebatch.Begin();

            if (rocket.acceleration != Vector2.Zero)
            {
                spritebatch.Draw(arrow, viewCenter, null, Color.Red, rocket.GetRocketAccelerationDirection(), (new Vector2(arrow.Width / 2, arrow.Height + 30)), 1f, SpriteEffects.None, 1);
            }

            spritebatch.Draw(compass, viewCenter, null, Color.Gray, MathHelper.ToRadians(rocket.rotation), (new Vector2(compass.Width / 2, compass.Height / 2)), 1f, SpriteEffects.None, 1);

            //statisk text
            //spritebatch.DrawString(font, "Rocket", new Vector2(graphics.Viewport.Width / 2, graphics.Viewport.Height / 2), Color.Red);
           // spritebatch.DrawString(font, (rocket.GetDistanceFromPlanetSurface(universe.GetPlanet("earth")) / 1000).ToString(), new Vector2(100, 100), Color.Red);
            spritebatch.DrawString(font, universe.seconds.ToString(), new Vector2(50, 50), Color.Red);
            spritebatch.DrawString(font, universe.rocket.enginePower.ToString(), new Vector2(50, 150), Color.Yellow);

            

            spritebatch.End();

            //Text som rör sig
            spritebatch.Begin(transformMatrix: view);

            spritebatch.DrawString(font, "Earth", new Vector2(earth.position.X, earth.position.Y), Color.Red);
            spritebatch.DrawString(font, "Moon", new Vector2(moon.position.X, earth.position.Y), Color.Red);
            spritebatch.End();

        }
    }
}
