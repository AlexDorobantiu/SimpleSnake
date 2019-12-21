using System;
using System.Threading;
using SimpleSnake.Logic;

namespace SimpleSnake
{

    class Program
    {
        const string programName = "Simple snake";
        const int screenSizeX = 80;
        const int screenSizeY = 40;

        static void initializeScreen()
        {
            Console.Title = programName;
            Console.CursorVisible = false;
            Console.SetWindowSize(screenSizeX, screenSizeY);
        }

        static void Main(string[] args)
        {
            initializeScreen();
            SnakeGame game = new SnakeGame();
            game.drawEverything();

            while (true)
            {   
                game.processInput();
                game.compute();
                game.drawUpdates();
                
                Thread.Sleep(50);
            }
        }
    }
}
