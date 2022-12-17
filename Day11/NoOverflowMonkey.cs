using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    class NoOverflowMonkey
    {
        public class Item
        {
            public int number;
            public HashSet<int> primes;
            private static readonly int[] PRIME_LIST = { 2, 3, 5, 7, 11, 13, 17, 19};

            public Item(int number)
            {
                this.number = (int)number;
                primes = new HashSet<int>();
                UpdateItem();
            }

            public void UpdateItem()
            {
                bool furtherDivisible = true;
                while (furtherDivisible)
                {
                    furtherDivisible = false;
                    foreach (int prime in PRIME_LIST)
                    {
                        if (number % prime == 0)
                        {
                            furtherDivisible = true;
                            number /= prime;
                            primes.Add(prime);
                            break;
                        }
                    }
                }
            }

            public void Add(int i)
            {
                number += i;
                UpdateItem();
            }
            
            public void Multiply(int i)
            {
                number *= i;
                UpdateItem();
            }

            public bool isDivisibleBy(int divisor)
            {
                return (primes.Contains(divisor) || number % divisor == 0);
            }
        }

        public List<Item> items;
        public Func<nuint, nuint, nuint> operation;
        private int? operationNumber;
        public int testNumber;
        public int throwToIfTrue;
        public int throwToIfFalse;
        public bool divideByThree;

        public NoOverflowMonkey(List<int> items, Func<nuint, nuint, nuint> operation, int? operationNumber, int testNumber, int throwToIfTrue, int throwToIfFalse, bool divideByThree)
        {
            List<Item> itemsList = new List<Item>();

            foreach(int item in items)
            {
                itemsList.Add(new Item(item));
            }

            this.items = itemsList;
            this.operation = operation;
            this.operationNumber = operationNumber;
            this.testNumber = testNumber;
            this.throwToIfTrue = throwToIfTrue;
            this.throwToIfFalse = throwToIfFalse;
            this.divideByThree = divideByThree;
        }

        public (Item, int) InspectAndThrowItem()
        {
            (Item, int) result = (0, 0);
            Item item = items[items.Count - 1]; //just to make it a bit faster to later renumber items when removing
            int number = item.number;

            checked
            {
                if (operationNumber is null)
                {
                    number = (int)operation((nuint)number, (nuint)number); //worry level increased
                }
                else
                {
                    number = (int)operation((nuint)number, (nuint)operationNumber); //worry level increased
                }
            }

            if (divideByThree)
            {
                number = number / 3; //monkey gets bored
            }

            item.number = number;
            item.UpdateItem();
            
            if(item.isDivisibleBy(testNumber))
            {
                result = (item, throwToIfTrue);
            }
            else
            {
                result = (item, throwToIfFalse);
            }

            items.RemoveAt(items.Count - 1);

            return result;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void AddItem(int item)
        {
            items.Add(new Item(item));
        }

        override public string ToString()
        {
            string itemss = items[0].ToString();

            for (int i = 1; i < items.Count; i++)
            {
                itemss += $", {items[i]}";
            }

            return $"Items: {itemss}\nOperationNumber: {operationNumber}\nTest: divisible by {testNumber}\n\tIf True: throw to {throwToIfTrue}\n\tIf False: throw to {throwToIfFalse}";
        }
    }
}
