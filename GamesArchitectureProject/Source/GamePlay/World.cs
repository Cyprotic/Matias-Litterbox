using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesArchitectureProject
{
    public class World
    {
        public Vector2 offset;


        public UI ui;

        public User user;
        public AIPlayer aIPlayer;

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public List<AttackableObject> allObjects = new List<AttackableObject>();

        PassObject ResetWorld;


        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;


            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;
            GameGlobals.PassSpawnPoint = AddSpawnPoint;

            // ID 1 since it's not a multiplayer game anyway, but it could be in future implementations!
            user = new User(1);
            aIPlayer = new AIPlayer(2);

            offset = new Vector2(0, 0);

            // Initialize UI
            ui = new UI();
        }

        public virtual void Update()
        {
            if (!user.hero.dead && user.buildings.Count > 0)
            {
                allObjects.Clear();
                allObjects.AddRange(user.GetAllObjects());
                allObjects.AddRange(aIPlayer.GetAllObjects());

                user.Update(aIPlayer, offset);
                aIPlayer.Update(user, offset);

                // Update projectiles
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, allObjects);

                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

            }
            else
            {
                if (Globals.keyboard.GetPress("Enter") && (user.hero.dead || user.buildings.Count <= 0))
                {
                    ResetWorld(null);
                }
            }

            ui.Update(this);
        }

        public virtual void AddMob(object INFO)
        {
            Unit tempUnit = (Unit)INFO;

            if (user.id == tempUnit.ownerId)
            {
                user.AddUnit(tempUnit);
            }
            else if (aIPlayer.id == tempUnit.ownerId)
            {
                aIPlayer.AddUnit(tempUnit);
            }

            aIPlayer.AddUnit((Mob)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }

        public virtual void AddSpawnPoint(object INFO)
        {
            catBoxGirl tempSpawnPoint = (catBoxGirl)INFO;

            if (user.id == tempSpawnPoint.ownerId)
            {
                user.AddSpawnPoint(tempSpawnPoint);
            }
            else if (aIPlayer.id == tempSpawnPoint.ownerId)
            {
                aIPlayer.AddSpawnPoint(tempSpawnPoint);
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            // Draw user
            user.Draw(offset);
            // Draw the AI of the user/player
            aIPlayer.Draw(offset);

            // Drawing projectiles
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            // Draw UI last
            ui.Draw(this);
        }
    }
}
