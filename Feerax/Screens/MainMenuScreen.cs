using System;
using Feerax.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Feerax.Screens
{
    internal class MainMenuScreen : GameScreen
    {
        private Sprite _logo;
        private Sprite _play;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuScreen" /> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public MainMenuScreen(Feerax game) : base(game)
        {
        }

        /// <summary>
        ///     Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            _logo = new Sprite(Content.Load<Texture2D>("Main Menu/logo"), SpriteBatch);
            _logo.Position = new Vector2(_logo.Center.X, 50);

            _play = new Sprite(Content.Load<Texture2D>("Main Menu/play"), SpriteBatch);
            _play.Position = _play.Center;
        }

        public override void Update(GameTime gameTime)
        {
            if (_play.Bounds.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                ScreenManager.To(new GameScene(Game));
            }
        }

        /// <summary>
        ///     Draws the game.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if
        ///     <see
        ///         cref="M:Microsoft.Xna.Framework.Graphics.SpriteBatch.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode,Microsoft.Xna.Framework.Graphics.BlendState,Microsoft.Xna.Framework.Graphics.SamplerState,Microsoft.Xna.Framework.Graphics.DepthStencilState,Microsoft.Xna.Framework.Graphics.RasterizerState,Microsoft.Xna.Framework.Graphics.Effect,System.Nullable{Microsoft.Xna.Framework.Matrix})" />
        ///     is called next time without previous <see cref="M:Microsoft.Xna.Framework.Graphics.SpriteBatch.End" />.
        /// </exception>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            _logo.Draw();
            _play.Draw();
            SpriteBatch.End();
        }
    }
}