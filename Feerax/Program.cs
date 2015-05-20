// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Program.cs">
//   
// </copyright>
// <summary>
//   The main class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feerax
{
    using System;

#if WINDOWS || LINUX

    /// <summary>
    ///     The main class.
    /// </summary>
    public static class Program
    {
        #region Methods

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (var game = new Feerax())
            {
                game.Run();
            }
        }

        #endregion
    }
#endif
}