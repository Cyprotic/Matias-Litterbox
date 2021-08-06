using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class Furball : Projectile2d
    {
       
        public Furball(Vector2 POS, Unit OWNER, Vector2 TARGET) : base("2d\\Projectiles\\Furball", POS, new Vector2(20, 20), OWNER, TARGET)
        {
            
        }

        public override void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
            base.Update(OFFSET, UNITS);
        }
         
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
    