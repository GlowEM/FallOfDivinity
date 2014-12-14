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
        
        //gets either 1 or zero
        Random rand = new Random();
        int dir;//0 is left, 1 is right.
        
        //constructor
        public Enemy(Rectangle loc, Player curPlayer, Game1 game)
            : base(loc, game)
        {
            player = curPlayer;
            charPos.X = loc.X;
            charPos.Y = loc.Y;
            findPlatform();
            dir = rand.Next(2) - 1;
        }
        public void findPlatform() {
            //takes all rectangles of platforms and find the one that is under it
            //in testing still
            foreach (Rectangle plRec in game.plRecs){

                int widthCheck = (int)Math.Abs(plRec.X - charPos.X);
                int heightCheck = (int)Math.Abs(plRec.Y - charPos.Y);
                //possible problem, platform is width distance AWAY from player
                //still working on that

                if ((heightCheck < 5 && heightCheck >= 0) && (widthCheck <= plRec.Width)) {
                    enemyZone = plRec;
                }
               }
            
            
            
            } 
            
            
    //basic movement along platform within bounds
        
        public void Move(){
            int maxDist = enemyZone.X + enemyZone.Width;
            int minDist = enemyZone.X;

            if (dir == 1)
            {
                if (charPos.X < maxDist)
                {
                    if (msdel < msAnim)
                    {
                        charPos.X++;

                    }
                }
                else if (charPos.X >= maxDist) { dir = 0; }
            }
            else if (dir == 0)
            {
                if (charPos.X < minDist)
                {
                    if (msdel < msAnim)
                    {
                        charPos.X--;

                    }
                }
                else if (charPos.X >= minDist) { dir = 1; }
            }
        }

    }
}
