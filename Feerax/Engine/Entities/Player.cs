// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="">
//   
// </copyright>
// <summary>
//   A player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Feerax.Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    ///     A player.
    /// </summary>
    internal class Player : Entity
    {
        #region Static Fields

        /// <summary>
        ///     The gravity.
        /// </summary>
        public static float Gravity = 100;

        /// <summary>
        ///     The move speed.
        /// </summary>
        public static int MoveSpeed = 400;

        #endregion

        #region Fields

        /// <summary>
        ///     The animation time.
        /// </summary>
        public int AnimationTime = 150;

        /// <summary>
        ///     The last animation time.
        /// </summary>
        public int LastAnimationT = Environment.TickCount;

        /// <summary>
        ///     The velocity of the player.
        /// </summary>
        public Vector2 Velocity = Vector2.Zero;

        /// <summary>
        ///     The front texture.
        /// </summary>
        private readonly Texture2D _front;

        /// <summary>
        ///     The first walking animation.
        /// </summary>
        private readonly Texture2D _walk1;

        /// <summary>
        ///     The second walking animation
        /// </summary>
        private readonly Texture2D _walk2;

        /// <summary>
        ///     The jumping animation.
        /// </summary>
        private Texture2D _jump;

        /// <summary>
        ///     The last keyboard state.
        /// </summary>
        private KeyboardState _lastKeyboardState = Keyboard.GetState();

        /// <summary>
        ///     The last mouse state.
        /// </summary>
        private MouseState _lastMouseState = Mouse.GetState();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="walk1">The walk1.</param>
        /// <param name="walk2">The walk2.</param>
        /// <param name="front">The front.</param>
        /// <param name="jump">The jump.</param>
        /// <param name="spriteBatch">The sprite batch.</param>
        public Player(Texture2D walk1, Texture2D walk2, Texture2D front, Texture2D jump, SpriteBatch spriteBatch)
            : base(walk1, spriteBatch)
        {
            this._walk1 = walk1;
            this._walk2 = walk2;
            this._front = front;
            this._jump = jump;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        public Player(Texture2D texture)
            : base(texture)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        /// <param name="spriteBatch">
        ///     The sprite batch.
        /// </param>
        public Player(Texture2D texture, SpriteBatch spriteBatch)
            : base(texture, spriteBatch)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the direction.
        /// </summary>
        public override Direction Direction { get; internal set; } = Direction.Forward;

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public override string Name { get; } = "Player";

        /// <summary>
        ///     Gets a value indicating whether the player is on ground.
        /// </summary>
        public bool OnGround
        {
            get
            {
                return
                    GameScene.Instance.Map.GetBlocks()
                        .Any(
                            x =>
                            x.Bounds.Intersects(
                                new Rectangle(this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height + 2)));
            }
        }

        /// <summary>
        ///     Gets or sets the sub entities.
        /// </summary>
        public override List<Entity> SubEntities { get; set; } = new List<Entity>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Draws the player.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Draw(
                this.Texture, 
                this.Position, 
                null, 
                Color.White, 
                0, 
                Vector2.Zero, 
                new Vector2(this.ScaleX, this.ScaleY), 
                this.Direction == Direction.Left ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 
                0);

            // Draw sub entities
            foreach (var entity in this.SubEntities)
            {
                entity.Draw(gameTime);
            }
        }

        /// <summary>
        ///     Updates the player.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.Position += this.Velocity * delta;

            if (!this.OnGround)
            {
                this.Velocity.Y += Gravity * delta;
            }

            if (this.OnGround)
            {
                this.Velocity.Y = 0;
            }

            // Jump
            if ((state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.W)) && this.OnGround)
            {
                this.Velocity.Y = -300;
            }

            if ((this._lastKeyboardState.IsKeyDown(Keys.Space) || this._lastKeyboardState.IsKeyDown(Keys.W))
                && (state.IsKeyUp(Keys.Space) && state.IsKeyUp(Keys.W)))
            {
                if (this.Velocity.Y < -12 * 4)
                {
                    this.Velocity.Y = -12 * 4;
                }
            }

            var mouseState = Mouse.GetState();

            // Fire missile
            if (mouseState.LeftButton == ButtonState.Pressed && this._lastMouseState.LeftButton == ButtonState.Released)
            {
                var bullet = new Bullet(Bullet.BulletTexture, this.SpriteBatch)
                                 {
                                    Point = mouseState.Position.ToVector2(), Start = this.Bounds.Center.ToVector2() 
                                 };
                bullet.Initialize();
                this.SubEntities.Add(bullet);
            }

            // Right
            if (state.IsKeyDown(Keys.D))
            {
                // Update Animation
                if (Environment.TickCount - this.LastAnimationT > this.AnimationTime)
                {
                    this.Texture = this.Texture == this._walk1 ? this._walk2 : this._walk1;
                    this.LastAnimationT = Environment.TickCount;
                    this.Direction = Direction.Right;
                }

                this.Position = new Vector2(this.Position.X + MoveSpeed * delta, this.Position.Y);
            }

            // Left
            if (state.IsKeyDown(Keys.A))
            {
                // Update Animation
                if (Environment.TickCount - this.LastAnimationT > this.AnimationTime)
                {
                    this.Texture = this.Texture == this._walk1 ? this._walk2 : this._walk1;
                    this.LastAnimationT = Environment.TickCount;
                    this.Direction = Direction.Left;
                }

                this.Position = new Vector2(this.Position.X - MoveSpeed * delta, this.Position.Y);
            }

            // Get out of running animation if we haven't moved in a while.
            if (Environment.TickCount - this.LastAnimationT > this.AnimationTime)
            {
                this.Direction = Direction.Forward;
                this.Texture = this._front;
            }

            // Update sub entities
            foreach (var entity in this.SubEntities)
            {
                entity.Update(gameTime);
            }

            // Remove invalids
            this.SubEntities.RemoveAll(x => !x.IsValid);
            this._lastMouseState = mouseState;
            this._lastKeyboardState = state;
        }

        #endregion
    }
}