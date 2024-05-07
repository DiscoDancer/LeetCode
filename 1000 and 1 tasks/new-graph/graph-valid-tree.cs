public class Solution {
    // возможные требования к дереву нет цикла (как) и одна компонента связности
    // BFS не должен встречать visited != parent + traverse all n vertixes
    public bool ValidTree(int n, int[][] edges) {
        var table = new List<int>[n];

        for (int i = 0; i < n; i++) {
            table[i] = new();
        }

        foreach (var edge in edges) {
            var a = edge.First();
            var b = edge.Last();

            table[a].Add(b);
            table[b].Add(a);
        }

        var visitedCount = 0;
        var visited = new bool[n];

        var queue = new Queue<(int cur, int parent)>();
        queue.Enqueue((0, 1));
        visited[0] = true;

        while (queue.Any()) {
            var (cur, parent) = queue.Dequeue();
            visitedCount++;

            foreach (var neighbour in table[cur]) {
                if (visited[neighbour] && neighbour != parent) {
                    return false;
                }
                // parent is always visited
                if (!visited[neighbour])
                {
                    visited[neighbour] = true;
                    queue.Enqueue((neighbour, cur));
                }
            }
        }

        return visitedCount == n;
    }
}