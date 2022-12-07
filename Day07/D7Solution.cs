using System;

namespace Day07
{
    class D7Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            Filesystem fs = new Filesystem();

            InitiateFilesystem(ref fs, lines);

            ulong answer = fs.addDirectoriesSmallerThanSpecifiedSize(100000);

            Console.WriteLine(answer);
        }

        static void InitiateFilesystem(ref Filesystem fs, string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts;
                if (line.Contains("$ ls"))
                {
                    i++;
                    ulong size;
                    while ( i < lines.Length && !lines[i].Contains("$"))
                    {
                        line = lines[i];
                        parts = line.Split(' ');
                        if (ulong.TryParse(parts[0], out size))
                        {
                            fs.addFile(parts[1], size);
                        }
                        else
                        {
                            fs.addFile(parts[1]);
                        }
                        i++;
                    }
                    i--;
                }
                if (line.Contains("$ cd"))
                {
                    parts = line.Split(' ');
                    fs.cd(parts[2]);
                }
            }
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            Filesystem fs = new Filesystem();
            ulong answer = 0;
            ulong spaceToBeFreed;

            InitiateFilesystem(ref fs, lines);

            spaceToBeFreed = 30000000 - (fs.capacity - fs.getUsedSpace());

            Console.WriteLine(spaceToBeFreed);

            answer = fs.findSmallestDirectoryOfMinimalSize(spaceToBeFreed);

            Console.WriteLine(answer);
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
    }
}
