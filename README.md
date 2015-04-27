![GM-Sharp logo](https://raw.githubusercontent.com/Radfordhound/Gamemaker-Sharp/master/logos/logo256.png)  
A GML (Short for "Game Maker Language's") wrapper for MonoGame/C# made to help developers more easily migrate their games from Game Maker to Monogame.

##Cut to the chase. I'm new to this. How the heck do I use it? :|
Check out the [Getting started guide](https://github.com/Radfordhound/Gamemaker-Sharp/wiki/Getting-Started)! :wink:

##Wait, what? What is this again? O.o
GM-Sharp is a GML wrapper for C#/MonoGame. In other words, it's a big chunk of code that allows MonoGame to understand GML code.

##Why would I want this?
Let's say you're a developer who's been using Game Maker for years and is confortable with it, but is now being limited by the engine and wants to move on to actual coding to unlock the full potential of the machine. It may sound like a pretty narrow group of people to some, but in reality the target audience is actually quite broad. And, un-fortunately, a lot of these coders are a bit, shall we say, "scared" to move on to more "professional" coding methods as they fear it'll take too much of their time to learn or be too difficult.

And, in a way, they'd be right. For example, let's take a simple game which draws an object to the screen and moves it around based upon keyboard button presses.

In Game Maker/GML, you make a room (Let's call it 'rm_main'.), make an object (Let's call it 'obj_player'.), and make a sprite (Let's call that 'spr_player'.). Then, you use spr_player as obj_player's sprite, add obj_player to a position in your room (Let's say 'X: 0, y: 0'), and do the following in it's step event:

```Delphi
if (keyboard_check(vk_left))
{
  x-=1;
}
else if (keyboard_check(vk_right))
{
  x+=1;
}
```

Now, in MonoGame, that whole thing looks like this:

```C#
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace TestGame
{
  public class Main : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Texture2D spr_player;
    int x = 0;
    int y = 0;
  
    public Main(): base()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }
  
    protected override void LoadContent()
    {
      // Create a new SpriteBatch, which can be used to draw textures.
      spriteBatch = new SpriteBatch(GraphicsDevice);
      spr_player = Content.Load<Texture2D>("spr_player");
    }

    protected override void UnloadContent()
    {
      Content.Unload();
    }

    protected override void Update(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.Left))
      {
        x-=1;
      }
      else if (Keyboard.GetState().IsKeyDown(Keys.Right))
      {
        x+=1;
      }

      base.Update(gameTime);
    }


    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.Black);
  
      spriteBatch.Begin();
      spriteBatch.Draw(spr_player,new Vector2(x,y));
      spriteBatch.End();
  
      base.Draw(gameTime);
    }
  }
}
```

Yeah, a little complicated for those new to the engine! Learning how it works takes a decent amount of time, and managing to port your current Game Maker games to it without optimization problems/sloppy code (Even the above example had a bit of that!) is pretty difficult for first-time users!

But MonoGame is so much faster than Game Maker, and so less limited! It's worth moving on to! And that's where GM-Sharp comes into play.

The above sample in GM-Sharp is instead split into multiple files to make it more "clean." for the developer. It looks something like this:

Main.cs
```C#
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GMSharp;
using GMSharp.Resources;

namespace TestGame
{
    public class Main : GMSharpGame
    {
        public override void Start()
        {
            Resources.Define(); //Executes the code inside resources.cs
        }
    }
}
```

Resources.cs
```C#
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMSharp.Resources;
using GMSharp;
using TestGame.Objects;

namespace TestGame
{
    public static class Resources
    {
        public static Sprite spr_player = new Sprite(new List<string> { "spr_player" }); //Makes a sprite called 'spr_player'.
        public static Room rm_main = new Room(); //Makes a room called 'rm_main'.
        
        public static void Define()
        {
          rm_main.objects.Add(new obj_player()); //Adds obj_player to rm_main.
          Main.rooms.Add(rm_main); //Tells the game "Hey! We just added a new room called 'rm_main'!"
        }
    }
}
```

obj_player.cs
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMSharp;

namespace TestGame.Objects
{
    public class obj_player : GMSharp.Resources.Object //Makes an object called 'obj_player'.
    {
        public override void Create() //The object's create event, like in Game Maker.
        {
            sprite = Resources.spr_player; //Set the object's sprite to 'spr_player'.
        }

        public override void Step() //The object's step event, like in Game Maker.
        {
            if (GML.keyboard_check(GML.vkeys.vk_right))
            {
                x+=1;
            }
            else if (GML.keyboard_check(GML.vkeys.vk_left))
            {
                x-=1;
            }
        }
    }
}
```

Now, yes, this still probably seems more complicated to new users. But it's much similar to GML than the plain MonoGame example used above! (And I plan on making it more like Game Maker shortly. :wink:)

The point of this project, quite simply, is to get existing Game Maker users started with "real programming" more comfortably. There's still a slight learning curve, yes, but I plan on remedying that with the help of the guides on [the wiki](https://github.com/Radfordhound/Gamemaker-Sharp/wiki). I hope to help Game Maker users move on more easily! :)

##Wait? It's like Game Maker, but it's free? Is this legal? O.o
While I'm no lawyer, I see no reason why it wouldn't be! This project contains 100% custom code that simply "looks like" GML. It isn't GML, it's just designed to pretend that it is to make porting Game Maker games easier. And, of course, I'm allowed to distribute my own content!

The best way I can describe this project's legality is that it's relationship to Game Maker/GML is as to Mono's relationship with .NET. Both .NET and Game Maker are copy-righted pieces of work. However, while both Mono and GM-Sharp act a lot like their inspiration, they're not and are custom pieces of code from the ground up. And how's Mono doing, you may ask? Amazingly! Millions of projects around the world are using it, and Microsoft themselves (Creator of the .NET framework Mono seemingly "copied.") has acknowledged it multiple times. Quite simply, as greedy as a company may be, there's no way to copy-right custom work they didn't produce! It's not theirs! They can't own it.

This isn't like taking an official picture of Mickey Mouse and claiming it's yours. This is more like making your own picture of a mouse with light-brites which somewhat resembles mickey, claiming you made **the image**, and stating that it was inspired by Mickey. It's your own work, whether it takes inspiration or not! And while I can't give expert legal advice, there's no reason why that shouldn't be allowed in my opinion.

##What license is this under?
The MIT license. Yeah, that's right. MIT. Essentially, you can go crazy with it so long as you follow it's super-small list of simple terms. ;)

The only exception being that, while under the MIT license you technically *could* sell this engine... well... just don't. Trust me. **You want to sell games made with this? Go right on ahead!** You can sell games made with MonoGame, which this is built off of (And basically is, in a sense.). So there's no reason you can't here as well! **But selling the actual engine? Nnoooooo. Don't do that. Trust me.**

For more information, see [the license](https://github.com/Radfordhound/Gamemaker-Sharp/blob/master/LICENSE).

##More README content coming soon!
