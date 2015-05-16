using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Extensions
{
    internal static class Texture2DExtensions
    {
        public static Vector2 GetCenter(this Texture2D texture)
        {
            var width = texture.GraphicsDevice.Viewport.Width;
            var height = texture.GraphicsDevice.Viewport.Height;

            return new Vector2(width/2 - texture.Width/2, height/2 - texture.Height/2);
        }
    }
}