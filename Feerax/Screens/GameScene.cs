using System;
using System.Collections.Generic;
using Feerax.Engine;
using Feerax.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Screens
{
    internal class GameScene : GameScreen
    {
        private readonly List<Sprite> _platform = new List<Sprite>();
        private Texture2D _background;
        public Player Player;

        public GameScene(Feerax game) : base(game)
        {
        }

        public override void LoadContent()
        {
            var grass = Content.Load<Texture2D>("Game/Ground/Grass/grassMid");
            const float scale = 0.375f;
            var y = grass.GraphicsDevice.Viewport.Height - (grass.Height*scale);
            var grassCount = Game.GraphicsDevice.Viewport.Width/(grass.Width*scale);

            for (var i = 0; i < grassCount; i++)
            {
                _platform.Add(new Sprite(grass, SpriteBatch)
                {
                    Position = new Vector2(i*grass.Width*scale, y),
                    ScaleX = scale,
                    ScaleY = scale
                });
            }

            _background = Content.Load<Texture2D>("Game/Backgrounds/blue_land");

            var playerTexture = Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_walk1");
            Player = new Player(playerTexture, Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_walk2"),
                Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_front"), SpriteBatch)
            {
                ScaleY = 0.5f,
                ScaleX = 0.5f,
                Position = new Vector2(20, y - playerTexture.Height*0.5f)
            };
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("FPS: {0}", 1/gameTime.ElapsedGameTime.TotalSeconds);

            Player.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            // Draw Background
            SpriteBatch.Draw(_background, null,
                new Rectangle(0, 0, Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height));

            // Draw grass
            foreach (var grass in _platform)
            {
                grass.Draw();
            }


            // Draw Player
            Player.Draw(gameTime);

            SpriteBatch.End();
        }
    }
}