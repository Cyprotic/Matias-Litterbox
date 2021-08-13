using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class EnemyWhiteCat : Mob
    {

        public GameTimer spawnTimer;

        //https://www.pikpng.com/transpng/xwRRoR/
        public EnemyWhiteCat(Vector2 POS, int OWNERID) : base("2d\\Units\\Mobs\\catWhite", POS, new Vector2(25,25), OWNERID)
        {
            speed = 2.5f;
            
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
