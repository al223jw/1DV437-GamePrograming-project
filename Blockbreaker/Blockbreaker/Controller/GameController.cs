using Blockbreaker.Model;
using Blockbreaker.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Controller
{
    class GameController
    {
        Ball ball;
        BallView ballView;
        Camera camera;
        ContentManager Content;
        SystemOfMap mapSystem;
        SpriteBatch spriteBatch;
        int selectLevel = 0;
        bool finishedLevel = false;
        bool died = false;

        public GameController(ContentManager content, GraphicsDeviceManager device, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            camera = _camera;

            mapSystem = new SystemOfMap(Content, camera, selectLevel, spriteBatch);
            ball = new Ball(mapSystem);
            ballView = new BallView(ball, camera, Content);
        }

        public void Update(GameTime gameTime, Brick brick)
        {
            mapSystem.updatePlatform((float)gameTime.ElapsedGameTime.TotalSeconds);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                mapSystem.movePlatformRight();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                mapSystem.movePlatformLeft();
            }

            ball.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            Platform platformCollidesWithBall = mapSystem.landsOnplatform(ball);
            if (platformCollidesWithBall != null)
            {
                ball.ballLandsOPlatform(platformCollidesWithBall);
            }

            Brick brickCollidedWithBall = mapSystem.hitsGreenBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsOrangeBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsPurpleBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsRedBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsYellowBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsGreenBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsOrangeBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsPurpleBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsRedBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsYellowBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsGreenBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsOrangeBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsPurpleBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsRedBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
            }

            brickCollidedWithBall = mapSystem.hitsYellowBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
            }

            if (mapSystem.allBlocksAreDead(brick))
            {
                finishedLevel = true;
            }
        }

        public void restart()
        {
            selectLevel = 0;
            loadLevel();
        }

        public void loadLevel()
        {
            died = false;
            mapSystem = new SystemOfMap(Content, camera, selectLevel, spriteBatch);
            ball = new Ball(mapSystem);
            ballView = new BallView(ball, camera, Content);
        }

        public void nextLevel()
        {
            if (nextLevelExists())
            {
                selectLevel++;
                loadLevel();
            }
        }

        public bool nextLevelExists()
        {
            return mapSystem.doseLevelExists(selectLevel + 1);
        }

        public bool isBallDead()
        {
            return ball.isDead;
        }

        public bool FinishedLevel
        {
            get
            {
                return finishedLevel;
            }
            set
            {
                finishedLevel = value;
            }
        }

        public void Draw(GameTime gameTime)
        {
            mapSystem.drawStuff(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            ballView.DrawBall(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
