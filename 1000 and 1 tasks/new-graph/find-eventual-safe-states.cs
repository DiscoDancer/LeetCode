public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var result = new List<int>();
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
                // result.Add(i);
                visited[i] = true;
                queue.Enqueue(i);
            }
        }

        // for (int i = 0; i < n; i++) {
        //     if (graph[i].Length == 0 || graph[i].All(x => visited[x])) {
        //         result.Add(i);
        //     }
        // }

        while (queue.Any()) {
            var x = queue.Dequeue();
            result.Add(x);

            foreach (var y in incoming[x]) {
                if (!visited[y]) {
                    if (graph[y].All(i => visited[i])) {
                        queue.Enqueue(y);
                        visited[y] = true;
                    }
                }
            }
        }

        return result.OrderBy(x => x).ToList();
    }
}