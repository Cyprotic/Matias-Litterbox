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

        PassObject ResetWorld;


        public World(PassObject RESETWORLD)
        {
            ResetWorld = RESETWORLD;


            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassMob = AddMob;

            user = new User();
            aIPlayer = new AIPlayer();

            offset = new Vector2(0, 0);

            // Initialize UI
            ui = new UI();
        }

        public virtual void Update()
        {
            if (!user.hero.dead)
            {

                user.Update(aIPlayer, offset);
                aIPlayer.Update(user, offset);

                // Update projectiles
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, aIPlayer.units.ToList<Unit>());

                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
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
            aIPlayer.AddUnit((Mob)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
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
