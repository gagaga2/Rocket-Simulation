using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rocket
{
    class Camera
    {
        //fönstrets center relativit till fönstret i pixlar.
        public Viewport viewport;
        public Vector2 viewportCenter;
        public float zoom { get; set; }

        //Kamerans position i världen, (alltså där raketen är)
        public Vector2 position;
        private Rocket rocket;

        public Camera(Rocket r, Viewport v)
        {
            viewport = v;
            rocket = r;

            viewportCenter = new Vector2(0, 0);
            viewportCenter.X = v.Width / 2;
            viewportCenter.Y = v.Height / 2;

            zoom = 1.0f;
            position = new Vector2(0, 0);

        }
        //separer i viewmatrix, worldmatrix, projectionmatrix?

        public Matrix getViewMatrix() //komplicerat, men ändå inte. Monogame sköter allt svårt.
        {


            return
                (
                Matrix.Identity *                                                   //matris multiplikation sker "baklänges"
                Matrix.CreateTranslation(new Vector3(-position, 0.0f)) *            //nerifrån och upp
                Matrix.CreateTranslation(new Vector3(viewportCenter, 0.0f)) *       //först skalar vi, sedan "flyttar" vi raketen till centrumet av skärmen
                Matrix.CreateScale(new Vector3(zoom, zoom, 1))
                );

            //works!
            //använd basiceffect istället för en standardiserad cameraclass??
            //http://www.opengl-tutorial.org/beginners-tutorials/tutorial-3-matrices/
            //
        }

        public void Zoom(float amount)
        {
            zoom += amount;

            if (zoom < 0.001f)
            {
                zoom = 0.001f;  //se till att vi inte kan zooma mindre än 0.001
            }
        }

        public void Update()
        {
            //sätt kamerans världsliga position till raketens position eftersom vi
            //vill följa raketen
            position.X = rocket.coords.X;
            position.Y = rocket.coords.Y;
            Console.WriteLine(((int)position.X) + " " + ((int)position.Y));


        }
    }
}
