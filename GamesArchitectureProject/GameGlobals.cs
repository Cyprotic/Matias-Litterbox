using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class GameGlobals
    {
        public static bool paused = false;

        public static bool restart = false;

        public static int score = 0;
        public int Value { get; set; }

        public static PassObject PassProjectile, PassMob, PassSpawnPoint;
    }
}
