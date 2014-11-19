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
    class RangedEnemy : Enemy
    {


        //constructor
                //no default
        public RangedEnemy(Player player,Game1 game)
            :base(new Rectangle(0,0,0,0), player, game)
        {}

            //requries:
        public RangedEnemy(int x, int y, Player player, Game1 game)
            :base(new Rectangle(x, y, 0,0), player, game)
        { 
            
        }

    }
}
