using Blockbreaker.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Controller
{
    class MidMenuController
    {
        MidMenuView midMenuView;
        Camera camera;
        ContentManager Content;
        Texture2D nextButton, restartButton;
        SpriteBatch spriteBatch;

        bool _pressedNext = false;
        bool _pressedRestart = false;
        bool _pressedMainMenu = false;

        public MidMenuController(ContentManager content, GraphicsDeviceManager device, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            nextButton = Content.Load<Texture2D>("nextbutton");
            restartButton = Content.Load<Texture2D>("restartbutton");
            camera = _camera;

            midMenuView = new MidMenuView(Content, camera, nextButton, restartButton);
        }

        public void Update(Vector2 mousePos, bool playerLost, bool nextLevelExists)
        {
            var buttonSize = midMenuView.getSize();
            var nextButtonPos = midMenuView.getNextButtonPos();
            var mainMenuButtonPos = midMenuView.getNextButtonPos();
            var restartButtonPos = midMenuView.getRestartButtonPos();

            if (camera.convertToLogicalCoords(mousePos).X < nextButtonPos.X + buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > nextButtonPos.X - buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < nextButtonPos.Y + buttonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > nextButtonPos.Y - buttonSize.Y / 2 &&
                !playerLost && nextLevelExists)
            {
                _pressedNext = true;
            }

       else if (camera.convertToLogicalCoords(mousePos).X < restartButtonPos.X + buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > restartButtonPos.X - buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < restartButtonPos.Y + buttonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > restartButtonPos.Y - buttonSize.Y / 2)
            {
                _pressedRestart = true;
            }

       else if (camera.convertToLogicalCoords(mousePos).X < nextButtonPos.X + buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > nextButtonPos.X - buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < nextButtonPos.Y + buttonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > nextButtonPos.Y - buttonSize.Y / 2 &&
                !playerLost && !nextLevelExists)
            {
                _pressedMainMenu = true;
            }
        }

        public void Draw(bool isPlayerDead, bool nextLevelExists)
        {
            midMenuView.Draw(spriteBatch, isPlayerDead, nextLevelExists);
        }

        public bool pressedNext
        {
            get
            {
                return _pressedNext;
            }
            set
            {
                _pressedNext = value;
            }
        }

        public bool pressedRestart
        {
            get
            {
                return _pressedRestart;
            }
            set
            {
                _pressedRestart = value;
            }
        }

        public bool pressedMainMenu
        {
            get
            {
                return _pressedMainMenu;
            }
            set
            {
                _pressedMainMenu = value;
            }
        }
    }
}
