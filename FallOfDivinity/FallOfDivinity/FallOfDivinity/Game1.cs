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
        }
        GameState CurrentGameState = GameState.MainMenu;

        //Screen Adjustments
        int screenWidth = 1280, screenHeight = 800;

        Button playButton;

        // Attribute
        //HUMAN
        public Rectangle blit;//blitting rectangle for spritesheet
        KeyboardState ks;
        KeyboardState previousState;

        //HUMAN
        public Vector2 charPos;//character position
        public Vector2 charAcc;//gravity on character
        public Vector2 charVel;//velocity for jumping
        public Vector2 humanSheetSize; //size of sprite sheet for human
        public Texture2D spriteHuman;
        public int columnCountH;
        public int rowcountH;
        public bool contact; //contact with ground (jump)
        public bool vine; //contact with vine (climb)
        public int msHuman = 200;
        public int msdel;

        //ENEMY
        Texture2D spriteEnemy;
        public Vector2 enemyPos; //basic enemy position
        public int columnCountE;
        public int rowcountE;
        int msEnemy = 200;
        public Rectangle blitEnemy;
        int walkCountE;
        string dirE;
        int msdelEnemy;


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
            graphics.PreferredBackBufferWidth = 1400;
            graphics.PreferredBackBufferHeight = 800;
           // graphics.ApplyChanges();

            //limit of any character movement
            minAccess.X = 0;
            minAccess.Y = 0;
            maxAccess.X = graphics.PreferredBackBufferWidth - 75;
            maxAccess.Y = graphics.PreferredBackBufferHeight - 85;//90

            //HUMAN
            //contact = true;
            vine = false;
            charPos.X = graphics.PreferredBackBufferWidth / 2;
            charPos.Y = graphics.PreferredBackBufferHeight / 2;
            humanSheetSize.Y = spriteHuman.Bounds.Height;
            humanSheetSize.X = spriteHuman.Bounds.Width;
            columnCountH = 0;
            rowcountH = 3;
            blit.Height = (int)humanSheetSize.Y / 7;
            blit.Width = (int)humanSheetSize.X / 12;
            msdel = 0;
            charAcc.Y = (float)0.3;
            charVel.Y = (float)0.0;
            charAcc.X = (float)0.0;
            charVel.X = (float)0.0;
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
            //character = Content.Load<Texture2D>("Character");
            spriteHuman = Content.Load<Texture2D>("spriteHuman");

            // Screen stuff
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
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
                    break;
            }

            //human blitting
            msdel += gameTime.ElapsedGameTime.Milliseconds;
            blit.Y = rowcountH * blit.Width;
            blit.X = columnCountH * blit.Height;

            //check buffer edge
            if (charPos.Y < minAccess.Y) { charPos.Y = minAccess.Y; }//top of screen
            if (charPos.X < minAccess.X) { charPos.X = minAccess.X; }//far left of screen
            if (charPos.Y > maxAccess.Y) { charPos.Y = maxAccess.Y; contact = true; }//bottom of screen
            if (charPos.X > maxAccess.X) { charPos.X = maxAccess.X; }//far right of screen
            previousState = ks;

            base.Update(gameTime);
            ProcessInput();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Crimson);

            // TODO: Add your drawing code here

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
                    //spriteBatch.Draw(character, v2, Color.White);
                    //human
                    if (charPos.Y > maxAccess.Y) { charPos.Y = maxAccess.Y; contact = true; }//bottom of screen
                    spriteBatch.Draw(spriteHuman, charPos, blit, Color.White);
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ProcessInput()
        {
            ks = Keyboard.GetState();

            charPos.X += charVel.X + (float)charAcc.X / 2;
            charPos.Y += charVel.Y + (float)charAcc.Y / 2;
            charVel.X += charAcc.X;
            charVel.Y += charAcc.Y;

            //W key = Up
            //jump if not near vine
            //climb if near vine
            if (previousState.IsKeyDown(Keys.W))
            {
                //climb
                if (vine == true)
                {
                    charPos.Y = charPos.Y - 1;
                    rowcountH = 4;
                    //columnCountH = 0;
                    if (msdel > msHuman)
                    {

                        columnCountH++;
                        if (columnCountH > 7) { columnCountH = 0; }
                        msdel = 0;
                    }
                }

                //jump
                if (contact == true)//no double jumps
                {
                    contact = false;
                    //jumping with +X Accerleration
                    if (previousState.IsKeyDown(Keys.W) && ks.IsKeyDown(Keys.D))
                    {
                        charAcc.X = (float)0.2;
                    }

                    //Jumping with -X Accerleration
                    if (previousState.IsKeyDown(Keys.W) && ks.IsKeyDown(Keys.A))
                    {
                        charAcc.X = (float)-0.2;
                    }

                    //Jumping with no X accel added
                    charVel.Y = (float)-5.5;

                }//end jump

            }//end W key

            //A key = left
            if (ks.IsKeyDown(Keys.A))
            {

                //walking on ground
                if (contact == true)
                {
                    charPos.X = charPos.X - 1;
                    rowcountH = 0;
                    //columnCountH = 0;
                    if (msdel > msHuman)
                    {
                        columnCountH++;
                        if (columnCountH > 11) { columnCountH = 0; }
                        msdel = 0;
                    }
                }

            }

            //S key = down
            if (previousState.IsKeyDown(Keys.S))
            {
                //climbing down vine
                if (vine == true)
                {
                    charPos.Y = charPos.Y + 1;
                    rowcountH = 4;
                    if (columnCountH == 0) { columnCountH = 7; }
                    //columnCountH = 0;
                    if (msdel > msHuman)
                    {
                        columnCountH--;
                        msdel = 0;
                    }
                }
            }

            //D key = right
            if (ks.IsKeyDown(Keys.D))
            {
                //walking on ground
                if (contact == true)
                {
                    charPos.X = charPos.X + 1;
                    rowcountH = 1;
                    //columnCountH = 0;
                    if (msdel > msHuman)
                    {
                        columnCountH++;
                        if (columnCountH > 11) { columnCountH = 0; }
                        msdel = 0;
                    }
                }
            }

            //return to stand position based on previous get state and current

            //facing left standing
            if (previousState.IsKeyDown(Keys.A) && ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.W) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S))
            {
                columnCountH = 0;
                rowcountH = 2;
                charAcc.X = (float)0.0;
                charVel.X = (float)0.0;
                charVel.Y = (float)0.0;
            }
            //facing right standing
            if (previousState.IsKeyDown(Keys.D) && ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.W) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S))
            {
                columnCountH = 0;
                rowcountH = 3;
                charAcc.X = (float)0.0;
                charVel.X = (float)0.0;
                charVel.Y = (float)0.0;
            }
        }
    }
}
