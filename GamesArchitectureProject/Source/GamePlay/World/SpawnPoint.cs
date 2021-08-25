using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GamesArchitectureProject
{
    public class SpawnPoint : AttackableObject
    {
        public List<MobChoice> mobChoices = new List<MobChoice>();

        public GameTimer spawnTimer = new GameTimer(2400);
        public SpawnPoint(string PATH, Vector2 POS, Vector2 DIMS, Vector2 FRAMES, int OWNERID, XElement DATA) : base(PATH, POS, DIMS, FRAMES, OWNERID)
        {
            dead = false;

            health = 3;
            healthMax = health;

            LoadData(DATA);

            hitDist = 35.0f;
        }

        
        public override void Update(Vector2 OFFSET)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test()) // If the timer has ended, spawn it
            {
                SpawnMob();
                spawnTimer.ResetToZero();
            }

            base.Update(OFFSET);
        }

        public virtual void LoadData(XElement DATA) // Loads the data for the XML file of timer, rate and mobs
        {
            if (DATA != null)
            {
                spawnTimer.AddToTimer(Convert.ToInt32(DATA.Element("timerAdd").Value, Globals.culture));

                List<XElement> mobList = (from t in DATA.Descendants("mob")
                                            select t).ToList<XElement>();

                for (int i = 0; i < mobList.Count; i++)
                {
                    mobChoices.Add(new MobChoice(mobList[i].Value, Convert.ToInt32(mobList[i].Attribute("rate").Value, Globals.culture)));
                }
            }
        }

        public virtual void GetHit()
        {
            dead = true;
        }

        public virtual void SpawnMob() // And spawns them
        {
            GameGlobals.PassMob(new EnemyCat(new Vector2(pos.X, pos.Y), new Vector2(1, 1), ownerId));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
