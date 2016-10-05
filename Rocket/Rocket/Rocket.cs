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

    class Rocket
    {
        private Texture2D rocket;

        Vector2 acceleration = new Vector2(0, 0);
        Vector2 coords = new Vector2(300, 300);
        float scale = 1f;

        int rocketArea;         //Used for Air Resistance calculations
        float mass;             //Total mass of rocket
        float fuelcapacity;     //85% of rocket mass
        float fuel;             //Remaining fuel
        float engineEfficiency; // Kn thrust/liter fuel

        int rotation;           //Rotation of rockets nose relative to earth (or closest body??)
        float altitude;         //Distance from earths sealevel

        public void Load(Texture2D tex)
        {
            rocket = tex;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                acceleration.X -= 2;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                acceleration.X += 2;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                acceleration.Y += 2;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                acceleration.Y -= 2;
            }

            //Slowwly soften acceleration
            if (acceleration.X < 0)
                acceleration.X += 1;

            if (acceleration.X > 0)
                acceleration.X -= 1;

            if (acceleration.Y < 0)
                acceleration.Y += 1;

            if (acceleration.Y > 0)
                acceleration.Y -= 1;

            //add acceleration
            coords += acceleration;

            if (acceleration.Y > 3)
                scale = 0.5f;
            else
                scale = 1f;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(rocket, coords, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
