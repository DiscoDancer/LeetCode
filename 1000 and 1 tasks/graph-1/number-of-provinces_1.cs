public class Solution {
    // как острова
    public int FindCircleNum(int[][] isConnected) {
        var provinces = 0;
        var N = isConnected.Length;

        var notVisited = Enumerable.Range(0, N).ToList();

        while (notVisited.Any()) {
            var top = notVisited.First();

            var queue = new Queue<int>();
            queue.Enqueue(top);
            while (queue.Any()) {
                var cur = queue.Dequeue();
                notVisited.Remove(cur);

                for (var j = 0; j < N; j++) {
                    if (notVisited.Contains(j) && isConnected[cur][j] == 1) {
                        queue.Enqueue(j);
                    }
                }
            }

            provinces++;
        }

        return provinces;
    }
}