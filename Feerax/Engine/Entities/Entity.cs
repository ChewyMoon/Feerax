// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Entity.cs">
//   
// </copyright>
// <summary>
//   An entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine.Entities
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    ///     An entity.
    /// </summary>
    internal abstract class Entity : Sprite
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        protected Entity(Texture2D texture)
            : base(texture)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        /// <param name="texture">
        ///     The texture.
        /// </param>
        /// <param name="spriteBatch">
        ///     The sprite batch.
        /// </param>
        protected Entity(Texture2D texture, SpriteBatch spriteBatch)
            : base(texture, spriteBatch)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the direction.
        /// </summary>
        public virtual Direction Direction { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether is valid.
        /// </summary>
        public virtual bool IsValid { get; } = true;

        /// <summary>
        ///     The name.
        /// </summary>
        public virtual string Name => "Unnamed Entity";

        /// <summary>
        ///     Gets or sets the sub entities.
        /// </summary>
        public virtual List<Entity> SubEntities { get; set; } = new List<Entity>(0);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Draw(GameTime gameTime)
        {
        }

        /// <summary>
        ///     Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Update(GameTime gameTime)
        {
        }

        #endregion
    }
}