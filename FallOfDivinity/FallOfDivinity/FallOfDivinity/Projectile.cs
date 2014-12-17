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
        private int gdOrBd;   //good or bad -- if spawned by player, 0 = good, if spawned by enemy 1 = bad.
        private bool isActive;
        private int speed;  ///tba
        private int dammage;  //
        private int yValue;  //if the yValue is constant, this is used, otherwise, yValue should be taken from Location.Y
                                        //if yValue = -1, then y value is dynamic

        public bool IsActive { get{ return isActive;}}
        


        //constructor
        //no default
            //if yValue is constant
        public Projectile(int dammage, Player player, Game1 game)
            : base(new Rectangle(player.Location.X, player.Location.Y, /*width*/0, /*length*/0), player, game)
        {
            yValue = player.Location.Y;
            dammage = this.dammage;
            player = this.player;
            gdOrBd = 0;

            isActive = false;
        }

        

        //methods
        public void Move()
        {
            //if (yValue != -1)
            //{
                xMove();
            //}
            //else
            //{
            //    xyMove();
            //}
        }

        public void xMove()  //movement if in only one direction.
        {               ///currently no collision detection with side of screen.  
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

        //attack enemy if within range.
        public void Attack(Enemy en)
        {
            Point pt = new Point((Location.X + (Location.Width / 2)), Location.Y);

            if (en.Location.Contains(pt))
            {
                
                player.LoseHealth(1);
                isActive = false;
            }

        }
    }
}