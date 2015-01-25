namespace Knapsack.Contracts
{
    using System.Collections.Generic;

    public interface IKnapsackSolution
    {
        string Approach { get; set; }

        IList<Item> Items { get; set; }

        double TotalWeight { get; set; }

        double Value { get; set; }
    }
}