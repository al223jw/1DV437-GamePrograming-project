using Blockbreaker.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.View
{
    class PlatformView
    {
        private SpriteBatch spriteBatch;
        private Camera camera;
        private Platform platform;

        public PlatformView(SpriteBatch spriteBatch, Camera camera, ContentManager content, Platform platform)
        {
            this.spriteBatch = spriteBatch;
            this.camera = camera;
            this.platform = platform;
        }
    }
}
