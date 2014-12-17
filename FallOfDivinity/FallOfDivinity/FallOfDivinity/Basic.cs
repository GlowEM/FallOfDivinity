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
    class Basic: Enemy
    {
        //fields
        private Platform locPlatform;  //platform bound enemies require a platform to be bound to.
        private int yValue;  //once set, this is constant
        private Random rand = new Random();
        private bool isAlive;
        protected bool hasAttacked;
        
        //constructor
            //nondefault
        public Basic(Rectangle location, Player curPlayer,Texture2D sprite, Game1 game)
            : base(location, curPlayer, sprite, game)
        {
            minDist = (enemyZone.X - (blit.Width / 5));
            maxDist = (enemyZone.X + enemyZone.Width) - (blit.Width) + (blit.Width/5);
            isAlive = true;
            hasAttacked = false;

        
        }
        
        public void Move(GameTime gameTime){
            //makes movement slower for basic
            if (dir == 1)
            {
                charAcc.X = (float)-1.0;
            }
            if (dir == 0)
            {
                charAcc.X = (float)1.0;
            }
            base.Move(gameTime);
       
        }
        //methods
        //attack player if within range.
        public override void Attack()
        {
            Point pt = new Point((Location.X + (Location.Width / 2)), Location.Y);

            if (player.Location.Contains(pt))
            {
                if (hasAttacked == false)
                {
                    player.LoseHealth(1);
                    hasAttacked = true;
                }
            }
            else
            {
                hasAttacked = false;
            }

        }

        public override void TakeDammage(int dammage)  //if hit by any player-attack, this henchmen dies.  Therefore:
        {
            //take dammage
            isAlive = false;
            

        }
    }
}
