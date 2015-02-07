namespace Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    using Knapsack.Solvers;
    using Knapsack.Utils;

    public class EntryPoint
    {
        public static void Main()
        {
            /* var input1 = ReadInput("./../../SampleInputs/easy20.txt");
             PrintResults(input1);*/
            var input2 = new KnapsackInput()
                             {
                                 Capacity = 18,
                                 ExpectedResult = 44,
                                 Items =
                                     new List<Item>()
                                         {
                                             new Item { Name = "fourth", Weight = 4, Value = 12 }, 
                                             new Item { Name = "third", Weight = 6,  Value = 10 }, 
                                             new Item { Name = "second", Weight = 5, Value = 8 }, 
                                             new Item { Name = "cheese", Weight = 7, Value = 11 }, 
                                             new Item { Name = "first", Weight = 3, Value = 14 }, 
                                             new Item { Name = "potatos", Weight = 1, Value = 7 }, 
                                             new Item { Name = "bear", Weight = 6, Value = 9 }
                                         }
                             };
            PrintResults(input2);

            var input3 = new KnapsackInput()
                             {
                                 Capacity = 4,
                                 ExpectedResult = 6,
                                 Items = new List<Item>()
                                         {
                                             new Item() { Name = "first", Value = 2, Weight = 1 }, 
                                             new Item() { Name = "Second", Value = 3, Weight = 2 }, 
                                             new Item() { Name = "Third", Value = 4, Weight = 3 }, 
                                             new Item() { Name = "Fourth", Value = 5, Weight = 4 }, 
                                             new Item() { Name = "Second", Value = 6, Weight = 5 }
                                         }
                             };
            PrintResults(input3);
        }

        public static void PrintResults(KnapsackInput input)
        {
            IList<KnapsackSolver> solvers = new List<KnapsackSolver>()
                                                    {
                                                        new BranchAndBoundSolver(input.Items, input.Capacity), 
                                                        new DynamicProgrammingSolver(input.Items, input.Capacity)
                                                    };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Max Capacity is {0}", input.Capacity);
            Console.WriteLine("Expected result is {0}", input.ExpectedResult);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var solver in solvers)
            {
                Stopwatch sw = new Stopwatch();

                sw.Start();

                var solution = solver.Solve();

                sw.Stop();

                Console.WriteLine(solution);
                Console.WriteLine("Elapsed = {0}\n", sw.Elapsed);
            }
        }

     /*   public static KnapsackInput ReadInput(string fileName)
        {
            var input = new KnapsackInput();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    int count = int.Parse(reader.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        var line = reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var item = new Item
                        {
                            Name = line[0],
                            Value = int.Parse(line[1]),
                            Weight = int.Parse(line[2])
                        };

                        input.Items.Add(item);
                    }

                    input.Capacity = int.Parse(reader.ReadLine());
                    input.ExpectedResult = int.Parse(reader.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return input;
        }*/
    }
}