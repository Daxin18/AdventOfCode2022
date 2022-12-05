using System;
using System.IO;

namespace Day01
{
    class Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
        }

        static void SolvePuzzle1()
        {
            //have to go one level higher because it somehow is a .NET console app and everything goes into \bin\Debug\net5.0
            string[] lines = System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\..\") + @"\input.txt");
            int maxCaloriesCount = 0;
            int tmp = 0;
            int x;

            foreach (string line in lines)
            {
                if (int.TryParse(line, out x))
                {
                    tmp += x;
                    if (tmp > maxCaloriesCount)
                        maxCaloriesCount = tmp;
                }
                else
                {
                    tmp = 0;
                }
            }

            Console.WriteLine(maxCaloriesCount);
        }
    }
}
