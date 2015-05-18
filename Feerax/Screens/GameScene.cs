using System;
using System.Collections.Generic;
using Feerax.Engine;
using Feerax.Engine.Entities;
using Feerax.Engine.Entities.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Screens
{
    internal class GameScene : GameScreen
    {
        public Player Player;
        public Map Map;
        public SpriteFont font;

        public GameScene(Feerax game, Map map) : base(game)
        {
            Map = map;
        }

        public override void LoadContent()
        {
            var playerTexture = Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_walk1");
            Player = new Player(playerTexture, Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_walk2"),
                Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_front"), SpriteBatch)
            {
                ScaleY = 0.5f,
                ScaleX = 0.5f,
                Position = new Vector2(20, (Grass.GrassTexture.GraphicsDevice.Viewport.Height - (Grass.GrassTexture.Height * Grass.Scale)) - playerTexture.Height*0.5f)
            };

            font = Content.Load<SpriteFont>("Game/Fonts/Default");
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("FPS: {0}", 1/gameTime.ElapsedGameTime.TotalSeconds);

            Player.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();

            Map.Draw(SpriteBatch, gameTime);

            // Draw Player
            Player.Draw(gameTime);

            var length = font.MeasureString(Player.Name).X;
            var x = Player.Bounds.Width/2f - length/2;
            SpriteBatch.DrawString(font, Player.Name, Player.Position - new Vector2(-x, 20), Color.CornflowerBlue);

            SpriteBatch.End();
        }
    }
}