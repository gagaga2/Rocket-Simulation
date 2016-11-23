using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class UniverseManager
    {
        public Rocket rocket;
        public Earth earth;
        public Moon moon;
        public Camera camera;

        public UniverseManager(Viewport view)
        {
            rocket = new Rocket(this);
            earth = new Earth();
            moon = new Moon();
            camera = new Camera(this, view);
        }

        public float getRocketRotationRelativeToEarth()
        {
            float x = rocket.position.X;
            float y = -rocket.position.Y;
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

        public double GetDistanceFromEarth()
        {
            float dx = this.rocket.position.X - this.earth.position.X;
            float dy = this.rocket.position.Y - this.earth.position.Y;

            return Math.Sqrt((dx * dx) + (dy * dy));
        }

        public double GetEarthAirDensity()
        {
            //retunera luftdensiteten utifrån tabellvärden baserat på GetDistanceFromEarth var 10:nde kilometr.
            int i = (int) Math.Round(GetDistanceFromEarth() / 10);
            return earth.AirDensity[i];
        }

        public Vector2 GetEarthGravitationalPull()
        {
            double G = 6.674E-11;
            double r2 = Math.Pow(GetDistanceFromEarth(), 2);
            float F = (float) (G * ((rocket.mass * earth.mass) / r2));
            //F är i newtons, därför måste vi dela den på raketens massa för att få accelerationen
            float acceleration = (F / rocket.mass);

            //detta ger oss en enhetsvector som "pekar" ner mot centret av universum(jorden)
            Vector2 gravitationalPullDirection = Vector2.Normalize(-rocket.position);


            Console.WriteLine(acceleration); //DEBUG
            return gravitationalPullDirection * acceleration;
        }

        public void ApplyAirResistance()
        {
            int a = this.rocket.area;
            double p = GetEarthAirDensity();
            float v = this.rocket.acceleration.Y;
            float c = this.rocket.dragCoefficient;

            float drag = (float) ((p * c * a * (v * v)) / 2);       //Drag Equation

            rocket.acceleration.Y -= drag;            //FUNGERAR BARA DÅ RAKETEN ÅKER "UPP", I Y LED.
        }                                            //orolig över all variabel casting/ olika typer. ska hålla koll på i framtiden då det kan brista här

        public void Update()
        {
            rocket.Update();
            camera.Update();

        }

        public void Draw(SpriteBatch spritebatch)
        {
            var viewmatrix = camera.getViewMatrix();
            // TODO: Add your drawing code here
            spritebatch.Begin(transformMatrix: viewmatrix);

            Vector2 bla = GetEarthGravitationalPull();
            rocket.Draw(spritebatch);
            earth.DrawModel(camera);

            spritebatch.End();

            //rita värden av funktioner som text på skärmen
        }
    }
}
