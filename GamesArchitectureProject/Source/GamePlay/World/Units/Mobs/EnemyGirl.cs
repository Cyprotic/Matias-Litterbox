using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class EnemyGirl : Mob
    {

        public GameTimer spawnTimer;

        //https://pixlr.com/stock/details/1001468272-pixel-art-woman-fashion/ GIRL
        //https://freesvg.org/vector-illustration-of-fist-as-mouse-pointer FIST
        public EnemyGirl(Vector2 POS, int OWNERID) : base("2d\\Units\\Mobs\\girl", POS, new Vector2(45,45), OWNERID)
        {
            speed = 1.4f;

            health = 3;
            healthMax = health;

            spawnTimer = new GameTimer(8000);
            spawnTimer.AddToTimer(4000);
        }

        
        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnCatBox();
                spawnTimer.ResetToZero();
            }

            base.Update(OFFSET, ENEMY);
        }

        public virtual void SpawnCatBox()
        {
            GameGlobals.PassSpawnPoint(new catBoxGirl(new Vector2(pos.X, pos.Y), ownerId, null));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
