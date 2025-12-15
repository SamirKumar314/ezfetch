using System;
using System.Collections.Generic;
using System.Text;

namespace ezfetch.Uitldir
{
    internal static class Displaymanager
    {
        private const int gap = 4;
        public static void Displaylayout(string[] Alogo, List<(string label, string value)> info)
        {
            int maxline = Math.Max(Alogo.Length, info.Count);

            for (int i = 0; i < maxline; i++)
            {
                //the left side(ASCII art)
                if (i < Alogo.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Alogo[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(new string(' ', Alogo[0].Length));
                }

                Console.Write(new string(' ', gap));  //gap between left and right side

                //right side(system info)
                if (i < info.Count)
                {
                    string labeltxt = info[i].label;
                    string valuetxt = info[i].value;
                    FormatText.Displaytxt(labeltxt + " ", valuetxt + "\n");
                }
                else
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            //color bar..
            Console.Write(new string(' ', Alogo[0].Length));
            Console.Write(new string(' ', gap));
            Colourbar.Getcoloursdark();
            Console.Write(new string(' ', Alogo[0].Length));
            Console.Write(new string(' ', gap));
            Colourbar.Getcolourslight();

            Console.WriteLine();
        }
    }
}
