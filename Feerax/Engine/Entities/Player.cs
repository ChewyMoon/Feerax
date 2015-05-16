using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Feerax.Engine.Entities
{
    internal class Player : Entity
    {
        public static int MoveSpeed = 200;
        public static int JumpHeight = 100;
        public static float Gravity = 300;
        private readonly Texture2D _front;
        private readonly Texture2D _walk1;
        private readonly Texture2D _walk2;
        private KeyboardState _lastState = Keyboard.GetState();
        public int AnimationTime = 150;
        public int LastAnimationT = Environment.TickCount;
        public Vector2 Velocity = Vector2.Zero;

        public Player(Texture2D walk1, Texture2D walk2, Texture2D front, SpriteBatch spriteBatch)
            : base(walk1, spriteBatch)
        {
            _walk1 = walk1;
            _walk2 = walk2;
            _front = front;
        }

        public Player(Texture2D texture) : base(texture)
        {
        }

        public Player(Texture2D texture, SpriteBatch spriteBatch) : base(texture, spriteBatch)
        {
        }

        public override Direction Direction { get; internal set; } = Direction.Forward;

        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            var delta = gameTime.ElapsedGameTime.TotalSeconds;

            Position += Velocity;

            Console.WriteLine("{0} | {1}", Environment.TickCount, LastAnimationT);

            // Jump
            if (state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.W))
            {
            }

            // Right
            if (state.IsKeyDown(Keys.D))
            {
                // Update Animation
                if (Environment.TickCount - LastAnimationT > AnimationTime)
                {
                    Texture = (Texture == _walk1 ? _walk2 : _walk1);
                    LastAnimationT = Environment.TickCount;
                    Direction = Direction.Right;
                }
                Position = new Vector2((float) (Position.X + MoveSpeed*delta), Position.Y);
            }

            // Left
            if (state.IsKeyDown(Keys.A))
            {
                // Update Animation
                if (Environment.TickCount - LastAnimationT > AnimationTime)
                {
                    Texture = (Texture == _walk1 ? _walk2 : _walk1);
                    LastAnimationT = Environment.TickCount;
                    Direction = Direction.Left;
                }
                Position = new Vector2((float) (Position.X - MoveSpeed*delta), Position.Y);
            }

            // Get out of running animation if we haven't moved in a while.
            if (Environment.TickCount - LastAnimationT > AnimationTime)
            {
                Direction = Direction.Forward;
                Texture = _front;
            }

            _lastState = state;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(Texture, Position, null, Color.White, 0, Vector2.Zero, new Vector2(ScaleX, ScaleY),
                (Direction == Direction.Left ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);
        }
    }
}