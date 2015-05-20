// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="GameScene.cs">
//   
// </copyright>
// <summary>
//   The game scene.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Screens
{
    using System;

    using global::Feerax.Engine;
    using global::Feerax.Engine.Entities;
    using global::Feerax.Engine.Entities.Blocks;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     The game scene.
    /// </summary>
    internal class GameScene : GameScreen
    {
        #region Static Fields


        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static GameScene Instance { get; private set; }

        #endregion

        #region Fields

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The font.
        /// </value>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// Gets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Map Map { get; private set; }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        public Player Player { get; private set; }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameScene" /> class.
        /// </summary>
        /// <param name="game">
        ///     The game.
        /// </param>
        /// <param name="map">
        ///     The map.
        /// </param>
        public GameScene(Feerax game, Map map)
            : base(game)
        {
            this.Map = map;
            Instance = this;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The draw.
        /// </summary>
        /// <param name="gameTime">
        ///     The game time.
        /// </param>
        public override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();

            this.Map.Draw(this.SpriteBatch, gameTime);

            // Draw Player
            this.Player.Draw(gameTime);

            var length = this.Font.MeasureString(this.Player.Name).X;
            var x = this.Player.Bounds.Width / 2f - length / 2;
            this.SpriteBatch.DrawString(
                this.Font, 
                this.Player.Name, 
                this.Player.Position - new Vector2(-x, 20), 
                Color.CornflowerBlue);

            this.SpriteBatch.End();
        }

        /// <summary>
        ///     The load content.
        /// </summary>
        public override void LoadContent()
        {
            var playerTexture = this.Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_walk1");
            this.Player = new Player(
                playerTexture, 
                this.Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_walk2"), 
                this.Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_front"), 
                this.Content.Load<Texture2D>("Game/Players/128x256/Blue/alienBlue_jump"), 
                this.SpriteBatch)
                              {
                                  ScaleY = 0.5f, ScaleX = 0.5f, 
                                  Position =
                                      new Vector2(
                                      20, 
                                      (Grass.GrassTexture.GraphicsDevice.Viewport.Height
                                       - (Grass.GrassTexture.Height * Grass.Scale)) - playerTexture.Height * 0.5f)
                              };

            this.Font = this.Content.Load<SpriteFont>("Game/Fonts/Default");
        }

        /// <summary>
        ///     The update.
        /// </summary>
        /// <param name="gameTime">
        ///     The game time.
        /// </param>
        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("FPS: {0}", 1 / gameTime.ElapsedGameTime.TotalSeconds);

            this.Player.Update(gameTime);
        }

        #endregion
    }
}