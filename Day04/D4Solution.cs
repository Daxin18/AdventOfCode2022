using System;
using System.Collections.Generic;

namespace Day04
{
    class d4Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            string[] ranges; //stores both ranges from the current pair (aka the one in foreach)
            char[] separators = ",-".ToCharArray();
            int sum = 0;

            foreach (string line in lines)
            {
                ranges = line.Split(separators);

                if ((Int32.Parse(ranges[0]) >= Int32.Parse(ranges[2]) && Int32.Parse(ranges[1]) <= Int32.Parse(ranges[3]))
                    || (Int32.Parse(ranges[0]) <= Int32.Parse(ranges[2]) && Int32.Parse(ranges[1]) >= Int32.Parse(ranges[3])))
                {
                    sum++;
                }
            }

            Console.WriteLine(sum);
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            string[] ranges; //stores both ranges from the current pair (aka the one in foreach)
            char[] separators = ",-".ToCharArray();
            int sum = 0;

            foreach (string line in lines)
            {
                ranges = line.Split(separators);

                if ((Int32.Parse(ranges[0]) <= Int32.Parse(ranges[3]) && (Int32.Parse(ranges[1]) >= Int32.Parse(ranges[3])))
                    || (Int32.Parse(ranges[2]) <= Int32.Parse(ranges[1]) && (Int32.Parse(ranges[3]) >= Int32.Parse(ranges[1]))))
                {
                    sum++;
                }
            }

            Console.WriteLine(sum);
        }



        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
    }
}

