// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Block.cs">
//   
// </copyright>
// <summary>
//   The block.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine.Entities.Blocks
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     The block.
    /// </summary>
    internal abstract class Block
    {
        #region Public Properties

        /// <summary>
        ///     The bounds.
        /// </summary>
        public virtual Rectangle Bounds => Rectangle.Empty;

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        ///     Gets or sets the texture.
        /// </summary>
        public virtual Texture2D Texture { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The draw.
        /// </summary>
        /// <param name="gameTime">
        ///     The game time.
        /// </param>
        /// <param name="spriteBatch">
        ///     The sprite batch.
        /// </param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, null, this.Bounds);
        }

        #endregion
    }
}