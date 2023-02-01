public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        var table = new Dictionary<int, List<int>>();
        foreach (var e in edges) {
            if (!table.ContainsKey(e[0])) {
                table[e[0]] = new ();
            }
            if (!table.ContainsKey(e[1])) {
                table[e[1]] = new ();
            }
            table[e[0]].Add(e[1]);
            table[e[1]].Add(e[0]);
        }

        var visited = new bool[n];
        visited[source] = true;

        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            if (cur == destination) {
                return true;
            }
            foreach (var neigh in table[cur]) {
                if (visited[neigh]) {
                    continue;
                }
                else {
                    queue.Enqueue(neigh);
                    visited[neigh] = true;
                }
            }
        }

        return false;

    }
}