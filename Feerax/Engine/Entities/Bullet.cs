using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine.Entities
{
    internal class Bullet : Entity
    {
        public static Texture2D BulletTexture = Feerax.Instance.Content.Load<Texture2D>("Game/Lasers/laserBlue01Flipped");
        public static int Speed = 100;
        public Vector2 Velocity;

        public Bullet(Texture2D texture) : base(texture)
        {
        }

        public Bullet(Texture2D texture, SpriteBatch spriteBatch) : base(texture, spriteBatch)
        {
        }

        public override string Name { get; } = "Bullet";
        public Vector2 Start { get; set; }
        public Vector2 Point { get; set; }

        public override bool IsValid
            => Position.Y < -30 || Position.X < -30 || Position.X > Feerax.Instance.GraphicsDevice.Viewport.Width;

        public void Initialize()
        {
            Velocity = -(Start - Point);
            Velocity.Normalize();
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity * Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Draw(GameTime gameTime)
        {
            var real = Start - Point;
            var rotation = (float) Math.Atan2(real.Y, real.X);

            SpriteBatch.Draw(Texture, Position, null, null, null, rotation, null, null, SpriteEffects.FlipHorizontally);
        }
    }
}