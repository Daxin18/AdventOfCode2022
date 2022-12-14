using System;
using System.Collections.Generic;


namespace Day11
{
    class Monkey
    {
        public List<nuint> items;
        public Func<nuint, nuint, nuint> operation;
        private nuint? operationNumber;
        public nuint testNumber;
        public int throwToIfTrue;
        public int throwToIfFalse;
        public bool divideByThree;

        public Monkey(List<nuint> items, Func<nuint, nuint, nuint> operation, nuint? operationNumber, nuint testNumber, int throwToIfTrue, int throwToIfFalse, bool divideByThree)
        {
            this.items = items;
            this.operation = operation;
            this.operationNumber = operationNumber;
            this.testNumber = testNumber;
            this.throwToIfTrue = throwToIfTrue;
            this.throwToIfFalse = throwToIfFalse;
            this.divideByThree = divideByThree;
        }

        public (nuint, int) InspectAndThrowItem()
        {
            (nuint, int) result = (0,0);
            nuint item = items[items.Count - 1]; //just to make it a bit faster to later renumber items when removing

            checked
            {
                if (operationNumber is null)
                {
                    item = operation(item, item); //worry level increased
                }
                else
                {
                    item = operation(item, (nuint)operationNumber); //worry level increased
                }
            }

            if(divideByThree)
            {
                item = item / 3; //monkey gets bored
            }

            if ((item % testNumber).Equals(UIntPtr.Zero))
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

        public void AddItem(nuint item)
        {
            items.Add(item);
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
