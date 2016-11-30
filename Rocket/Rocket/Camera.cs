using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rocket
{
    class Camera
    {
        //fönstrets center relativit till fönstret i pixlar.
        public Viewport viewport;
        public Vector2 viewportCenter;
        public float zoom;

        //Kamerans position i världen, (alltså där raketen är)
        public Vector2 position;
        private UniverseManager universe;

        //GUI
        SpriteFont font;

        public Camera(UniverseManager _universe, Viewport _viewport)
        {
            universe = _universe;
            viewport = _viewport;

            viewportCenter = new Vector2(0, 0);
            viewportCenter.X = _viewport.Width / 2;
            viewportCenter.Y = _viewport.Height / 2;

            zoom = 1.0f;
            position = new Vector2(0, 0);
        }

        public Matrix getViewMatrix() //komplicerat, men ändå inte. Monogame sköter allt svårt.
        {
            return
                (
                //skapa en tom enhetsmatris
                Matrix.Identity *                                                   
                Matrix.CreateTranslation(new Vector3(-position, 0.0f)) *     
                //multiplicera in "skala"-matrisen       
                Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                Matrix.CreateTranslation(new Vector3(viewportCenter, 0.0f))       
                );
            //works!
        }

        public void Update()
        {
            //sätt kamerans världsliga position till raketens position eftersom vi
            //vill följa raketen
            position.X = universe.rocket.position.X;
            position.Y = universe.rocket.position.Y;
            //Console.WriteLine(((int)position.X) + " " + ((int)position.Y));

            //Zooma
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Z))
            {
                //kommer aldrig bli mindre än 0, vilket är bra
                zoom *= 0.5f;
                universe.earth.zoom *= 0.5f;
            }
            if (state.IsKeyDown(Keys.X))
            {
                zoom *= 1.5f;
                universe.earth.zoom *= 1.5f;
            }
        }

        public void Load(SpriteFont _font)
        {
            font = _font;
        }

        public void DrawGUI(SpriteBatch spr)
        {
            spr.Begin();
            spr.DrawString(font, "Rocket", viewportCenter, Color.Black);
            spr.End();
        }
    }
}
