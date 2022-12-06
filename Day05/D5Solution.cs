using System;
using System.Collections.Generic;

namespace Day05
{
    class D5Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            int stackCount = 0;
            int maxStackHeight = 0;
            List<Stack<char>> stacks = BuildStacks(lines, ref stackCount, ref maxStackHeight);


            string[] delimiter = { "move ", " from ", " to " };
            for (int i = maxStackHeight + 2; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] moveFromTo = line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                MoveFromTo(ref stacks, Int32.Parse(moveFromTo[0]), Int32.Parse(moveFromTo[1]), Int32.Parse(moveFromTo[2]));
            }

            foreach (Stack<char> stack in stacks)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }

        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
        }

        //is this an overkill? Yeah, it probably is...
        private static List<Stack<char>> BuildStacks(string[] lines, ref int stackCount, ref int maxStackHeight)
        {
            List<Stack<char>> result = new List<Stack<char>>();
            List<Stack<char>> tmp = new List<Stack<char>>();

            //first, we count number of all the stacks
            foreach (string line in lines)
            { 
                //initial stacks are numbered, and crates only contain letters
                //this means that once we reach number 1, we are done with stacks
                if (line.Contains('1'))
                    break;

                string[] stacks = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (stacks.Length > stackCount)
                    stackCount = stacks.Length;

                maxStackHeight++;
            }

            //then we add all the needed stacks
            for (int i = 0; i < stackCount; i++)
            {
                result.Add(new Stack<char>());
                tmp.Add(new Stack<char>());
            }

            //then, we put all the crates into proper stacks (in temporary list of stacks), but in reversed order
            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].Equals('['))
                    {
                        i++; //increment i to get to the letter on a crate
                        int stackNumber = (i - 1) / 4; //get the stack number based on char index
                        tmp[stackNumber].Push(line[i]); //push the crate char into proper temporary stack (reversed order)
                    }
                }
            }
            
            //finally, we reverse crates in the stacks back into the actual order 
            for(int i = 0; i < tmp.Count; i++)
            {
                Stack<char> current = tmp[i];

                while(current.Count > 0)
                {
                    result[i].Push(current.Pop());
                }
            }

            return result;
        }

        private static void MoveFromTo(ref List<Stack<char>> stacks, int move, int from, int to)
        {
            //numbers of stacks are 1 higher than their indexes
            from--;
            to--;
            
            while(move > 0)
            {
                stacks[to].Push(stacks[from].Pop());
                move--;
            }
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
    }
}
