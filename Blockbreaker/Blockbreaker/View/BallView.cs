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
        Texture2D ballTexture, spark;

        List<ExplotionParticle> sparkParticles = new List<ExplotionParticle>();
        Random rand = new Random();

        public BallView(Ball _ball, Camera _camera, ContentManager Content, Texture2D _spark)
        {
            ball = _ball;
            spark = _spark;
            camera = _camera;
            ballTexture = Content.Load<Texture2D>("Ball.png");
            ballCenter = new Vector2(ballTexture.Width / 2, ballTexture.Height / 2);
            Vector2 size = ball.getSize;
            scale = camera.Scale(size, ballTexture.Width, ballTexture.Height);
        }


        public void DrawBall(SpriteBatch spriteBatch, float elapsedTime)
        {
            sparkParticles.Add(new ExplotionParticle(spark, rand, spriteBatch, camera, ball.Position, 1f));
            foreach (ExplotionParticle particle in sparkParticles)
            {
                particle.Draw(elapsedTime);
            }
            Vector2 ballVisualLocation = camera.convertToVisualCoords(ball.Position);
            spriteBatch.Draw(ballTexture, ballVisualLocation, null, Color.White, 0, ballCenter, scale, SpriteEffects.None, 1f);
        }
    }
}
