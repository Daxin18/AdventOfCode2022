using System;

namespace Day08
{
    class D8Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();

            int[,] grid = SetupGrid(lines);

            int[,] visibilityRequirements = GetVisibilityRequirements(grid);

            int result = CountVisibleTrees(grid, visibilityRequirements);

            Console.WriteLine(result);
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();

            int[,] grid = SetupGrid(lines);

            int maxScenicScore = 0;

            //it's like using brute-force to solve it, but I'm low on time
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int tree = grid[i, j];

                    int[] viewingDistance = new int[4];

                    if (!(i == 0 || j == 0 || i == grid.GetLength(0) - 1 || j == grid.GetLength(1) - 1))
                    {
                        //bottom
                        for (int n = 1; n < grid.GetLength(0) - i; n++)
                        {
                            viewingDistance[0]++;
                            if (grid[i + n, j] >= tree)
                            {
                                break;
                            }
                        }
                        //top
                        for (int n = 1; n <= i; n++)
                        {
                            viewingDistance[1]++;
                            if (grid[i - n, j] >= tree)
                            {
                                break;
                            }
                        }
                        //right
                        for (int n = 1; n < grid.GetLength(1) - j; n++)
                        {
                            viewingDistance[2]++;
                            if (grid[i, j + n] >= tree)
                            {
                                break;
                            }
                        }
                        //right
                        for (int n = 1; n <= j; n++)
                        {
                            viewingDistance[3]++;
                            if (grid[i, j - n] >= tree)
                            {
                                break;
                            }
                        }
                    }
                    int scenicScore = viewingDistance[0] * viewingDistance[1] * viewingDistance[2] * viewingDistance[3];

                    if (scenicScore > maxScenicScore)
                    {
                        maxScenicScore = scenicScore;
                    }
                }
            }

            Console.WriteLine(maxScenicScore);
        }

        private static int CountVisibleTrees(int[,] grid, int[,] visibilityRequirements)
        {
            int result = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] > visibilityRequirements[i, j] || i == 0 || j == 0 || i == grid.GetLength(0) - 1 || j == grid.GetLength(1) - 1)
                    {
                        result++;
                        //Console.Write('.');
                    }
                    else
                    {
                        //Console.Write('*');
                    }
                    //Console.Write(grid[i, j]);
                }
                //Console.WriteLine();
            }

            return result;
        }

        private static int[,] GetVisibilityRequirements(int[,] grid)
        {
            int[,] requirements = new int[grid.GetLength(0), grid.GetLength(1)];
            int[,] top = new int[grid.GetLength(0), grid.GetLength(1)];
            int[,] left = new int[grid.GetLength(0), grid.GetLength(1)];
            int[,] right = new int[grid.GetLength(0), grid.GetLength(1)];
            int[,] bottom = new int[grid.GetLength(0), grid.GetLength(1)];

            //visibility from top and left
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i > 0 && j > 0)
                    {
                        left[i, j] = Math.Max(left[i, j - 1], grid[i, j - 1]);
                        top[i, j] = Math.Max(top[i - 1, j], grid[i - 1, j]);
                    }
                    else
                    {
                        left[i, j] = 0;
                        top[i, j] = 0;
                    }
                }
            }

            //adding visibility from bottom and right
            for (int i = grid.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = grid.GetLength(1) - 1; j >= 0; j--)
                {
                    if (i < grid.GetLength(0) - 1 && j < grid.GetLength(1) - 1)
                    {
                        right[i, j] = Math.Max(right[i, j + 1], grid[i, j + 1]);
                        bottom[i, j] = Math.Max(bottom[i + 1, j], grid[i + 1, j]);
                    }
                    else
                    {
                        right[i, j] = 0;
                        bottom[i, j] = 0;
                    }
                }
            }

            //finalizing by getting the minimum required height to be seen from one of four sides
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    requirements[i, j] = Math.Min(Math.Min(top[i, j], left[i, j]), Math.Min(right[i, j], bottom[i, j]));
                    //Console.Write(requirements[i, j]);
                }
                //Console.WriteLine();
            }

            return requirements;
        }

        private static int[,] SetupGrid(string[] lines)
        {
            int[,] result = new int[lines.Length, lines.Length];

            int i = 0;
            foreach(string line in lines)
            {
                int j = 0;
                foreach(char tree in line)
                {
                    result[i, j] = (int)tree - (int)'0';
                    j++;
                }
                i++;
            }

            return result;
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
    }
}
