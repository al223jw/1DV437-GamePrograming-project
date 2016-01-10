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

        GraphicsDeviceManager device;
        SpriteBatch spriteBatch;
        Camera camera;

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
            //this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
            //currentState = GameState.mainMenu;
            currentState = GameState.playing;
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
            gameController = new GameController(Content, device, spriteBatch, camera);

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
                currentState = GameState.midMenu;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                if (currentState == GameState.playing || currentState == GameState.midMenu)
                {
                    gameController.loadLevel();
                    currentState = GameState.playing;
                }
            }

            gameController.Update(gameTime, brick);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            gameController.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
