using System;

namespace ConsoleClient
{
    public enum Types
    {
        Default,
        Error,
        Logo,
        ChooseItem,
        Success,
    }

    public static class ConsoleProvider
    {
        private static ConsoleColor _errorBackbroundColor = ConsoleColor.DarkRed;
        private static ConsoleColor _errorForegroundColor = ConsoleColor.Black;

        private static ConsoleColor _logoBackgroundColor = ConsoleColor.Blue;
        private static ConsoleColor _logoForegroundColor = ConsoleColor.Cyan;

        private static ConsoleColor _chooseBackgroundColor = ConsoleColor.Gray;
        private static ConsoleColor _chooseForegroundColor = ConsoleColor.Black;

        private static ConsoleColor _successBackgroundColor = ConsoleColor.Green;
        private static ConsoleColor _successForegroundColor = ConsoleColor.Black;

        private static ConsoleColor _defaultConsoleBackgroundColor = Console.BackgroundColor;
        private static ConsoleColor _defaultConsoleForegroundColor = Console.ForegroundColor;

        public static void DeleteRows(int start, int end)
        {
            for(int index = start; index <= end; index++)
            {
                Console.SetCursorPosition(0, index);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }

                Console.SetCursorPosition(0, index);
            }
        }

        public static void ChangeConsoleColors(Types type)
        {
            switch (type)
            {
                case Types.Default:
                    Console.BackgroundColor = _defaultConsoleBackgroundColor;
                    Console.ForegroundColor = _defaultConsoleForegroundColor;
                    break;
                case Types.Error:
                    Console.BackgroundColor = _errorBackbroundColor;
                    Console.ForegroundColor = _errorForegroundColor;
                    break;
                case Types.Logo:
                    Console.BackgroundColor = _logoBackgroundColor;
                    Console.ForegroundColor = _logoForegroundColor;
                    break;
                case Types.ChooseItem:
                    Console.BackgroundColor = _chooseBackgroundColor;
                    Console.ForegroundColor = _chooseForegroundColor;
                    break;
                case Types.Success:
                    Console.BackgroundColor = _successBackgroundColor;
                    Console.ForegroundColor = _successForegroundColor;
                    break;
                default:
                    Console.BackgroundColor = _defaultConsoleBackgroundColor;
                    Console.ForegroundColor = _defaultConsoleForegroundColor;
                    break;
            }
        }
    }
}
