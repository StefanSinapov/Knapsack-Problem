namespace Knapsack.Contracts
{
    using System.Collections.Generic;

    public interface IKnapsackSolution
    {
        string Approach { get; set; }

        IList<Item> Items { get; set; }

        double Weight { get; set; }

        double Value { get; set; }
    }
}