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

            //*** This enemy walks back and forth on the platform, attacking when it comes into contact with the player.
    class PlatformBoundEnemy : Enemy
    {
        //fields
        private Platform locPlatform;  //platform bound enemies require a platform to be bound to.
        private int yValue;  //once set, this is constant
        //***********REPLACE NEXT TWO FIELDS ONCE ASSETS ARE CREATED;  THESE ARE CONSTANT***********
        private static int SizeWidth = 10;
        private static int SizeHeight = 10;
        private Random rand = new Random();
        private static int dammage = 1;     //amount of health player loses when attacked by this enemy
        private int direction;  //0 is left, 1 is right.
        private bool isAlive;

        //properites
        public Platform LocPlatform { get { return locPlatform; } }
        public int Direction { get { return direction; } set { if (value == 0 || value == 1) { direction = value; } } }

        //constructor
            //no default

            //requires:  platform, player
        public PlatformBoundEnemy(Platform platform, Player player, Game1 game)
            :base(new Rectangle(0,0,0,0),player,game)       //location of enemy is replaced within constructor
        {
                //set attributes
            locPlatform = platform;
                //determine initial location of enemy
                    //determine x
            int xPos = rand.Next(0, platform.Location.Width - 1);
            int x = platform.Location.X + xPos;
                    //dermine y---set yValue attribute.
            yValue = platform.Location.Y;
                        //replace location rectangle.
            this.Location = new Rectangle(x, yValue, SizeWidth, SizeHeight);
                //randomize direction
            direction = rand.Next(0, 2);
                //ativate
            isAlive = true;
        }



        //methods
        public void Attack()
        { 
            //this will likely change, but for now...a stub of sorts.
            if (this.Location.Intersects(player.Location))
            {
                player.LoseHealth(dammage);
            }
        }

        public void TakeDammage()  //if hit by any player-attack, this henchmen dies.  Therefore:
        { 
            //take dammage
            isAlive = false;
        }

        public void Move()
        {
            if (direction == 0)  //left
            {       //if at left end of platform, change direction;
                        //doesn't move enemy (slight pause at end of platform during turn)
                if (this.Location.X == locPlatform.Location.X)
                {
                    direction = 1;
                }
                else
                {
                    int x = this.Location.X;
                    x--;
                    this.Location = new Rectangle(x, yValue, SizeWidth, SizeHeight);
                }
            }
            else if (direction == 1)  //right
            {       //if at left end of platform, change direction;
                //doesn't move enemy (slight pause at end of platform during turn)
                if (this.Location.X == (locPlatform.Location.X + locPlatform.Location.Width - SizeWidth))
                {
                    direction = 0;
                }
                else
                {
                    int x = this.Location.X;
                    x++;
                    this.Location = new Rectangle(x, yValue, SizeWidth, SizeHeight);
                }
            }
        }



    }
}
