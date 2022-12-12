using System;
using System.Collections.Generic;

namespace Day11
{
    class D11Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            List<Monkey> monkeys = new List<Monkey>();
            List<int> itemsInspected = new List<int>();
            int roundCount = 20;

            SetupMonkeys(lines, ref monkeys, true);

            foreach(Monkey monkey in monkeys)
            {
                itemsInspected.Add(0);
                //Console.WriteLine(monkey.ToString());
            }

            for(int i = 0; i < roundCount; i++)
            {
                for(int j = 0; j < monkeys.Count; j++)
                {
                    Monkey monkey = monkeys[j];
                    itemsInspected[j] += monkey.items.Count;
                    int itemNumber = monkey.items.Count;
                    for (int k = 0; k < itemNumber; k++)
                    {
                        (int, int) throwTo = monkey.InspectAndThrowItem();
                        monkeys[throwTo.Item2].AddItem(throwTo.Item1);
                    }
                }
            }

            itemsInspected.Sort();

            long result = itemsInspected[itemsInspected.Count - 1] * itemsInspected[itemsInspected.Count - 2];

            Console.WriteLine(result);
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            List<Monkey> monkeys = new List<Monkey>();
            List<long> itemsInspected = new List<long>();
            int roundCount = 10000;

            SetupMonkeys(lines, ref monkeys, false);

            foreach (Monkey monkey in monkeys)
            {
                itemsInspected.Add(0);
                //Console.WriteLine(monkey.ToString());
            }

            for (int i = 0; i < roundCount; i++)
            {
                for (int j = 0; j < monkeys.Count; j++)
                {
                    Monkey monkey = monkeys[j];
                    itemsInspected[j] += monkey.items.Count;
                    int itemNumber = monkey.items.Count;
                    for (int k = 0; k < itemNumber; k++)
                    {
                        (int, int) throwTo = monkey.InspectAndThrowItem();
                        monkeys[throwTo.Item2].AddItem(throwTo.Item1);
                    }
                }
            }

            itemsInspected.Sort();

            long result = itemsInspected[itemsInspected.Count - 1] * itemsInspected[itemsInspected.Count - 2];

            Console.WriteLine(result);
        }

        private static void SetupMonkeys(string[] lines, ref List<Monkey> monkeys, bool divideByThree)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                int fullMonkey = 1; //first line is just monkey number (which we automatically get via list index placement
                i++; //we omit the line with monkey number
                string[] split;
                List<int> monkeyItems = new List<int>();
                Func<int, int, int> monkeyOperation = Addition;
                int? monkeyOperationNumber = 0;
                int monkeyTest = 0;
                int monkeyTrue = 0;
                int monkeyFalse = 0;
                while (fullMonkey < 6) //monkey information consists of 6 lines
                {
                    switch (fullMonkey)
                    {
                        case 1: //monkey items
                            split = lines[i].Split(' ', ',');
                            int tmp;
                            foreach (string s in split)
                            {
                                if (Int32.TryParse(s, out tmp))
                                {
                                    monkeyItems.Add(tmp);
                                }
                            }
                            break;
                        case 2: //monkey operation
                            split = lines[i].Split(' ');
                            for (int j = 0; j < split.Length; j++)
                            {
                                if (split[j] == "*")
                                {
                                    monkeyOperation = Multiplication;
                                    if (!split[j + 1].Equals("old"))
                                    {
                                        monkeyOperationNumber = Int32.Parse(split[++j]);
                                    }
                                    else
                                    {
                                        monkeyOperationNumber = null;
                                    }
                                    break;
                                }
                                else if (split[j] == "+")
                                {
                                    monkeyOperation = Addition;
                                    if (!split[j + 1].Equals("old"))
                                    {
                                        monkeyOperationNumber = Int32.Parse(split[++j]);
                                    }
                                    else
                                    {
                                        monkeyOperationNumber = null;
                                    }
                                    break;
                                }
                            }
                            break;
                        case 3: //monkey test
                            split = lines[i].Split(' ');
                            monkeyTest = Int32.Parse(split[split.Length - 1]);
                            break;
                        case 4: //monkey test is true
                            split = lines[i].Split(' ');
                            monkeyTrue = Int32.Parse(split[split.Length - 1]);
                            break;
                        case 5: //monkey test is false
                            split = lines[i].Split(' ');
                            monkeyFalse = Int32.Parse(split[split.Length - 1]);
                            break;
                    }
                    fullMonkey++;
                    i++; //we go to the next line
                }

                monkeys.Add(new Monkey(monkeyItems, monkeyOperation, monkeyOperationNumber, monkeyTest, monkeyTrue, monkeyFalse, divideByThree));
            }
        }

        private static int Multiplication(int old, int number) => old * number;
        private static int Addition(int old, int number) => old + number;

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");

        }
    }
}
