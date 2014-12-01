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
  public class Stats
  {
    // HEALTH STATS
    int playerHealth = 100;
    int basicEnemyHealth = 50;
    int homingEnemyHealth = 90;
    int bossHealth = 400;
    
    // ATTACK STRENGTH STATS
    int playerMelee = 40;
    int playerEarth = 20;
    int basicEnemyAttack = 15;
    int homingEnemyAttack = 25;
    int bossRangedAttack = 10;
    int bossMeleeAttack = 35;
    
    // SIZE STATS
    int backgroundWidth = 1600;
    int backgroundHeight = 900;
    int playerWidth = 110;
    int playerHeight = 175;
    int EnemyWidth = 140;
    int EnemyHeight = 175;
    // int bossWidth = TBD;
    // int bossHeight = TBD;
  }
