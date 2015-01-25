namespace Knapsack
{
    using System.Collections.Generic;
    using System.Text;

    using Knapsack.Contracts;

    public class KnapsackSolution : IKnapsackSolution
    {
        public string Approach { get; set; }

        public IList<Item> Items { get; set; }

        public double TotalWeight { get; set; }

        public double Value { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("{0}| value: {1}, total weight: {2}", this.Approach, this.Value, this.TotalWeight);
            output.AppendLine(string.Join(", ", this.Items));

            return output.ToString();
        }
    }
}
