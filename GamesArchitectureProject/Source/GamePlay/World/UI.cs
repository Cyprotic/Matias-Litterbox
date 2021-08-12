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

        public QuantityDisplayBar healthBar;

        public UI()
        {
            font = Globals.content.Load<SpriteFont> ("Fonts\\Arial16");

            healthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }

        public void Update(World WORLD) 
        {
            healthBar.Update(WORLD.user.hero.health, WORLD.user.hero.healthMax);
        }

        public void Draw(World WORLD)
        {
            // To print
            string tempStr = "Score = " + GameGlobals.score;
            // Dimensions of font
            Vector2 strDims = font.MeasureString(tempStr);
            //Draw
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight - 40), Color.Black);

            // Draw healthBar
            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));

            if (WORLD.user.hero.dead)
            {
                tempStr = "Press Enter to Restart!";
                strDims = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth/2 - strDims.X/2, Globals.screenHeight/2), Color.Black);
            }
        }
    }
}
