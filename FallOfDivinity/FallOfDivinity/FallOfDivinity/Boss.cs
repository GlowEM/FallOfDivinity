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
    class Boss : Enemy
    {

        //constructor
        public Boss(Player player,Texture2D sprite, Game1 game)
            : base(new Rectangle(0,0,0,0),player,sprite,game)
        { }
    }
}