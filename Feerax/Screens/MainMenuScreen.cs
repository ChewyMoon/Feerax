// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="MainMenuScreen.cs">
//   
// </copyright>
// <summary>
//   The main menu screen.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Screens
{
    using System;

    using global::Feerax.Engine;
    using global::Feerax.Engine.Maps;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    ///     The main menu screen.
    /// </summary>
    internal class MainMenuScreen : GameScreen
    {
        #region Fields

        /// <summary>
        ///     The logo.
        /// </summary>
        private Sprite _logo;

        /// <summary>
        ///     The play.
        /// </summary>
        private Sprite _play;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainMenuScreen" /> class.
        /// </summary>
        /// <param name="game">The game.</param>
        public MainMenuScreen(Feerax game)
            : base(game)
        {
        }

        #endregion

        #region Public Methods and Operators

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
            this.SpriteBatch.Begin();
            this._logo.Draw();
            this._play.Draw();
            this.SpriteBatch.End();
        }

        /// <summary>
        ///     Loads the content.
        /// </summary>
        public override void LoadContent()
        {
            this._logo = new Sprite(this.Content.Load<Texture2D>("Main Menu/logo"), this.SpriteBatch);
            this._logo.Position = new Vector2(this._logo.Center.X, 50);

            this._play = new Sprite(this.Content.Load<Texture2D>("Main Menu/play"), this.SpriteBatch);
            this._play.Position = this._play.Center;
        }

        /// <summary>
        ///     Updates the game.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            if (this._play.Bounds.Contains(Mouse.GetState().Position)
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                ScreenManager.To(new GameScene(this.Game, new Xareef()));
            }
        }

        #endregion
    }
}