using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Threading;

namespace GMSharp
{
    public class GMGame : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public Texture2D splashscreen;
        public bool contentloaded = false;

        /// <summary>
        /// The game's sprites. <para />
        /// Access them like this: sprites["SPRITENAME"] with "SPRITENAME" being the name of the sprite you want to load.
        /// </summary>
        public Dictionary<GMSprite, string> sprites = new Dictionary<GMSprite, string>();

        public GMGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Window.Title = GameProperties.gamedisplayname;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

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

            if (Directory.Exists(Main.contentpath))
            {
                splashscreen = Content.Load<Texture2D>("splashscreen");
                new Thread(new ThreadStart(LoadContentThreaded)).Start();
            }
        }

        /// <summary>
        /// Loads content on a separate thread, thus allowing the game to do other stuff (such as show a splash screen).
        /// </summary>
        private void LoadContentThreaded()
        {
            if (Directory.Exists(Main.contentpath + "\\Sprites"))
            {
                //Load all the sprites with the following extensions.
                string[] spriteextensions = { ".xml", ".sprite.gmx", ".json" };

                foreach (string file in Directory.GetFiles(Main.contentpath + "\\Sprites", "*.*").Where(file => spriteextensions.Contains(Path.GetExtension(file).ToLower())))
                {
                    GMSprite.LoadSprite(file);
                    //sprites.Add(new GMSprite(Content.Load<Texture2D>(Path.GetFileNameWithoutExtension(file)),"");
                }
            }

            contentloaded = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                GML.game_restart();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (contentloaded || splashscreen != null)
            {
                spriteBatch.Begin();

                if (!contentloaded)
                {
                    int screenwidth = GraphicsDevice.Viewport.Width, screenheight = GraphicsDevice.Viewport.Height;
                    spriteBatch.Draw(splashscreen, new Vector2(0, -((screenwidth - screenheight) / 2)), scale: new Vector2((float)screenwidth/splashscreen.Width));
                }
                else
                {
                    //TODO
                }

                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
