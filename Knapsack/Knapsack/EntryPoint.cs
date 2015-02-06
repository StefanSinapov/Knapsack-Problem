namespace Knapsack
{
    using System;
    using System.Collections.Generic;

    using Knapsack.Solvers;
    using Knapsack.Utils;

    public class EntryPoint
    {
        public static void Main()
        {
            int capacity = 18;
            var items = new List<Item>()
            {
                new Item() { Name = "fourth", Weight = 4, Value = 12 }, 
                new Item() { Name = "third", Weight = 6, Value = 10 }, 
                new Item() { Name = "second", Weight = 5, Value = 8 },
                new Item() { Name = "cheese", Weight = 7, Value = 11 },
                new Item() { Name = "first", Weight = 3, Value = 14 },
                new Item() { Name = "cheese", Weight = 1, Value = 7 },
                new Item() { Name = "cheese", Weight = 6, Value = 9 }
            };

            IList<KnapsackSolution> solutions = new List<KnapsackSolution>()
                                                    {
                                                        new BranchAndBoundSolver(items, capacity).Solve(),
                                                        new DynamicProgrammingSolver(items, capacity).Solve()
                                                    };

            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }
    }
}