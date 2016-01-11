using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.View
{
    class MidMenuView
    {
        Camera camera;
        ContentManager Content;

        Vector2 restartButtonPos = new Vector2(8f, 7f);
        Vector2 nextButtonPos = new Vector2(8f, 4.5f);
        Vector2 victoryTextPos = new Vector2(8f, 2f);
        Vector2 size = new Vector2(4f, 2f);

        Texture2D nextLevelButton, restartButton, victoryText, mainMenu;
        Vector2 textureCenter, textCenter;
        Vector2 scale;

        public MidMenuView(ContentManager content, Camera _camera, Texture2D _nextlevel, Texture2D _restartLevel)
        {
            camera = _camera;
            Content = content;
            nextLevelButton = _nextlevel;
            restartButton = _restartLevel;
            victoryText = Content.Load<Texture2D>("wintext");
            mainMenu = Content.Load<Texture2D>("mainmenu");
            textureCenter = new Vector2(_nextlevel.Width / 2, _nextlevel.Height / 2);
            textCenter = new Vector2(victoryText.Width / 2, victoryText.Height / 2);
            scale = camera.Scale(size, _nextlevel.Width, _nextlevel.Height);
        }

        public Vector2 getNextButtonPos()
        {
            return nextButtonPos;
        }

        public Vector2 getRestartButtonPos()
        {
            return restartButtonPos;
        }

        public Vector2 getSize()
        {
            return size;
        }

        public void Draw(SpriteBatch spriteBatch, bool isPlayerDead, bool nextLevelExists)
        {
            var nextVisLoc = camera.convertToVisualCoords(nextButtonPos);
            var restartVisLoc = camera.convertToVisualCoords(restartButtonPos);

            spriteBatch.Draw(restartButton, restartVisLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);

            if (!isPlayerDead && nextLevelExists)
            {
                spriteBatch.Draw(nextLevelButton, nextVisLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            }
            else if (!isPlayerDead && !nextLevelExists)
            {
                spriteBatch.Draw(victoryText, camera.convertToVisualCoords(victoryTextPos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
                spriteBatch.Draw(mainMenu, nextVisLoc, null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            }
        }
    }
}
