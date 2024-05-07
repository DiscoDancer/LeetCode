public class Solution {
    // острова по компонентам связности ходим
    // не важно, откуда начинать, главное пройти все и разметить

    private int[][] _graph;
    private int[] _visited;

    private bool F(int i) {
        var queue = new Queue<int>();
        queue.Enqueue(i);
        _visited[i] = 1;

        while (queue.Any()) {
            var cur = queue.Dequeue();
            foreach (var j in _graph[cur]) {
                if (_visited[j] == _visited[cur]) {
                    return false;
                }
                if (_visited[j] == 0) {
                    var newVal = _visited[cur] == 1 ? 2 : 1;
                    _visited[j] = newVal;
                    queue.Enqueue(j);
                }
            }
        }

        return true;
    }

    public bool IsBipartite(int[][] graph) {
        var n = graph.Length;
        _graph = graph;
        _visited = new int[n];

        var result = true;

        for (int i = 0; i < n && result; i++) {
            if (_visited[i] == 0) {
                result &= F(i);
            }
        }

        return result;
    }
}