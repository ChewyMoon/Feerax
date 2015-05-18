using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine.Entities.Blocks
{
    class Grass : Block
    {
        public static float Scale = 0.375f;
        public static Texture2D GrassTexture = new Grass().Texture;

        public override Texture2D Texture { get; set; } = Feerax.Instance.Content.Load<Texture2D>("Game/Ground/Grass/grassMid");

        public override Rectangle Bounds => new Rectangle(Position.ToPoint(), new Point((int)(Texture.Width * Scale), (int)(Texture.Height * Scale)));
    }
}
