using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; //Let's take some time to reflect....
using System.IO;
using System.Numerics;

namespace GMSharp
{
    /// <summary>
    /// Contains the base variables/constants/functions pertaining to GMSharp.
    /// </summary>
    public static class Main
    {
        /// <summary>
        /// The path the application was started from.
        /// </summary>
        public static string startuppath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Returns the path to the game's content. <para/>
        /// Change "Main.game.Content.RootDirectory" if you wish to modify contentpath's value.
        /// </summary>
        public static string contentpath
        {
            get
            {
                return startuppath + "\\" + game.Content.RootDirectory;
            }
        }
        /// <summary>
        /// The main game class.
        /// </summary>
        public static GMGame game;
    }

    /// <summary>
    /// Contains game-related properties (many of which come from the GMS Global Game Settings window).
    /// </summary>
    public class GameProperties
    {
        /// <summary>
        /// The name of your game.
        /// </summary>
        public static string gamedisplayname  = "GMSharp";

        /// <summary>
        /// Where game save data will be stored. <para/>
        /// Can be saved to the following locations: <para/>
        /// - The user's local application data ("SaveDataLocations.LocalAppData"). <para/>
        /// - The user's roaming application data ("SaveDataLocations.AppData"). <para/>
        /// - A custom location.
        /// </summary>
        public static string savedatalocation = "";

        /// <summary>
        /// Whether or not to display the game's splash screen loaded from the game's "Content/splashscreen.png" file.
        /// </summary>
        public static bool displaysplashscreen = true;
    }

    /// <summary>
    /// Typical locations for game save data.
    /// </summary>
    public struct SaveDataLocations
    {
        /// <summary>
        /// Represents the user's local application data. Typically in "C:\Users\USERNAME\AppData\Local".
        /// </summary>
        public static readonly string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        /// <summary>
        /// Represents the user's roaming application data. Typically in "C:\Users\USERNAME\AppData\Roaming".
        /// </summary>
        public static readonly string AppData      = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }
}
