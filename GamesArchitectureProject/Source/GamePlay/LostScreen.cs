using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace GamesArchitectureProject
{
    public class LostScreen
    {
        public Basic2d bkg_lost;

        public PassObject ChangeLevel;

        public SpriteFont font;

        ScoreManager scoreManager;


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
            // Load in our score manager
            scoreManager = ScoreManager.Load();
            // BackGround lost
            bkg_lost.Draw(Vector2.Zero);
            
            // To print
            string tempStrScore = "Score = " + GameGlobals.score;
            // Dimensions of font
            Vector2 strDimsScore = font.MeasureString(tempStrScore);
            //Draw
            Globals.spriteBatch.DrawString(font, tempStrScore, new Vector2(Globals.screenWidth / 2 - strDimsScore.X / 2, Globals.screenHeight - 700), Color.Black);

            // To print
            string tempStrHighScore = "Highscores: \n";
            // Dimensions of font
            Vector2 strDimsHighScore = font.MeasureString(tempStrHighScore);
            //Draw
            Globals.spriteBatch.DrawString(font, tempStrHighScore + string.Join("\n", scoreManager.Highscores.Select(c => c.Value).ToArray()), new Vector2(Globals.screenWidth / 2 - strDimsHighScore.X / 2, Globals.screenHeight - 670), Color.Black);

        }
    }
}
