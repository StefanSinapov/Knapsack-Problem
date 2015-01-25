namespace Knapsack
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main()
        {
            int capacity = 5;
            var items = new List<Item>()
            {
                new Item() { Name = "beer", Weight = 3, Value = 5 }, 
                new Item() { Name = "vodka", Weight = 2, Value = 3 }, 
                new Item() { Name = "cheese", Weight = 1, Value = 4 }
            };

            var solver = new DynamicProgrammingSolver(items, capacity);

            Console.WriteLine(solver.Solve());
        }
    }
}