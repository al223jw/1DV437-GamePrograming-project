using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class Ball
    {
        Vector2 position;
        Vector2 velocity = new Vector2(1f, -3f);

        Vector2 ballSize = new Vector2(0.2f, 0.2f);
        SystemOfMap systemOfMap;

        int ballLife = 3;
        int countLife = 0;
        bool _isDead = false;


        public Ball(SystemOfMap _systamOfMap)
        {
            systemOfMap = _systamOfMap;
            position = _systamOfMap.getBallSpawnLocation;
        }

        public Vector2 getSize
        {
            get
            {
                return ballSize;
            }
        }

        public bool isDead
        {
            get
            {
                return _isDead;
            }
            set
            {
                _isDead = value;
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
            position = elapsedTime * velocity + position;
            Collision();
        }

        public void Collision()
        {

            if (position.X + ballSize.X / 2 >= 16)
            {
                position.X = 16 - ballSize.X / 2;
                velocity.X = -3f;
            }
            else if (position.X - ballSize.X / 2 <= 0)
            {
                position.X = 0 + ballSize.X / 2;
                velocity.X = 3f;
            }

            if (position.Y >= 10)
            {
                isDead = true;
            }

            if (position.Y <= 0)
            {
                position.Y = 0 + ballSize.Y / 2;
                velocity.Y = 3f;
            }
        }

        public void ballLandsOPlatform(Platform platform)
        {
            velocity.Y = -3f;
        }

        public void ballLandsOPlatformRightSide(Platform platform)
        {
            velocity.Y = -3f;
            velocity.X = 2f;
        }

        public void ballLandsOPlatformLeftSide(Platform platform)
        {
            velocity.Y = -3f;
            velocity.X = -2f;
        }

        public void ballHitsABrick(Brick brick)
        {
               velocity.Y = 3f;
        }

        public void ballHitsABrickFromAbove(Brick brick)
        {
            velocity.Y = -3f;
        }

        public void ballHitsBrickSide(Brick brick)
        {
            if (velocity.X == 3f)
            {
                velocity.X = -3f;
            }
            velocity.X = 3f;
        }


        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                Position = value;
            }
        }
    }
}