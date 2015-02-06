namespace Knapsack.Utils
{
    using System;
    using System.Collections.Generic;

    public class Node : IComparable<Node>
    {
        public Node()
        {
            this.TakenItems = new List<Item>();
        }

        public Node(Node parent)
        {
            this.Height = parent.Height + 1;
            this.TakenItems = new List<Item>(parent.TakenItems);
            this.Bound = parent.Bound;
            this.Value = parent.Value;
            this.Weight = parent.Weight;
        }

        public int Height { get; set; }

        public IList<Item> TakenItems { get; set; }

        public int Value { get; set; }

        public int Weight { get; set; }

        public double Bound { get; set; }

        public void ComputeBound(IList<Item> items, int capacity)
        {
            double w = this.Weight;
            this.Bound = this.Value;
            int index = this.Height;
            Item currentItem;

            do
            {
                currentItem = items[index];
                if (w + currentItem.Weight > capacity)
                {
                    break;
                }

                w += currentItem.Weight;
                this.Bound += currentItem.Value;
                index++;
            }
            while (index < items.Count);

            this.Bound += (capacity - w) * currentItem.Ratio;
        }

        public int CompareTo(Node other)
        {
            return (int)(other.Bound - this.Bound);
        }
    }
}