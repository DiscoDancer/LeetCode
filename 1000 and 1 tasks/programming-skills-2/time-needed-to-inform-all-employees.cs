public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        var iManager = new List<int>[n];
        for (int i = 0; i < n; i++) {
            iManager[i] = new List<int>();
        }

        for (int i = 0; i < n; i++) {
            if (manager[i] >= 0) {
                iManager[manager[i]].Add(i);
            }  
        }

        var queue = new Queue<(int node, int time)>();
        queue.Enqueue((headID, 0));

        var max = 0;
        while (queue.Any()) {
            var (node, time) = queue.Dequeue();
            max = Math.Max(max, time);

            foreach (var c in iManager[node]) {
                queue.Enqueue((c, informTime[node] + time));
            }
        }

        return max;
    }
}