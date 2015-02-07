namespace Knapsack.Utils
{
    using System.Collections.Generic;

    public class KnapsackInput
    {
        public KnapsackInput()
        {
            this.Items = new List<Item>();
        }

        public IList<Item> Items { get; set; }

        public int Capacity { get; set; }

        public int ExpectedResult { get; set; }
    }
}