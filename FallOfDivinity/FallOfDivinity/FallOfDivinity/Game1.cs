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
        int screenWidth = 800, screenHeight = 600;

        Button playButton;

        // Attribute
        Texture2D character;
        Vector2 v2;

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
            v2 = new Vector2(30, 60);

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

            // TODO: use this.Content to load your game content here
            character = Content.Load<Texture2D>("Character");

            // Screen stuff
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
            IsMouseVisible = true;

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
            spriteBatch.Draw(character, v2, Color.White);
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    playButton.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void ProcessInput()
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.W))
            {
                v2.Y = v2.Y - 1;
            }

            if (ks.IsKeyDown(Keys.A))
            {
                v2.X = v2.X - 1;
            }

            if (ks.IsKeyDown(Keys.S))
            {
                v2.Y = v2.Y + 1;
            }

            if (ks.IsKeyDown(Keys.D))
            {
                v2.X = v2.X + 1;
            }
        }
    }
}
