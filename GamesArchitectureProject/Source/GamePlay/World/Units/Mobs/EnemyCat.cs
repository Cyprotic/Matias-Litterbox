using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class EnemyCat : Mob
    {
        
        //https://www.pinterest.com/pin/344032859020619279/
        public EnemyCat(Vector2 POS) : base("2d\\Units\\Mobs\\cat1", POS, new Vector2(40,40))
        {
            speed = 2.0f;
        }

        
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            base.Update(OFFSET, ENEMY);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
