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

        Vector2 forces = new Vector2(0, 0);             //this vector holds all forces that should be applied
        Vector2 coords = new Vector2(300, 300);         //this holds the rockets position
        float scale = 1f;                               //The "scale" of the drawn rocket (used for eventual zooming?)

        int rocketArea;                                 //Used for Air Resistance calculations
        float mass;                                     //Total mass of rocket
        float fuelcapacity;                             //should be 85% of rocket mass
        float fuel;                                     //Remaining fuel
        float engineEfficiency;                         // Kn thrust/liter fuel

        int rotation;                                   //Rotation of rockets nose relative to earth (or closest body??)
        float altitude;                                 //Distance from earths sealevel




        public void Load(Texture2D tex)
        {
            rocket = tex;
        }


        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                forces.X -= 2;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                forces.X += 2;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                forces.Y += 2;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                forces.Y -= 2;
            }

            //Slowwly soften acceleration
            if (forces.X < 0)
                forces.X += 1;

            if (forces.X > 0)
                forces.X -= 1;

            if (forces.Y < 0)
                forces.Y += 1;

            if (forces.Y > 0)
                forces.Y -= 1;

            //Apply all forces every step to change position
            coords += forces;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(rocket, coords, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
