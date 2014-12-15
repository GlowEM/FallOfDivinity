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
    abstract class Enemy : Character
    {
        //fields
        protected Rectangle enemyZone;
        protected int maxDist;
        protected int minDist;
       
        //gets either 1 or zero
        Random rand = new Random();
        int dir;//0 is left, 1 is right.
        
        //constructor
        public Enemy(Rectangle loc, Player curPlayer,Texture2D sprite, Game1 game)
            : base(loc, game)
        {
            spriteSheet = sprite;
            player = curPlayer;
            charPos.X = loc.X;
            charPos.Y = loc.Y;
            findPlatform();
            dir = rand.Next(0, 1);

            spriteSheetSize.X = spriteSheet.Bounds.Width;
            spriteSheetSize.Y = spriteSheet.Bounds.Height;
            columnCount = 0;
            rowcount = 3;
            blit.Height = (int)spriteSheetSize.Y / 7;
            blit.Width = (int)spriteSheetSize.X / 12;
            maxDist = enemyZone.X + enemyZone.Width;
            minDist = enemyZone.X;
            base.contact = true;

        }
        public void findPlatform() {
            //takes all rectangles of platforms and find the one that is under it
            //if enemy not bound to platform they'll be bound to the ground
            Rectangle checkIntersect = location;

            checkIntersect.Width += 5;
            checkIntersect.Height += 5;
            checkIntersect.Y -= 5;
                foreach (Rectangle plRec in game.plRecs)
                {//short platforms

                    //checkint = distance of character position within bounds of platform (x coord)

                    int checkInt = (int)Math.Abs(charPos.X - plRec.Right);
                    
                    //check if rectangles interesect
                    bool check = (plRec.Intersects(checkIntersect));

                    //if true then bind
                    if (check == true)
                    {
                        enemyZone = plRec;

                    }

                    //backup
                    //if the character isnt within the y coord bounds (human error)
                    //but within x coord bounds, bind
                    //basically puts it to the closest platform
                    else{
                        if (checkInt > 0 && checkInt < 15)
                        {
                            enemyZone = plRec;
                        }
                        else
                        {

                        }
                    }
                }
           
                foreach (Rectangle lRec in game.lRecs)
                {//long platforms

                    //checkint = distance of character position within bounds of platform (x coord)
                   int checkInt = (int)Math.Abs(charPos.X - lRec.Right);
                    
                    bool check = (lRec.Intersects(checkIntersect));

                    //check if rectangles interesect
                    if (check == true)
                    {
                        enemyZone = lRec;
                        
                    }
                    //backup
                    //if the character isnt within the y coord bounds (human error)
                    //but within x coord bounds, bind
                    //basically puts it to the closest
                    else
                    {
                        if (checkInt > 0 && checkInt < 15)
                        {
                            enemyZone = lRec;
                        }
                    }
                }
            
        }

        public override void Check(GameTime gameTime)
        {
            charPos.Y = enemyZone.Y - blit.Height + 5;

            base.Check(gameTime);
        }
            
            
            
            
    //basic movement along platform within bounds
        
        public void Move(GameTime gameTime){
            
            charPos.X += charVel.X + (float)charAcc.X / 2;
            charPos.Y += charVel.Y + (float)charAcc.Y / 2;
            charVel.X += charAcc.X;
            charVel.Y += charAcc.Y;

            if (dir == 1)//direction is right
            {
                if (charPos.X < (maxDist - blit.Width))
                {
                    rowcount = 3;
                        charVel.X = 1.0f;
                     
                }
                else if (charPos.X >= (maxDist - blit.Width) || (charPos.X > maxAccess.X)) { dir = 0; }
            }
            else if (dir == 0)//direction is left
            {
                if (charPos.X > minDist)
                {
                    rowcount = 2;
                    
                        charVel.X = -1.0f;
                     
                }
                else if ((charPos.X <= minDist)||(charPos.X < minAccess.X)) { dir = 1; }
            }
        }

    }
}
