#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace GamesArchitectureProject
{
    public class AIPlayer : Player
    {

        public AIPlayer(int ID, XElement DATA)
            : base(ID, DATA)
        {
            /*
                // Instaciating the spawns points
                // http://pixelartmaker.com/art/870e175101a248f
                spawnPoints.Add(new catBox( new Vector2(50, 50), id));
                spawnPoints.Add(new catBox( new Vector2(Globals.screenWidth / 2, 50), id));

                // Add half a second to the timer so they don't spawn cats at the same time
                spawnPoints[spawnPoints.Count   - 1].spawnTimer.AddToTimer(500);

                spawnPoints.Add(new catBox( new Vector2(Globals.screenWidth - 50, 50), id));
                // Add a second to the timer so they don't spawn cats at the same time
                spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);
            */
        }

        public override void Update(Player ENEMY, Vector2 OFFSET)
        {
            base.Update(ENEMY, OFFSET);
        }

        public override void ChangeScore(int SCORE)
        {
            GameGlobals.score += SCORE;
        }

    }
}
