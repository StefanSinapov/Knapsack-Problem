namespace Knapsack
{
    public class Item
    {
        public Item(int name, double value, double weight)
        {
            this.Name = name;
            this.Value = value;
            this.Weight = weight;
        }

        public int Name { get; set; }

        public double Value { get; set; }

        public double Weight { get; set; }

        public double GetRatio()
        {
            return this.Value / this.Weight;
        }

        public override string ToString()
        {
            return string.Format("{0} - weight: {1}, value: {2}", this.Name, this.Weight, this.Value);
        }
    }
}
