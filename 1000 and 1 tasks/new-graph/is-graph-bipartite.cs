public class Solution {
    // острова по компонентам связности ходим

    private int _n;
    private int[][] _graph;
    private int[] _visited;
    private bool _result = true;

    // значение можно не передавать
    private void F(int i, int valueOfi) {
        if (!_result) {
            return;
        }

        foreach (var j in _graph[i]) {
            if (_visited[j] == valueOfi) {
                _result = false;
                return;
            }
            if (_visited[j] == 0) {
                var newVal = valueOfi == 1 ? 2 : 1;
                _visited[j] = newVal;
                F(j, newVal);
            }
        }
    }

    public bool IsBipartite(int[][] graph) {
        _graph = graph;
        _n = graph.Length;
        _visited = new int[_n];

        for (int i = 0; i < _n && _result; i++) {
            if (_visited[i] == 0) {
                _visited[i] = 1;
                F(i, 1);
            }
        }

        return _result;
    }
}