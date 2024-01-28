
namespace ConsoleApplication
{
    public class Program
    {
        private const double _infinity = double.PositiveInfinity;
        private static Dictionary<string, Dictionary<string, double>> _graph = new Dictionary<string, Dictionary<string, double>>();
        private static List<string> _processed = new List<string>();

        public static void Main(string[] args)
        {
            _graph.Add("start", new Dictionary<string, double>());
            _graph["start"].Add("a", 5.0);
            _graph["start"].Add("b", 2.0);

            _graph.Add("a", new Dictionary<string, double>());
            _graph["a"].Add("c", 4.0);
            _graph["a"].Add("d", 2.0);

            _graph.Add("b", new  Dictionary<string, double>());
            _graph["b"].Add("a", 8.0);
            _graph["b"].Add("d", 7.0);

            _graph.Add("c", new Dictionary<string, double>());
            _graph["c"].Add("d", 6.0);
            _graph["c"].Add("fim", 3.0);

            _graph.Add("d", new Dictionary<string, double>());
            _graph["d"].Add("fim", 1.0);

            _graph.Add("fim", new Dictionary<string, double>());

            var costs = new Dictionary<string, double>();
            costs.Add("a", 5.0);
            costs.Add("b", 2.0);
            costs.Add("c", _infinity);
            costs.Add("d", _infinity);
            costs.Add("fim", _infinity);

            var parents = new Dictionary<string, string>();
            parents.Add("a", "start");
            parents.Add("b", "start");
            parents.Add("fim", null);

            var node = FindLowestCostNode(costs);
            while(node != null)
            {
                var cost = costs[node];
                var neighbors = _graph[node];
                foreach (var n in neighbors.Keys)
                {
                    var new_cost = cost + neighbors[n];
                    if(costs[n] > new_cost)
                    {
                        costs[n] = new_cost;
                        parents[n] = node;
                    }
                }
                _processed.Add(node);
                node = FindLowestCostNode(costs);
            }
            Console.WriteLine(string.Join(", ", costs));
        }

        private static string FindLowestCostNode(Dictionary<string, double> costs)
        {
            var lowestCost = double.PositiveInfinity;
            string lowestCostNode = null;
            foreach (var node in costs)
            {
                var cost = node.Value;
                if(cost < lowestCost && !_processed.Contains(node.Key))
                {
                    lowestCost = cost;
                    lowestCostNode = node.Key;
                }
            }
            return lowestCostNode;
        }
    }
}