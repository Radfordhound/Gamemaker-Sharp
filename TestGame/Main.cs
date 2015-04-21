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
        public override void Start()
        {
            Resources.Define(); //Defines your game's resources. Pretty self-explanitory.
        }
    }
}
