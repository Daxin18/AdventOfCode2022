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
            List<nuint> itemsInspected = new List<nuint>();
            int roundCount = 20;

            SetupMonkeys(lines, ref monkeys, true);

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
                    itemsInspected[j] += (nuint)monkey.items.Count;
                    int itemNumber = monkey.items.Count;
                    for (int k = 0; k < itemNumber; k++)
                    {
                        (nuint, int) throwTo = monkey.InspectAndThrowItem();
                        monkeys[throwTo.Item2].AddItem(throwTo.Item1);
                    }
                }
            }

            itemsInspected.Sort();

            nuint result = itemsInspected[itemsInspected.Count - 1] * itemsInspected[itemsInspected.Count - 2];

            foreach (nuint item in itemsInspected)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(result);
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            List<Monkey> monkeys = new List<Monkey>();
            List<nuint> itemsInspected = new List<nuint>();
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
                    itemsInspected[j] += (nuint)monkey.items.Count;
                    int itemNumber = monkey.items.Count;
                    for (int k = 0; k < itemNumber; k++)
                    {
                        (nuint, int) throwTo = monkey.InspectAndThrowItem();
                        monkeys[throwTo.Item2].AddItem(throwTo.Item1);
                    }
                }
            }

            itemsInspected.Sort();

            nuint result = itemsInspected[itemsInspected.Count - 1] * itemsInspected[itemsInspected.Count - 2];

            foreach (nuint item in itemsInspected)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(result);
        }

        private static void SetupMonkeys(string[] lines, ref List<Monkey> monkeys, bool divideByThree)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                int fullMonkey = 1; //first line is just monkey number (which we automatically get via list index placement
                i++; //we omit the line with monkey number
                string[] split;
                List<nuint> monkeyItems = new List<nuint>();
                Func<nuint, nuint, nuint> monkeyOperation = Addition;
                nuint? monkeyOperationNumber = 0;
                nuint monkeyTest = 0;
                int monkeyTrue = 0;
                int monkeyFalse = 0;
                while (fullMonkey < 6) //monkey information consists of 6 lines
                {
                    switch (fullMonkey)
                    {
                        case 1: //monkey items
                            split = lines[i].Split(' ', ',');
                            nuint tmp;
                            foreach (string s in split)
                            {
                                if (nuint.TryParse(s, out tmp))
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
                                        monkeyOperationNumber = nuint.Parse(split[++j]);
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
                                        monkeyOperationNumber = nuint.Parse(split[++j]);
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
                            monkeyTest = nuint.Parse(split[split.Length - 1]);
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

        private static nuint Multiplication(nuint old, nuint number) => old * number;
        private static nuint Addition(nuint old, nuint number) => old + number;
        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("test.txt");
        }
    }
}
