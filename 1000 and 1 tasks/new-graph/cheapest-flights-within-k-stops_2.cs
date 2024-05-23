public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var flightTable = new List<(int to, int cost)>[n];
        var distancesFromSrc = new int[n];
        for (int i = 0; i < n; i++) {
            flightTable[i] = new ();
            distancesFromSrc[i] = int.MaxValue;
        }

        var queue = new Queue<(int x, int cost)>();

        foreach (var abc in flights) {
            var from = abc[0];
            var to = abc[1];
            var cost = abc[2];

            flightTable[from].Add((to, cost));

            if (from == src) {
                distancesFromSrc[to] = cost;
                queue.Enqueue((to, cost));
            }
        }

        var stops = 0;
        while (queue.Any() && stops < k) {
            var size = queue.Count();

            for (int i = 0; i < size; i++) {
                var (x, cost) = queue.Dequeue();

                foreach (var flight in flightTable[x]) {
                    var (flightTo, flightCost) = flight;
                    if (distancesFromSrc[flightTo] > cost + flightCost) {
                        distancesFromSrc[flightTo] = cost + flightCost;
                        queue.Enqueue((flightTo, cost + flightCost));
                    }
                }
            }

            stops++;
        }

        var result = distancesFromSrc[dst];
        if (result == int.MaxValue) {
            return -1;
        }

        return result;
    }
}