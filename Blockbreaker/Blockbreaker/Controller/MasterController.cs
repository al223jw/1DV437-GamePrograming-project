using Blockbreaker.Controller;
using Blockbreaker.Model;
using Blockbreaker.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blockbreaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GameController gameController;
        MenuController menuController;
        MidMenuController midMenuController;
        GraphicsDeviceManager device;
        SpriteBatch spriteBatch;
        Camera camera;
        MouseState lastMouseState;
        Audio audio;

        float timer = 0;
        float MenuShows = 0.5f;

        Brick brick;
        Vector2 pos;
        float size;

        GameState currentState;
        enum GameState
        { 
            mainMenu,
            playing,
            midMenu,
        }

        public MasterController()
        {
            device = new GraphicsDeviceManager(this);
            device.PreferredBackBufferWidth = 1600;
            device.PreferredBackBufferHeight = 900;
            device.ApplyChanges();
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
            currentState = GameState.mainMenu;
            audio = new Audio(Content);
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(device.GraphicsDevice.Viewport);
            gameController = new GameController(Content, device, spriteBatch, camera, audio);
            menuController = new MenuController(Content, device, spriteBatch, camera);
            midMenuController = new MidMenuController(Content, device, spriteBatch, camera);

            brick = new Brick(Content, pos, size);
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                currentState = GameState.mainMenu;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                if (currentState == GameState.playing || currentState == GameState.midMenu)
                {
                    gameController.loadLevel();
                    currentState = GameState.playing;
                }
            }

            if (currentState == GameState.mainMenu)
            {
                var mouseState = Mouse.GetState();
                if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                {
                    menuController.Update(new Vector2(mouseState.Position.X, mouseState.Position.Y));

                    if (menuController.pressedContinue)
                    {
                        currentState = GameState.playing;
                        menuController.pressedContinue = false;
                    }
                    else if (menuController.pressedNewGame)
                    {
                        currentState = GameState.playing;
                        menuController.pressedNewGame = false;
                        gameController.restart();
                    }
                }
                lastMouseState = mouseState;
            }

            else if (currentState == GameState.playing)
            {
                gameController.Update(gameTime, brick);    
            }
            else if (currentState == GameState.midMenu)
            {
                var mouseState = Mouse.GetState();

                if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                {
                    midMenuController.Update(new Vector2(mouseState.Position.X, mouseState.Position.Y), gameController.isBallDead(), gameController.nextLevelExists());

                    if (midMenuController.pressedRestart)
                    {
                        currentState = GameState.playing;
                        gameController.loadLevel();
                        midMenuController.pressedRestart = false;
                    }
                    else if (midMenuController.pressedNext && !gameController.isBallDead())
                    {
                        currentState = GameState.playing;
                        gameController.nextLevel();
                        midMenuController.pressedNext = false;
                    }
                    else if(midMenuController.pressedMainMenu)
                    {
                        currentState = GameState.mainMenu;
                        midMenuController.pressedMainMenu = false;
                    }
                }
                lastMouseState = mouseState;
            }

            if (gameController.isBallDead() && currentState != GameState.midMenu)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer >= MenuShows)
                {
                    currentState = GameState.midMenu;
                    timer = 0;
                }
            }
            else if (gameController.FinishedLevel && currentState != GameState.midMenu)
            {
                currentState = GameState.midMenu;
                gameController.FinishedLevel = false;
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
            spriteBatch.Begin();

            if (currentState == GameState.mainMenu)
            {
                menuController.Draw();
            }
            else if (currentState == GameState.playing)
            {
                gameController.Draw(gameTime);
            }
            else if (currentState == GameState.midMenu)
            {
                midMenuController.Draw(gameController.isBallDead(), gameController.nextLevelExists());
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
