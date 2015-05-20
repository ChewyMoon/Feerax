// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Xareef.cs">
//   
// </copyright>
// <summary>
//   The Xareef map, 1st map ever.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine.Maps
{
    using System.Collections.Generic;
    using System.Linq;

    using global::Feerax.Engine.Entities.Blocks;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     The Xareef map, 1st map ever.
    /// </summary>
    internal class Xareef : Map
    {
        #region Fields

        /// <summary>
        ///     The background
        /// </summary>
        private readonly Texture2D background = Feerax.Instance.Content.Load<Texture2D>("Game/Backgrounds/blue_land");

        /// <summary>
        ///     The blocks.
        /// </summary>
        private readonly List<Block> blocks = new List<Block>();

        #endregion

        #region Public Properties

        /// <summary>
        ///     The map id.
        /// </summary>
        public override int MapId => 1;

        /// <summary>
        ///     The name.
        /// </summary>
        public override string Name => "Xareef";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the background.
        /// </summary>
        /// <returns></returns>
        public override Texture2D GetBackground()
        {
            return this.background;
        }

        /// <summary>
        ///     Gets the blocks.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Block> GetBlocks()
        {
            // Populate map
            if (this.blocks.Any())
            {
                return this.blocks;
            }

            // Add bottom platform
            for (var i = 0;
                 i < Feerax.Instance.GraphicsDevice.Viewport.Width / (Grass.GrassTexture.Width * Grass.Scale);
                 i++)
            {
                this.blocks.Add(
                    new Grass
                        {
                            Position =
                                new Vector2(
                                i * Grass.GrassTexture.Width * Grass.Scale, 
                                Grass.GrassTexture.GraphicsDevice.Viewport.Height
                                - (Grass.GrassTexture.Height * Grass.Scale))
                        });
            }

            return this.blocks;
        }

        #endregion
    }
}