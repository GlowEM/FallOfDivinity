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
        private static int BaseDammage = 1;
            //attack timer  ---  NEEDS ACTUAL animationTime ADDED
        private float lastTime;
        private float animationTime = 1f;
        private float currentTime = 0f;
       
        

        //constructor
            //default, in the case that map doesn't load in correctly
        public Player(Game1 game)
            :base(new Rectangle(0, game.GraphicsDevice.Viewport.Height, SizeWidth, SizeHeight), game)
                    //sets the character in the lower right hand corner
        {
            lastTime = 0f;
        }

        public Player(Rectangle loc, Game1 game)
            :base(new Rectangle(loc.X, loc.Y, SizeWidth, SizeHeight), game)
        {
            health = Stats.playerHealth;
            lastTime = 0f;


        }

        



        //methods
        ///<summary>
        ///if an enemy is within the player's picture box, and in front of the character, does base dammage.
        ///only availiable every ___ seconds  *******NUMBER BASED UPON ANIMATION CAST******
        ///</summary>
        public void Attack(float elapsedGameTime)
        { 
            //check timer to see if character can attack
            currentTime += elapsedGameTime;

            if ((currentTime - lastTime) >= animationTime)
            {
                //ATTACK
                //reset Timer
                lastTime = currentTime;
            }
        }
        
        
        
        public void LoseHealth(int dammageTaken)
            //called by PlatformBoundEnemy.Attack, Henchmen.Attack
        {
            health = health - dammageTaken;

            if (health <= 0)
            { 
                //game over
            }
        }
    }
}
