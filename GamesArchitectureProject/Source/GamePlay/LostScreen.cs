using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GamesArchitectureProject
{
    public class LostScreen
    {
        public Basic2d bkg_lost;

        public PassObject ChangeLevel;

        public SpriteFont font;


        public LostScreen(PassObject CHANGELEVEL)
        {
            ChangeLevel = CHANGELEVEL;

            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");


            // Original
            bkg_lost = new Basic2d("2d\\UI\\BackGrounds\\GameOverBkg", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(Globals.screenWidth, Globals.screenHeight));
            
        }

        public virtual void Update()
        {
            
            if (Globals.keyboard.GetSinglePress("Enter"))
            {
                GameGlobals.score = 0;
                ChangeLevel.Invoke(1);
            }
        }

        public virtual void Draw()
        {
            bkg_lost.Draw(Vector2.Zero);

            // To print
            string tempStr = "Score = " + GameGlobals.score;
            // Dimensions of font
            Vector2 strDims = font.MeasureString(tempStr);
            //Draw
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight - 650), Color.Black);
        }
    }
}
