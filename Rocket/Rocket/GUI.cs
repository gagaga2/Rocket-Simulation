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

        public GUI()
        {

        }

        public void Load(SpriteFont font, UniverseManager universe)
        {
            this.universe = universe;
            this.font = font;
        }

        public void Draw(SpriteBatch spritebatch, GraphicsDevice graphics)
        {
            Planet earth = universe.GetPlanet("earth");
            Planet moon = universe.GetPlanet("moon");

            Matrix view = Matrix.CreateLookAt(new Vector3(universe.rocket.position.X, -universe.rocket.position.Y, 3), new Vector3(universe.rocket.position.X, universe.rocket.position.Y, 0), Vector3.UnitY) *
                          Matrix.CreateTranslation(new Vector3(0, 0, 0));

            //Statisk text
            spritebatch.Begin();

            spritebatch.DrawString(font, "Rocket", new Vector2(graphics.Viewport.Width / 2, graphics.Viewport.Height / 2), Color.Red);
            spritebatch.DrawString(font, ((universe.rocket.GetDistanceFromPlanetSurface(universe.GetPlanet("earth")) / 1000).ToString()), new Vector2(100, 100), Color.Red);
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
