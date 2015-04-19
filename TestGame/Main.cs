#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GMSharp;
using GMSharp.Resources;
#endregion

namespace TestGame
{
    public class Main : GMSharpGame
    {
        public Main()
        {
            Resources.Define();
            GML.room_goto(0);
        }
    }
}
