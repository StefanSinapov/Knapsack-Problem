namespace Knapsack.Utils
{
    public class Item
    {
        public Item()
        {
        }

        public Item(string name, int value, int weight)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public int Weight { get; set; }

        public int Ratio
        {
            get
            {
                return this.Value / this.Weight;
            }
        }

        public override string ToString()
        {
            return string.Format("\n    {0} - weight: {1}, value: {2}", this.Name, this.Weight, this.Value);
        }
    }
}
