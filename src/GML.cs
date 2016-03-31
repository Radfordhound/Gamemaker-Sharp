using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GMSharp
{
    public static class GML
    {
        #region Standard GML functions/variables/constants

        /// <summary>
        /// This variable holds a different constant depending on the operating system the game is currently being run with. <para/>
        /// Currently it should return correct values when running on Desktop Windows, Mac OSX, iOS, and Android. Other platforms will likely return "Unknown."
        /// </summary>
        public static OSType os_type = GetOS();

        /// <summary>
        /// Enumerator of Operating Systems MonoGame (GMSharp's framework) currently runs on.
        /// </summary>
        public enum OSType
        {
            os_windows, os_win8native, os_winphone, os_uwp,
            os_linux, os_macosx, os_ios, os_android,
            os_ps4, os_psvita, os_xboxone, os_ouya, os_unknown
        }

        /// <summary>
        /// Returns the unique game identifier. We recommend you use "Properties.Settings.Default.game_id" instead. <para />
        /// (Kept in for compatibility with existing GML projects. For GMSharp, this is always set to "183742990".)
        /// </summary>
        [Obsolete("This value is only kept in for compatibility with existing GML projects. We recommend you use \"Properties.Settings.Default.game_id\" instead.")]
        public static readonly int game_id = 183742990;
        
        /// <summary>
        /// The location where the game files are saved to.
        /// </summary>
        public static string game_save_id
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + GameProperties.gamedisplayname;
            }
        }

        /// <summary>
        /// Returns the game name string as defined in "GameProperties.gamedisplayname".
        /// </summary>
        public static string game_display_name
        {
            get
            {
                return GameProperties.gamedisplayname;
            }
        }

        /// <summary>
        /// Returns a version of the game display name as defined in "GameProperties.gamedisplayname" that's safe to use in file names (all invalid file name characters have been replaced with "_").
        /// </summary>
        public static string game_project_name
        {
            get
            {
                string projectname = GameProperties.gamedisplayname;
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    GameProperties.gamedisplayname.Replace(c,'_');
                }

                return projectname;
            }
        }

        /// <summary>
        /// Deprecated as it's NOT SUPPORTED ON ALL PLATFORMS! Please use "Main.game.End();" instead.
        /// </summary>
        [Obsolete("game_end could not be integrated into GMSharp due to a limitation that would prevent it from running on multiple platforms. Please use \"Main.game.end\" instead.", true)]
        public static void game_end()
        {
            //Why are you looking at this when you could just be using Main.game.End(); instead?! :P
        }

        /// <summary>
        /// THIS FUNCTION HAS NOT YET BEEN IMPLEMENTED: Restarts the game.
        /// </summary>
        public static void game_restart()
        {
            //TODO: CODE GAME RESTART CLASS
        }

        //TODO: Code the following functions/variables/constants (delete each line when implemented):
        //game_load
        //game_load_buffer
        //game_save
        //game_save_buffer
        //script_exists
        //script_get_name
        //script_execute
        //gml_release_mode
        //gml_pragma
        //parameter_count
        //parameter_string
        //environment_get_variable
        //external_define
        //external_call
        //external_free
        //cursor_sprite
        //alarm_set
        //alarm_get
        //GM_build_date
        //GM_version

        #endregion

        #region Sprite-related GML functions/variables/constants

        /// <summary>
        /// Draws a sprite at a given position.
        /// </summary>
        /// <param name="sprite">The index of the sprite to draw.</param>
        /// <param name="subimg">The sub-img (frame) of the sprite to draw (image_index or -1 correlate to the current frame of animation in the object).</param>
        /// <param name="x">The x coordinate of where to draw the sprite.</param>
        /// <param name="y">The y coordinate of where to draw the sprite.</param>
        public static void draw_sprite(GMSprite sprite, int subimg, float x, float y)
        {
            //TODO: This
        }

        //TODO: Add the rest of the sprite-related GML functions/variables/constants

        #endregion

        //TODO: Add the rest of the GML functions/variables/constants

        #region Non-GML functions

        /// <summary>
        /// Returns the current Operating System the game is running on. <para/>
        /// - Currently doesn't return correct values on all platforms!! -
        /// </summary>
        /// <returns>The Operating System the game is running on.</returns>
        private static OSType GetOS()
        {
            //TODO: Return correct values on all platforms
            int platform = (int)Environment.OSVersion.Platform;

            #if !__MOBILE__
                if (platform <= 3)
                {
                    return OSType.os_windows;
                }
                else if (platform == (int)PlatformID.MacOSX)
                {
                    return OSType.os_macosx;
                }
            #else
                #if __IOS__
                    return OSType.os_ios;
                #endif
                
                #if __ANDROID__
                    return OSType.os_android;
                #endif
            #endif

            return OSType.os_unknown;
        }

        #endregion
    }
}
