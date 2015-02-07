namespace Knapsack.Tests
{
    using System.Collections.Generic;

    using Knapsack.Solvers;
    using Knapsack.Utils;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BranchAndBoundTests
    {
        [TestMethod]
        public void StandartInputShouldReturnExpectedResult()
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

            var actualResult = new BranchAndBoundSolver(items, capacity).Solve().Value;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StandertInputShouldReturnResultWithLessThanOrEqualCapacity()
        {
            int capacity = 18;
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

            var actualResult = new BranchAndBoundSolver(items, capacity).Solve().TotalWeight;

            Assert.IsTrue(actualResult <= capacity);
        }

        [TestMethod]
        public void InputWithItemsWithWeightsBiggerThanCapacityShouldReturn0AsValue()
        {
            int capacity = 3;
            int expectedResult = 0;
            var items = new List<Item>()
            {
                new Item() { Name = "fourth", Weight = 4, Value = 12 }, 
                new Item() { Name = "third", Weight = 6, Value = 10 }
            };

            var actualResult = new BranchAndBoundSolver(items, capacity).Solve().Value;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InputWithItemsWithWeightsBiggerThanCapacityShouldReturn0AsTotalWeight()
        {
            int capacity = 3;
            int expectedResult = 0;
            var items = new List<Item>()
            {
                new Item() { Name = "fourth", Weight = 4, Value = 12 }, 
                new Item() { Name = "third", Weight = 6, Value = 10 }
            };

            var actualResult = new BranchAndBoundSolver(items, capacity).Solve().TotalWeight;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
