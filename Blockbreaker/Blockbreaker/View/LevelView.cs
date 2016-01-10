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
    class LevelView
    {
        Texture2D platformTexture, greenBrickTexture, orangeBrickTexture, purpleBrickTexture, redBrickTexture, yellowBrickTexture;
        Vector2 platformCenter, brickCenter;
        Vector2 scale;
        Camera camera;
        SpriteBatch spriteBatch;

        public LevelView(ContentManager Content, Camera _camera, SpriteBatch _spriteBatch)
        {
            camera = _camera;
            spriteBatch = _spriteBatch;
            platformTexture = Content.Load<Texture2D>("Platform");
            greenBrickTexture = Content.Load<Texture2D>("greenblock");
            orangeBrickTexture = Content.Load<Texture2D>("orangeblock");
            purpleBrickTexture = Content.Load<Texture2D>("purpleblock");
            redBrickTexture = Content.Load<Texture2D>("redblock");
            yellowBrickTexture = Content.Load<Texture2D>("yellowblock");

            platformCenter = new Vector2(platformTexture.Width / 2, platformTexture.Height / 2);
            brickCenter = new Vector2(greenBrickTexture.Width / 2, greenBrickTexture.Height / 2);
        }


        public void DrawPlatform(Platform platform)
        {
            scale = camera.Scale(platform.Size, platformTexture.Width, platformTexture.Height);
            Vector2 pos = platform.Position;
            spriteBatch.Draw(platformTexture, camera.convertToVisualCoords(pos), null, Color.White, 0, platformCenter, scale, SpriteEffects.None, 1f);
        }

        public void DrawBrickGreen(Brick brick)
        {
            scale = camera.Scale(brick.Size, greenBrickTexture.Width, greenBrickTexture.Height);
            Vector2 pos = brick.Position;
            spriteBatch.Draw(greenBrickTexture, camera.convertToVisualCoords(pos), null, Color.White, 0, brickCenter, scale, SpriteEffects.None, 1f);
        }

        public void DrawBrickOrange(Brick brick)
        {
            scale = camera.Scale(brick.Size, orangeBrickTexture.Width, orangeBrickTexture.Height);
            Vector2 pos = brick.Position;
            spriteBatch.Draw(orangeBrickTexture, camera.convertToVisualCoords(pos), null, Color.White, 0, brickCenter, scale, SpriteEffects.None, 1f);
        }

        public void DrawBrickPurple(Brick brick)
        {
            scale = camera.Scale(brick.Size, purpleBrickTexture.Width, purpleBrickTexture.Height);
            Vector2 pos = brick.Position;
            spriteBatch.Draw(purpleBrickTexture, camera.convertToVisualCoords(pos), null, Color.White, 0, brickCenter, scale, SpriteEffects.None, 1f);
        }

        public void DrawBrickRed(Brick brick)
        {
            scale = camera.Scale(brick.Size, redBrickTexture.Width, redBrickTexture.Height);
            Vector2 pos = brick.Position;
            spriteBatch.Draw(redBrickTexture, camera.convertToVisualCoords(pos), null, Color.White, 0, brickCenter, scale, SpriteEffects.None, 1f);
        }

        public void DrawBrickYellow(Brick brick)
        {
            scale = camera.Scale(brick.Size, yellowBrickTexture.Width, yellowBrickTexture.Height);
            Vector2 pos = brick.Position;
            spriteBatch.Draw(yellowBrickTexture, camera.convertToVisualCoords(pos), null, Color.White, 0, brickCenter, scale, SpriteEffects.None, 1f);
        }
    }
}
