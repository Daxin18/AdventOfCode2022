using System;
using System.Collections.Generic;

namespace Day03
{
    class Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            int sum = 0;

            foreach (string line in lines)
            {
                sum += GetItemPriority( FindCommonItem( SplitIntoTwoCompartments(line)));
            }

            Console.WriteLine(sum);
        }

        static List<string> SplitIntoTwoCompartments(string rucksack)
        {
            List<string> result = new List<string>();

            result.Add(rucksack.Substring(rucksack.Length / 2));
            result.Add(rucksack.Remove(rucksack.Length / 2));

            return result;
        }

        static char FindCommonItem(List<string> compartments)
        {
            char result = new char();

            foreach (char item1 in compartments[0])
                foreach (char item2 in compartments[1])
                    if (item1.Equals(item2))
                        result = item1;

            return result;
        }

        
        static void SolvePuzzle2()
        {

        }


        private static int GetItemPriority(char item)
        {
            int priority;

            if (Char.IsLower(item))
            {
                priority = item - 'a' + 1;
            }
            else
            {
                priority = item - 'A' + 27;
            }

            return priority;
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\..\") + @"\input.txt");
        }
    }
}
