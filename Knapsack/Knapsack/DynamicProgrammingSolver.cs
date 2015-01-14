namespace Knapsack
{
    using System;
    using System.Collections.Generic;

    public class DynamicProgrammingSolver : KnapsackSolver
    {
        public DynamicProgrammingSolver(IList<Item> items, int capacity) : base(items, capacity)
        {
        }

        public override KnapsackSolution Solve()
        {
            throw new NotImplementedException();
        }
    }
}
