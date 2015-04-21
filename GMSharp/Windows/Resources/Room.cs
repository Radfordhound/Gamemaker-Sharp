using GMSharp.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMSharp.Resources
{
    public class Room : Resource
    {
        public List<Object> objects = new List<Object>();

        public void Init()
        {
            foreach (Object obj in objects)
            {
                obj.Init();
            }
            this.Creationcode();
        }

        public virtual void Creationcode() { } //Creation code can go here if this function is overriden

        public void Update()
        {
            foreach (Object obj in objects)
            {
                obj.Update();
            }
        }

        public void Draw()
        {
            foreach (Object obj in objects)
            {
                obj.Draw();
            }
        }
    }
}
