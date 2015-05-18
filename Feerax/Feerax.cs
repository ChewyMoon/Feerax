using System;
using Feerax.Engine;
using Feerax.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feerax
{
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class Feerax : Game
    {
        public static Feerax Instance;
        private GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        public Feerax()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 720,
                PreferredBackBufferWidth = 1280
            };

            Content.RootDirectory = "Content";

            Instance = this;
        }

        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.To(new MainMenuScreen(this));

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.Title = "Feerax " + (IntPtr.Size != 4 ? "64-bit" : "32-bit");
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

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            ScreenManager.ActiveScreen.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}