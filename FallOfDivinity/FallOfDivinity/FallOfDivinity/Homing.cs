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
    class Homing : Enemy
    {
        public bool hasAttacked;

        private int health;
        private bool isAlive;

        public bool IsAlive { get { return isAlive; } }

            //nondefault
        public Homing(Rectangle location, Player curPlayer,Texture2D sprite, Game1 game)
            : base(location, curPlayer,sprite, game)
        { }

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
            health -= dammage;
            if (health <= 0)
            {
                //take dammage
                isAlive = false;
            }

        }
    }
}
