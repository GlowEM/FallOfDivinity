﻿using System;
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
        

        //constructor
        public Player()
            :base(new Rectangle(0,0,0,0))
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
