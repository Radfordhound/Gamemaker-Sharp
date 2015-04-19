using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GMSharp.Resources;
using System.Diagnostics;

namespace GMSharp
{
    public static class GMSharp
    {
        /// <summary>
        /// Whether or not to use the error font to write the error log
        /// to the screen in the event that something were to go wrong with
        /// the game.
        /// </summary>
        public static bool useerrorfont = true;

        /// <summary>
        /// Whether or not the game is encountering an un-recoverable exception.
        /// </summary>
        public static bool iserroring = false;

        /// <summary>
        /// Whether or not the game is encountering an ignorable exception.
        /// </summary>
        public static bool iswarning = false;

        /// <summary>
        /// A string to contain error messages to be drawn to the screen
        /// in the case of an exception.
        /// </summary>
        public static string errorstrng = "";

        
    }

    /// <summary>
    /// The main resource class
    /// </summary>
    public class Resource{}

    /// <summary>
    /// The main type for your GMSharp Game
    /// </summary>
    public class GMSharpGame : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public static List<Room> rooms = new List<Room>();
        SpriteFont errorfont;
        SpriteFont errorfontheader;

        public GMSharpGame(): base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Resources";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load the error font if needed.
            if (GMSharp.useerrorfont)
            {
                try
                {
                    errorfontheader = Content.Load<SpriteFont>("errorfontheader");
                    errorfont = Content.Load<SpriteFont>("errorfont");
                }
                catch
                {
                    Console.WriteLine("ERROR: Error font could not be found! Ignoring...");
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))Exit();

            try
            {
                rooms[GML.room].Update();
            }
            catch (Exception ex)
            {
                GML.show_error("Something went wrong whilst during this step!",ex, true);
            }

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            if ((GMSharp.iserroring || GMSharp.iswarning) && GMSharp.useerrorfont && GMSharp.errorstrng != "")
            {
                Color excol = Color.Red;

                if (GMSharp.iserroring)
                {
                    spriteBatch.DrawString(errorfontheader, "ERROR", new Vector2(0, 0), excol);
                }
                else
                {
                    excol = Color.Yellow;
                    spriteBatch.DrawString(errorfontheader, "WARNING", new Vector2(0, 0), excol);
                }

                spriteBatch.DrawString(errorfont,WrapText(GMSharp.errorstrng),new Vector2(10,50),excol);
            }
            else if ((GMSharp.iserroring || GMSharp.iswarning) && GMSharp.errorstrng != "")
            {
                if (GMSharp.iserroring)
                {
                    Console.WriteLine("ERROR: " + GMSharp.errorstrng);
                }
                else
                {
                    Console.WriteLine("WARNING: " + GMSharp.errorstrng);
                }
            }
            else
            {
                //TODO: Add rest of drawing code.
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private string WrapText(string text)
        {
            if (errorfont.MeasureString(text).X < GraphicsDevice.Viewport.Width)
            {
                return text;
            }

            string[] words = text.Split(' ');
            StringBuilder wrappedText = new StringBuilder();
            float linewidth = 0f;
            float spaceWidth = errorfont.MeasureString(" ").X;
            for (int i = 0; i < words.Length; ++i)
            {
                Vector2 size = errorfont.MeasureString(words[i]);
                if (linewidth + size.X < GraphicsDevice.Viewport.Width)
                {
                    linewidth += size.X + spaceWidth;
                }
                else
                {
                    wrappedText.Append("\n");
                    linewidth = size.X + spaceWidth;
                }
                wrappedText.Append(words[i]);
                wrappedText.Append(" ");
            }

            return wrappedText.ToString();
        }
    }
}
