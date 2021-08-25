using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GamesArchitectureProject
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;

        GamePlay gamePlay;

        MainMenu mainMenu;

        LostScreen lostScreen;

        Basic2d cursor;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        // Initialization logic
        protected override void Initialize()
        {
            Globals.screenWidth = 1600;
            Globals.screenHeight = 900;

            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

        // Loading content logic
        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // https://iconarchive.com/show/flat-gradient-social-icons-by-limav/Aim-icon.html
            cursor = new Basic2d("2d//Misc//cursor", new Vector2(0, 0), new Vector2(28, 28));
            
            // Load the custom keyboard input
            Globals.keyboard = new Keyboard();
            // Load the custom mouse input
            Globals.mouse = new MouseControl();

            gamePlay = new GamePlay(ChangeGameState);
            mainMenu = new MainMenu(ChangeGameState, ExitGame);
            lostScreen = new LostScreen(ChangeGameState);
        }
            
        // All the update logic
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Provides a snapshot of timing values
            Globals.gameTime = gameTime;
            // Update our key precesses
            Globals.keyboard.Update();
            Globals.mouse.Update();

            // States logic for the different type of screens
            if (Globals.gameState == 0)
            {
                mainMenu.Update();
            }
            else if (Globals.gameState == 1)
            {
                // Update the gameplay logic
                gamePlay.Update();
            }
            else if (Globals.gameState == 2)
            {
                // Update the gameplay logic
                lostScreen.Update();
            }

            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();

            base.Update(gameTime);
        }

        // Changing the game states
        public virtual void ChangeGameState(object INFO)
        {
            Globals.gameState = Convert.ToInt32(INFO, Globals.culture);
        }

        // Function to exit the game
        public virtual void ExitGame(object INFO)
        {
            System.Environment.Exit(0);
        }


        // All the drawing logic
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            // Drawing the states
            if (Globals.gameState == 0)
            {
                // Draw the main menu screen
                mainMenu.Draw();
            }
            else if (Globals.gameState == 1)
            {
                // Draw the gameplay
                gamePlay.Draw();
            }
            else if (Globals.gameState == 2)
            {
                // Draw the lost screen
                lostScreen.Draw();
            }

            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0), Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    // Run the Program
    public static class Program
    {
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }
}
