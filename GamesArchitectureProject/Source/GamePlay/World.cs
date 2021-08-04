using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class World
    {

        public Hero hero;

        public World()
        {
            // Cat image from http://pixelartmaker.com/art/99b1245ee58be2c
            hero = new Hero("2d\\matias", new Vector2(300, 300), new Vector2(48, 48));
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);
        }
    }
}
