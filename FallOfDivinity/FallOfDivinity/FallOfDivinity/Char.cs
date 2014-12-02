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
    class Char:GameObject
    {
        //constructor
        public Char(Game1 game)
            : base(new Rectangle(0,0,0,0), game)
        { }

            //nondefault
        public Char(Rectangle location, Game1 game)
            : base(location, game)
        { }
    }
}
