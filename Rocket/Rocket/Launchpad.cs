﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket
{
    class Launchpad
    {
        double heightOverSea;
        int rotationRelativeToEarth;
        Vector2 position;
        Texture2D texture;
        Vector2 textureCenter;
        UniverseManager universe;

        public Launchpad(UniverseManager universe)
        {
            this.universe = universe;
        }

        public void Load(Texture2D texture)
        {
            this.texture = texture;
            textureCenter = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Draw(SpriteBatch spritebatch, GraphicsDevice graphics, float zoom)
        {
            Matrix viewMatrix = Matrix.Identity *
                    Matrix.CreateScale(new Vector3(zoom, zoom, 1));
                 // Matrix.CreateTranslation(new Vector3((graphics.Viewport.Width / 2), (graphics.Viewport.Height / 2), 0.0f));

            spritebatch.Begin(transformMatrix: viewMatrix);
            spritebatch.Draw(texture, position, null, Color.White, (MathHelper.ToRadians(rotationRelativeToEarth)), textureCenter, 1f, SpriteEffects.None, 0f);
            spritebatch.End();
        }
    }
}