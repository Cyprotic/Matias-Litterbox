﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class Mob : Unit
    {
        public Mob(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {
            speed = 2.0f;
        }

        
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            AI(ENEMY);

            base.Update(OFFSET);
        }

        public virtual void AI(Player ENEMY)
        {
            // Go to hero
            pos += Globals.RadialMovement(ENEMY.hero.pos, pos, speed);
            // Rotato to hero
            rot = Globals.RotateTowards(pos, ENEMY.hero.pos);

            if (Globals.GetDistance(pos, ENEMY.hero.pos) < 15)
            {
                ENEMY.hero.GetHit(1);
                dead = true;
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
