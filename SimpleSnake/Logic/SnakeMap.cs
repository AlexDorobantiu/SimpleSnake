using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Logic
{
    class SnakeMap
    {
        private HashSet<SnakePosition2d> walls;

        public SnakeMap(ICollection<SnakePosition2d> walls)
        {
            this.walls = new HashSet<SnakePosition2d>(walls);
        }

        public HashSet<SnakePosition2d> getWalls()
        {
            return walls;
        }
    }
}
