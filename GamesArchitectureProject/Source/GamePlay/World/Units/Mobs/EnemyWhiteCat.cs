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
        public EnemyWhiteCat(Vector2 POS, Vector2 FRAMES, int OWNERID) : base("2d\\Units\\Mobs\\catWhite", POS, new Vector2(25,25), FRAMES, OWNERID)
        {
            speed = 2.5f;
            
        }

        
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {

            base.Update(OFFSET, ENEMY);
        }

        public override void AI(Player ENEMY)
        {
            Building temp = null;
            for (int i = 0; i < ENEMY.buildings.Count; i++)
            {
                if (ENEMY .buildings[i].GetType().ToString() == "GamesArchitectureProject.LitterBox")
                {
                    temp = ENEMY.buildings[i];
                }
            }

            if (temp != null)
            {

                pos += Globals.RadialMovement(temp.pos, pos, speed);
                rot = Globals.RotateTowards(pos, temp.pos);

                if (Globals.GetDistance(pos, temp.pos) < 15)
                {
                    ENEMY.hero.GetHit(1);
                    dead = true;
                }
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
