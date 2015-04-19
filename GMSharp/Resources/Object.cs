using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMSharp.Resources
{
    public class Object : Resource
    {
        public int x = 0;
        public int y = 0;

        public void Update()
        {
            this.Step();
        }

        public virtual void Step()
        {
            //
        }
    }
}
