using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine
{
    internal class Sprite
    {
        public readonly SpriteBatch SpriteBatch;

        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }

        public Sprite(Texture2D texture, SpriteBatch spriteBatch)
        {
            Texture = texture;
            SpriteBatch = spriteBatch;
        }

        public float Width => Texture.Width*ScaleX;
        public float Height => Texture.Height*ScaleY;
        public float ScaleX { get; set; } = 1.0f;
        public float ScaleY { get; set; } = 1.0f;
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Rectangle Bounds => new Rectangle((int) Position.X, (int) Position.Y, (int) Width, (int) Height);

        public Vector2 Center
            =>
                new Vector2(Texture.GraphicsDevice.Viewport.Width/2 - Texture.Width/2,
                    Texture.GraphicsDevice.Viewport.Height/2 - Texture.Height/2);

        public void Draw()
        {
            SpriteBatch.Draw(Texture, null, Bounds);
        }
    }
}