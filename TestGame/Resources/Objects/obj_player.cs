using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMSharp;

namespace TestGame.Objects
{
    public class obj_player : GMSharp.Resources.Object
    {
        public override void Create()
        {
            sprite = Resources.spr_player; //Set the object's sprite.

            //TODO: Add your own code for object's create event
        }

        public override void Step()
        {
            //Some simple code to move the object left or right depending on which key is held.
            //You may remove this is you wish to keep your object from moving in this way.

            if (GML.keyboard_check(GML.vkeys.vk_right))
            {
                x++;
            }
            else if (GML.keyboard_check(GML.vkeys.vk_left))
            {
                x--;
            }
        }

        //Un-comment the following to add a draw event to your code.
        //Otherwise the game will simply execute 'GML.draw_self' just like in real GML.

        //public override void Draw()
        //{
        //    GML.draw_self(this); //Same as doing base.Draw();
        //}
    }
}
