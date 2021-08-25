using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class UI
    {
        public Basic2d pauseOverlay;

        public SpriteFont font;

        public QuantityDisplayBar healthBar;

        public UI()
        {
            //https://www.iconfinder.com/icons/211871/pause_icon
            pauseOverlay = new Basic2d("2d\\Misc\\PauseOverlay", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(300,300));

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


            if (GameGlobals.paused) // If the game is pauses draw the pause icon
            {
                pauseOverlay.Draw(Vector2.Zero);
            }
        }
    }
}
