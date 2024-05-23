public class Solution {
    // Решения взято из cheapest-flights-within-k-stops_2.cs
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
        var flightTable = new List<(int to, double cost)>[n];
        var distancesFromSrc = new double[n];
        
        for (var i = 0; i < n; i++) {
            flightTable[i] = new ();
        }
        
        var queue = new Queue<(int x, double prob)>();

        for (var ei = 0; ei < edges.Length; ei++) {
            var from = edges[ei][0];
            var to = edges[ei][1];
            var prob = succProb[ei];

            flightTable[from].Add((to, prob));
            flightTable[to].Add((from, prob));

            if (from == start_node) {
                distancesFromSrc[to] = prob;
                queue.Enqueue((to, prob));
            }
            if (to == start_node) {
                distancesFromSrc[from] = prob;
                queue.Enqueue((from, prob));
            }
        }

        while (queue.Any())
        {
            var (x, prob) = queue.Dequeue();
            foreach (var edge in flightTable[x])
            {
                var (y ,yProb) = edge;
                if (distancesFromSrc[y] < yProb * prob)
                {
                    distancesFromSrc[y] = yProb * prob;
                    queue.Enqueue((y, yProb * prob));
                }
            }
        }

        return distancesFromSrc[end_node];
    }
}