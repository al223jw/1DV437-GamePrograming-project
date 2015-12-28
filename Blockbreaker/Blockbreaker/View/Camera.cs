using Blockbreaker.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.View
{
    class Camera
    {
        Platform platform = new Platform();
        Brick brick = new Brick();
        private float Dissort = 10;
        private float WallThickness = 5;

        private GraphicsDevice device;

        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        public Vector2 GetVisualCords(Vector2 logicalCords, float imageWidth, float imageHeight)
        {
            return new Vector2((this.device.Viewport.Width * logicalCords.X) - imageWidth / 2,
                                (this.device.Viewport.Height * logicalCords.Y) - imageHeight / 2);
        }

        public Vector2 GetBallVisualCord(Texture2D ballTexture, Ball ball)
        {
            float totalDissort = Dissort + WallThickness;

            float x = ball.BallLogicCords.X * (device.Viewport.Width - totalDissort * 2) + totalDissort;
            float y = ball.BallLogicCords.Y * (device.Viewport.Height - totalDissort * 2) + totalDissort;

            return new Vector2(x, y);
        }

        public Vector2 GetWallVisualCord(Vector2 StartDrawPoint)
        {
            float x;
            float y;
            if (StartDrawPoint.X == 1)
            {
                x = (device.Viewport.Width * StartDrawPoint.X) - Dissort - WallThickness;
                y = (device.Viewport.Height * StartDrawPoint.Y) + Dissort;
            }
            else if (StartDrawPoint.Y == 1)
            {
                x = (device.Viewport.Width * StartDrawPoint.X) + Dissort;
                y = (device.Viewport.Height * StartDrawPoint.Y) - Dissort - WallThickness;
            }
            else
            {
                x = (device.Viewport.Width * StartDrawPoint.X) + Dissort;
                y = (device.Viewport.Height * StartDrawPoint.Y) + Dissort;
            }

            return new Vector2(x, y);
        }

        public Vector2 GetPlatformVisualCord(Texture2D platformTexture)
        {
            float totalDissort = Dissort + WallThickness;

            float x = platform.PlatformLogicChords.X * (device.Viewport.Width - totalDissort * 2) + totalDissort;
            float y = platform.PlatformLogicChords.Y * (device.Viewport.Height - totalDissort * 2) + totalDissort;

            return new Vector2(x, y);
        }

        public Vector2 GetBrickVisualCord(Texture2D brickTexture, Brick brick)
        {
            float totalDissort = Dissort + WallThickness;

            float x = brick.BrickLogicCords.X * (device.Viewport.Width - totalDissort * 2) + totalDissort;
            float y = brick.BrickLogicCords.Y * (device.Viewport.Height - totalDissort * 2) + totalDissort;

            return new Vector2(x, y);
        }


        public Vector2 GetBallScale(Texture2D ballTexture, Ball ball)
        {
            float x = ((device.Viewport.Width - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Width;
            float y = ((device.Viewport.Height - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Height;
            return new Vector2(x, y);
        }

        public Vector2 GetPlatformScale(Texture2D platformTexture)
        {
            float x = ((device.Viewport.Width - (float)Dissort * 2) * platform.PlatformLengt) / platformTexture.Bounds.Width;
            float y = ((device.Viewport.Height - (float)Dissort * 2) * platform.PlatformHeight)  / platformTexture.Bounds.Height;

            return new Vector2(x, y);
        }

        public Vector2 GetBrickScale(Texture2D brickTexture, Brick brick)
        {
            float x = ((device.Viewport.Width - (float)Dissort * 2) * brick.BrickLengt) / brickTexture.Bounds.Width;
            float y = ((device.Viewport.Height - (float)Dissort * 2) * brick.BrickHeight) / brickTexture.Bounds.Height;

            return new Vector2(x, y);
        }

        internal Vector2 GetVerticalWallScale(Texture2D VerticalWall)
        {
            float scale = (device.Viewport.Height - (float)Dissort * 2) / VerticalWall.Bounds.Height;
            return new Vector2(1, scale);
        }

        internal Vector2 GetHorizontalWallScale(Texture2D HorizontalWall)
        {
            float scale = (device.Viewport.Width - (float)Dissort * 2) / HorizontalWall.Bounds.Width;
            return new Vector2(scale, 1);
        }

        public Vector2 GetLogicalCords(Vector2 VisualLocation)
        {
            return new Vector2((float)VisualLocation.X / device.Viewport.Width,
                               (float)VisualLocation.Y / device.Viewport.Height);
        }
    }
}
