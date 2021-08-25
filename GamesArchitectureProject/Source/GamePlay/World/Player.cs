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

        public int id;
        public Hero hero;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
        public List<Building> buildings = new List<Building>();

        public event EventHandler OnHitEnemy;

        public Player(int ID, XElement DATA)
        {
            id = ID;

            LoadData(DATA);

            // Subscribing to our event
            OnHitEnemy += ChangeScore;
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

                if (spawnPoints[i].dead)
                {
                    spawnPoints.RemoveAt(i);
                    i--;
                }
            }

            // Update enemies
            for (int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY);

                if (units[i].dead)
                {
                    // If not null, invoke
                    OnHitEnemy?.Invoke(this, EventArgs.Empty);
                    units.RemoveAt(i);
                    i--;
                }
            }

            // Update buildings
            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Update(OFFSET, ENEMY);

                if (buildings[i].dead)
                {
                    buildings.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddUnit(object INFO)
        {
            Unit tempUnit = (Unit)INFO;
            tempUnit.ownerId = id;
            units.Add(tempUnit);
        }

        public virtual void AddSpawnPoint(object INFO)
        {
            catBoxGirl tempSpawnPoint = (catBoxGirl)INFO;
            tempSpawnPoint.ownerId = id;
            spawnPoints.Add(tempSpawnPoint);
        }

        // Event to add points
        public virtual void ChangeScore(object sender, EventArgs e)
        {
            GameGlobals.score += 1;
        }

        public virtual List<AttackableObject> GetAllObjects()
        {
            List<AttackableObject> tempObjects = new List<AttackableObject>();
            tempObjects.AddRange(units.ToList<AttackableObject>());
            tempObjects.AddRange(spawnPoints.ToList<AttackableObject>());
            tempObjects.AddRange(buildings.ToList<AttackableObject>());

            return tempObjects;
        }

        //Deal with only loading the data for the current level by getting it from the XML file using linq
        public virtual void LoadData(XElement DATA)
        {
            List<XElement> spawnList = (from t in DATA.Descendants("SpawnPoint")
                                        select t).ToList<XElement>();

            Type sType = null;

            for (int i = 0; i < spawnList.Count; i++)
            {
                sType = Type.GetType("GamesArchitectureProject." + spawnList[i].Element("type").Value, true);
                spawnPoints.Add((SpawnPoint)Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(spawnList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(spawnList[i].Element("Pos").Element("y").Value, Globals.culture)), id, spawnList[i]));
            }


            List<XElement> buildingList = (from t in DATA.Descendants("Building")
                                        select t).ToList<XElement>();

            for (int i = 0; i < buildingList.Count; i++)    
            {
                sType = Type.GetType("GamesArchitectureProject." + buildingList[i].Element("type").Value, true);

                buildings.Add((Building)Activator.CreateInstance(sType, new Vector2(Convert.ToInt32(buildingList[i].Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(buildingList[i].Element("Pos").Element("y").Value, Globals.culture)), id));
            }
            
            if (DATA.Element("Hero") != null)
            {
                hero = new Hero("2d\\matias", new Vector2(Convert.ToInt32(DATA.Element("Hero").Element("Pos").Element("x").Value, Globals.culture), Convert.ToInt32(DATA.Element("Hero").Element("Pos").Element("y").Value, Globals.culture)), new Vector2(64, 64), id);
            }
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

            // Draw Buildings
            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].Draw(OFFSET);

            }

            // Draw SpawnPoints
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(OFFSET);

            }
        }
    }
}
