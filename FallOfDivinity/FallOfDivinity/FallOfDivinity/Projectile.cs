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
    class Projectile : MovableGameObject
    {
        private bool isActive;
        private int speed;  ///tba
        private int dammage;  //
        private int yValue;
        


        //constructor
        //no default
        public Projectile(int dammage, Player player, Game1 game)
            : base(new Rectangle(player.Location.X, player.Location.Y, /*width*/0, /*length*/0), player, game)
        {
            yValue = player.Location.Y;
            dammage = this.dammage;
            player = this.player;

            isActive = true;
        }

        //requries:
        public Projectile(int x, int y, Player player, Game1 game)
            : base(new Rectangle(x, y, 0, 0), player, game)
        {

        }

        //methods
        public void Move()
        {
            if (player.Dir == "left")  //left
            {
                int x = this.Location.X;
                x--;
                this.Location = new Rectangle(x, yValue, 0, 0);  //CHANGE ONCE ASSET HAS BEEN ADDED.

            }
            else if (player.Dir == "right")  //right
            {
                int x = this.Location.X;
                x++;
                this.Location = new Rectangle(x, yValue, 0, 0);   //CHANGE ONCE ASSET HAS BEEN ADDED
            }
        }
    }
}