using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class Ball
    {
        private Vector2 ballLogicCords;
        private float ballLogicSpeedX;
        private float ballLogicSpeedY;
        private const float ballLogicDiameter = 0.03f;

        private int life = 3;
        private bool isDead = true;
        private bool brickLife;
        Random rand = new Random();


        public Ball()
        {
            isDead = false;
            this.ballLogicCords = GenerateRandomLogicCords();
            ballLogicSpeedX = 0.3f;
            ballLogicSpeedY = 0.3f;
        }
        public Vector2 BallLogicCords
        {
            get { return ballLogicCords; }
        }

        public float BallLogicDiameter
        {
            get { return ballLogicDiameter; }
        }

        public void UpdateLocation(float time)
        {
            ballLogicCords.X += time * ballLogicSpeedX;
            ballLogicCords.Y += time * ballLogicSpeedY;
        }

        public void CollisionHorizontalWall()
        {
            if (!isDead)
            {
                float NewSpeed = 0.3f;

                if (ballLogicCords.Y <= 0)
                {
                    ballLogicCords.Y = 0;
                    ballLogicSpeedY = NewSpeed;
                }
                else
                {
                    ballLogicCords.Y = 1 - ballLogicDiameter;
                    ballLogicSpeedY = -NewSpeed;
                }
            }
        }

        public void CollisionVerticalWall()
        {
            if (!isDead)
            {
                float NewSpeed = 0.3f;

                if (ballLogicCords.X <= 0)
                {
                    ballLogicCords.X = 0;
                    ballLogicSpeedX = NewSpeed;
                }
                else
                {
                    ballLogicCords.X = 1 - ballLogicDiameter;
                    ballLogicSpeedX = -NewSpeed;
                }
            }
        }

        public void CollisionPlatform()
        {
            float speedAccselerate = 0.01f;
            float newSpeed = 0.3f + speedAccselerate;
            ballLogicSpeedY = -newSpeed;
        }

        public void CollisionBrick()
        {
            brickLife = false;
            float newSpeed = 0.3f;
            ballLogicSpeedY = newSpeed;
        }

        private Vector2 GenerateRandomLogicCords()
        {
            int x = rand.Next(10, 90);
            int y = rand.Next(10, 90);
            float xCord = (float)x / 100f;
            float yCord = (float)y / 100f;
            return new Vector2(xCord, yCord);
        }

        internal void DeadBall()
        {
            isDead = true;
            ballLogicSpeedX = 0;
            ballLogicSpeedY = 0;
            life--;
        }
    }
}
