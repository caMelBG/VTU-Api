using ImageAPI.Enums;
using ImageAPI.Resizer.Strategies;
using System;
using System.Threading;

namespace ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Start();

                    ConsoleProvider.ChangeConsoleColors(Types.Success);
                    Console.WriteLine("Success.");
                }
                catch (Exception ex)
                {
                    ConsoleProvider.ChangeConsoleColors(Types.Error);
                    Console.WriteLine("Error: {0}", ex.Message);
                }

                ConsoleProvider.ChangeConsoleColors(Types.Default);
                Console.Write("Press any [Enter] to reload.");
                var line = Console.ReadLine();
            }
        }

        static void Start()
        {
            Console.Clear();
            PrintLogo();
            ChooseFunction();

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                ConvertChoosed();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                ResizeChoosed();
            }
        }

        static void ResizeChoosed()
        {
            ConsoleProvider.DeleteRows(3, 5);
            Console.SetCursorPosition(0, 3);

            Console.Write("Choose a image function: ");

            ConsoleProvider.ChangeConsoleColors(Types.ChooseItem);

            Console.WriteLine("Resize");

            ConsoleProvider.ChangeConsoleColors(Types.Default);

            Console.Write("sourceFile:              ");
            string sourceFile = Console.ReadLine();

            Console.Write("destinationFile:         ");
            string destiinationFile = Console.ReadLine();

            Console.WriteLine("Choose resize type:");
            Console.WriteLine("Press [1] Skew [2] KeepAspect [3] Crop");

            var resizeType = ResizeType.None;
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    resizeType = ResizeType.Skew;
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    resizeType = ResizeType.KeepAspect;
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    resizeType = ResizeType.Crop;
                    break;
                }
                else
                {
                    ConsoleProvider.DeleteRows(9, 9);
                }
            }

            ConsoleProvider.DeleteRows(7, 9);
            Console.SetCursorPosition(0, 6);

            Console.Write("Choose resize type:      ");

            ConsoleProvider.ChangeConsoleColors(Types.ChooseItem);

            Console.WriteLine(resizeType);

            ConsoleProvider.ChangeConsoleColors(Types.Default);

            Console.Write("Width:   ");
            var width = Console.ReadLine();

            Console.Write("Height:  ");
            var height = Console.ReadLine();

            Console.Write("StartX:  ");
            var x = Console.ReadLine();

            Console.Write("StartY:  ");
            var y = Console.ReadLine();

            Resize(sourceFile, destiinationFile, resizeType, int.Parse(width), int.Parse(height), int.Parse(x), int.Parse(y));
        }

        static void ShowLoading(int row)
        {
            char symbole = '-';
            while (true)
            {
                Console.SetCursorPosition(0, row);
                Console.WriteLine(symbole);
                switch (symbole)
                {
                    case '-': symbole = '\\'; break;
                    case '\\': symbole = '|'; break;
                    case '|': symbole = '/'; break;
                    case '/': symbole = '-'; break;
                }
                Thread.Sleep(100);
            }
        }

        static void Convert(string src, string dest, ImageType type)
        {
            var con = new ImageAPI.Converter.Converter();

            con.Convert(src, dest, type);

        }

        static void Resize(string src, string dest, ResizeType type, int width, int height, int x, int y)
        {
            var resizer = new ImageAPI.Resizer.Resizer(new ResizeStrategyCreator());

            resizer.Resize(src, dest, type, width, height, x, y);

            Console.WriteLine("Done");

            ShowLoading(8);
        }

        static void ConvertChoosed()
        {
            ConsoleProvider.DeleteRows(3, 5);
            Console.SetCursorPosition(0, 3);

            Console.Write("Choose a image function: ");

            ConsoleProvider.ChangeConsoleColors(Types.ChooseItem);

            Console.WriteLine("Convert");

            ConsoleProvider.ChangeConsoleColors(Types.Default);

            Console.Write("sourceFile:              ");
            string sourceFile = Console.ReadLine();

            Console.Write("destinationFile:         ");
            string destiinationFile = Console.ReadLine();

            Console.WriteLine("Choose image format:");
            Console.WriteLine("Press [1] Gif [2] Png [3] Jpg");

            var imageFormat = ImageType.None;
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    imageFormat = ImageType.Gif;
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    imageFormat = ImageType.Png;
                    break;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    imageFormat = ImageType.Jpg;
                    break;
                }
                else
                {
                    ConsoleProvider.DeleteRows(9, 9);
                }
            }

            ConsoleProvider.DeleteRows(7, 9);
            Console.SetCursorPosition(0, 6);

            Console.Write("Choose image format:     ");
            ConsoleProvider.ChangeConsoleColors(Types.ChooseItem);
            Console.WriteLine(imageFormat);
            ConsoleProvider.ChangeConsoleColors(Types.Default);

            Convert(sourceFile, destiinationFile, imageFormat);
        }

        static void ChooseFunction()
        {
            Console.WriteLine("Choose a image function:");
            Console.WriteLine("Press [1] to Convert or [2] to Resize a image.");
        }

        static void PrintLogo()
        {
            ConsoleProvider.ChangeConsoleColors(Types.Logo);
            for (int i = 0; i < 18; i++)
            {
                Console.Write("=");
            }

            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("=");
            }

            Console.Write("ImageAPI");

            for (int i = 0; i < 5; i++)
            {
                Console.Write("=");
            }

            Console.WriteLine();
            for (int i = 0; i < 18; i++)
            {
                Console.Write("=");
            }

            Console.WriteLine();
            ConsoleProvider.ChangeConsoleColors(Types.Default);
        }
    }
}
