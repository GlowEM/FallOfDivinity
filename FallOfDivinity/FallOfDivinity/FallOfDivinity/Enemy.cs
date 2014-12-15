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
            //in testing still
                foreach (Rectangle plRec in game.plRecs)
                {

                    int widthCheck = (int)Math.Abs(plRec.X - charPos.X);
                    int heightCheck = (int)Math.Abs(charPos.Y - plRec.Top);
                    //possible problem, platform is width distance AWAY from player
                    //still working on that
                    bool check = (plRec.Intersects(Location));

                    //if ((charPos.Y < lRec.Bottom && charPos.Y > (lRec.Y  - 25)) && (charPos.X < lRec.Left && charPos.X < lRec.Right))
                    if (check == true)
                    {
                        enemyZone = plRec;

                    }
                }
           
                foreach (Rectangle lRec in game.lRecs)
                {

                    int widthCheck = (int)Math.Abs(lRec.X - charPos.X);
                    int heightCheck = (int)Math.Abs(charPos.Y - lRec.Top);
                    //possible problem, platform is width distance AWAY from player
                    //still working on that
                    bool check = (lRec.Intersects(Location));

                    //if ((charPos.Y < lRec.Bottom && charPos.Y > (lRec.Y  - 25)) && (charPos.X < lRec.Left && charPos.X < lRec.Right))
                    if (check == true)
                    {
                        enemyZone = lRec;
                        
                    }
                }
            
        }

        public override void Check(GameTime gameTime)
        {
            charPos.Y = enemyZone.Y - blit.Height;

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
                else if (charPos.X >= (maxDist - blit.Width)) { dir = 0; }
            }
            else if (dir == 0)//direction is left
            {
                if (charPos.X > minDist)
                {
                    rowcount = 2;
                    
                        charVel.X = -1.0f;
                     
                }
                else if (charPos.X <= minDist) { dir = 1; }
            }
        }

    }
}
