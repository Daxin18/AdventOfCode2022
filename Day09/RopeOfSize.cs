using System;
using System.Collections.Generic;
using System.Linq;

namespace Day09
{
    class RopeOfSize
    {
        class Head
        {
            public int x;
            public int y;
        }

        class Knot : Head
        {
            public Head head;
            public HashSet<(int,int)> set = new HashSet<(int, int)>();

            public Knot(Head head)
            {
                this.head = head;
            }

            public void UpdateSet()
            {
                set.Add((x, y));
            }
        }


        private Head head;
        private Knot[] knots;

        public RopeOfSize(int size)
        {
            head = new Head();
            knots = new Knot[size];
            knots[0] = new Knot(head);
            for(int i = 1; i < size; i++)
            {
                knots[i] = new Knot(knots[i-1]);
            }
        }

        public int CountVisitedByKnot(int i)
        {
            return knots[i].set.Count;
        }

        public void MoveHead(char direction)
        {
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

            for(int i = 0; i < knots.Length; i++)
            {
                MoveKnotIfTooFar(knots[i]);
            }
        }
        private void MoveKnotIfTooFar(Knot knot)
        {
            switch ((knot.head.x - knot.x, knot.head.y - knot.y))
            {
                case (2, 2): //DR
                    knot.y++;
                    knot.x++;
                    break;
                case (-2, 2): //DL
                    knot.y++;
                    knot.x--;
                    break;
                case (2, -2): //UR
                    knot.y--;
                    knot.x++;
                    break;
                case (-2, -2): //UL
                    knot.y--;
                    knot.x--;
                    break;
                case (1, 2): //DR
                    knot.y++;
                    knot.x++;
                    break;
                case (-1, 2): //DL
                    knot.y++;
                    knot.x--;
                    break;
                case (1, -2): //UR
                    knot.y--;
                    knot.x++;
                    break;
                case (-1, -2): //UL
                    knot.y--;
                    knot.x--;
                    break;
                case (2, 1): //DR
                    knot.y++;
                    knot.x++;
                    break;
                case (-2, 1): //DL
                    knot.y++;
                    knot.x--;
                    break;
                case (2, -1): //UR
                    knot.y--;
                    knot.x++;
                    break;
                case (-2, -1): //UL
                    knot.y--;
                    knot.x--;
                    break;
                case (0, 2): //D
                    knot.y++;
                    break;
                case (0, -2): //U
                    knot.y--;
                    break;
                case (2, 0): //R
                    knot.x++;
                    break;
                case (-2, 0): //L
                    knot.x--;
                    break;
                default:
                    break;
            }

            knot.UpdateSet();
        }
    }
}
