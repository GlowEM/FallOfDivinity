﻿using System;
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
    class Player : Character
    {
        //fields
        private Projectile earthProj;
        private bool projActive;


        public KeyboardState ks;
        public KeyboardState previousState;
        public bool vine; //contact with vine (climb)
        protected string dir;

       // water attack - will replace with actual assests
        public bool water;
        private int msWaterA;
        private int msWatDel = 0;
        public Rectangle watBlit; //for animation 
        public int watCount;

        private int health;
        //***********REPLACE NEXT 2 FIELDS ONCE ASSETS ARE CREATED;  THESE ARE CONSTANT***********
        private static int SizeWidth = 0;
        private static int SizeHeight = 0;
        private static int BaseDammage = 1;
            //attack timer  ---  NEEDS ACTUAL animationTime ADDED
        private float lastTime;
        private float animationTime = 1f;
        private float currentTime = 0f;
      
        

        //constructor
            //default, in the case that map doesn't load in correctly
        public Player(Game1 game)
            :base(new Rectangle(0, game.GraphicsDevice.Viewport.Height, SizeWidth, SizeHeight), game)
                    //sets the character in the lower right hand corner
        {
            lastTime = 0f;
            projActive = false;
        }

        public Player(Rectangle loc, Game1 game)
            :base(new Rectangle(loc.X, loc.Y, SizeWidth, SizeHeight), game)
        {
            health = 10;  //for now
            lastTime = 0f;

            vine = false;
            charPos.X = loc.X;
            charPos.Y = loc.Y;
            //spriteSheetSize.Y = spriteHuman.Bounds.Height;
            //spriteSheetSize.X = spriteHuman.Bounds.Width;
            columnCount = 0;
            rowcount = 3;
            blit.Height = (int)spriteSheetSize.Y / 7;
            blit.Width = (int)spriteSheetSize.X / 12;
            msdel = 0;
            charAcc.Y = (float)0.3;
            charVel.Y = (float)0.0;
            charAcc.X = (float)0.0;
            charVel.X = (float)0.0;

            //water attack
            msWaterA = 50;
            watBlit.Width = 1500;
            watBlit.Height = 1500;
            watBlit.Y = 0;
            watCount = 0;        }

        public string Dir { get { return dir; } }

        //public Vector2 charPos { get { return charPos; } }
       

        public void setCurrent()
        {
            previousState = ks;
            if (charPos.Y > maxAccess.Y) { charPos.Y = maxAccess.Y; contact = true; }//bottom of screen
            
            //water attack animation
            watBlit.X = watCount * watBlit.Width;
        }




        public void ProcessInput(GameTime gameTime)
        {
            ks = Keyboard.GetState();

            charPos.X += charVel.X + (float)charAcc.X / 2;
            charPos.Y += charVel.Y + (float)charAcc.Y / 2;
            charVel.X += charAcc.X;
            charVel.Y += charAcc.Y;

            //W key = Up
            //jump if not near vine
            //climb if near vine
            if (previousState.IsKeyDown(Keys.Space))
            {
                //climb
                if (vine == true)
                {
                    charPos.Y = charPos.Y - 1;
                    rowcount = 4;
                    //columnCountH = 0;
                    if (msdel > msAnim)
                    {

                        columnCount++;
                        if (columnCount > 7) { columnCount = 0; }
                        msdel = 0;
                    }
                }

                //jump
                if (contact == true)//no double jumps
                {
                    contact = false;
                    //jumping with +X Accerleration
                    if (previousState.IsKeyDown(Keys.Space) && ks.IsKeyDown(Keys.D))
                    {
                        charAcc.X = (float)0.2;
                    }

                    //Jumping with -X Accerleration
                    if (previousState.IsKeyDown(Keys.Space) && ks.IsKeyDown(Keys.A))
                    {
                        charAcc.X = (float)-0.2;
                    }

                    //Jumping with no X accel added
                    charVel.Y = (float)-5.5;

                }//end jump

            }//end Space key

            //A key = left
            if (ks.IsKeyDown(Keys.A))
            {

                //walking on ground
                if (contact == true)
                {
                    charPos.X = charPos.X - 1;
                    rowcount = 0;
                    //columnCountH = 0;
                    if (msdel > msAnim)
                    {
                        columnCount++;
                        if (columnCount > 11) { columnCount = 0; }
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
                    rowcount = 4;
                    if (columnCount == 0) { columnCount = 7; }
                    //columnCountH = 0;
                    if (msdel > msAnim)
                    {
                        columnCount--;
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
                    rowcount = 1;
                    //columnCountH = 0;
                    if (msdel > msAnim)
                    {
                        columnCount++;
                        if (columnCount > 11) { columnCount = 0; }
                        msdel = 0;
                    }
                }
            }

            //K key = attack
            if (ks.IsKeyDown(Keys.K))
            {
                //on ground
                if (contact == true)
                {

                    Attack((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }

            //CAPSLOCK key, will be changed = water attack
            if (ks.Equals(Keys.CapsLock))
            {
                //on ground
                if (contact == true)
                {
                    waterAttack(gameTime, previousState);
                }

            }




            //return to stand position based on previous get state and current

            //facing left standing
            if (previousState.IsKeyDown(Keys.A) && ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.Space) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S))
            {
                
                columnCount = 0;
                rowcount = 2;
                charAcc.X = (float)0.0;
                charVel.X = (float)0.0;
                charVel.Y = (float)0.0;
               
                //change for attack
                dir = "left";
            }
            //facing right standing
            if (previousState.IsKeyDown(Keys.D) && ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.Space) && ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.S))
            {

                columnCount = 0;
                rowcount = 3;
                charAcc.X = (float)0.0;
                charVel.X = (float)0.0;
                charVel.Y = (float)0.0;

                //change for attack
                dir = "right";
            }
        }
        //methods
        ///<summary>
        ///if an enemy is within the player's picture box, and in front of the character, does base dammage.
        ///only availiable every ___ seconds  *******NUMBER BASED UPON ANIMATION CAST******
        ///</summary>

        public void waterAttack(GameTime gametime, KeyboardState previousState) {
            msWatDel += gametime.ElapsedGameTime.Milliseconds;

            //on one down press(same as jump
            if (previousState.Equals(Keys.CapsLock))
            {
                water = true;
                if (msWatDel > msWaterA)
                {
                    watCount++;
                    if (watCount > 1) { watCount = 0; }
                }
            }
            //once over drawing will stop
            water = false;
            
            
        }



        public void Attack(float elapsedGameTime)
        { 
            //check timer to see if character can attack
            currentTime += elapsedGameTime;

            if ((currentTime - lastTime) >= animationTime)
            {
                //ATTACK
                if (contact == true)
                {
                    //check for direction
                    switch (dir)
                    {
                        case "left":
                            rowcount = 6;
                            break;
                        case "right":
                            rowcount = 7;
                            break;
                        default://default face left
                            rowcount = 6;
                            break;
                    }
                    
                    if (msdel > msAnim)
                    {
                        columnCount++;
                        if (columnCount > 7) { columnCount = 0; }
                        msdel = 0;
                    }
                }
                //reset Timer
                lastTime = currentTime;
            }
        }

        //earth attack
        public void projAttack()            ///no input triggers this attack as of yet.  TBA
        {
            if (projActive != true)
            {
                earthProj = new Projectile(BaseDammage, this, game);

            }
        }
        
        public void LoseHealth(int dammageTaken)
            //called by PlatformBoundEnemy.Attack, Henchmen.Attack
        {
            health = health - dammageTaken;

            if (health <= 0)
            { 
                //game over
            }
        }
    }
}
