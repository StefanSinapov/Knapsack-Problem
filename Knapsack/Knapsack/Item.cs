namespace Knapsack
{
    using System;

    public class Item
    {
        public int Name { get; set; }

        public double Value { get; set; }

        public double Weight { get; set; }

        public double GetRatio()
        {
            return this.Value / this.Weight;
        }
    }
}
