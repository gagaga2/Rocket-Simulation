using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rocket.Content
{
    class Camera
    {
        //fönstrets center relativit till fönstret i pixlar.
        private Vector2 ViewportCenter = new Vector2(0, 0);
        public float zoom {get; set;} = 1.0f;

        //Kamerans position i världen, (alltså där raketen är)
        private Vector2 position = new Vector2(0, 0);
        private Rocket r;


        public Camera(Rocket _r) //skicka med raketen som kameran ska följa
        {
            r = _r;
        }

        public Matrix getTranslationMatrix() //magi
        {
            return Matrix.CreateTranslation(
                (int)position.X, (int)position.Y, 0) *
                Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                Matrix.CreateTranslation(ViewportCenter.X, ViewportCenter.Y, 0);
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
            //Kamerana centreras i mitten av skärmen, osäker på om detta ska ske varje tick eller 
            //varje gång man trycker på en knapp efter man resizat
            ViewportCenter.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2;
            ViewportCenter.Y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2;

            //sätt kamerans världsliga position till raketens position eftersom vi
            //vill följa raketen
            position.X = r.coords.X;
            position.Y = r.coords.Y;

            //https://roguesharp.wordpress.com/2014/07/13/tutorial-5-creating-a-2d-camera-with-pan-and-zoom-in-monogame/


        }
    }
}
