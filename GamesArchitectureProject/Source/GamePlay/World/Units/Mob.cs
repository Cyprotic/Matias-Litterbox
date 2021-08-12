using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class Mob : Unit
    {
        public Mob(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 2.0f;
        }

        
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            AI(ENEMY.hero);

            base.Update(OFFSET);
        }

        public virtual void AI(Hero HERO)
        {
            // Go to hero
            pos += Globals.RadialMovement(HERO.pos, pos, speed);
            // Rotato to hero
            rot = Globals.RotateTowards(pos, HERO.pos);

            if (Globals.GetDistance(pos, HERO.pos) < 15)
            {
                HERO.GetHit(1);
                dead = true;
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
