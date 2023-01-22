public class Solution {
    // как острова
    public int FindCircleNum(int[][] isConnected) {
        var provinces = 0;
        var N = isConnected.Length;
        var visited = new bool[N];

        for (int i = 0; i < N; i++) {
            if (!visited[i]) {
                var queue = new Queue<int>();
                queue.Enqueue(i);
                while (queue.Any()) {
                    var cur = queue.Dequeue();
                    visited[cur] = true;

                    for (var j = 0; j < N; j++) {
                        if (!visited[j] && isConnected[cur][j] == 1) {
                            queue.Enqueue(j);
                        }
                    }
                }

                provinces++;
            }
        }

        return provinces;
    }
}