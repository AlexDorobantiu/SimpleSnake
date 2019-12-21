namespace SimpleSnake.Logic
{
    class SnakeReward
    {
        SnakePosition2d position;
        int value;

        public SnakeReward(SnakePosition2d position, int value)
        {
            this.position = position;
            this.value = value;
        }

        public SnakePosition2d getPosition()
        {
            return position;
        }

        public int getValue()
        {
            return value;
        }
    }
}
