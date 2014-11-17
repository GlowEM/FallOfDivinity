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
    class Player : Character
    {
        //fields
        private int health;
        //***********REPLACE NEXT 2 FIELDS ONCE ASSETS ARE CREATED;  THESE ARE CONSTANT***********
        private static int SizeWidth = 0;
        private static int SizeHeight = 0;
        

        //constructor
            //default, in the case that map doesn't load in correctly
        public Player(Game1 game)
            :base(new Rectangle(0, 0, SizeWidth, SizeHeight), game)
                    
        { }

        



        //methods

        public void LoseHealth(int dammageTaken)
        {
            health = health - dammageTaken;

            if (health <= 0)
            { 
                //game over
            }
        }
    }
}
