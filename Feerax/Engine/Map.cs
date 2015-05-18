using System.Collections.Generic;
using Feerax.Engine.Entities.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine
{
    internal abstract class Map
    {
        public virtual IEnumerable<Block> GetBlocks()
        {
            return new List<Block>(0);
        }

        public virtual Texture2D GetBackground()
        {
            return new Texture2D(Feerax.Instance.GraphicsDevice, 0, 0);
        }

        public virtual int MapId { get; } = -1;
        public virtual string Name { get; } = "Unknown Map";

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(GetBackground(), null, new Rectangle(0, 0, Feerax.Instance.GraphicsDevice.Viewport.Width, Feerax.Instance.GraphicsDevice.Viewport.Height));
            foreach (var block in GetBlocks())
            {
                block.Draw(gameTime, spriteBatch);
            }
        }
       
    }
}