using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class BallSimulation
    {
        private List<Ball> balls;
        Platform platform = new Platform();
        Brick brick = new Brick();

        public List<Ball> getBalls()
        {
            return this.balls;
        }

        public BallSimulation()
        {
            balls = new List<Ball>(3);
            for (int i = 0; i < 1; i++)
            {
                balls.Add(new Ball());
            }

        }

        public void Update(float timeElapsed)
        {
            foreach (Ball b in balls)
            {
                b.UpdateLocation(timeElapsed);
                CheckCollision(b);
            }
        }

        private void CheckCollision(Ball ball)
        {
            if (ball.BallLogicCords.X + ball.BallLogicDiameter >= 1 || ball.BallLogicCords.X <= 0)
            {
                ball.CollisionVerticalWall();
            }

            if (ball.BallLogicCords.Y + ball.BallLogicDiameter >= 1 || ball.BallLogicCords.Y <= 0)
            {
                ball.CollisionHorizontalWall();
            }

            if (ball.BallLogicCords.X + ball.BallLogicDiameter >= platform.PlatformLogicChords.X + platform.PlatformLengt + platform.PlatformHeight && 
                ball.BallLogicCords.Y + ball.BallLogicDiameter >= platform.PlatformLogicChords.Y + platform.PlatformLengt + platform.PlatformHeight)
            {
                ball.CollisionPlatform();
            }

            //if (ball.BallLogicCords.X + ball.BallLogicDiameter >= brick.BrickLogicCords.X + brick.BrickLengt + brick.BrickHeight && 
            //    ball.BallLogicCords.Y + ball.BallLogicDiameter >= brick.BrickLogicCords.Y + brick.BrickLengt + brick.BrickHeight)
            //{
            //    ball.CollisionBrick();
            //}
        }
    }
}
