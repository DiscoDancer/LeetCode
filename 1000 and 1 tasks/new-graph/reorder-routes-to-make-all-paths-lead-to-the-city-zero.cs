public class Solution {
    public int MinReorder(int n, int[][] connections) {
        var incoming = new List<int>[n];
        var outcoming = new List<int>[n];

        for (int i = 0; i < n; i++) {
            incoming[i] = new ();
            outcoming[i] = new ();
        }

        foreach (var connection in connections) {
            var from = connection[0];
            var to = connection[1];

            outcoming[from].Add(to);
            incoming[to].Add(from);
        }

        var result = 0;
        // do we need it?
        var visited = new bool[n];
        visited[0] = true;

        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Any()) {
            var x = queue.Dequeue();
            foreach (var y in incoming[x]) {
                if (!visited[y]) {
                    visited[y] = true;
                    queue.Enqueue(y);
                }
            }
            foreach (var y in outcoming[x]) {
                if (!visited[y]) {
                    visited[y] = true;
                    queue.Enqueue(y);
                    result++;
                }
            }
        }


        return result;
    }
}