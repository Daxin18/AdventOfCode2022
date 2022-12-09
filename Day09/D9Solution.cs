using System;

namespace Day09
{
    class D9Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            Rope rope = new Rope();

            foreach(string line in lines)
            {
                string[] split = line.Split(' ');

                for(int i = 0; i < Int32.Parse(split[1]); i++)
                {
                    rope.MoveHead(Char.Parse(split[0]));
                }
            }

            Console.WriteLine(rope.CountVisited());
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            RopeOfSize rope = new RopeOfSize(9);

            foreach (string line in lines)
            {
                string[] split = line.Split(' ');

                for (int i = 0; i < Int32.Parse(split[1]); i++)
                {
                    rope.MoveHead(Char.Parse(split[0]));
                }
            }

            Console.WriteLine(rope.CountVisitedByKnot(8));
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
    }
}
