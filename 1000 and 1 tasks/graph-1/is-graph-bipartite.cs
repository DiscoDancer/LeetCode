public class Solution {

    private const int RED = 5;
    private const int BLUE = 6;

    private int[] _colors;
    private int[][] _graph;

    public bool IsPossibleColorize(int i) {
        var queue = new Queue<int>();
        queue.Enqueue(i);
        _colors[i] = RED;

        while (queue.Any()) {
            var cur = queue.Dequeue();

            if (_graph[cur].Length == 0) {
                continue;
            }

            foreach (var n in _graph[cur]) {
                if (_colors[n] == _colors[cur]) {
                    return false;
                }

                if (_colors[n] == 0) {
                    _colors[n] = _colors[cur] == RED ? BLUE : RED;
                    queue.Enqueue(n);
                }
            }
        }

         return true;
    }

    public bool IsBipartite(int[][] graph) {
        var n = graph.Length;
        _graph = graph;
        _colors = _colors = new int[n];

        for (int i = 0; i < n; i++) {
            if (_colors[i] == 0) {
                if (!IsPossibleColorize(i)) {
                    return false;
                }
            }
        }

        return true;
    }
}