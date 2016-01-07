using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class PlatformSimulation
    {
        Platform platform = new Platform();

        public void Update(float timeElapsed)
        {
            platform.UpdateLocation(timeElapsed);
        }
    }
}
