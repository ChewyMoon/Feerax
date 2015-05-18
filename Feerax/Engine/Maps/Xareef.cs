using System.Collections.Generic;
using System.Linq;
using Feerax.Engine.Entities.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine.Maps
{
    internal class Xareef : Map
    {
        private readonly Texture2D _background = Feerax.Instance.Content.Load<Texture2D>("Game/Backgrounds/blue_land");
        private readonly List<Block> _blocks = new List<Block>();
        public override int MapId => 1;
        public override string Name => "Xareef";

        public override IEnumerable<Block> GetBlocks()
        {
            // Populate map
            if (_blocks.Any())
            {
                return _blocks;
            }

            // Add bottom platform
            for (var i = 0;
                i < Feerax.Instance.GraphicsDevice.Viewport.Width/(Grass.GrassTexture.Width*Grass.Scale);
                i++)
            {
                _blocks.Add(new Grass
                {
                    Position =
                        new Vector2(i*Grass.GrassTexture.Width*Grass.Scale,
                            Grass.GrassTexture.GraphicsDevice.Viewport.Height - (Grass.GrassTexture.Height*Grass.Scale))
                });
            }

            return _blocks;
        }

        public override Texture2D GetBackground()
        {
            return _background;
        }
    }
}