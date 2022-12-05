using System;

namespace Day02
{
    class D2Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            string[] playedShapes;
            int points = 0;

            foreach (string line in lines)
            {
                playedShapes = line.Split(' ');
                switch(playedShapes[1])
                {
                    case "X":
                        points += 1;
                        points += determineWinner(playedShapes[0], playedShapes[1]) * 3;
                        break;
                    case "Y":
                        points += 2;
                        points += determineWinner(playedShapes[0], playedShapes[1]) * 3;
                        break;
                    case "Z":
                        points += 3;
                        points += determineWinner(playedShapes[0], playedShapes[1]) * 3;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(points);
        }

        //-1 - wrong
        //0 - first player won
        //1 - draw
        //2 - second player won
        private static int determineWinner(string playerOne, string playerTwo)
        {
            int result = 1;
            switch(playerOne, playerTwo)
            {
                case ("A", "X"):
                    result = 1;
                    break;
                case ("A", "Y"):
                    result = 2;
                    break;
                case ("A", "Z"):
                    result = 0;
                    break;
                case ("B", "X"):
                    result = 0;
                    break;
                case ("B", "Y"):
                    result = 1;
                    break;
                case ("B", "Z"):
                    result = 2;
                    break;
                case ("C", "X"):
                    result = 2;
                    break;
                case ("C", "Y"):
                    result = 0;
                    break;
                case ("C", "Z"):
                    result = 1;
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }
        
        //I knew how to solve the second puzzle right away, but still got sad I'm not gonna get to use "determineWinner" here :(
        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            string[] stratGuide;
            int points = 0;

            foreach (string line in lines)
            {
                stratGuide = line.Split(' ');

                points += determinePoints(stratGuide[0], stratGuide[1]);
            }

            Console.WriteLine(points);
        }

        private static int determinePoints(string playerOne, string strat)
        {
            int result = 1;
            switch (playerOne, strat)
            {
                case ("A", "X"):
                    result = 0 + 3;
                    break;
                case ("A", "Y"):
                    result = 3 + 1;
                    break;
                case ("A", "Z"):
                    result = 6 + 2;
                    break;
                case ("B", "X"):
                    result = 0 + 1;
                    break;
                case ("B", "Y"):
                    result = 3 + 2;
                    break;
                case ("B", "Z"):
                    result = 6 + 3;
                    break;
                case ("C", "X"):
                    result = 0 + 2;
                    break;
                case ("C", "Y"):
                    result = 3 + 3;
                    break;
                case ("C", "Z"):
                    result = 6 + 1;
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }


        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
        
    }
}
