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
        private Texture2D texture;

        public Vector2 acceleration = new Vector2(0, 0);                //this vector holds all forces that should be applied
        public Vector2 forces = new Vector2(0, 0);                      //
        public Vector2 coords = new Vector2(300, 300);                  //this holds the rockets position
        float scale = 1f;                               //The "scale" of the drawn rocket (used for eventual zooming?)

        public int rocketArea { get; }                  //Used for Air Resistance calculations
        public float dragCoefficient;
        float mass;                                     //Total mass of rocket
        float fuelcapacity;                             //should be 85% of rocket mass
        float fuel;                                     //Remaining fuel
        float engineEfficiency;                         // Kn thrust/liter fuel

        int rotation = 0;                               //Rotation of rocket, in degrees
        float altitude;                                 //Distance from earths sealevel

        private const float toRadians = (float) Math.PI / 180;  //multiply with degrees to get radians
        
        
        public Vector2 RotateDegrees(Vector2 v, int degrees)
        {

            double cos = Math.Cos(degrees * toRadians);
            double sin = Math.Sin(degrees * toRadians);

            float rX = (float) ((v.X * cos) - (v.Y * sin));
            float rY = (float) ((v.X * sin) + (v.Y * cos));

            return new Vector2(rX, rY);
        }


        public void Load(Texture2D tex)
        {
            texture = tex;
        }


        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                rotation -= 5;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                rotation += 5;
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


            //Apply all forces every step to change position
            //forces += acceleration;
            coords += RotateDegrees(acceleration, rotation);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, coords, null, Color.White, (rotation * toRadians), Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
