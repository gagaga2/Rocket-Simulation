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
        public UniverseManager universe;

        public double mass { get; set; } = 1;
        public int radian { get; set; } = 1;     
        public Vector3 position { get; set; } = Vector3.Zero;

        public Color innerColor = Color.Black;
        public Color outerColor = Color.White;

        Matrix world;
        Matrix view;
        Matrix projection;

        VertexBuffer vertexbuffer;
        BasicEffect basicEffect;
        int triangles;

        public void Load(GraphicsDevice graphics, int triangles)
        {

            this.triangles = triangles;
            int totalVertices = triangles * 3;

            basicEffect = new BasicEffect(graphics);
            VertexPositionColor[] vertices = new VertexPositionColor[totalVertices];


            for (int i = 0; i < vertices.Length; i += 3)
            {
                float angle = ((float)(2 * Math.PI) / triangles);
                float angleFirstSide = (angle + (angle * i));
                float angleSecondSide = (angle + (angle * (i + 1)));

                vertices[i] = new VertexPositionColor(position, innerColor);
                vertices[i + 1] = new VertexPositionColor(position + new Vector3((float) (radian * Math.Sin(angleFirstSide)), (float) (radian * Math.Cos(angleFirstSide)), 0), outerColor); //beter sig konstigt
                vertices[i + 2] = new VertexPositionColor(position + new Vector3((float) (radian * Math.Sin(angleSecondSide)), (float) (radian * Math.Cos(angleSecondSide)), 0), outerColor);
            }

            vertexbuffer = new VertexBuffer(graphics, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            vertexbuffer.SetData<VertexPositionColor>(vertices);
        }

        public virtual void Update()
        {

        }

        public virtual double GetAirDensity(double altitude)
        {
            return 0.0f;
        }

        public void Draw(GraphicsDevice graphics, float zoom)
        {
            world = Matrix.CreateTranslation(0, 0, 0);
            
            //IT WORKS!
            view = Matrix.CreateLookAt(new Vector3(universe.rocket.position.X, -universe.rocket.position.Y, 10), new Vector3(universe.rocket.position.X, -universe.rocket.position.Y, 0), Vector3.UnitY) *
                   Matrix.CreateScale(zoom, zoom, 1);

            projection = Matrix.CreateOrthographic(graphics.Viewport.Width, graphics.Viewport.Height, 0.1f, 10.0f);


            basicEffect.World = world;
            basicEffect.View = view;
            basicEffect.Projection = projection;
            basicEffect.VertexColorEnabled = true;

            graphics.SetVertexBuffer(vertexbuffer);
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphics.DrawPrimitives(PrimitiveType.TriangleList, 0, triangles);
            }
        }


    }
}
