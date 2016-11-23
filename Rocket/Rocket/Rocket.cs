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
        private UniverseManager universe;
        private Texture2D texture;

        public Vector2 startPosition = new Vector2(0, 0); //används ej
        public Vector2 acceleration = new Vector2(0, 0);       //this vector holds all forces that should be applied
        public Vector2 position = new Vector2(0, 0);             //this holds the rockets position
        public Vector2 center = new Vector2(0, 0);

        public int area { get; }                         //Used for Air Resistance calculations
        public float dragCoefficient;                          //based on rocket "shape"
        public float mass = 10000;                                     //Total mass of rocket
        float fuelCapacity;                                    //should be 85% of rocket mass
        float fuel;                                            //Remaining fuel
        float engineEfficiency;                                // Kn thrust/liter fuel
        float enginePower = 0;

        int rotation = 0;                                      //Rotation of rocket, in degrees
        float altitude;                                        //Distance from earths sealevel
        
        public Rocket(UniverseManager _universe)
        {
            universe = _universe;
        }


        public Vector2 RotateDegrees(Vector2 v, int degrees)
        {
            double cos = Math.Cos(MathHelper.ToRadians(degrees));
            double sin = Math.Sin(MathHelper.ToRadians(degrees));

            float rX = (float) ((v.X * cos) - (v.Y * sin));
            float rY = (float) ((v.X * sin) + (v.Y * cos));

            return new Vector2(rX, rY);
        }

        public void FireEngines()
        {
            float power = 10 * enginePower;
            acceleration = RotateDegrees(new Vector2(0, -power), rotation);
        }


        public void Load(Texture2D _texture, Vector2 _startposition)
        {
            texture = _texture;
            center.X = (_texture.Width / 2);
            center.Y = (_texture.Height / 2);
            position = _startposition;
        }

        public void Update()
        {
            if (Math.Abs(universe.GetDistanceFromEarth()) > universe.earth.radian)
            {
                acceleration += universe.GetEarthGravitationalPull();
            }

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
                enginePower -= 0.1f;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                enginePower += 0.1f;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                FireEngines();
            }

            //Apply all forces every step to change position
            position += acceleration;
            acceleration = Vector2.Zero;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position, null, Color.White, (MathHelper.ToRadians(rotation)), center, 1f, SpriteEffects.None, 0f);
        }
    }
}
