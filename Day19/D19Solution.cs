using System;

namespace Day19
{
    class D19Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
            /*
            remember to add the command
            
               copy "$(ProjectDir)\input.txt" "$(TargetDir)\input.txt"

            to post build events in project properties
            */
        }
    }
}
