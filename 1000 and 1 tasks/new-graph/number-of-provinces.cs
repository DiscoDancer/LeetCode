public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        var n = isConnected.Length;
        var visited = new bool[n];
        var result = 0;

        for (int i = 0; i < n; i++) {
            if (visited[i]) {
                continue;
            }

            visited[i] = true;
            result++;

            var queue = new Queue<int>();
            queue.Enqueue(i);
            while (queue.Any()) {
                var x = queue.Dequeue();
                for (int j = 0; j < n; j++) {
                    if (x != j && isConnected[x][j] == 1 && !visited[j]) {
                        visited[j] = true;
                        queue.Enqueue(j);
                    }
                }
            }
        }

        return result;
    }
}