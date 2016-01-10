using Blockbreaker.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.View
{
    class BallView
    {
        Ball ball;
        private Camera camera;
        Vector2 ballCenter;
        Vector2 scale;
        Texture2D ballTexture;

        public BallView(Ball _ball, Camera _camera, ContentManager Content)
        {
            ball = _ball;
            camera = _camera;
            ballTexture = Content.Load<Texture2D>("Ball.png");
            ballCenter = new Vector2(ballTexture.Width / 2, ballTexture.Height / 2);
            Vector2 size = ball.getSize;
            scale = camera.Scale(size, ballTexture.Width, ballTexture.Height);
        }


        public void DrawBall(SpriteBatch spriteBatch, float elapsedTime)
        {
            Vector2 ballVisualLocation = camera.convertToVisualCoords(ball.Position);
            spriteBatch.Draw(ballTexture, ballVisualLocation, null, Color.White, 0, ballCenter, scale, SpriteEffects.None, 1f);
        }
    }
}
