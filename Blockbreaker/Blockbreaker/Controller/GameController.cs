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
        Texture2D spark;
        SpriteBatch spriteBatch;
        Audio audio;
        int selectLevel = 0;
        bool finishedLevel = false;

        public GameController(ContentManager content, GraphicsDeviceManager device, SpriteBatch _spriteBatch, Camera _camera, Audio _audio)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            camera = _camera;
            spark = Content.Load<Texture2D>("spark");
            audio = _audio;

            mapSystem = new SystemOfMap(Content, camera, selectLevel, spriteBatch, audio);
            ball = new Ball(mapSystem);
            ballView = new BallView(ball, camera, Content, spark);
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
                audio.hitPlatform();
            }

            platformCollidesWithBall = mapSystem.landsOnPlatformRightSIde(ball);
            if(platformCollidesWithBall != null)
            { 
                ball.ballLandsOPlatformRightSide(platformCollidesWithBall);
                audio.hitPlatform();
            }
            

            platformCollidesWithBall = mapSystem.landsOnPlatformLeftSide(ball);
            if(platformCollidesWithBall != null)
            { 
                ball.ballLandsOPlatformLeftSide(platformCollidesWithBall);
                audio.hitPlatform();
            }

            Brick brickCollidedWithBall = mapSystem.hitsGreenBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsOrangeBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsPurpleBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsRedBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsYellowBrick(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrick(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsGreenBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsOrangeBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsPurpleBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsRedBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsYellowBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsABrickFromAbove(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsGreenBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsOrangeBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsPurpleBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsRedBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
                audio.hitBlock();
            }

            brickCollidedWithBall = mapSystem.hitsYellowBrickFromAbove(ball);
            if (brickCollidedWithBall != null)
            {
                ball.ballHitsBrickSide(brickCollidedWithBall);
                audio.hitBlock();
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
            mapSystem = new SystemOfMap(Content, camera, selectLevel, spriteBatch, audio);
            ball = new Ball(mapSystem);
            ballView = new BallView(ball, camera, Content, spark);
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
