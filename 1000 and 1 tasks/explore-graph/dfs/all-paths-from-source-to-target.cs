public class Solution {
    private int[][] _graph;
    private IList<IList<int>> _result = new List<IList<int>>();
    private int _goal;

    private void DFS(List<int> curPath, int v) {
        if (v == _goal) {
            _result.Add(curPath.ToList());
            return;
        }

        var copy = curPath.ToList();

        foreach(var n in _graph[v]) {
            if (!copy.Contains(n)) {
                copy.Add(n);
                DFS(copy, n);
                copy.Remove(n);
            }
        }
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        _graph = graph;
        var n = graph.Length;
        _goal = n - 1;

        DFS(new List<int>() {0}, 0);

        return _result;
    }
}