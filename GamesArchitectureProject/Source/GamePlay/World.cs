using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesArchitectureProject
{
    public class World
    {

        public int numKilled;
        public Vector2 offset;

        public Hero hero;

        public UI ui;

        public List<Projectile2d> projectiles = new List<Projectile2d>();
        public List<EnemyCat> mobs = new List<EnemyCat>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        PassObject ResetWorld;


        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;

            numKilled = 0;
            // Cat image from http://pixelartmaker.com/art/99b1245ee58be2c
            hero = new Hero("2d\\matias", new Vector2(300, 300), new Vector2(48, 48));

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;

            offset = new Vector2(0, 0);

            // Instaciating the spawns points
            // http://pixelartmaker.com/art/870e175101a248f
            spawnPoints.Add(new SpawnPoint("2d\\Misc\\catSpawn", new Vector2(50,50), new Vector2(35,35)));
            spawnPoints.Add(new SpawnPoint("2d\\Misc\\catSpawn", new Vector2(Globals.screenWidth/2, 50), new Vector2(35, 35)));

            // Add half a second to the timer so they don't spawn cats at the same time
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\catSpawn", new Vector2(Globals.screenWidth - 50, 50), new Vector2(35, 35)));
            // Add a second to the timer so they don't spawn cats at the same time
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);

            // Initialize UI
            ui = new UI();
        }

        public virtual void Update()
        {
            if (!hero.dead)
            {

                hero.Update(offset);

                // Update spawn points
                for (int i = 0; i < spawnPoints.Count; i++)
                {
                    spawnPoints[i].Update(offset);

                }

                // Update projectiles
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, mobs.ToList<Unit>());

                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

                // Update mobs
                for (int i = 0; i < mobs.Count; i++)
                {
                    mobs[i].Update(offset, hero);

                    if (mobs[i].dead)
                    {
                        numKilled++;
                        mobs.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                if (Globals.keyboard.GetPress("Enter"))
                {
                    ResetWorld(null);
                }
            }

            ui.Update(this);
        }

        public virtual void AddMob(object INFO)
        {
            mobs.Add((EnemyCat)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(offset);

            // Drawing projectiles
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            // Drawing spawn points
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(offset);
            }

            // Drawing mobs
            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(offset);
            }

            ui.Draw(this);
        }
    }
}
