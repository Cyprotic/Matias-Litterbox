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
        public EnemyGirl(Vector2 POS, Vector2 FRAMES, int OWNERID) : base("2d\\Units\\Mobs\\girl", POS, new Vector2(85, 85), FRAMES, OWNERID)
        {
            speed = 1.4f;

            health = 3;
            healthMax = health;

            spawnTimer = new GameTimer(8000);
            spawnTimer.AddToTimer(4000);

            attackRange = 300;
        }

        public override void AI(Player ENEMY)
        {

            if (ENEMY.hero != null && (Globals.GetDistance(pos, ENEMY.hero.pos) < attackRange * .9f || isAttacking))
            {
                isAttacking = true;

                attackTimer.UpdateTimer();

                if (attackTimer.Test())
                {
                    GameGlobals.PassProjectile(new Fist(new Vector2(pos.X, pos.Y), this, new Vector2(ENEMY.hero.pos.X, ENEMY.hero.pos.Y)));

                    attackTimer.ResetToZero();
                    isAttacking = false;
                }
            }
            else
            {
                base.AI(ENEMY);
            }
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
            GameGlobals.PassSpawnPoint(new catBoxGirl(new Vector2(pos.X, pos.Y), new Vector2(1, 1), ownerId, null));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
