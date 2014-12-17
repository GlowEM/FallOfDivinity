using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace FallOfDivinity
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //enum
        enum GameState
        {
            MainMenu,
            Options,
            Playing,
            GameOver,
        }
        GameState CurrentGameState = GameState.MainMenu;

        //Screen Adjustments
        int screenWidth = 1280, screenHeight = 800;

        private int maxX;
        private int maxY;

        public int MaxX { get { return maxX; } }
        public int MaxY { get { return maxY; } }

        private bool isPressedQ = false;

        Button playButton;

        // Attribute
        //Map Assets
        Texture2D platTexture;
        Texture2D longTexture;
        Texture2D vineTexture;
        public Texture2D charTexture;
        Texture2D basicTexture;
        Texture2D homingTexture;
        Texture2D homingSpriteSheet;
        Texture2D basicSpriteSheet;
        int p = 0;
        public Rectangle[] plRecs = new Rectangle[1000];
        public Rectangle[] lRecs = new Rectangle[1000];
        public Rectangle[] vineRecs = new Rectangle[1000];
        Rectangle playerRec;
        Rectangle[] basicRecs = new Rectangle[1000];
        Rectangle[] homingRecs = new Rectangle[1000];

        Platform[] platforms = new Platform[1000];
        Platform[] lPlatforms = new Platform[1000];
        Vine[] vines = new Vine[1000];
        Player player;
        Basic[] basics = new Basic[1000];
        Homing[] homings = new Homing[1000];
        Stack<Homing> homingL;
        Stack<Basic> basicL;
        //Projectile projec;

        

        //Player
        public Texture2D spriteHuman;
        public Texture2D spriteWater;
        Rectangle blitHuman;//blitting rectangle for spritesheet for human


        //change to rectangle
        Vector2 minAccess;//edge of screen minimum X, Y
        Vector2 maxAccess;//edge of screen maximum X,Y

        public Game1()
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
            // TODO: Add your initialization logic here
           // v2 = new Vector2(300, 600);
            base.Initialize();
            //change size of screen
           // graphics.PreferredBackBufferWidth = 1400;
           // graphics.PreferredBackBufferHeight = 800;
           // graphics.ApplyChanges();

            // Screen stuff
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            //set maxX and maxY
            maxX = graphics.PreferredBackBufferWidth;
            maxY = graphics.PreferredBackBufferHeight;

            //PLAYER
            player = new Player(new Rectangle(0, charTexture.Height, charTexture.Width, charTexture.Height), this);
            blitHuman = player.blit;
             homingL = new Stack<Homing>();
             basicL = new Stack<Basic>();
            try
            {
                //Read in map
                StreamReader input = new StreamReader("map.txt");
                string text = "";
                while ((text = input.ReadLine()) != null)
                {
                    string[] ls = text.Split(',');
                     
                    if (ls[0].Contains("platforms"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        plRecs[p] = new Rectangle(x, y, w, h);
                        platforms[p] = new Platform(new Rectangle(x, y, w, h), this);
                        p++;
                    }
                    if (ls[0].Contains("long platform"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        lRecs[p] = new Rectangle(x, y, w, h);
                        lPlatforms[p] = new Platform(new Rectangle(x, y, w, h), this);
                        p++;
                    }
                    if (ls[0].Contains("vines"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        vineRecs[p] = new Rectangle(x, y, w, h);
                        vines[p] = new Vine(new Rectangle(x, y, w, h), this);
                        p++;
                    }

                    if (ls[0].Contains("char"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        playerRec = new Rectangle(x, y, w, h);
                        player = new Player(playerRec, this);
                        p++;
                    }
                    if (ls[0].Contains("basic"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        basicRecs[p] = new Rectangle(x, y, w, h);
                        basicL.Push(new Basic(new Rectangle(x, y, w, h), player, basicSpriteSheet, this));
                        basics[p] = basicL.Peek();
                        p++;
                    }
                    if (ls[0].Contains("homing"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        homingRecs[p] = new Rectangle(x, y, w, h);
                        homingL.Push(new Homing(new Rectangle(x, y, w, h), player, homingSpriteSheet, this));
                        homings[p] = homingL.Peek();
                        p++;
                    }
                    //projec = new Projectile(1, player, this);
                }
            }
            catch(Exception ex)
            {}
            finally
            {
                //Read in map
                StreamReader input = new StreamReader("map_default.txt");
                string text = "";
                while ((text = input.ReadLine()) != null)
                {
                    string[] ls = text.Split(',');

                    if (ls[0].Contains("platforms"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        plRecs[p] = new Rectangle(x, y, w, h);
                        platforms[p] = new Platform(new Rectangle(x, y, w, h), this);
                        p++;
                    }
                    if (ls[0].Contains("long platform"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        lRecs[p] = new Rectangle(x, y, w, h);
                        lPlatforms[p] = new Platform(new Rectangle(x, y, w, h), this);
                        p++;
                    }
                    if (ls[0].Contains("vines"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        vineRecs[p] = new Rectangle(x, y, w, h);
                        vines[p] = new Vine(new Rectangle(x, y, w, h), this);
                        p++;
                    }

                    if (ls[0].Contains("char"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        playerRec = new Rectangle(x, y, w, h);
                        player = new Player(new Rectangle(x, y, w, h), this);
                        p++;
                    }
                    if (ls[0].Contains("basic"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        basicRecs[p] = new Rectangle(x, y, w, h);
                        basicL.Push(new Basic(new Rectangle(x, y, w, h), player, basicSpriteSheet, this));
                        basics[p] = basicL.Peek();
                        p++;
                    }
                    if (ls[0].Contains("homing"))
                    {
                        int x;
                        int y;
                        int w;
                        int h;
                        Boolean parsed = int.TryParse(ls[2], out x);
                        parsed = int.TryParse(ls[4], out y);
                        parsed = int.TryParse(ls[6], out w);
                        parsed = int.TryParse(ls[8], out h);
                        homingRecs[p] = new Rectangle(x, y, w, h);
                        homingL.Push(new Homing(new Rectangle(x, y, w, h), player, homingSpriteSheet, this));
                        homings[p] = homingL.Peek();
                        p++;
                    }
                }
            }

           
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            spriteWater = Content.Load<Texture2D>("water_spriteMock");
            platTexture = this.Content.Load<Texture2D>("Platform");
            longTexture = this.Content.Load<Texture2D>("Long Platform");
            vineTexture = this.Content.Load<Texture2D>("Vines");
             charTexture = this.Content.Load<Texture2D>("Haruka");
            basicTexture = this.Content.Load<Texture2D>("Basic Samurai");
            homingTexture = this.Content.Load<Texture2D>("Homing Samurai");
            homingSpriteSheet = this.Content.Load<Texture2D>("spriteHoming");
            basicSpriteSheet = this.Content.Load<Texture2D>("spriteBasic");

            
            IsMouseVisible = true;

            // Brings in button and places at top left corner
            playButton = new Button(Content.Load <Texture2D>("Play"), graphics.GraphicsDevice);
            playButton.SetPosition(new Vector2(20, 20));
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
            MouseState mouse = Mouse.GetState();
            KeyboardState kbState = Keyboard.GetState();

            // TODO: Add your update logic here
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (playButton.isClicked == true)
                    {
                        CurrentGameState = GameState.Playing;
                    }
                    playButton.Update(mouse);
                    break;
                case GameState.Playing:
                    playButton.isClicked = false;
                    if (kbState.IsKeyDown(Keys.Q))
                    {
                        CurrentGameState = GameState.GameOver;
                    }
                    break;
                case GameState.GameOver:
                    {
                        if (mouse.LeftButton == ButtonState.Pressed)
                        {
                            CurrentGameState = GameState.MainMenu;
                        }
                        break;
                    }
            }
            foreach (Homing soldier in homingL)
            {
                soldier.Check(gameTime);
                soldier.Move(gameTime);
                soldier.Attack();
                //projec.Attack(soldier);
            }
            foreach (Basic soldier in basicL)
            {
                soldier.Check(gameTime);
                soldier.Move(gameTime);
                soldier.Attack();
                //projec.Attack(soldier);
            }
            //projectile
            //

            player.Check(gameTime);
            player.setCurrent();
            player.ProcessInput(gameTime);
            //K key = attack
            if (player.ks.IsKeyDown(Keys.K))
            {
                //on ground
                if (player.contact == true)
                {

                    foreach (Homing soldier in homingL)
                    {
                        soldier.Check(gameTime);
                        soldier.Move(gameTime);
                        soldier.Attack();
                        //projec.Attack(soldier);
                    }
                    foreach (Basic soldier in basicL)
                    {
                        soldier.Check(gameTime);
                        soldier.Move(gameTime);
                        soldier.Attack();
                        //projec.Attack(soldier);
                    }
                }
            }

            base.Update(gameTime);
          
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            // TODO: Add your drawing code here
            //spriteBatch.Draw(spriteHuman, player.charPos, player.blit, Color.White);

           
            //Begin
            spriteBatch.Begin();

            
            
            
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    playButton.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    spriteBatch.Draw(Content.Load<Texture2D>("Background"), new Rectangle(0,0, screenWidth,screenHeight), Color.White);
                    
                    foreach (Rectangle plRec in plRecs)
                    {
                        spriteBatch.Draw(platTexture, plRec, Color.White);
                    }
                    foreach (Rectangle lRec in lRecs)
                    {
                        spriteBatch.Draw(longTexture, lRec, Color.White);
                    }
                    foreach (Rectangle vineRec in vineRecs)
                    {
                        spriteBatch.Draw(vineTexture, vineRec, Color.White);
                    }
                    //player
                        spriteBatch.Draw(charTexture, player.charPos, player.blit, Color.White);
                    foreach (Basic soldier in basicL)
                    {
                        spriteBatch.Draw(basicSpriteSheet, soldier.charPos, soldier.blit, Color.White);
                    }
                    foreach (Homing soldier in homingL)
                    {
                        spriteBatch.Draw(homingSpriteSheet, soldier.charPos, soldier.blit, Color.White);
                    }
                    /*foreach (Rectangle homingRec in homingRecs)
                    {
                        spriteBatch.Draw(homingTexture, homingRec, Color.White);
                    }*/
                    //if water attack activated
                    
                  
                    break;
                case GameState.GameOver:
                    spriteBatch.Draw(Content.Load<Texture2D>("GameOver"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

       
    }
}
