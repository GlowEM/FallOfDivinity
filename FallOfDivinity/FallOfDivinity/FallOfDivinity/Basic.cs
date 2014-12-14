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
using System.IO;

namespace FallOfDivinity
{
    class Basic:MovableGameObject
    {
        //constructor
        public Basic(Game1 game)
            : base(new Rectangle(0,0,0,0), game)
        { }

            //nondefault
        public Basic(Rectangle location, Game1 game)
            : base(location, game)
        { }
    }
}