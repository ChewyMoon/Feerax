using System;

namespace Feerax.Engine
{
    internal class ScreenManager
    {
        /// <summary>
        ///     Gets the active screen.
        /// </summary>
        /// <value>
        ///     The active screen.
        /// </value>
        public static GameScreen ActiveScreen { get; private set; }

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
    }
}