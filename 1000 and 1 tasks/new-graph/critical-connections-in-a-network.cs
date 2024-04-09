public class Solution {

    private bool CanReachAll(int n, bool[,] table) {
        var visited = new bool[n];
        visited[0] = true;
        var visitedCount = 1;

        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            for (int i = 0; i < n; i++) {
                if (i != cur && !visited[i] && table[cur,i]) {
                    visited[i] = true;
                    visitedCount++;
                    queue.Enqueue(i);
                }
            }
        }

        return visitedCount == n;
    }

    // решить наивно
    // TL
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        var table = new bool[n,n];

        foreach (var connection in connections) {
            // a <-> b
            var a = connection[0];
            var b = connection[1];
            table[a,b] = true;
            table[b,a] = true;
        }

        var result = new List<IList<int>>();

        foreach (var connection in connections) {
            // a <-> b
            var a = connection[0];
            var b = connection[1];
            table[a,b] = false;
            table[b,a] = false;

            if (!CanReachAll(n, table)) {
                result.Add(connection);
            }

            table[a,b] = true;
            table[b,a] = true;
        }

        return result;
    }
}