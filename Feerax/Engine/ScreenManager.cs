// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ScreenManager.cs">
//   
// </copyright>
// <summary>
//   The screen manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax.Engine
{
    using System;

    /// <summary>
    ///     The screen manager.
    /// </summary>
    internal class ScreenManager
    {
        #region Public Properties

        /// <summary>
        ///     Gets the active screen.
        /// </summary>
        /// <value>
        ///     The active screen.
        /// </value>
        public static GameScreen ActiveScreen { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Switches to the specified screen.
        /// </summary>
        /// <param name="screen">The screen.</param>
        public static void To(GameScreen screen)
        {
            // First dispose the active screen to free up memory for new textures
            ActiveScreen?.Dispose();

            screen.Initialize();
            screen.LoadContent();

            ActiveScreen = screen;

            // Collect garbage
            GC.Collect();
        }

        #endregion
    }
}