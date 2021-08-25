using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesArchitectureProject
{
    public class MainMenu
    {
        public Basic2d bkg;

        public PassObject PlayKey, ExitKey;

        public MainMenu(PassObject PLAYKEY, PassObject EXITKEY)
        {
            PlayKey = PLAYKEY;
            ExitKey = EXITKEY;

            // Original
            bkg = new Basic2d("2d\\UI\\BackGrounds\\MainMenuBkg", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(Globals.screenWidth, Globals.screenHeight));
        }

        public virtual void Update()
        {
            if (Globals.keyboard.GetSinglePress("Space"))
            {
                PlayKey.Invoke(1);
            }

            if (Globals.keyboard.GetSinglePress("Esc"))
            {
                ExitKey.Invoke(null);
            }
        }

        public virtual void Draw()
        {
            bkg.Draw(Vector2.Zero);
        }
    }
}
