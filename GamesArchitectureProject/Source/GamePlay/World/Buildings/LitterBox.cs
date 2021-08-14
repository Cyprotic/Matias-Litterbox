using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class LitterBox : Building
    {
        //https://www.flaticon.com/free-icon/litter-box_1581662
        public LitterBox(Vector2 POS, int OWNERID) : base("2d\\buildings\\litterBox", POS, new Vector2 (45, 45), OWNERID)
        {
            health = 20;
            healthMax = health;

            hitDist = 35.0f;
        }

        public virtual void Update(Vector2 OFFSET, Player ENEMY)
        {
            base.Update(OFFSET);
        }
        
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
