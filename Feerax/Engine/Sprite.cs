// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Sprite.cs">
//   
// </copyright>
// <summary>
//   A sprite.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     A sprite.
    /// </summary>
    internal class Sprite
    {
        #region Fields

        /// <summary>
        ///     The sprite batch
        /// </summary>
        public readonly SpriteBatch SpriteBatch;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        public Sprite(Texture2D texture)
        {
            this.Texture = texture;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sprite" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        /// <param name="spriteBatch">
        ///     The sprite batch.
        /// </param>
        public Sprite(Texture2D texture, SpriteBatch spriteBatch)
        {
            this.Texture = texture;
            this.SpriteBatch = spriteBatch;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The bounds.
        /// </summary>
        public Rectangle Bounds
            => new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Width, (int)this.Height);

        /// <summary>
        ///     The center.
        /// </summary>
        public Vector2 Center
            =>
                new Vector2(
                    this.Texture.GraphicsDevice.Viewport.Width / 2 - this.Texture.Width / 2, 
                    this.Texture.GraphicsDevice.Viewport.Height / 2 - this.Texture.Height / 2);

        /// <summary>
        ///     The height.
        /// </summary>
        public float Height => this.Texture.Height * this.ScaleY;

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public Vector2 Position { get; set; } = Vector2.Zero;

        /// <summary>
        ///     Gets or sets the scale x.
        /// </summary>
        public float ScaleX { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the scale y.
        /// </summary>
        public float ScaleY { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the texture.
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        ///     The width.
        /// </summary>
        public float Width => this.Texture.Width * this.ScaleX;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Draws this instance.
        /// </summary>
        public void Draw()
        {
            this.SpriteBatch.Draw(this.Texture, null, this.Bounds);
        }

        #endregion
    }
}