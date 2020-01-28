using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LarrysAngelWarfare
{
    public enum currentScreen { startScreen, loadScreen, inGame, pauseMenu, deathScreen, exit, help, credits, options }
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class LarrysAngelWarfare : Game
    {
        //this will be the font used in the game
        public static SpriteFont font;
        //this will be the var that keep track of the screen
        //public static byte FPS = 0;
        //public static GameTime currentTime = new GameTime();
        //This will be used to keep track of what level the game is on
        public static int levelCounter = 1;
        
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        //this will keep track of what screen the game is on
        public static currentScreen currentScreen = currentScreen.startScreen;
        Level level = new Level();
        private Screen screen;
        public LarrysAngelWarfare()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            Window.AllowAltF4 = true;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            base.Initialize();


        }
        /// <summary>
        /// This will be used to load the level
        /// </summary>
        /// <param name="levelImg"></param>
        public void loadLevels(string levelImg)
        {
            level.load(levelImg, spriteBatch, Content);
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            Images.LoadImages(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static MouseState mouseState;
        public static bool mouseClicked = false;

        internal Screen Screen { get => screen; set => screen = value; }

        protected override void Update(GameTime gameTime)
        {
            //Will check if the the mouse is done being pressed
            if (mouseState.LeftButton == ButtonState.Released) mouseClicked = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //gets mouse state for press and releases
            mouseState = Mouse.GetState();
            // TODO: Add your update logic here
            //this will update all the objects
            //this will check what screen the game is in.
            switch (currentScreen)
            {
                case currentScreen.inGame:
                    ObjectsList.update();
                    break;
                case currentScreen.startScreen:
                    if (!(screen is menuScreen))
                    { screen = new menuScreen(); }
                    screen.update();
                    break;
                case currentScreen.credits:
                    if (!(screen is CreditScreen))
                    { screen = new CreditScreen(); }
                    screen.update();
                    break;
                case currentScreen.options:
                    if (!(screen is OptionsScreen))
                    { screen = new OptionsScreen(); }
                    screen.update();
                    break;
                case currentScreen.exit:
                    Exit();
                    break;
                case currentScreen.help:
                    if (!(screen is helpScreen))
                    {
                        screen = new helpScreen();
                    }
                    screen.update();
                    break;
            }
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            //this will draw all the images 
            spriteBatch.Begin();
            //this will check what what screen it is      
            switch (currentScreen)
            {
                case currentScreen.inGame:
                    ObjectsList.draw(spriteBatch);
                    break;
                case currentScreen.loadScreen:
                    loadLevels("level"/* + levelCounter.ToString()*/);
                    currentScreen = currentScreen.inGame;
                    break;
                case currentScreen.startScreen:
                case currentScreen.pauseMenu:
                case currentScreen.help:
                case currentScreen.deathScreen:
                case currentScreen.options:
                case currentScreen.credits:
                    screen.draw(spriteBatch);
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);





            //FPS++;

        }
    }
}
