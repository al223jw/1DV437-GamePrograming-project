using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.View
{
    class MainMenuView
    {
        Camera camera;
        Vector2 continiueButtonPos = new Vector2(8f, 7f);
        Vector2 newGameButtonPos = new Vector2(8f, 4.5f);
        Vector2 titlePos = new Vector2(8f, 2f);
        Vector2 size = new Vector2(4f, 2f);
        Vector2 titleSize = new Vector2(10f, 2f);

        Texture2D continiueBotton, newGameButton, title;
        Vector2 textureCenter, titleCenter;
        Vector2 scale;

        public MainMenuView(Camera _camera, Texture2D buttonTexture, Texture2D newButtonTexture, Texture2D _title)
        {
            camera = _camera;
            continiueBotton = buttonTexture;
            newGameButton = newButtonTexture;
            title = _title;

            textureCenter = new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2);
            titleCenter = new Vector2(title.Width / 2, title.Height / 2);
            scale = camera.Scale(size, buttonTexture.Width, buttonTexture.Height);
        }

        public Vector2 getContiniueBottonPos()
        {
            return continiueButtonPos;
        }

        public Vector2 getNewGameButtonPos()
        {
            return newGameButtonPos;
        }

        public Vector2 getSize()
        {
            return size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(title, camera.convertToVisualCoords(titlePos), null, Color.White, 0, titleCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(continiueBotton, camera.convertToVisualCoords(continiueButtonPos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(newGameButton, camera.convertToVisualCoords(newGameButtonPos), null, Color.White, 0, textureCenter, scale, SpriteEffects.None, 1f);
        }

    }
}
