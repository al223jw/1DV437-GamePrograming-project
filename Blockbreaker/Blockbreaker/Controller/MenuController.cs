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
    class MenuController
    {
        MainMenuView mainMenuView;
        Camera camera;
        ContentManager Content;
        Texture2D continueButton, newGameButton, title;
        SpriteBatch spriteBatch;

        bool _pressedContinue = false;
        bool _pressedNewGame = false;

        public MenuController(ContentManager content, GraphicsDeviceManager device, SpriteBatch _spriteBatch, Camera _camera)
        {
            Content = content;
            spriteBatch = _spriteBatch;
            continueButton = Content.Load<Texture2D>("continue");
            newGameButton = Content.Load<Texture2D>("newgame");
            title = Content.Load<Texture2D>("title");

            camera = _camera;
            mainMenuView = new MainMenuView(camera, continueButton, newGameButton, title);
        }

        public void Update(Vector2 mousePos)
        {
            var buttonSize = mainMenuView.getSize();
            var continueButtonPos = mainMenuView.getContiniueBottonPos();
            var newGameButtonPos = mainMenuView.getNewGameButtonPos();

            if (camera.convertToLogicalCoords(mousePos).X < continueButtonPos.X + buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > continueButtonPos.X - buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < continueButtonPos.Y + buttonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > continueButtonPos.Y - buttonSize.Y / 2)
            {
                _pressedContinue = true;
            }

            if (camera.convertToLogicalCoords(mousePos).X < newGameButtonPos.X + buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).X > newGameButtonPos.X - buttonSize.X / 2 &&
                camera.convertToLogicalCoords(mousePos).Y < newGameButtonPos.Y + buttonSize.Y / 2 &&
                camera.convertToLogicalCoords(mousePos).Y > newGameButtonPos.Y - buttonSize.Y / 2)
            {
                _pressedNewGame = true;
            }
        }

        public void Draw()
        {
            mainMenuView.Draw(spriteBatch);
        }

        public bool pressedNewGame
        {
            get
            {
                return _pressedNewGame;
            }
            set
            {
                _pressedNewGame = value;
            }
        }

        public bool pressedContinue
        {
            get
            {
                return _pressedContinue;
            }
            set
            {
                _pressedContinue = value;
            }
        }
    }
}
