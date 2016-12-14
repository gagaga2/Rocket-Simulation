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

        private Vector2 acceleration = new Vector2(0, 0);        //this vector holds all forces that should be applied
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 position = new Vector2(0, 0);            //this holds the rockets position
        public Vector2 center = new Vector2(0, 0);              //center of rocket

        public double area = 1;                                //Used for Air Resistance calculations
        public float dragCoefficient = 0.75f;                    //based on rocket "shape" https://spaceflightsystems.grc.nasa.gov/education/rocket/shaped.html
        public double mass = 1;                             //Total mass of rocket in KG
        public double fuelCapacity;                                     //should be 85% of rocket mass
        public double fuel;                                             //Remaining fuel
        double engineEfficiency;                                 //Kn thrust/liter fuel
        public float enginePower = 0;
        public float engineMaxPower;
        bool leftPlatform = false;

        public float rotation;                                  //Rotation of rocket, in radians
        double altitude;                                        //Distance from earths sealevel
        
        public Rocket(Vector2 startPosition, double area, double mass, double fuel, double engineEfficiency, float rotation, float engineMaxPower)
        {
            this.position = startPosition;
            this.area = area;
            this.mass = mass;
            this.fuelCapacity = fuel;
            this.fuel = fuel;
            this.engineEfficiency = engineEfficiency;
            this.rotation = rotation;
            this.engineMaxPower = engineMaxPower;

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

            acceleration = Vector2.Zero;

            if (enginePower != 0)
            {
                leftPlatform = true;
            }

            if (leftPlatform)
            {

                if (GetDistanceFromPlanetSurface(earth) < -2 || GetDistanceFromPlanetSurface(moon) < -2)
                {
                    acceleration = Vector2.Zero;
                    velocity = Vector2.Zero;
                }
                else if (GetDistanceFromPlanetSurface(earth) > 0 && GetDistanceFromPlanetSurface(moon) > 0)
                {
                    acceleration += ((GetDragAccelerationVector(earth) * timeStep) +
                       (GetPlanetGravitationalPullAcceleration(earth) * timeStep) +
                       (GetPlanetGravitationalPullAcceleration(moon) * timeStep));
                }

                acceleration += (GetEngineAcceleration() * timeStep);

            }
            velocity += acceleration;
            position += velocity;


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
                enginePower -= (engineMaxPower / 100);
                enginePower = MathHelper.Clamp(enginePower, 0, engineMaxPower);
            }
            if (state.IsKeyDown(Keys.Up))
            {
                enginePower += (engineMaxPower / 100);
                enginePower = MathHelper.Clamp(enginePower, 0, engineMaxPower);
            }

            //allt det här är trasigt
            //http://stackoverflow.com/questions/667034/simple-physics-based-movement
            //http://stackoverflow.com/questions/8041431/how-to-make-fluid-drag-equation-not-framerate-dependent
            //http://gamedev.stackexchange.com/questions/11119/adding-air-drag-to-a-golf-ball-trajectory-equation
            //http://gamedev.stackexchange.com/questions/102106/how-do-i-integrate-drag-over-distance

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


        public Vector2 GetPlanetGravitationalPullAcceleration(Planet planet)
        {
            double G = 6.674E-11;
            double r2 = Math.Pow(GetDistanceFromPlanetCore(planet), 2);
            float F = (float)(G * ((mass * planet.mass) / r2));
            //F är i newtons, därför måste vi dela den på raketens massa för att få accelerationen
            double gravitationalAcceleration = (F / mass);

            //detta ger oss en enhetsvector som pekar mot planeten
            Vector2 directionVector = Vector2.Normalize((new Vector2(planet.position.X, -planet.position.Y) - position));

            //förläng enhetsvektorn med gravitationskraften
            return directionVector * (float)gravitationalAcceleration;
        }


        public Vector2 GetDragAccelerationVector(Planet planet)
        {
            
            double a = area;
            double p = planet.GetAirDensity(altitude);
            float v = velocity.Length();
            float c = dragCoefficient;
            float drag = (float)(c * a * p * 0.5 * Math.Pow(v, 2)); 
            //v borde vara upphöjt i två
            //eftersom luftmotståndsekvationen ger oss newtons
            //måste vi dela med massan för att få accelerationen som verkar.
            float dragAcceleration = drag / (float) mass;

            if (velocity.Length() != 0)
            {
                //skapa en enhetsvector i riktningen vi rör oss i
                Vector2 dragVector = velocity;
                dragVector.Normalize();
                
                
                //förläng med vårt luftmotstånd
                dragVector *= (dragAcceleration);
                return -dragVector;
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

        public Vector2 GetEngineAcceleration()
        {
            if ((fuel - (enginePower / engineEfficiency)) > 0)
            {
                mass -= (engineMaxPower * enginePower / engineEfficiency);
                fuel -= (engineMaxPower * enginePower / engineEfficiency);
                float engineAcceleration = engineMaxPower * enginePower * 1000 / (float) mass;
                return RotateVector(new Vector2(0, -engineAcceleration), rotation);
            }
            else
            {
                Console.WriteLine("out of fuel!");
                return Vector2.Zero;
            }
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
