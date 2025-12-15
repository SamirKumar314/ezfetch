using System;
using System.Collections.Generic;
using System.Text;

namespace ezfetch.Uitldir
{
    internal class Colourbar
    {
        public static void Getcoloursdark()
        {
            ConsoleColor[] colours = new ConsoleColor[]
            {
                ConsoleColor.Black,
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkYellow,
                ConsoleColor.Gray
            };
            foreach (var colour in colours)
            {
                Console.BackgroundColor = colour;
                Console.Write("   ");
                Console.ResetColor();

            }
            Console.WriteLine();
        }

        public static void Getcolourslight()
        {
            ConsoleColor[] colours = new ConsoleColor[]
            {
                ConsoleColor.DarkGray,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Cyan,
                ConsoleColor.Red,
                ConsoleColor.Magenta,
                ConsoleColor.Yellow,
                ConsoleColor.White
            };
            foreach (var colour in colours)
            {
                Console.BackgroundColor = colour;
                Console.Write("   ");
                Console.ResetColor();

            }
        }
    }
}
