public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var flightTable = new List<(int to, int cost)>[n];
        var distancesFromSrc = new int[n];
        for (int i = 0; i < n; i++) {
            flightTable[i] = new ();
            distancesFromSrc[i] = int.MaxValue;
        }

        var queue = new Queue<(int x, int cost, int stops)>();

        foreach (var abc in flights) {
            var from = abc[0];
            var to = abc[1];
            var cost = abc[2];

            flightTable[from].Add((to, cost));

            if (from == src) {
                distancesFromSrc[to] = cost;
                queue.Enqueue((to, cost, 0));
            }
        }

        // stops гарантировано валиден
        while (queue.Any()) {
            var (x, cost, stops) = queue.Dequeue();

            // никуда больше лететь нельзя
            if (stops == k) continue;

            foreach (var flight in flightTable[x]) {
                var (flightTo, flightCost) = flight;
                if (distancesFromSrc[flightTo] > cost + flightCost) {
                    distancesFromSrc[flightTo] = cost + flightCost;
                    queue.Enqueue((flightTo, cost + flightCost, stops + 1));
                }
            }
        }

        var result = distancesFromSrc[dst];
        if (result == int.MaxValue) {
            return -1;
        }

        return result;
    }
}