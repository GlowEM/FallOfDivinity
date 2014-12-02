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
    abstract class Character : MovableGameObject
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        
        public Rectangle blit;//blitting rectangle for spritesheet
               
        public Vector2 charPos;//character position
        public Vector2 charAcc;//gravity on character
        public Vector2 charVel;//velocity for jumping
        public Vector2 spriteSheetSize; //size of sprite sheet 
        
        public int columnCount;
        public int rowcount;
        public bool contact; //contact with ground (jump)
        
        public int msAnim = 200;
        public int msdel;

        protected Vector2 minAccess;//edge of screen minimum X, Y
        protected Vector2 maxAccess;//edge of screen maximum X,Y

        //constructor
        public Character(Rectangle loc, Player player, Game1 game)
            : base(loc, player, game)
        {
            //limit of any character movement
            minAccess.X = 0;
            minAccess.Y = 0;
            maxAccess.X = game.MaxX - 75;
            maxAccess.Y = game.MaxY - 85;//90
            
        }

                //for player class to inherit from
        public Character(Rectangle loc, Game1 game)
            : base(loc, game)
        {
            //limit of any character movement
            minAccess.X = 0;
            minAccess.Y = 0;
            maxAccess.X = game.MaxX - 75;
            maxAccess.Y = game.MaxY - 85;//90
            
        }


        

            protected virtual void Check(GameTime gameTime) {

            //for blitting
            msdel += gameTime.ElapsedGameTime.Milliseconds;
            blit.Y = rowcount * blit.Width;
            blit.X = columnCount * blit.Height;

            //check buffer edge
            if (charPos.Y < minAccess.Y) { charPos.Y = minAccess.Y; }//top of screen
            if (charPos.X < minAccess.X) { charPos.X = minAccess.X; }//far left of screen
            if (charPos.Y > maxAccess.Y) { charPos.Y = maxAccess.Y; contact = true; }//bottom of screen
            if (charPos.X > maxAccess.X) { charPos.X = maxAccess.X; }//far right of screen
            if (contact == true) { charAcc.Y = (float)0.0; charAcc.X = (float)0.0; charVel.X = (float)0.0; }
            else if (contact == false) { charAcc.Y = (float)0.3; }
            
        }

        

     
    }
}
