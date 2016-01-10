using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class Brick
    {
        Vector2 position;
        Vector2 brickSize;
        bool isDead = false;

        public Brick(ContentManager Content, Vector2 pos, float size)
        {
            brickSize = new Vector2(size, size);
            position = pos;
        }

        public Vector2 Size
        {
            get
            {
                return brickSize;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public bool hitsABlock(Ball ball)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - brickSize.X / 2;
            maxX = position.X + brickSize.X / 2;
            minY = position.Y - brickSize.Y / 2;
            maxY = position.Y + brickSize.Y / 2;

            return
                (
                ball.Position.X + ball.getSize.X / 3 > minX && ball.Position.X - ball.getSize.X / 3 < maxX &&
                ball.Position.Y > minY &&
                ball.Position.Y - ball.getSize.Y / 2 < maxY &&
                ball.Velocity.Y <= -3f
                );
        }

        public bool hitsABlockFromAbove(Ball ball)
        {
            float minX, maxX, minY, maxY;

            minX = position.X - brickSize.X / 2;
            maxX = position.X + brickSize.X / 2;
            minY = position.Y - brickSize.Y / 2;
            maxY = position.Y + brickSize.Y / 2;

            return
                (
                ball.Position.X + ball.getSize.X / 3 > minX && ball.Position.X - ball.getSize.X / 3 < maxX &&
                ball.Position.Y + ball.getSize.Y / 2 > minY &&
                ball.Position.Y - ball.getSize.Y / 2 < minY &&
                ball.Velocity.Y >= 3f
                );
        }

        public bool collisionSide(Ball ball)
        {
            float minX, maxX, minY, maxY;
            minX = position.X - brickSize.X / 2;
            maxX = position.X + brickSize.X / 2;
            minY = position.Y - brickSize.Y / 2;
            maxY = position.Y + brickSize.Y / 2;

            return
                (
                ball.Position.Y + ball.getSize.Y / 3 > minY && ball.Position.Y - ball.getSize.Y / 3 < maxY &&
                ball.Position.X + ball.getSize.X / 2 > minX &&
                ball.Position.X - ball.getSize.X / 2 < maxX
                );
        }

        public bool brickIsDead()
        {
            return isDead = true;
        }
    }
}
