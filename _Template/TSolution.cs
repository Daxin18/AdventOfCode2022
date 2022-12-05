using System;

namespace _Template
{
    class TSolution
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
            return System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\..\") + @"\input.txt");
        }
    }
}
