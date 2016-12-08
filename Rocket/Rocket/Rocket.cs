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

        public Vector2 startPosition = new Vector2(0, 0);      //används ej
        public Vector2 acceleration = new Vector2(0, 0);       //this vector holds all forces that should be applied
        public Vector2 position = new Vector2(0, 0);           //this holds the rockets position
        public Vector2 center = new Vector2(0, 0);

        public int area { get; }                               //Used for Air Resistance calculations
        public float dragCoefficient = 1.5f;                          //based on rocket "shape"
        public float mass = 10000;                             //Total mass of rocket
        float fuelCapacity;                                    //should be 85% of rocket mass
        float fuel;                                            //Remaining fuel
        float engineEfficiency;                                // Kn thrust/liter fuel
        public float enginePower = 0;

        int rotation = 0;                                      //Rotation of rocket, in degrees
        double altitude;                                        //Distance from earths sealevel
        
        public Rocket()
        {
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
            float power = enginePower;
            acceleration += RotateDegrees(new Vector2(0, -power), rotation);
        }


        public void Load(Texture2D _texture, Vector2 _startposition)
        {
            texture = _texture;
            center.X = (_texture.Width / 2);
            center.Y = (_texture.Height / 2);
            position = _startposition;
        }

        public void Update(UniverseManager universe, float timeStep)
        {

            Planet earth = universe.GetPlanet("earth");

            altitude = GetDistanceFromPlanetSurface(earth);

            //om vi är "ovanför jordens yta", applicera gravitationskraften 
            if (GetDistanceFromPlanetSurface(earth) > 0)
            {
                acceleration += GetPlanetGravitationalPull(earth);
            }
            else if(GetDistanceFromPlanetSurface(earth) < 0)
            {
                //annars, om vi är "under", ta bort alla acceleration så vi inte sjunker igenom.
                acceleration = Vector2.Zero;
            }

            acceleration.Y += ApplyAirResistance(earth);



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

            //Console.WriteLine(acceleration);
            //Apply all forces every step to change position
            position += (acceleration * timeStep);
            Console.WriteLine(acceleration * timeStep);
        }

        public void Draw(SpriteBatch spritebatch, GraphicsDevice graphics, float zoom)
        {
            Matrix viewMatrix = Matrix.Identity *
                                Matrix.CreateTranslation(new Vector3(-position, 0)) *
                                //multiplicera in "skala"-matrisen       
                                Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                Matrix.CreateTranslation(new Vector3((graphics.Viewport.Width / 2), (graphics.Viewport.Height  / 2), 0.0f));

            spritebatch.Begin(transformMatrix: viewMatrix);
            spritebatch.Draw(texture, position, null, Color.White, (MathHelper.ToRadians(rotation)), center, 1f, SpriteEffects.None, 0f);
            spritebatch.End();
        }


        public double GetDistanceFromPlanetCore(Planet planet)
        {
            float dx = position.X - planet.position.X;
            float dy = position.Y - planet.position.Y;

            return Math.Sqrt((dx * dx) + (dy * dy));
        }

        public double GetDistanceFromPlanetSurface(Planet planet)
        {
            float dx = position.X - planet.position.X;
            float dy = position.Y - planet.position.Y;

            return (Math.Sqrt((dx * dx) + (dy * dy)) - planet.radian);
        }


        public Vector2 GetPlanetGravitationalPull(Planet planet)
        {
            double G = 6.674E-11;
            double r2 = Math.Pow(GetDistanceFromPlanetCore(planet), 2);
            float F = (float)(G * ((mass * planet.mass) / r2));
            //F är i newtons, därför måste vi dela den på raketens massa för att få accelerationen
            float acceleration = (F / mass);

            //detta ger oss en enhetsvector som "pekar" ner mot centret av universum(jorden)
            Vector2 gravitationalPullDirection = Vector2.Normalize(-position);


            return gravitationalPullDirection * acceleration;
        }


        public float ApplyAirResistance(Planet planet)
        {
            int a = area;
            double p = planet.GetAirDensity(altitude);
            float v = acceleration.Y;
            float c = dragCoefficient;
            float drag = (float)((p * c * a * (v * v)) / 2);

            return drag;     //måste åtgärdas, fungerar bara i Y-led... eller?
        }

        public float GetRocketRotationRelativeToEarth()
        {


            float x = position.X;
            float y = -position.Y;
            float angle = 0;

            angle = (float)(Math.Atan2(y, x) * 180 / Math.PI);
            angle = angle % 360;

            if (angle < 0)
            {
                angle += 360;
            }

            Console.WriteLine(angle);
            return angle;
        }
    }
}
