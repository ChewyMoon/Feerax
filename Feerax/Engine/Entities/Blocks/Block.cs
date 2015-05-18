using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine.Entities.Blocks
{
    abstract class Block
    {
        public Vector2 Position { get; set; }
        public virtual Texture2D Texture { get; set; }
        public virtual Rectangle Bounds => Rectangle.Empty;

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, null, Bounds);
        }
    }
}
