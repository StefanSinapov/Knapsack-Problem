namespace Knapsack
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

        public override string ToString()
        {
            return string.Format("{0} - weight: {1}, value: {2}", this.Name, this.Weight, this.Value);
        }
    }
}
