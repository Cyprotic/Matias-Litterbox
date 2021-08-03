using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class Hero : Basic2d
    {
        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {

        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - 1, pos.Y);
            }
            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + 1, pos.Y);
            }
            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - 1);
            }
            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + 1);
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
