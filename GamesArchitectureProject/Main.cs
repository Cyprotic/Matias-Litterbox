using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GamesArchitectureProject
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        World world;

        Basic2d cursor;

        //private Texture2D _logoImage;
        //private SoundEffect _logoSound;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
        }

        // Initialization logic
        protected override void Initialize()
        {
            

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

            world = new World();

            //_logoImage = Content.Load<Texture2D>("Logo");
            //_logoSound = Content.Load<SoundEffect>("Logo_sound"); // https://freesound.org/people/hy96/sounds/48182/

            //_logoSound.Play();
        }

        // All the update logic
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update our key precesses
            Globals.keyboard.Update();
            Globals.mouse.Update();

            // Update the current world
            world.Update();

            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();

            base.Update(gameTime);
        }

        // All the drawing logic
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //OBSOLETE Globals.spriteBatch.Draw(_logoImage, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);


            world.Draw(Vector2.Zero);


            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0));
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
