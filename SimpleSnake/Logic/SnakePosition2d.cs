using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Logic
{
    struct SnakePosition2d
    {
        public int x;
        public int y;

        public SnakePosition2d(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public SnakePosition2d getNextPosition(SnakeDirection direction)
        {
            switch (direction)
            {
                case SnakeDirection.Up:
                    return new SnakePosition2d(x, y - 1);
                case SnakeDirection.Down:
                    return new SnakePosition2d(x, y + 1);
                case SnakeDirection.Left:
                    return new SnakePosition2d(x - 1, y);
                case SnakeDirection.Right:
                    return new SnakePosition2d(x + 1, y);
                default:
                    return this;
            }
        }
    }
}
