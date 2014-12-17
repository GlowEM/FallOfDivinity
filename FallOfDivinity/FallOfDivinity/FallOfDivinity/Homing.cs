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
       //constructor
        //public Homing(Game1 game)
          //  : base(new Rectangle(0,0,0,0), game)
        //{ }

            //nondefault
        public Homing(Rectangle location, Player curPlayer,Texture2D sprite, Game1 game)
            : base(location, curPlayer,sprite, game)
        { }



        public void findPlayer(){
            int checkY = (int)player.charPos.Y;
            int checkX = (int)player.charPos.X;

            if (checkY <= charPos.Y) { 
            int checkOnce = (int)(charPos.X - player.charPos.X);
                int newX = (int)charPos.X++;
                int checkNew = newX - (int)player.charPos.X;

                if(checkOnce < checkNew){
                    dir = 1;
                }
                else{
                    dir = 0;
                }
                
            
            }
        
        
        }
    }
}
