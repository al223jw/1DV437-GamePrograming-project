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
    class BrickView
    {
        private BrickSimulation brickSimulation = new BrickSimulation();
        private SpriteBatch spriteBatch;
        private Camera camera;
        private Brick brick = new Brick();
        ContentManager content;

        Texture2D redBlock;
        Texture2D greenBlock;
        Texture2D yellowBlock;
        Texture2D purpleBlock;
        Texture2D orangeBlock;

        public BrickView(SpriteBatch spriteBatch, Camera camera, ContentManager content, BrickSimulation brickSimulation)
        {
            this.spriteBatch = spriteBatch;
            this.camera = camera;
            this.brickSimulation = brickSimulation;
            this.content = content;

             redBlock = content.Load<Texture2D>("redblock.png");
             greenBlock = content.Load<Texture2D>("greenblock.png");
             yellowBlock = content.Load<Texture2D>("yellowblock.png");
             purpleBlock = content.Load<Texture2D>("purpleblock.png");
             orangeBlock = content.Load<Texture2D>("orangeblock.png");
        }

        public void DrawBricks()
        {
            spriteBatch.Begin();

            List<Brick> bricks = brickSimulation.getBricks();
            foreach (Brick b in bricks)
            {

                spriteBatch.Draw(redBlock,
                                 camera.GetBrickVisualCord(redBlock, b),
                                 null,
                                 Color.White,
                                 0,
                                 new Vector2(0, 0),
                                 camera.GetBrickScale(redBlock, b),
                                 SpriteEffects.None,
                                 0f);

            }
            spriteBatch.End();
        }
    }
}
