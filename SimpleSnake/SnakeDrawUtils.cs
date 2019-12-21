using System;

namespace SimpleSnake
{
    class SnakeDrawUtils
    {
        private static void prepareWrite(int x, int y, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.SetCursorPosition(x, y);
        }

        public static void writeText(string text, int x, int y, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            prepareWrite(x, y, foregroundColor, backgroundColor);
            Console.Write(text);
        }

        public static void drawChar(char c, int x, int y, ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            prepareWrite(x, y, foregroundColor, backgroundColor);
            Console.Write(c);
        }

        public static void clearScreen()
        {
            Console.Clear();
        }
    }
}
