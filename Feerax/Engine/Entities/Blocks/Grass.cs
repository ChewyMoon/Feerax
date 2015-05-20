// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Grass.cs">
//   
// </copyright>
// <summary>
//   The grass.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine.Entities.Blocks
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     The grass.
    /// </summary>
    internal class Grass : Block
    {
        #region Static Fields

        /// <summary>
        ///     The grass texture.
        /// </summary>
        public static Texture2D GrassTexture = new Grass().Texture;

        /// <summary>
        ///     The scale.
        /// </summary>
        public static float Scale = 0.375f;

        #endregion

        #region Public Properties

        /// <summary>
        ///     The bounds.
        /// </summary>
        public override Rectangle Bounds
            =>
                new Rectangle(
                    this.Position.ToPoint(), 
                    new Point((int)(this.Texture.Width * Scale), (int)(this.Texture.Height * Scale)));

        /// <summary>
        ///     Gets or sets the texture.
        /// </summary>
        public override Texture2D Texture { get; set; } =
            Feerax.Instance.Content.Load<Texture2D>("Game/Ground/Grass/grassMid");

        #endregion
    }
}