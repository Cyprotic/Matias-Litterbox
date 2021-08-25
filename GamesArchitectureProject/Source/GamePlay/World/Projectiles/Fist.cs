using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class Fist : Projectile2d
    {
        //https://freesvg.org/vector-illustration-of-fist-as-mouse-pointer FIST
        public Fist(Vector2 POS, Unit OWNER, Vector2 TARGET) : base("2d\\Projectiles\\Fist", POS, new Vector2(20, 20), OWNER, TARGET)
        {
            speed = 2.5f;

            timer = new GameTimer(1800);
        }

        public override void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            base.Update(OFFSET, UNITS);
        }
         
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
    