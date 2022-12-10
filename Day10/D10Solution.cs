using System;

namespace Day10
{
    class D10Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();

            int cycle = 0;
            int register = 1;
            int sum = 0;

            foreach(string line in lines)
            {
                string[] split = line.Split(' ');

                cycle++; //noop takes 1 cycle, and addx increases the value after 2 cycles, either way we need one cycle to pass without changing any value
                
                if ((cycle + 20) % 40 == 0 && cycle <= 220)
                {
                    sum += cycle * register;
                }

                if(split[0].Equals("addx"))
                {
                    cycle++;
                    if ((cycle + 20) % 40 == 0 && cycle <= 220)
                    {
                        sum += cycle * register;
                    }
                    register += Int32.Parse(split[1]);
                }
            }
            Console.WriteLine(sum);
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
    }
}
