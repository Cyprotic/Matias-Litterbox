using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace GamesArchitectureProject
{
    public class catBox : SpawnPoint
    {

        // http://pixelartmaker.com/art/870e175101a248f
        public catBox(Vector2 POS, int OWNERID, XElement DATA) : base("2d\\SpawnPoints\\catSpawn", POS, new Vector2(45, 45), OWNERID, DATA)
        {
            health = 10;
            healthMax = health;
        }
        
        public override void Update(Vector2 OFFSET)
        {

            base.Update(OFFSET);
        }

        public override void SpawnMob()
        {
            // The +1 is for a possible list so it doesnt overflow our parameters, for this case it is not necessary
            int num = Globals.rand.Next(0, 100 + 1);

            Mob tempMob = null;
            int total = 0;

            for(int i  = 0; i < mobChoices.Count; i++)
            {
                total += mobChoices[i].rate;

                // Chance to spawn a normal cat
                if (num < total)
                {
                    Type sType = Type.GetType("GamesArchitectureProject." + mobChoices[i].mobStr, true);

                    tempMob = ((Mob)Activator.CreateInstance(sType, new Vector2(pos.X, pos.Y), ownerId));
                    
                    break;
                }
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
