using System;
using System.Collections.Generic;
using System.IO;

namespace Day01
{
    class Solution
    {
        static void Main(string[] args)
        {
            //SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            //have to go one level higher because it somehow is a .NET console app and everything goes into \bin\Debug\net5.0
            //I may have chosen wrong project file
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

        static void SolvePuzzle2()
        {
            int ElvesToFind = 3;

            string[] lines = System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\..\") + @"\input.txt");
            List<int> elves = CaloriesOfElves(lines);

            elves = GetNHighest(ElvesToFind, elves);

            int sum = 0;
            foreach (int elf in elves)
            {
                sum += elf;
            }

            Console.WriteLine(sum);
        }
        
        private static List<int> GetNHighest(int n, List<int> list)
        {
            List<int> result = new List<int>();   

            list.Sort();
            list.Reverse();

            for (int i = 0; i < n; i++)
            {
                result.Add(list[i]);
            }

            return result;
        }

        private static List<int> CaloriesOfElves(string[] lines)
        {
            List<int> elves = new List<int>();
            int tmp = 0;
            int x;

            foreach (string line in lines)
            {
                if (int.TryParse(line, out x))
                {
                    tmp += x;
                }
                else
                {
                    elves.Add(tmp);
                    tmp = 0;
                }
            }

            return elves;
        }
    }
}
