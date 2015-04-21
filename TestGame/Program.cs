#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace TestGame
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static GMSharp.GMSharpGame game;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                game = new Main();
                game.Run();
            }
            catch (Exception ex)
            {
                GMSharp.GML.show_error("Something went wrong during the execution of your game!\nYou're lucky to even be seeing this message!",ex,true);
            }
        }
    }
#endif
}
