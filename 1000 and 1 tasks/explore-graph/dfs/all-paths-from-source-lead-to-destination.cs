// https://leetcode.com/problems/all-paths-from-source-lead-to-destination/solutions/1007695/all-paths-from-source-lead-to-destination/?orderBy=most_votes
public class Solution {
    private const int DEFAULT = 0;
    private const int GREY = 2;
    private const int BLACK = 3;

    private List<int>[] _graph;
    private int _destination;
    private int[] _colors;

    private bool DFS(int v) {
        // cycle detection
        if (_colors[v] != DEFAULT) {
            return _colors[v] == BLACK;
        }

        if (!_graph[v].Any()) {
            return v == _destination;
        }

        // being processed
        _colors[v] = GREY;

        foreach (var n in _graph[v]) {
            if (!DFS(n)) {
                return false;
            }
        }

        // processed
        _colors[v] = BLACK;
        return true;
    }


    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) {
        _destination = destination;
        _colors = new int[n];
        _graph = new List<int>[n];
        for (int i = 0; i < n; i++) {
            _graph[i] = new ();
        }
        foreach (var e in edges) {
            _graph[e[0]].Add(e[1]);
        }

        return DFS(source);
    }
}