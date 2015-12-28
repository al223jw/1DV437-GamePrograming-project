using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class Brick
    {
        private Vector2 brickLogicCords;
        private const float brickLenght = 0.05f;
        private const float brickHeight = 0.01f;

        public Brick()
        {
            brickLogicCords = GenerateLogicCords();
        }

        public Vector2 BrickLogicCords
        {
            get { return brickLogicCords; }
        }

        public float BrickLengt
        {
            get { return brickLenght; }
        }

        public float BrickHeight
        {
            get { return brickHeight; }
        }

        private Vector2 GenerateLogicCords()
        {
            float xCord = 0f;
            float yCord = 0.1f;
            return new Vector2(xCord, yCord);
        }
    }
}
