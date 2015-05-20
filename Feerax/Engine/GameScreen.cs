// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="GameScreen.cs">
//   
// </copyright>
// <summary>
//   The game screen.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     The game screen.
    /// </summary>
    internal abstract class GameScreen : IDisposable
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameScreen" /> class.
        /// </summary>
        /// <param name="game">The game.</param>
        protected GameScreen(Feerax game)
        {
            this.Game = game;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     The ContentManager
        /// </summary>
        public ContentManager Content => this.Game.Content;

        /// <summary>
        ///     Gets the game.
        /// </summary>
        /// <value>
        ///     The game.
        /// </value>
        public Feerax Game { get; }

        /// <summary>
        ///     Gets or sets the sprite batch.
        /// </summary>
        /// <value>
        ///     The sprite batch.
        /// </value>
        public SpriteBatch SpriteBatch => this.Game.SpriteBatch;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public virtual void Dispose()
        {
        }

        /// <summary>
        ///     Draws the game.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Draw(GameTime gameTime)
        {
        }

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        ///     Loads the content.
        /// </summary>
        public virtual void LoadContent()
        {
        }

        /// <summary>
        ///     Updates the game.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Update(GameTime gameTime)
        {
        }

        #endregion
    }
}