using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMSharp.Resources
{
    public class Object : Resource
    {
        /// <summary>
        /// The x position of the instance.
        /// </summary>
        public int x = 0;
        /// <summary>
        /// The y position of the instance.
        /// </summary>
        public int y = 0;

        /// <summary>
        /// The sprite of the instance. If you're new to GMSharp, you probably shouldn't mess with
        /// this. (Except for setting the sprite of the object at the beginning of the object's create event.)
        /// </summary>
        public Sprite sprite;
        /// <summary>
        /// The current sub-image being shown for the instance sprite.
        /// </summary>
        public int image_index = 0;

        /// <summary>
        /// The function that calls the create event. Leave this alone unless you know what you're doing.
        /// </summary>
        public void Init()
        {
            //TODO: Add initialization code, if any.
            this.Create();
        }

        /// <summary>
        /// The create event is called when the object is first spawned.
        /// </summary>
        public virtual void Create(){}

        /// <summary>
        /// The function that calls the step events. Leave this alone unless you know what you're doing.
        /// </summary>
        public void Update()
        {
            //TODO: Add update code, if any.
            this.BeginStep();
            this.Step();
            this.EndStep();
        }

        public virtual void BeginStep() { }

        /// <summary>
        /// The Step event happens once every second.
        /// </summary>
        public virtual void Step(){}

        public virtual void EndStep() { }

        /// <summary>
        /// The Draw event is where you define how the object should be drawn.
        /// </summary>
        public virtual void Draw()
        {
            GML.draw_self(this);
        }
    }
}
