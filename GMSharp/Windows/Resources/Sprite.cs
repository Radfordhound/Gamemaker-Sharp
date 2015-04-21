using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GMSharp.Resources
{
    public class Sprite : Resource
    {
        public Texture2D currenttex;
        public List<Texture2D> frames = new List<Texture2D>();

        public Sprite(List<string> frms)
        {
            foreach (string frm in frms)
            {
                try
                {
                    frames.Add(GMSharpGame.cntnt.Load<Texture2D>("Sprites\\"+frm));
                }
                catch (Exception ex)
                {
                    GML.show_error("Your sprite could not be loaded.\nDoes " + frm + " exist?",ex,false);
                }
            }

            try
            {
                currenttex = frames[0];
            }
            catch (Exception ex)
            {
                GML.show_error("Your sprite's frame couldn't be set for... some... reason.\nThis is pretty weird.",ex,true);
            }
        }
    }
}
