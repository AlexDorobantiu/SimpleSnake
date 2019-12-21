using System;
using System.Collections.Generic;

namespace SimpleSnake.Logic
{
    class SnakeGame
    {
        private const char fillChar = '█';
        private const char emptyChar = ' ';
        private const char rewardChar = '$';

        Snake snake;
        SnakeMap map;
        SnakeReward reward;

        int score;
        int gameTime;

        Random random = new Random(123); // fixed seed

        public SnakeGame()
        {
            resetGame();
        }

        private void resetGame()
        {
            SnakePosition2d snakeStartPosition = new SnakePosition2d(40, 20);
            SnakeDirection snakeStartDirection = SnakeDirection.Right;
            snake = new Snake(snakeStartPosition, snakeStartDirection);

            ICollection<SnakePosition2d> walls = new List<SnakePosition2d>();
            for (int x = 0; x < Console.BufferWidth; x++)
            {
                walls.Add(new SnakePosition2d(x, 1));
                walls.Add(new SnakePosition2d(x, Console.BufferHeight - 2));
            }
            for (int y = 2; y < Console.BufferHeight - 2; y++)
            {
                walls.Add(new SnakePosition2d(0, y));
                walls.Add(new SnakePosition2d(Console.BufferWidth - 1, y));
            }
            map = new SnakeMap(walls);
            placeReward();

            score = 0;
            gameTime = 0;
        }

        public void drawEverything()
        {
            SnakeDrawUtils.clearScreen();
            drawScoreAndTime();
            drawMap();
            drawFullSnake();
            drawReward();
        }

        public void drawUpdates()
        {
            drawSnakeTile(snake.getHeadPosition());
            while (snake.getDeleteQueue().Count > 0)
            {
                SnakePosition2d position = snake.getDeleteQueue().Dequeue();
                SnakeDrawUtils.drawChar(emptyChar, position.x, position.y);
            }
            drawReward();
            drawScoreAndTime();
        }

        public void processInput()
        {
            SnakeDirection newDirection = snake.getDirection();

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        newDirection = SnakeDirection.Up;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        newDirection = SnakeDirection.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        newDirection = SnakeDirection.Left;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        newDirection = SnakeDirection.Right;
                        break;
                    case ConsoleKey.Spacebar:
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(1);
                        break;
                }
            }

            switch (newDirection)
            {
                case SnakeDirection.Up:
                    if (!SnakeDirection.Down.Equals(snake.getDirection()))
                    {
                        snake.setDirection(SnakeDirection.Up);
                    }
                    break;
                case SnakeDirection.Down:
                    if (!SnakeDirection.Up.Equals(snake.getDirection()))
                    {
                        snake.setDirection(SnakeDirection.Down);
                    }
                    break;
                case SnakeDirection.Left:
                    if (!SnakeDirection.Right.Equals(snake.getDirection()))
                    {
                        snake.setDirection(SnakeDirection.Left);
                    }
                    break;
                case SnakeDirection.Right:
                    if (!SnakeDirection.Left.Equals(snake.getDirection()))
                    {
                        snake.setDirection(SnakeDirection.Right);
                    }
                    break;
            }
        }

        public void compute()
        {
            gameTime++;

            SnakePosition2d snakeHeadPosition = snake.getHeadPosition();
            SnakePosition2d nextHeadPosition = snakeHeadPosition.getNextPosition(snake.getDirection());

            if (snake.getBody().Contains(nextHeadPosition) || map.getWalls().Contains(nextHeadPosition))
            {
                string message = "Dead!";
                SnakeDrawUtils.writeText(message, Console.BufferWidth / 2 - message.Length / 2, 0, ConsoleColor.Red);
                Console.ReadKey();
                resetGame();
                drawEverything();
            }

            if (nextHeadPosition.Equals(reward.getPosition()))
            {
                score += reward.getValue();
                snake.increaseLength(2);
                reward = null;
            }

            snake.advance();

            if (reward == null)
            {
                placeReward();                
            }
        }

        private void placeReward()
        {
            while (true)
            {
                SnakePosition2d position = new SnakePosition2d(random.Next(Console.BufferWidth - 2) + 1, random.Next(Console.BufferHeight - 3) + 1);
                if (!snake.getBody().Contains(position) && !map.getWalls().Contains(position))
                {
                    reward = new SnakeReward(position, 1);
                    break;
                }
            }
        }

        private void drawReward()
        {
            SnakePosition2d position = reward.getPosition();
            SnakeDrawUtils.drawChar(rewardChar, position.x, position.y, ConsoleColor.Yellow);
        }

        private void drawMap()
        {
            foreach (SnakePosition2d position in map.getWalls())
            {
                SnakeDrawUtils.drawChar(fillChar, position.x, position.y, ConsoleColor.Blue);
            }
        }

        private void drawFullSnake()
        {
            foreach (SnakePosition2d position in snake.getBody())
            {
                drawSnakeTile(position);
            }
        }

        private void drawSnakeTile(SnakePosition2d position)
        {
            SnakeDrawUtils.drawChar(fillChar, position.x, position.y, ConsoleColor.DarkRed);
        }

        private void drawScoreAndTime()
        {
            SnakeDrawUtils.writeText("Score: " + score, 0, 0);
            SnakeDrawUtils.writeText("Time: " + gameTime, 0, Console.BufferHeight - 1);
        }

    }
}
