using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class Platform
    {
        Vector2 position;
        Vector2 platfromSize;
        Vector2 velocity;
        float moveSpeed = 250f;


        public Platform(Vector2 pos)
        {
            platfromSize = new Vector2(1.7f, 0.2f);
            position = pos;
        }

        public Vector2 Size
        {
            get
            {
                return platfromSize;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public void Update(float elapsedTime)
        {
            velocity = elapsedTime * velocity;
            position = elapsedTime * velocity + position;
        }

        public bool landsOnplatform(Ball ball)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - (platfromSize.X - 0.7f) / 2;
            maxX = position.X + (platfromSize.X - 0.7f) / 2;
            minY = position.Y - platfromSize.Y / 2;
            maxY = position.Y + platfromSize.Y / 2;

            return
                (
                    ball.Position.X + ball.getSize.X / 3 > minX && ball.Position.X - ball.getSize.X / 3 < maxX &&
                    ball.Position.Y + ball.getSize.Y / 2 > minY &&
                    ball.Position.Y - ball.getSize.Y / 2 < minY &&
                    ball.Velocity.Y >= 0f
                );
        }

        public bool landsOnPlatformLeftSide(Ball ball)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - (platfromSize.X) / 2;
            maxX = position.X + (platfromSize.X - 2f) / 2;
            minY = position.Y - platfromSize.Y / 2;
            maxY = position.Y + platfromSize.Y / 2;

            return
            (
                    ball.Position.X + ball.getSize.X / 3 > minX && ball.Position.X - ball.getSize.X / 3 < maxX &&
                    ball.Position.Y + ball.getSize.Y / 2 > minY &&
                    ball.Position.Y - ball.getSize.Y / 2 < minY &&
                    ball.Velocity.Y >= 0f
            );
        }

        public bool landsOnPlatformRightSide(Ball ball)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - (platfromSize.X - 3f) / 2;
            maxX = position.X + (platfromSize.X) / 2;
            minY = position.Y - platfromSize.Y / 2;
            maxY = position.Y + platfromSize.Y / 2;

            return
            (
                    ball.Position.X + ball.getSize.X / 3 > minX && ball.Position.X - ball.getSize.X / 3 < maxX &&
                    ball.Position.Y + ball.getSize.Y / 2 > minY &&
                    ball.Position.Y - ball.getSize.Y / 2 < minY &&
                    ball.Velocity.Y >= 0f
            );
        }

        public void moveLeft()
        {
            if (position.X - platfromSize.X / 2 <= 0)
            {
                stopMoving();
                return;
            }
            velocity.X = -moveSpeed;
        }
        public void moveRight()
        {
            if (position.X + platfromSize.X / 2 >= 16)
            {
                stopMoving();
                return;
            }
            velocity.X = moveSpeed;
        }

        public void stopMoving()
        {
            velocity.X = 0;
        }
    }
}
