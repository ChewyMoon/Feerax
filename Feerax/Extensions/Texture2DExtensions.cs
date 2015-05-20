// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Texture2DExtensions.cs">
//   
// </copyright>
// <summary>
//   Texture 2 d extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Extensions
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     Texture 2 d extensions.
    /// </summary>
    internal static class Texture2DExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Gets the center.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <returns></returns>
        public static Vector2 GetCenter(this Texture2D texture)
        {
            var width = texture.GraphicsDevice.Viewport.Width;
            var height = texture.GraphicsDevice.Viewport.Height;

            return new Vector2(width / 2 - texture.Width / 2, height / 2 - texture.Height / 2);
        }

        #endregion
    }
}