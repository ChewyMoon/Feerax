using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax.Engine
{
    internal abstract class GameScreen : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameScreen" /> class.
        /// </summary>
        /// <param name="game">The game.</param>
        protected GameScreen(Feerax game)
        {
            Game = game;
        }

        /// <summary>
        ///     Gets the game.
        /// </summary>
        /// <value>
        ///     The game.
        /// </value>
        public Feerax Game { get; }

        /// <summary>
        ///     The ContentManager
        /// </summary>
        public ContentManager Content => Game.Content;

        /// <summary>
        ///     Gets or sets the sprite batch.
        /// </summary>
        /// <value>
        ///     The sprite batch.
        /// </value>
        public SpriteBatch SpriteBatch => Game.SpriteBatch;

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public virtual void Dispose()
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

        /// <summary>
        ///     Draws the game.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Draw(GameTime gameTime)
        {
        }
    }
}