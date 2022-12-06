using System;
using System.Collections.Generic;

namespace Day06
{
    class D6Solution
    {
        static void Main(string[] args)
        {
            SolvePuzzle1();
            SolvePuzzle2();
        }

        static void SolvePuzzle1()
        {
            string[] lines = GetLines();
            Queue<char> last4 = new Queue<char>();
            int markerSize = 4;
            int result = 0;

            //there is only one line, but it doesn't mean I can't make it work with more lines
            foreach (string line in lines)
            {
                foreach(char item in line)
                {
                    EnqueueLimitX(ref last4, item, markerSize);
                    result++;

                    if (MarkerOfSizeXAppeared(last4, markerSize))
                    {
                        goto MarkerFound;
                    }
                }    
            }

            MarkerFound:
            Console.WriteLine(result);
        }

        private static void EnqueueLimitX(ref Queue<char> queue, char item, int limit)
        {
            queue.Enqueue(item);

            if(queue.Count > limit)
            {
                queue.Dequeue();
            }
        }
        private static bool MarkerOfSizeXAppeared(Queue<char> queue, int size)
        {
            bool result = false;

            if (queue.Count == size)
            {
                char[] possibleMarker = queue.ToArray();
                result = true;
                //an easy solution that hurts my soul, but i have to get it done quickly
                for(int i = 0; i < size; i++)
                {
                    for(int j = i + 1; j < size; j++)
                    {
                        if (possibleMarker[i].Equals(possibleMarker[j]))
                            result = false;
                    }
                }
            }

            return result;
        }


        static void SolvePuzzle2()
        {
            string[] lines = GetLines();
            Queue<char> last4 = new Queue<char>();
            int markerSize = 14;
            int result = 0;

            //there is only one line, but it doesn't mean I can't make it work with more lines
            foreach (string line in lines)
            {
                foreach (char item in line)
                {
                    EnqueueLimitX(ref last4, item, markerSize);
                    result++;

                    if (MarkerOfSizeXAppeared(last4, markerSize))
                    {
                        goto MarkerFound;
                    }
                }
            }

        MarkerFound:
            Console.WriteLine(result);
        }

        private static string[] GetLines()
        {
            return System.IO.File.ReadAllLines("input.txt");
        }
    }
}
