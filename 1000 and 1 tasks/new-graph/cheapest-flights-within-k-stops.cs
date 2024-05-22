// out of memory
public class Solution {
    // bfs просто и дешево
    // делаем бфс, потом разбираем дейкстру или найти его, нахуя, лучше разобрать
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        if (src == dst) {
            return 0;
        }

        var table = new int[n,n];

        foreach (var abc in flights) {
            var from = abc[0];
            var to = abc[1];
            var cost = abc[2];

            table[from, to] = cost;
        }

        if (k == 0) {
            if (table[src, dst] > 0) {
                return table[src, dst];
            }
            return -1;
        }

        var queue = new Queue<(int x, int totalCost)>();
        queue.Enqueue((src, 0));

        var result = int.MaxValue;

        var flightCount = -2;

        while (queue.Any() && flightCount < k) {
            var size = queue.Count();
            for (var s = 0; s < size; s++) {
                var (x, totalCost) = queue.Dequeue();
                if (x == dst) {
                    result = Math.Min(result, totalCost);
                }
                for (int i = 0; i < n; i++) {
                    if (table[x, i] > 0) {
                        queue.Enqueue((i, totalCost + table[x, i]));
                    }
                }
            }

            flightCount++;
        }

        return result == int.MaxValue ?  - 1 : result;
    }
}