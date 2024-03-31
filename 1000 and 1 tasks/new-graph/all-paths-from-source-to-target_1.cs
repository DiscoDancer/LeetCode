public class Solution {
    private int[][] _graph;
    private int _n;
    private List<IList<int>> _result = new ();

    private void F(List<int> path) {
        if (path.Last() == _n - 1) {
            _result.Add(path.ToList());
        }
        else {
            foreach (var x in _graph[path.Last()]) {
                var length = path.Count();
                path.Add(x);
                F(path);
                path.RemoveAt(length);            
            }
        }
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        _graph = graph;
        var n = graph.Length;
        _n = n;

        F(new List<int>{0});

        return _result;
    }
}