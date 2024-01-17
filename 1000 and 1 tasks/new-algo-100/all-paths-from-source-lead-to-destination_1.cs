public class Solution {
    private List<int>[] incomingTable;
    private List<int>[] outgoingTable;
    private int _destination;
    private int _source;
    private bool[] _isDeadend;
    private bool _result = true;

    private void Init(int n, int[][] edges) {
        incomingTable = new List<int>[n];
        outgoingTable = new List<int>[n];

        for (int i = 0; i < n; i++) {
            incomingTable[i] = new ();
            outgoingTable[i] = new ();
        }

        foreach (var e in edges) {
            // a -> b
            var a = e[0];
            var b = e[1];
            incomingTable[b].Add(a);
            outgoingTable[a].Add(b);
        }

        _isDeadend = new bool[n];
        for (int i = 0; i < n; i++) {
            _isDeadend[i] = outgoingTable[i].Count() == 0;
        }
    }

    private void Traverse(int node, bool[] visited) {
        if (!_result || node == _destination) {
            return;
        }

        if (outgoingTable[node].Contains(node)) {
            _result = false;
            return;
        }

        var proceded = false;

        foreach (var o in outgoingTable[node]) {
            if (visited[o]) {
                continue;
            }
            visited[o] = true;
            Traverse(o, visited);
            visited[o] = false;
            proceded = true;
        }

        if (!proceded) {
            _result = false;
        }
    }

    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) {
        _destination = destination;
        _source = source;
        Init(n, edges);

        var visited = new bool[n];
        visited[source] = true;
        Traverse(source, visited);

        if (outgoingTable[destination].Any()) {
            return false;
        }

        return _result;
    }
}