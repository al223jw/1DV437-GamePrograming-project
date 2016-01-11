using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.View
{
    class Audio
    {
        SoundEffect hitsBlock, hitsPlatform;

        public Audio(ContentManager Content)
        {
            hitsBlock = Content.Load<SoundEffect>("fire");
            hitsPlatform = Content.Load<SoundEffect>("bounce");
        }

        public void hitBlock()
        {
            hitsBlock.Play(0.03f, 0, 0);
        }

        public void hitPlatform()
        {
            hitsPlatform.Play(0.03f, 0, 0);
        }
    }
}
