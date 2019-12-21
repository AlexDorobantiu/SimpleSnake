using System.Collections.Generic;

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
