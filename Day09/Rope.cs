using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    class Rope
    {
        private (int x, int y) head;
        private (int x, int y) tail;
        private HashSet<(int, int)> set = new HashSet<(int, int)>();


        public int CountVisited()
        {
            return set.Count;
        }
        public void MoveHead(char direction)
        {
            //Console.WriteLine(direction);
            switch (direction)
            {
                case 'R':
                    head.x++;
                    break;
                case 'L':
                    head.x--;
                    break;
                case 'U':
                    head.y--;
                    break;
                case 'D':
                    head.y++;
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }

            MoveTailIfTooFar();
        }
        private void MoveTailIfTooFar()
        {
            switch ((head.x - tail.x, head.y - tail.y))
            {
                case (1, 2): //DR
                    tail.y++;
                    tail.x++;
                    break;
                case (-1, 2): //DL
                    tail.y++;
                    tail.x--;
                    break;
                case (1, -2): //UR
                    tail.y--;
                    tail.x++;
                    break;
                case (-1, -2): //UL
                    tail.y--;
                    tail.x--;
                    break;
                case (2, 1): //DR
                    tail.y++;
                    tail.x++;
                    break;
                case (-2, 1): //DL
                    tail.y++;
                    tail.x--;
                    break;
                case (2, -1): //UR
                    tail.y--;
                    tail.x++;
                    break;
                case (-2, -1): //UL
                    tail.y--;
                    tail.x--;
                    break;
                case (0, 2): //D
                    tail.y++;
                    break;
                case (0, -2): //U
                    tail.y--;
                    break;
                case (2, 0): //R
                    tail.x++;
                    break;
                case (-2, 0): //L
                    tail.x--;
                    break;
                default:
                    break;
            }

            set.Add(tail);
            //Console.WriteLine($"Head: x = {head.x}, y = {head.y}");
            //Console.WriteLine($"Tail: x = {tail.x}, y = {tail.y}");
            //Console.WriteLine("--------------------------");
        }
    }
}
