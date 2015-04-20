using GMSharp.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMSharp.Resources
{
    public class Room : Resource
    {
        public List<Object> objects = new List<Object>();

        public void Update()
        {
            foreach (Object obj in objects)
            {
                obj.Update();
            }
        }
    }
}
