using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine.Entities
{
    internal abstract class Entity : Sprite
    {
        protected Entity(Texture2D texture) : base(texture)
        {
        }

        protected Entity(Texture2D texture, SpriteBatch spriteBatch) : base(texture, spriteBatch)
        {
        }

        public virtual string Name => "Unnamed Entity";
        public virtual Direction Direction { get; internal set; }
        public virtual List<Entity> SubEntities { get; set; } = new List<Entity>(0);
        public virtual bool IsValid { get; } = true;

        public virtual void Draw(GameTime gameTime)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}