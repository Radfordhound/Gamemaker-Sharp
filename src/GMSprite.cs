using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace GMSharp
{
    public class GMSprite
    {
        public Texture2D texture;
        public Rectangle[] frames;
        public int currentframe = 0, curfrm = 0, loopframe = 0;
        public float framerate = 1;

        public GMSprite(Texture2D texture, int framecount, int framewidth, int frameheight, int framesperrow, int framespercolumn, float framerate = 1, int loopframe = 0)
        {
            frames = new Rectangle[framecount];
            this.texture = texture;
            this.framerate = framerate;
            this.loopframe = loopframe;

            int i = 0;
            for (int y = 0; y < framespercolumn * frameheight; y += frameheight)
            {
                for (int x = 0; x < framesperrow * framewidth; x += framewidth)
                {
                    if (i < framecount)
                    {
                        frames[i] = new Rectangle(x, y, framewidth, frameheight);
                        i++;
                    }
                    else break;
                }
            }
        }

        public GMSprite(Texture2D texture, Rectangle[] frames, float framerate = 1, int loopframe = 0)
        {
            this.frames = frames;
            this.texture = texture;
            this.framerate = framerate;
            this.loopframe = loopframe;
        }

        /// <summary>
        /// Changes the sprite frame appropriately when a certain number of frames have passed.
        /// </summary>
        /// <param name="framerate">How many frames must pass before the sprite's current frame is changed.</param>
        public void Animate(float framerate = 1)
        {
            if (curfrm < framerate)
            {
                curfrm++;
            }
            else if (curfrm >= framerate)
            {
                curfrm = 0;
                currentframe = (currentframe < frames.Length - 1) ? currentframe + 1 : loopframe;
            }
        }

        /// <summary>
        /// Loads a sprite from a given file.
        /// </summary>
        /// <param name="file">The path to the file.. must be within the game's "Content" folder</param>
        public static void LoadSprite(string file)
        {
            string extension = Path.GetExtension(file).ToLower();

            if (extension == ".xml")
            {
                //TODO
            }
            else if (extension == ".sprite.gmx")
            {
                //TODO
            }
            else if (extension == ".json")
            {
                //TODO
            }
        }
    }
}
