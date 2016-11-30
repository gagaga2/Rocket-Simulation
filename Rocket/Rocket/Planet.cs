using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rocket
{
    class Planet
    {
        public double mass { get; set; }                         /// mass of the planet
        public int radian { get; set; }                          /// radian of the planet
        public Vector3 position { get; set; }             /// position in world
        public float zoom { get; set; } = 1;                    /// used to scale (zoom)
        public Model model;                                      /// 3D model to use

        public Planet()
        {

        }
        public Planet(double _mass, int _radian, Vector2 _position)
        {
            mass = _mass;
            radian = _radian;
            position = new Vector3(_position.X, _position.Y, 0);

        }

        public void Load(Model _model)
        {
            this.model = _model;
        }

        public void DrawModel(Camera c)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {

                    /// Stores the world matrix for the model, which transforms the 
                    /// model to be in the correct position, scale, and rotation
                    /// in the game world.

                    effect.World = Matrix.CreateTranslation(new Vector3(0, 0, 0)) * Matrix.CreateScale(radian, radian, 0);

                    /// Stores the view matrix for the model, which gets the model
                    /// in the right place, relative to the camera.
                    /// HOLY FUCK DET FUNKAR!!!!!!!!

                    effect.View = Matrix.CreateLookAt(new Vector3(c.position.X, -c.position.Y, 10), new Vector3(c.position.X, -c.position.Y, 0), Vector3.UnitY) * 
                                  Matrix.CreateScale(zoom, zoom, 1) *
                                  Matrix.CreateTranslation(new Vector3(0, 0, 0));

                    /// Stores the projection matrix, which gets the model projected
                    /// onto the screen in the correct way.  Essentially, this defines the
                    /// properties of the camera, like lens and such.

                    effect.Projection = Matrix.CreateOrthographic(c.viewport.Width, c.viewport.Height, 0.1f, 10f);
                }

                mesh.Draw();
            }
        }
    }
}
