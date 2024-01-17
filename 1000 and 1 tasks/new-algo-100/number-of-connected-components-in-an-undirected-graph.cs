public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var connectedTable = new List<int>[n];
        for (int i = 0; i < n; i++) {
            connectedTable[i] = new ();
        }

        foreach (var e in edges) {
            var a = e[0];
            var b = e[1];
            connectedTable[a].Add(b);
            connectedTable[b].Add(a);
        }

        var visited = new bool[n];
        var countComponents = 0;
        for (int i = 0; i < n; i++) {
            if (visited[i]) {
                continue;
            }
            var queue = new Queue<int>();
            countComponents++;
            queue.Enqueue(i);
            visited[i] = true;
            while (queue.Any()) {
                var cur = queue.Dequeue();
                foreach (var o in connectedTable[cur]) {
                    if (!visited[o]) {
                        queue.Enqueue(o);
                        visited[o] = true;
                    }
                }
            }
        }

        return countComponents;
    }
}