using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class Projectile2d : Basic2d
    {
        public bool done;

        public float speed;

        public Vector2 direction;

        public Unit owner;

        public GameTimer timer;
        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
        {

            done = false;

            speed = 5.0f;

            owner = OWNER;
            // The direction is always the opposite of the owners, and we normalize it
            direction = TARGET - owner.pos;
            direction.Normalize();

            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

            // Time until the projectile vanishes
            timer = new GameTimer(1500);
        }

        public virtual void Update(Vector2 OFFSET, List<AttackableObject> UNITS) // Update it
        {
            pos += direction * speed;


            timer.UpdateTimer();
            if (timer.Test())// Check if the timer ended
            {
                done = true;
            }

            if (HitSomething(UNITS)) // Or it hit something
            {
                done = true;
            }
        }

        public virtual bool HitSomething(List<AttackableObject> UNITS) // If it did hit something, tell the unity that got hit
        {
            for(int i = 0; i < UNITS.Count; i++)
            {
                if (owner.ownerId != UNITS[i].ownerId && Globals.GetDistance(pos, UNITS[i].pos) < UNITS[i].hitDist)
                {
                    UNITS[i].GetHit(1);
                    return true;
                }
            }

            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
