using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Logic
{
    class Snake
    {
        private Queue<SnakePosition2d> body;

        private SnakeDirection direction;

        private SnakePosition2d headPosition;

        private int maximumLength;

        private Queue<SnakePosition2d> deleteQueue;

        public Snake(SnakePosition2d startPosition, SnakeDirection startDirection, int startLength = 3)
        {
            direction = startDirection;
            body = new Queue<SnakePosition2d>();
            body.Enqueue(startPosition);
            headPosition = startPosition;
            maximumLength = startLength;

            deleteQueue = new Queue<SnakePosition2d>();
        }

        public Queue<SnakePosition2d> getBody()
        {
            return body;
        }

        public SnakePosition2d getHeadPosition()
        {
            return headPosition;
        }

        public SnakeDirection getDirection()
        {
            return direction;
        }

        public void setDirection(SnakeDirection direction)
        {
            this.direction = direction;
        }

        public void advance()
        {
            headPosition = headPosition.getNextPosition(direction);
            body.Enqueue(headPosition);

            while (body.Count > maximumLength)
            {
                deleteQueue.Enqueue(body.Dequeue());
            }
        }

        public void increaseLength(int amount)
        {
            maximumLength += amount;
        }

        public Queue<SnakePosition2d> getDeleteQueue()
        {
            return deleteQueue;
        }
    }
}
