using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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

        #region Key Constants
        /// <summary>
        /// Virtual Key Constants from GML
        /// </summary>
        public enum vkeys
        {
        /// <summary>
        /// keycode representing that no key is pressed
        /// </summary>
        vk_nokey = Keys.None,
        /// <summary>
        /// keycode representing that any key is pressed
        /// </summary>
        vk_anykey = -1,
        /// <summary>
        /// keycode for left arrow key
        /// </summary>
        vk_left = Keys.Left,
        /// <summary>
        /// keycode for right arrow key
        /// </summary>
         vk_right = Keys.Right,
        /// <summary>
        /// keycode for up arrow key
        /// </summary>
         vk_up = Keys.Up,
        /// <summary>
        /// keycode for down arrow key
        /// </summary>
         vk_down = Keys.Down,
        /// <summary>
        /// enter key
        /// </summary>
         vk_enter = Keys.Enter,
        /// <summary>
        /// escape key
        /// </summary>
         vk_escape = Keys.Escape,
        /// <summary>
        /// spacebar
        /// </summary>
         vk_space = Keys.Space,
        /// <summary>
        /// either of the shift keys
        /// </summary>
         vk_shift,
        /// <summary>
        /// either of the control keys
        /// </summary>
         vk_control,
        /// <summary>
        /// either of the alt keys
        /// </summary>
         vk_alt,
        /// <summary>
        /// backspace key
        /// </summary>
        vk_backspace = Keys.Back,
        /// <summary>
        /// tab key
        /// </summary>
        vk_tab = Keys.Tab,
        /// <summary>
        /// home key
        /// </summary>
        vk_home = Keys.Home,
        /// <summary>
        /// end key
        /// </summary>
        vk_end = Keys.End,
        /// <summary>
        /// delete key
        /// </summary>
        vk_delete = Keys.Delete,
        /// <summary>
        /// insert key
        /// </summary>
        vk_insert = Keys.Insert,
        /// <summary>
        /// pageup key
        /// </summary>
        vk_pageup = Keys.PageUp,
        /// <summary>
        /// pagedown key
        /// </summary>
        vk_pagedown = Keys.PageDown,
        /// <summary>
        /// pause/break key
        /// </summary>
        vk_pause = Keys.Pause,
        /// <summary>
        /// printscreen/sysrq key
        /// </summary>
        vk_printscreen = Keys.PrintScreen,
        /// <summary>
        /// keycode for the F1 function key
        /// </summary>
        vk_f1 = Keys.F1,
        /// <summary>
        /// keycode for the F2 function key
        /// </summary>
        vk_f2 = Keys.F2,
        /// <summary>
        /// keycode for the F3 function key
        /// </summary>
        vk_f3 = Keys.F3,
        /// <summary>
        /// keycode for the F4 function key
        /// </summary>
        vk_f4 = Keys.F4,
        /// <summary>
        /// keycode for the F5 function key
        /// </summary>
        vk_f5 = Keys.F5,
        /// <summary>
        /// keycode for the F6 function key
        /// </summary>
        vk_f6 = Keys.F6,
        /// <summary>
        /// keycode for the F7 function key
        /// </summary>
        vk_f7 = Keys.F7,
        /// <summary>
        /// keycode for the F8 function key
        /// </summary>
        vk_f8 = Keys.F8,
        /// <summary>
        /// keycode for the F9 function key
        /// </summary>
        vk_f9 = Keys.F9,
        /// <summary>
        /// keycode for the F10 function key
        /// </summary>
        vk_f10 = Keys.F10,
        /// <summary>
        /// keycode for the F11 function key
        /// </summary>
        vk_f11 = Keys.F11,
        /// <summary>
        /// keycode for the F12 function key
        /// </summary>
        vk_f12 = Keys.F12,
        /// <summary>
        /// number key 0 on the numeric keypad
        /// </summary>
        vk_numpad0 = Keys.NumPad0,
        /// <summary>
        /// number key 1 on the numeric keypad
        /// </summary>
        vk_numpad1 = Keys.NumPad1,
        /// <summary>
        /// number key 2 on the numeric keypad
        /// </summary>
        vk_numpad2 = Keys.NumPad2,
        /// <summary>
        /// number key 3 on the numeric keypad
        /// </summary>
        vk_numpad3 = Keys.NumPad3,
        /// <summary>
        /// number key 4 on the numeric keypad
        /// </summary>
        vk_numpad4 = Keys.NumPad4,
        /// <summary>
        /// number key 5 on the numeric keypad
        /// </summary>
        vk_numpad5 = Keys.NumPad5,
        /// <summary>
        /// number key 6 on the numeric keypad
        /// </summary>
        vk_numpad6 = Keys.NumPad6,
        /// <summary>
        /// number key 7 on the numeric keypad
        /// </summary>
        vk_numpad7 = Keys.NumPad7,
        /// <summary>
        /// number key 8 on the numeric keypad
        /// </summary>
        vk_numpad8 = Keys.NumPad8,
        /// <summary>
        /// number key 9 on the numeric keypad
        /// </summary>
        vk_numpad9 = Keys.NumPad9,
        /// <summary>
        /// multiply key on the numeric keypad
        /// </summary>
        vk_multiply = Keys.Multiply,
        /// <summary>
        /// divide key on the numeric keypad
        /// </summary>
        vk_divide = Keys.Divide,
        /// <summary>
        /// add key on the numeric keypad
        /// </summary>
        vk_add = Keys.Add,
        /// <summary>
        /// subtract key on the numeric keypad
        /// </summary>
        vk_subtract = Keys.Subtract,
        /// <summary>
        /// decimal dot key on the numeric keypad
        /// </summary>
        vk_decimal = Keys.Decimal,
    }
        #endregion

        /// <summary>
        /// Returns whether the given key on the keyboard is currently held down.
        /// </summary>
        /// <param name="key">The key to check the down state of.</param>
        /// <returns>Whether the given key on the keyboard is currently held down.</returns>
        public static bool keyboard_check(vkeys key)
        {
            if (key == vkeys.vk_anykey)
            {
                return Keyboard.GetState().GetPressedKeys().Length > 0;
            }
            else if (key == vkeys.vk_nokey)
            {
                return Keyboard.GetState().GetPressedKeys().Length <= 0;
            }
            else if (key == vkeys.vk_shift)
            {
                return (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift));
            }
            else if (key == vkeys.vk_control)
            {
                return (Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl));
            }
            else if (key == vkeys.vk_alt)
            {
                return (Keyboard.GetState().IsKeyDown(Keys.LeftAlt) || Keyboard.GetState().IsKeyDown(Keys.RightAlt));
            }
            return Keyboard.GetState().IsKeyDown((Keys)key);
        }

        /// <summary>
        /// Returns whether the key with the particular keycode is pressed by checking the hardware directly.
        /// Currently functions identically to keyboard_check.
        /// </summary>
        /// <param name="key">The key to check the down state of.</param>
        /// <returns>Whether the key with the particular keycode is pressed by checking the hardware directly.</returns>
        public static bool keyboard_check_direct(vkeys key)
        {
            return keyboard_check(key);
        }
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
            if (!GMSharp.iserroring && !GMSharp.iswarning)
            {
                StackTrace st = new StackTrace(ex, true);

                GMSharp.errorstrng = string.Format("{0}\n\nAdvanced Info (For Debugging):\n\n{1}", str, st.ToString());
                GMSharp.iserroring = abort;
                GMSharp.iswarning = !abort;
            }
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        /// <param name="ex">The exception of the caught error.</param>
        /// <param name="abort">The string to show in the pop-up message.</param>
        public static void show_error(Exception ex, bool abort)
        {
            StackTrace st = new StackTrace(ex, true);

            GMSharp.errorstrng = string.Format("An un-identified error has occured.\n\nAdvanced Info (For Debugging):\n\n{0}", st.ToString());
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

        /// <summary>
        /// This will return the index of the room after the given room id.
        /// </summary>
        /// <param name="numb">The index of the base room to check from.</param>
        public static int room_next(int numb)
        {
            if (GMSharpGame.rooms.Count-1 > numb)
            {
                return numb+1;
            }
            return -1;
        }
        #endregion

        #region Sprite Functions/Variables/Constants
        //TODO: Add functions
        #endregion

        #region Object Functions/Variables/Constants
        /// <summary>
        /// Creates an instance of a given object at a given position.
        /// </summary>
        /// <param name="x">The x position the object will be created at.</param>
        /// <param name="y">The y position the object will be created at.</param>
        /// <param name="obj">The object to create an instance of.</param>
        public static Resources.Object instance_create(int x, int y, Resources.Object obj)
        {
            Resources.Object newobj = new Resources.Object();
            newobj.x = x;
            newobj.y = y;
            GMSharpGame.rooms[room].objects.Add(newobj);
            newobj.Init();
            return newobj;
        }
        #endregion

        #region Drawing functions/variables/constants

        #region Color variables
            public static readonly Color c_aqua = Color.Aqua;
            public static readonly Color c_black = Color.Black;
            public static readonly Color c_blue = Color.Blue;
            public static readonly Color c_dkgray = Color.DarkGray;
            public static readonly Color c_fuchsia = Color.Fuchsia;
            public static readonly Color c_gray = Color.Gray;
            public static readonly Color c_green = Color.Green;
            public static readonly Color c_lime = Color.Lime;
            public static readonly Color c_ltgray = Color.LightGray;
            public static readonly Color c_maroon = Color.Maroon;
            public static readonly Color c_navy = Color.Navy;
            public static readonly Color c_olive = Color.Olive;
            public static readonly Color c_orange = Color.Orange;
            public static readonly Color c_purple = Color.Purple;
            public static readonly Color c_red = Color.Red;
            public static readonly Color c_silver = Color.Silver;
            public static readonly Color c_teal = Color.Teal;
            public static readonly Color c_white = Color.White;
            public static readonly Color c_yellow = Color.Yellow;
        #endregion

        /// <summary>
        /// Draws a sprite at a given position, with customizable scaling, rotation, blend and alpha.
        /// </summary>
        /// <param name="sprite">The index of the sprite to draw.</param>
        /// <param name="subimg">The subimg (frame) of the sprite to draw (image_index or -1 correlate to the current frame of animation in the object).</param>
        /// <param name="x">The x coordinate of where to draw the sprite.</param>
        /// <param name="y">The y coordinate of where to draw the sprite.</param>
        /// <param name="xscale">The horizontal scaling of the sprite, as a multiplier: 1 = normal scaling, 0.5 is half etc...</param>
        /// <param name="yscale">The vertical scaling of the sprite as a multiplier: 1 = normal scaling, 0.5 is half etc...</param>
        /// <param name="rot">The rotation of the sprite. 0=right way up, 90=rotated 90 degrees counter-clockwise etc...</param>
        /// <param name="colour">The colour with which to blend the sprite. c_white is to display it normally.</param>
        /// <param name="alpha">The alpha of the sprite (from 0 to 1 where 0 is transparent and 1 opaque).</param>
        public static void draw_sprite_ext(Resources.Sprite sprite,int subimg, double x, double y, double xscale,double yscale,double rot,Color colour,double alpha)
        {
            GMSharpGame.spriteBatch.Draw(sprite.frames[subimg], new Vector2((float)x, (float)y), null, null, new Vector2(0, 0), (float)rot, new Vector2((float)xscale, (float)yscale), colour * (float)alpha);
        }

        /// <summary>
        /// This draws the instance sprite the same as the default draw.
        /// </summary>
        /// <param name="obj">The object to draw. Use 'this' if you're un-sure.</param>
        public static void draw_self(Resources.Object obj)
        {
            GMSharpGame.spriteBatch.Draw(obj.sprite.frames[obj.image_index], new Vector2(obj.x, obj.y),null,null,new Vector2(0,0), 0, Vector2.One,GML.c_white * 1);
        }
        #endregion
    }
}
