namespace Knapsack.Solvers
{
    using System.Collections.Generic;
    using System.Linq;

    using Knapsack.Utils;

    public class BranchAndBoundSolver : KnapsackSolver
    {
        public BranchAndBoundSolver(IList<Item> items, int capacity)
            : base(items, capacity)
        {
        }

        public override KnapsackSolution Solve()
        {
            this.Items = this.Items.OrderBy(i => i.Ratio).ToList();

            Node best = new Node();
            Node root = new Node();

            root.ComputeBound(this.Items, this.Capacity);

            var queue = new PriorityQueue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.Bound > best.Value && node.Height < this.Items.Count - 1)
                {
                    Node with = new Node(node);

                    var item = this.Items[node.Height];
                    with.Weight += item.Weight;

                    if (with.Weight <= this.Capacity)
                    {
                        with.TakenItems.Add(this.Items[node.Height]);
                        with.Value += item.Value;
                        with.ComputeBound(this.Items, this.Capacity);

                        if (with.Value > best.Value)
                        {
                            best = with;
                        }

                        if (with.Bound > best.Value)
                        {
                            queue.Enqueue(with);
                        }
                    }

                    var without = new Node(node);
                    without.ComputeBound(this.Items, this.Capacity);

                    if (without.Bound > best.Value)
                    {
                        queue.Enqueue(without);
                    }
                }
            }

            var solution = new KnapsackSolution
                               {
                                   Value = best.Value,
                                   TotalWeight = best.Weight,
                                   Items = best.TakenItems,
                                   Approach = "Best-First Search with Branch and Bound"
                               };

            return solution;
        }
    }
}