using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class catBox : SpawnPoint
    {

        // http://pixelartmaker.com/art/870e175101a248f
        public catBox(Vector2 POS, int OWNERID) : base("2d\\SpawnPoints\\catSpawn", POS, new Vector2(45, 45), OWNERID)
        {
            
        }
        
        public override void Update(Vector2 OFFSET)
        {

            base.Update(OFFSET);
        }

        public override void SpawnMob()
        {
            // The +1 is for a possible list so it doesnt overflow our parameters, for this case it is not necessary
            int num = Globals.rand.Next(0, 10 + 1);

            Mob tempMob = null;

            // Chance to spawn a normal cat
            if (num < 5)
            {
                tempMob = new EnemyCat(new Vector2(pos.X, pos.Y), ownerId);
            }
            // Chance to spawn a white fast cat
            else if (num < 8)
            {
                tempMob = new EnemyGirl(new Vector2(pos.X, pos.Y), ownerId);
            }
            if (tempMob != null)
            {
                GameGlobals.PassMob(tempMob);
            }
            
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
