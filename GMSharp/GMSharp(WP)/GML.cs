using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GMSharp
{
    /// <summary>
    /// The main class for the wrapped GML functions/variables/constants.
    /// </summary>
    public static class GML
    {
        #region Standard GML functions/variables/constants
        //
        #endregion

        #region Debug only functions/variables/constants
        /// <summary>
        /// Displays an error message with a custom error string.
        /// </summary>
        /// <param name="str">Whether to abort (true) or not (false).</param>
        /// <param name="abort">The string to show in the pop-up message.</param>
        /// <param name="ex">The exception of the caught error.</param>
        public static void show_error(string str,Exception ex, bool abort)
        {
            GMSharp.errorstrng = string.Format("{0}\n\nAdvanced Info can not be displayed on this platform.:(",str);
            GMSharp.iserroring = abort;
            GMSharp.iswarning = !abort;
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        /// <param name="ex">The exception of the caught error.</param>
        /// <param name="abort">The string to show in the pop-up message.</param>
        public static void show_error(Exception ex, bool abort)
        {
            GMSharp.errorstrng = "An un-identified error has occured.\n\nAdvanced Info can not be displayed on this platform.:(";
            GMSharp.iserroring = abort;
            GMSharp.iswarning = !abort;
        }
        #endregion

        #region Room Functions/Variables/Constants
        /// <summary>
        /// The index of the current room.
        /// </summary>
        public static int room {get; private set;}

        /// <summary>
        /// This is used to go to a given room.
        /// </summary>
        /// <param name="numb"> The index of the room to go to. </param>
        public static void room_goto(int numb)
        {
            
            room = numb;
        }
        #endregion
    }
}
