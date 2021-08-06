using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class UI
    {
        public SpriteFont font;

        public UI()
        {
            font = Globals.content.Load<SpriteFont> ("Fonts\\Arial16");
        }

        public void Update(World WORLD)
        {

        }

        public void Draw(World WORLD)
        {
            // To print
            string tempStr = "Cats balled = " + WORLD.numKilled;
            // Dimensions of font
            Vector2 strDims = font.MeasureString(tempStr);
            //Draw
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40), Color.Black);
        }
    }
}
