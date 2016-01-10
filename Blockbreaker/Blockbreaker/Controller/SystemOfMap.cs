using Blockbreaker.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class SystemOfMap
    {
        ContentManager content;
        Camera camera;
        List<Brick> greenBricks = new List<Brick>();
        List<Brick> orangeBricks = new List<Brick>();
        List<Brick> purpleBricks = new List<Brick>();
        List<Brick> redBricks = new List<Brick>();
        List<Brick> yellowBricks = new List<Brick>();
        Platform platform;

        float size = 0.5f;
        Vector2 ballSpawnPosition;

        List<char[,]> levels = new List<char[,]>();

        LevelView levelView;

        public SystemOfMap(ContentManager _content, Camera _camera, int levelSelect, SpriteBatch spriteBatch)
        {
            levelView = new LevelView(_content, _camera, spriteBatch);
            content = _content;
            camera = _camera;
            LevelCreater levelCreator = new LevelCreater();
            levels = levelCreator.getLevels();
            loadLevel(levelSelect);
        }

        public bool doseLevelExists(int level)
        {
            if (level >= 0 && levels.Count > level)
            {
                return true;
            }
            return false;
        }

        public void loadLevel(int level)
        {
            for (int i = 0; i < levels[level].GetLength(1); i++)
            {
                for (int y = 0; y < levels[level].GetLength(0); y++)
                {
                    if (levels[level][y, i] == 'G')
                    {
                        greenBricks.Add(new Brick(content, new Vector2(size / 2 + size * i, size / 2 + size * y), size));
                    }
                    else if (levels[level][y, i] == 'O')
                    {
                        orangeBricks.Add(new Brick(content, new Vector2(size / 2 + size * i, size / 2 + size * y), size));
                    }
                    else if (levels[level][y, i] == 'P')
                    {
                        purpleBricks.Add(new Brick(content, new Vector2(size / 2 + size * i, size / 2 + size * y), size));
                    }
                    else if (levels[level][y, i] == 'R')
                    {
                        redBricks.Add(new Brick(content, new Vector2(size / 2 + size * i, size / 2 + size * y), size));
                    }
                    else if (levels[level][y, i] == 'Y')
                    {
                        yellowBricks.Add(new Brick(content, new Vector2(size / 2 + size * i, size / 2 + size * y), size));
                    }
                    else if (levels[level][y, i] == '$')
                    {
                        ballSpawnPosition = new Vector2(size / 2 + size * i, size / 2 + size * y);
                    }
                    else if (levels[level][y, i] == 'p')
                    {
                        platform = new Platform(new Vector2(0.5f / 2 + 0.5f * i, 0.5f / 2 + 0.5f * y));
                    }
                }
            }
        }

        public Vector2 getBallSpawnLocation
        {
            get
            {
                return ballSpawnPosition;
            }
        }

        public void drawStuff(SpriteBatch spriteBatch, float elapsedTime)
        {
            levelView.DrawPlatform(platform);

            foreach (Brick brick in greenBricks)
            {
                levelView.DrawBrickGreen(brick);
            }
            foreach (Brick brick in orangeBricks)
            {
                levelView.DrawBrickOrange(brick);
            }
            foreach (Brick brick in purpleBricks)
            {
                levelView.DrawBrickPurple(brick);
            }
            foreach (Brick brick in redBricks)
            {
                levelView.DrawBrickRed(brick);
            }
            foreach (Brick brick in yellowBricks)
            {
                levelView.DrawBrickYellow(brick);
            }
        }

        public void updatePlatform(float time)
        {
            platform.Update(time);
        }

        public void movePlatformRight()
        {
            platform.moveRight();
        }

        public void movePlatformLeft()
        {
            platform.moveLeft();
        }

        public Platform landsOnplatform(Ball ball)
        {
             if(platform.landsOnplatform(ball))
             {
                return platform;   
             }
             return null;
        }

        public Brick hitsGreenBrickFromAbove(Ball ball)
        {
            foreach (Brick brick in greenBricks)
            {
                if (brick.hitsABlockFromAbove(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsOrangeBrickFromAbove(Ball ball)
        {
            foreach (Brick brick in orangeBricks)
            {
                if (brick.hitsABlockFromAbove(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsPurpleBrickFromAbove(Ball ball)
        {
            foreach (Brick brick in purpleBricks)
            {
                if (brick.hitsABlockFromAbove(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsRedBrickFromAbove(Ball ball)
        {
            foreach (Brick brick in redBricks)
            {
                if (brick.hitsABlockFromAbove(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsYellowBrickFromAbove(Ball ball)
        {
            foreach (Brick brick in yellowBricks)
            {
                if (brick.hitsABlockFromAbove(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsGreenBrick(Ball ball)
        {
            foreach (Brick brick in greenBricks)
            {
                if (brick.hitsABlock(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsOrangeBrick(Ball ball)
        {
            foreach (Brick brick in orangeBricks)
            {
                if (brick.hitsABlock(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsPurpleBrick(Ball ball)
        {
            foreach (Brick brick in purpleBricks)
            {
                if (brick.hitsABlock(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsRedBrick(Ball ball)
        {
            foreach (Brick brick in redBricks)
            {
                if (brick.hitsABlock(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsYellowBrick(Ball ball)
        {
            foreach (Brick brick in yellowBricks)
            {
                if (brick.hitsABlock(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsGreenBrickOnSide(Ball ball)
        {
            foreach (Brick brick in greenBricks)
            {
                if (brick.collisionSide(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsOrangeBrickOnSide(Ball ball)
        {
            foreach (Brick brick in orangeBricks)
            {
                if (brick.collisionSide(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsPurpleBrickOnSide(Ball ball)
        {
            foreach (Brick brick in purpleBricks)
            {
                if (brick.collisionSide(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsRedBrickOnSide(Ball ball)
        {
            foreach (Brick brick in redBricks)
            {
                if (brick.collisionSide(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public Brick hitsYellowBrickOnSide(Ball ball)
        {
            foreach (Brick brick in yellowBricks)
            {
                if (brick.collisionSide(ball))
                {
                    return brick;
                }
            }
            return null;
        }

        public bool allBlocksAreDead(Brick brick)
        {
            if (greenBricks.Count + orangeBricks.Count + purpleBricks.Count + redBricks.Count + yellowBricks.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
