// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Feerax.cs">
//   
// </copyright>
// <summary>
//   This is the main type for your game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax
{
    using System;

    using global::Feerax.Engine;
    using global::Feerax.Screens;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class Feerax : Game
    {
        #region Static Fields

        /// <summary>
        ///     The instance.
        /// </summary>
        public static Feerax Instance;

        #endregion

        #region Fields

        /// <summary>
        ///     The sprite batch.
        /// </summary>
        public SpriteBatch SpriteBatch;

        /// <summary>
        ///     The graphics.
        /// </summary>
        private GraphicsDeviceManager graphics;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Feerax" /> class.
        /// </summary>
        public Feerax()
        {
            this.graphics = new GraphicsDeviceManager(this)
                                {
                                   PreferredBackBufferHeight = 720, PreferredBackBufferWidth = 1280 
                                };

            this.Content.RootDirectory = "Content";

            Instance = this;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.Black);

            ScreenManager.ActiveScreen.Draw(gameTime);

            base.Draw(gameTime);
        }

        /// <summary>
        ///     The initialize.
        /// </summary>
        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            ScreenManager.To(new MainMenuScreen(this));

            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = true;
            this.Window.Title = "Feerax " + (Environment.Is64BitProcess ? "64-bit" : "32-bit");
            this.IsFixedTimeStep = false;
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            ScreenManager.ActiveScreen.Update(gameTime);

            base.Update(gameTime);
        }

        #endregion
    }
}