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
            int expectedResult = 44;
            var items = new List<Item>()
            {
                new Item() { Name = "fourth", Weight = 4, Value = 12 }, 
                new Item() { Name = "third", Weight = 6, Value = 10 }, 
                new Item() { Name = "second", Weight = 5, Value = 8 }, 
                new Item() { Name = "cheese", Weight = 7, Value = 11 }, 
                new Item() { Name = "first", Weight = 3, Value = 14 }, 
                new Item() { Name = "potatos", Weight = 1, Value = 7 }, 
                new Item() { Name = "bear", Weight = 6, Value = 9 }
            };

            PrintResults(items, capacity, expectedResult);

            capacity = 4;
            expectedResult = 6;
            items = new List<Item>()
                        {
                            new Item() { Name = "first", Value = 2, Weight = 1 },
                            new Item() { Name = "Second", Value = 3, Weight = 2 },
                            new Item() { Name = "Third", Value = 4, Weight = 3 },
                            new Item() { Name = "Fourth", Value = 5, Weight = 4 },
                            new Item() { Name = "Second", Value = 6, Weight = 5 }
                        };
            PrintResults(items, capacity, expectedResult);
        }

        public static void PrintResults(IList<Item> items, int capacity, int expectedResult)
        {
            IList<KnapsackSolution> solutions = new List<KnapsackSolution>()
                                                    {
                                                        new BranchAndBoundSolver(items, capacity).Solve(), 
                                                        new DynamicProgrammingSolver(items, capacity).Solve()
                                                    };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Expected result is {0}", expectedResult);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }
    }
}