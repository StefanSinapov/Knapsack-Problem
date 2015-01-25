namespace Knapsack
{
    using System;
    using System.Collections.Generic;

    public class DynamicProgrammingSolver : KnapsackSolver
    {
        private double[,] table;

        public DynamicProgrammingSolver(IList<Item> items, int capacity)
            : base(items, capacity)
        {
        }

        public override KnapsackSolution Solve()
        {
            this.FillTable();
            var solution = this.TakeItems();
            solution.Approach = "Dynamic Programming";

            return solution;
        }

        private KnapsackSolution TakeItems()
        {
            var best = new KnapsackSolution() { Items = new List<Item>() };
            for (int row = Items.Count, col = this.Capacity; row > 0; row--)
            {
                if (this.table[row, col] != table[row - 1, col])
                {
                    best.Items.Add(this.Items[row - 1]);
                    col -= Items[row - 1].Weight;
                }
            }

            best.TotalWeight = this.GetWeight(best.Items);
            best.Value = this.GetValue(best.Items);
            return best;
        }

        private void FillTable()
        {
            this.table = new double[this.Items.Count + 1, this.Capacity + 1];
            for (int row = 1; row < this.Items.Count; row++)
            {
                var item = this.Items[row - 1];
                for (int col = 0; col <= this.Capacity; col++)
                {
                    if (item.Weight > col)
                    {
                        this.table[row, col] = this.table[row - 1, col];
                    }
                    else
                    {
                        this.table[row, col] = Math.Max(this.table[row - 1, col], this.table[row - 1, col - item.Weight] + item.Value);
                    }
                }
            }
        }
    }
}
