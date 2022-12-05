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

        //starting to feel like it's a common theme to not be able to use the majority of your previous methods in the second puzzle
        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            List<string> group = new List<string>();
            int groupSize = 3;
            int sum = 0;

            foreach (string line in lines)
            {
                group.Add(line);

                if (group.Count == groupSize)
                {
                    sum += GetItemPriority(FindCommonItemInGroupOfSizeN(group));
                    group = new List<string>();
                }
            }

            Console.WriteLine(sum);
        }

        static char FindCommonItemInGroupOfSizeN(List<string> group) //N - size of a list
        {
            char result = new char();

            Dictionary<char, int> seenItems = new Dictionary<char, int>();
            List<char> itemsInRucksack = new List<char>();

            foreach (string rucksack in group)
            {
                itemsInRucksack = new List<char>();

                foreach (char item in rucksack)
                {
                    if (!itemsInRucksack.Contains(item))
                    {
                        itemsInRucksack.Add(item);
                        if (seenItems.ContainsKey(item))
                        {
                            seenItems[item]++;
                            if (seenItems[item] == group.Count)
                                result = item;
                        }
                        else
                        {
                            seenItems.Add(item, 1);
                        }
                    }
                }
            }
            return result;
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
