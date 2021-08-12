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
    public class Player
    {

        public Hero hero;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        public Player()
        {

        }

        public virtual void Update(Player ENEMY, Vector2 OFFSET)
        {
            // If hero exists update him
            if (hero != null)
            {
                hero.Update(OFFSET);
            }

            // Update spawn points
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Update(OFFSET);

            }

            // Update enemies
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY);

                if (units[i].dead)
                {
                    ChangeScore(1);
                    units.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddUnit(object INFO)
        {
            units.Add((Unit)INFO);
        }

        public virtual void ChangeScore(int SCORE)
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {

            // If the hero exists draw him
            if (hero != null)
            {
                hero.Draw(OFFSET);
            }

            // Draw Units
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Draw(OFFSET);

            }

            // Draw SpawnPoints
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(OFFSET);

            }
        }
    }
}
