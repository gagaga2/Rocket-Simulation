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

        public Vector2 acceleration = new Vector2(0, 0);        //this vector holds all forces that should be applied
        public Vector2 position = new Vector2(0, 0);            //this holds the rockets position
        public Vector2 center = new Vector2(0, 0);              //center of rocket

        public double area = 1;                                //Used for Air Resistance calculations
        public float dragCoefficient = 1.5f;                    //based on rocket "shape"
        public double mass = 1;                             //Total mass of rocket in KG
        double fuelCapacity;                                     //should be 85% of rocket mass
        double fuel;                                             //Remaining fuel
        double engineEfficiency;                                 //Kn thrust/liter fuel
        public float enginePower = 0;

        public float rotation;                                  //Rotation of rocket, in radians
        double altitude;                                        //Distance from earths sealevel
        
        public Rocket(Vector2 startPosition, double area, double mass, double fuel, double engineEfficiency, float rotation)
        {
            this.position = startPosition;
            this.area = area;
            this.mass = mass;
            this.fuelCapacity = fuel;
            this.engineEfficiency = engineEfficiency;
            this.rotation = rotation;

        }


        public void Load(Texture2D texture)
        {
            this.texture = texture;
            center.X = (texture.Width / 2);
            center.Y = (texture.Height / 2);
        }

        public void Update(UniverseManager universe, float timeStep)
        {
            Planet earth = universe.GetPlanet("earth");
            Planet moon = universe.GetPlanet("moon");
            altitude = GetDistanceFromPlanetSurface(earth);


            Console.WriteLine(GetPlanetGravitationalPull(moon));

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

            //checka om vi kolliderar med månen och sluta accelerera då
            if (GetDistanceFromPlanetSurface(moon) > 0)
            {
                acceleration += GetPlanetGravitationalPull(moon);
            }
            else if (GetDistanceFromPlanetSurface(moon) < 0)
            {
                acceleration = Vector2.Zero;
            }

           
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                rotation -= (float)(Math.PI / 24f);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                rotation += (float)(Math.PI / 24f);
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

            //plocka isär floaten till komposanter...?
            //Do

            acceleration -= GetDragVector(earth);
            //Console.WriteLine(acceleration);
            //Apply all forces every step to change position
            position += (acceleration * timeStep);
        }

        public void Draw(SpriteBatch spritebatch, GraphicsDevice graphics, float zoom)
        {
            Matrix viewMatrix = Matrix.Identity *
                                Matrix.CreateTranslation(new Vector3(-position, 0)) *
                                //multiplicera in "skala"-matrisen       
                                Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                Matrix.CreateTranslation(new Vector3((graphics.Viewport.Width / 2), (graphics.Viewport.Height  / 2), 0.0f));

            spritebatch.Begin(transformMatrix: viewMatrix);
            spritebatch.Draw(texture, position, null, Color.White, rotation, center, 1f, SpriteEffects.None, 0f);
            spritebatch.End();
        }


        public double GetDistanceFromPlanetCore(Planet planet)
        {
            float dx = position.X - planet.position.X;
            float dy = -position.Y - planet.position.Y;

            return Math.Sqrt((dx * dx) + (dy * dy));
        }

        public double GetDistanceFromPlanetSurface(Planet planet)
        {
            float dx = position.X - planet.position.X;
            float dy = -position.Y - planet.position.Y;

            return (Math.Sqrt((dx * dx) + (dy * dy)) - planet.radian);
        }


        public Vector2 GetPlanetGravitationalPull(Planet planet)
        {
            double G = 6.674E-11;
            double r2 = Math.Pow(GetDistanceFromPlanetCore(planet), 2);
            float F = (float)(G * ((mass * planet.mass) / r2));
            //F är i newtons, därför måste vi dela den på raketens massa för att få accelerationen
            double acceleration = (F / mass);

            //detta ger oss en enhetsvector som pekar mot planeten
            Vector2 directionVector = Vector2.Normalize((new Vector2(planet.position.X, -planet.position.Y) - position));

            //förläng enhetsvektorn med gravitationskraften
            return directionVector * (float)acceleration;
        }


        public Vector2 GetDragVector(Planet planet)
        {
            double a = area;
            double p = planet.GetAirDensity(altitude);
            float v = acceleration.Length();
            float c = dragCoefficient;
            float drag = (float)((p * c * a * (v * v)) / 2);
            //eftersom luftmotståndsekvationen ger oss newtons
            //måste vi dela med massan för att få accelerationen som verkar.
            double dragAcceleration = drag / mass;

            if (acceleration.Length() != 0)
            {
                //skapa ny vector med accelerationsriktningen
                Vector2 dragVector = acceleration;
                dragVector.Normalize();
                
                //förläng med vårt luftmotstånd
                dragVector *= (float)(dragAcceleration);
                return dragVector;

                //rimligt? http://io9.gizmodo.com/5893615/absolutely-mindblowing-video-shot-from-the-space-shuttle-during-launch
            }
            else
            {
                return Vector2.Zero;
            }

        }

        public float GetVectorDirection(Vector2 vec)
        {
            float vectorDirection = (float)(Math.Atan2(-vec.Y, -vec.X) % MathHelper.TwoPi);
            return (vectorDirection - MathHelper.PiOver2);
        }

        public Vector2 RotateVector(Vector2 v, float radians)
        {
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);

            float rX = (float)((v.X * cos) - (v.Y * sin));
            float rY = (float)((v.X * sin) + (v.Y * cos));

            return new Vector2(rX, rY);
        }

        public void FireEngines()
        {
            float power = enginePower;
            acceleration += RotateVector(new Vector2(0, -power), rotation);
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
            return angle;
        }
    }
}
