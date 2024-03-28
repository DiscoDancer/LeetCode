public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var n = graph.Length;
        var incoming = new List<int>[n];
        for (int i = 0; i < n; i++) {
            incoming[i] = new ();
        }

        var visited = new bool[n];
        var queue = new Queue<int>();

        // can be merged + null checks
        for (int i = 0; i < n; i++) {
            // i -> j
            foreach (var j in graph[i]) {
                incoming[j].Add(i);
            }
            if (!graph[i].Any()) {
                visited[i] = true;
                queue.Enqueue(i);
            }
        }

        while (queue.Any()) {
            var x = queue.Dequeue();
            foreach (var y in incoming[x]) {
                if (!visited[y]) {
                    if (graph[y].All(i => visited[i])) {
                        queue.Enqueue(y);
                        visited[y] = true;
                    }
                }
            }
        }

        var result = new List<int>();
        for (int i = 0; i < n; i++) {
            if (visited[i]) {
                result.Add(i);
            }
        }

        return result;
    }
}