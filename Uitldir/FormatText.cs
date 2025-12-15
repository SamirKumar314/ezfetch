using System;
using System.Collections.Generic;
using System.Text;

namespace ezfetch.Uitldir
{
    internal class FormatText
    {
        private static ConsoleColor labelcolour = ConsoleColor.Blue;
        public static void Displaytxt(string labels, string values)
        {
            Console.ForegroundColor = labelcolour;
            Console.Write($"{labels}");
            Console.ResetColor();
            Console.Write(values);
        }
    }
}
