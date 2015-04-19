using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMSharp;

namespace TestGame.Objects
{
    public class obj_player : GMSharp.Resources.Object
    {
        public override void Step()
        {
            x++;
        }
    }
}
