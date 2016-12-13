using Microsoft.Xna.Framework;
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
        Texture2D altimeter;
        Texture2D menu;
        public GUI()
        {

        }

        public void Load(SpriteFont font, UniverseManager universe, Texture2D compass, Texture2D arrow, Texture2D altimeter, Texture2D menu)
        {
            this.universe = universe;
            this.font = font;
            this.compass = compass;
            this.arrow = arrow;
            this.altimeter = altimeter;
            this.menu = menu;
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

            //rita pil som pekar mot accelerationen
            if (rocket.acceleration != Vector2.Zero)
            {
                spritebatch.Draw(arrow, viewCenter, null, Color.Red, rocket.GetVectorDirection(rocket.acceleration), (new Vector2(arrow.Width / 2, arrow.Height + 30)), 1f, SpriteEffects.None, 1);
            }

            //rita pil som pekar mot jordens gravitationskraft
            spritebatch.Draw(arrow, viewCenter, null, Color.Green, rocket.GetVectorDirection(rocket.GetPlanetGravitationalPull(universe.GetPlanet("earth"))), (new Vector2(arrow.Width / 2, arrow.Height + 30)), 1f, SpriteEffects.None, 1);

            //rita pil som pekar mot månens gravitationskraft
            spritebatch.Draw(arrow, viewCenter, null, Color.Gray, rocket.GetVectorDirection(rocket.GetPlanetGravitationalPull(universe.GetPlanet("moon"))), (new Vector2(arrow.Width / 2, arrow.Height + 30)), 1f, SpriteEffects.None, 1);

            //rita compass
            spritebatch.Draw(compass, viewCenter, null, Color.Gray, rocket.rotation, (new Vector2(compass.Width / 2, compass.Height / 2)), 1f, SpriteEffects.None, 1);
            //rita altimeter
            spritebatch.Draw(altimeter, new Vector2(viewCenter.X, graphics.Viewport.Height - 20), null, Color.White, 0, (new Vector2(altimeter.Width / 2, altimeter.Height / 2)), 1f, SpriteEffects.None, 1);
            spritebatch.DrawString(font, (Math.Truncate(rocket.GetDistanceFromPlanetSurface(earth)).ToString() + " M.A.S.L."), new Vector2(graphics.Viewport.Width/2 - 90, graphics.Viewport.Height - 30), Color.White);

            //rita meny
            Vector2 menuLocation = new Vector2(graphics.Viewport.Width - 150, graphics.Viewport.Height - 195);
            spritebatch.Draw(menu, menuLocation, Color.White);
            spritebatch.DrawString(font, rocket.GetDragVector(earth).Length().ToString() + " m/s2", new Vector2(menuLocation.X + 10, menuLocation.Y + 25), Color.White);
            spritebatch.DrawString(font, rocket.acceleration.Length().ToString() + " m/s" , new Vector2(menuLocation.X + 10, menuLocation.Y + 70), Color.White);
            spritebatch.DrawString(font, rocket.GetPlanetGravitationalPull(moon).Length().ToString() + " m/s2", new Vector2(menuLocation.X + 10, menuLocation.Y + 115), Color.White);
            spritebatch.DrawString(font, rocket.GetPlanetGravitationalPull(earth).Length().ToString() + " m/s2" , new Vector2(menuLocation.X + 10, menuLocation.Y + 160), Color.White);

            //statisk text
            spritebatch.DrawString(font, universe.seconds.ToString(), new Vector2(50, 50), Color.Red);
            spritebatch.DrawString(font, rocket.acceleration.Length().ToString(), new Vector2(50, 150), Color.Yellow);
            spritebatch.DrawString(font, universe.timeScale.ToString(), new Vector2(50, 200), Color.Gray);


            spritebatch.End();

            //Text som rör sig
            spritebatch.Begin(transformMatrix: view);

            spritebatch.DrawString(font, "Earth", new Vector2(earth.position.X, earth.position.Y), Color.Red);
            spritebatch.DrawString(font, "Moon", new Vector2(moon.position.X, earth.position.Y), Color.Red);
            spritebatch.End();

        }
    }
}
