// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Bullet.cs">
//   
// </copyright>
// <summary>
//   A bullet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine.Entities
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     A bullet.
    /// </summary>
    internal class Bullet : Entity
    {
        #region Static Fields

        /// <summary>
        ///     The bullet texture.
        /// </summary>
        public static Texture2D BulletTexture = Feerax.Instance.Content.Load<Texture2D>(
            "Game/Lasers/laserBlue01Flipped");

        /// <summary>
        ///     The speed of the bullet.
        /// </summary>
        public static int Speed = 1000;

        #endregion

        #region Fields

        /// <summary>
        ///     The velocity.
        /// </summary>
        public Vector2 Velocity;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Bullet" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        public Bullet(Texture2D texture)
            : base(texture)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Bullet" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        /// <param name="spriteBatch">
        ///     The sprite batch.
        /// </param>
        public Bullet(Texture2D texture, SpriteBatch spriteBatch)
            : base(texture, spriteBatch)
        {
            this.Position = Vector2.One;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public override bool IsValid
            =>
                new Rectangle(
                    0, 
                    0, 
                    Feerax.Instance.GraphicsDevice.Viewport.Width, 
                    Feerax.Instance.GraphicsDevice.Viewport.Height).Contains(this.Bounds);

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public override string Name { get; } = "Bullet";

        /// <summary>
        ///     Gets or sets the point.
        /// </summary>
        public Vector2 Point { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        public Vector2 Start { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Draw(GameTime gameTime)
        {
            var real = this.Start - this.Point;
            var rotation = (float)Math.Atan2(real.Y, real.X);

            this.SpriteBatch.Draw(
                this.Texture, 
                this.Position, 
                null, 
                null, 
                null, 
                rotation, 
                null, 
                null, 
                SpriteEffects.FlipHorizontally);
        }

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            this.Position = this.Start;
            this.Velocity = -(this.Start - this.Point);
            this.Velocity.Normalize();
        }

        /// <summary>
        ///     Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            this.Position += this.Velocity * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        #endregion
    }
}