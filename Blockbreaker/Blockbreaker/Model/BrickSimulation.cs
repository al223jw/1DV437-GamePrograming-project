using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockbreaker.Model
{
    class BrickSimulation
    {
        private List<Brick> bricks;

        public List<Brick> getBricks()
        {
            return this.bricks;    
        }

        public BrickSimulation()
        {
            bricks = new List<Brick>(10);
            for (int i = 0; i < bricks.Count; i++)
            {
                bricks.Add(new Brick());
            }
        }

    }
}
