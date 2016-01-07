using Blockbreaker.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.View
{
    class MainView
    {
        private SpriteBatch spriteBatch;
        private Camera camera;
        private BallView ballView;
        private BrickView brickView;
        private Platform platform = new Platform();
        private GraphicsDevice device;
        private float platformRadius;
        Texture2D platformTexture;

        public MainView(GraphicsDevice device, ContentManager content, BallSimulation ballSimulation, BrickSimulation brickSimulation)
        {
            this.device = device;
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device);

            ballView = new BallView(spriteBatch, camera, content, ballSimulation);
            brickView = new BrickView(spriteBatch, camera, content, brickSimulation);

            platformTexture = loadGraphics(content);
            Console.WriteLine(platform.PlatformLogicChords);
        }


        public void DrawGame()
        {

            ballView.DrawBall();
            brickView.DrawBricks();

            spriteBatch.Begin();

            spriteBatch.Draw(platformTexture,
                             camera.GetPlatformVisualCord(platformTexture),
                             null,
                             Color.White,
                             0,
                             new Vector2(0, 0),
                             camera.GetPlatformScale(platformTexture),
                             SpriteEffects.None,
                             0f);
            spriteBatch.End();

        }

        private Texture2D loadGraphics(ContentManager content)
        {
            return platformTexture = content.Load<Texture2D>("platform.png");
        }
    }
}
