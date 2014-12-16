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
        //constructor
       // public Basic(Game1 game)
       //     : base(new Rectangle(0,0,0,0), game)
        //{ }
        

            //nondefault
        public Basic(Rectangle location, Player curPlayer,Texture2D sprite, Game1 game)
            : base(location, curPlayer, sprite, game)
        {
            minDist = (enemyZone.X - (blit.Width / 5));
            maxDist = (enemyZone.X + enemyZone.Width) - (blit.Width) + (blit.Width/5);
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
    }
}
