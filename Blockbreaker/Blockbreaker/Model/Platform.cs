using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class Platform
    {
        private Vector2 platformLogicCords;
        private const float platformLenght = 0.17f;
        private const float platformHeight = 0.03f;

        public Platform()
        {
            platformLogicCords = GenerateLogicChords();
            
        }

        public Vector2 PlatformLogicChords
        {
            get { return platformLogicCords; }
        }

        public float PlatformLengt
        {
            get { return platformLenght; }
        }

        public float PlatformHeight
        {
            get { return platformHeight; }
        }

        public void UpdateLocation()
        {
            platformLogicCords.X += Mouse.GetState().X;
        }

        private Vector2 GenerateLogicChords()
        {
            float xCord = 0.42f;
            float yCord = 0.9f;
            return new Vector2(xCord, yCord);
        }
    }
}
