using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class GamePlay
    {
        int playState = 0;

        World world;

        PassObject ChangeGameState;

        public GamePlay(PassObject CHANGEGAMESTATE)
        {
            playState = 0;

            ResetWorld(null);
            ChangeGameState = CHANGEGAMESTATE;
        }

        public virtual void Update()
        {
            if (playState == 0)
            {
                world.Update();
            }
        }

        public virtual void ResetWorld(object INFO)
        {
            world = new World(ResetWorld, ChangeGameState);
        }

        public virtual void Draw()
        {
            if (playState == 0)
            {
                world.Draw(Vector2.Zero);
            }
        }
    }
}
