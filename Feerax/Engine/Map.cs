// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Map.cs">
//   
// </copyright>
// <summary>
//   Map interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine
{
    using System.Collections.Generic;

    using global::Feerax.Engine.Entities.Blocks;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     Map interface.
    /// </summary>
    internal abstract class Map
    {
        #region Public Properties

        /// <summary>
        ///     Gets the map id.
        /// </summary>
        public virtual int MapId { get; } = -1;

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public virtual string Name { get; } = "Unknown Map";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Draws the map.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="gameTime">The game time.</param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(
                this.GetBackground(), 
                null, 
                new Rectangle(
                    0, 
                    0, 
                    Feerax.Instance.GraphicsDevice.Viewport.Width, 
                    Feerax.Instance.GraphicsDevice.Viewport.Height));
            foreach (var block in this.GetBlocks())
            {
                block.Draw(gameTime, spriteBatch);
            }
        }

        /// <summary>
        ///     Gets the background.
        /// </summary>
        /// <returns></returns>
        public virtual Texture2D GetBackground()
        {
            return new Texture2D(Feerax.Instance.GraphicsDevice, 0, 0);
        }

        /// <summary>
        ///     Gets the blocks in the map.
        /// </summary>
        /// <returns>
        /// </returns>
        public virtual IEnumerable<Block> GetBlocks()
        {
            return new List<Block>(0);
        }

        /// <summary>
        ///     Updates the map.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Update(GameTime gameTime)
        {
        }

        #endregion
    }
}