using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMSharp.Resources;
using GMSharp;
using TestGame.Objects;

namespace TestGame
{
    public static class Resources
    {
        /*Note to new users: If you've never used C# or any high-level programming language, this
         *part may confuse you. Please read the explanation written here: https://github.com/Radfordhound/Gamemaker-Sharp/wiki */

        #region Declare (Or "Let the compiler know about.") all your resources here!

        #region Sprites
        #endregion

        #region Sounds
        #endregion

        #region Backgrounds
        #endregion

        #region Paths
        #endregion

        #region Scripts
        #endregion

        #region Fonts
        #endregion

        #region Time Lines
        #endregion

        #region Objects
        #endregion

        #region Rooms
        public static Room rm_main = new Room();
        #endregion
        #endregion

        /// <summary>
        /// Defines the resources. Pretty self-explanatory.
        /// </summary>
        public static void Define()
        {
            #region Define (Or "Let the compiler know what goes inside.") all your resources here!

            #region Sprites
            #endregion
            
            #region Sounds
            #endregion

            #region Backgrounds
            #endregion

            #region Paths
            #endregion

            #region Scripts
            #endregion

            #region Fonts
            #endregion

            #region Time Lines
            #endregion

            #region Objects
            #endregion

            #region Rooms
            rm_main.objects.Add(new obj_player());
            Main.rooms.Add(rm_main);
            #endregion
            #endregion
        }
    }
}
