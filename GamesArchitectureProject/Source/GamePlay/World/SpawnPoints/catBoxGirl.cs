using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GamesArchitectureProject
{
    public class catBoxGirl : SpawnPoint
    {
        int maxSpawns, totalSpawns;

        // http://pixelartmaker.com/art/870e175101a248f
        public catBoxGirl(Vector2 POS, Vector2 FRAMES, int OWNERID, XElement DATA) : base("2d\\SpawnPoints\\catBoxGirl", POS, new Vector2(45, 45), FRAMES, OWNERID, DATA)
        {
            totalSpawns = 0;
            maxSpawns = 5;

            health = 3;
            healthMax = health;

            spawnTimer = new GameTimer(3000);
        }

        
        public override void Update(Vector2 OFFSET)
        {

            base.Update(OFFSET);
        }


    public override void SpawnMob()
        {
            Mob tempMob = new EnemyWhiteCat(new Vector2(pos.X, pos.Y), new Vector2(1, 1), ownerId);

            if (tempMob != null)
            {
                GameGlobals.PassMob(tempMob);

                totalSpawns++;
                if (totalSpawns >= maxSpawns)
                {
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
