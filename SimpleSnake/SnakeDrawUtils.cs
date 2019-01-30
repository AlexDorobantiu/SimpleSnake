using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake
{
    class SnakeDrawUtils
    {
        public static void writeText(string text, int x, int y, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void drawChar(char c, int x, int y, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            if (x < 0 || y < 0 || x >= Console.BufferWidth || y >= Console.BufferHeight)
            {
                return;
            }
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public static void clearScreen()
        {
            Console.Clear();
        }
    }
}
