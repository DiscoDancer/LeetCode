public class Solution {
    // n vertices 0..n-1
    // edges[i] = [ui, vi]

    /*
        - прерывать если результат уже есть
        - edges -> dic
        - backtracking
    */

    private Dictionary<int, List<int>> _edgeTable = new Dictionary<int, List<int>>();
    private bool _res = false;
    private bool[] _visited;
    private int _destination;

    private void DFS(int v) {
        if (_res) {
            return;
        }

        _visited[v] = true;

        if (v == _destination) {
            _res = true;
            return;
        }

        foreach (var n in _edgeTable[v]) {
            if (!_visited[n]) {
                DFS(n);
            }
        }
    }

    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        _destination = destination;
        _visited = new bool[n];
        foreach (var e in edges) {
            if (!_edgeTable.ContainsKey(e[0])) {
                _edgeTable[e[0]] = new ();
            }
            if (!_edgeTable.ContainsKey(e[1])) {
                _edgeTable[e[1]] = new ();
            }
            _edgeTable[e[0]].Add(e[1]);
            _edgeTable[e[1]].Add(e[0]);
        }

        DFS(source);

        return _res;
    }
}