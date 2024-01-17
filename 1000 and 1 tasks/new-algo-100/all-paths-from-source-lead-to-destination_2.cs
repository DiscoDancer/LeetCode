public class Solution {
    private bool[,] incomingTable;
    private bool[,] outgoingTable;
    private List<int>[] outgoingList;
    private int _destination;
    private int _source;
    private bool _result = true;

    private void Init(int n, int[][] edges) {
        incomingTable = new bool [n, n];
        outgoingTable = new bool [n, n];
        outgoingList = new List<int>[n];

        for (int i = 0; i < n; i++) {
            outgoingList[i] = new ();
        }

        foreach (var e in edges) {
            // a -> b
            var a = e[0];
            var b = e[1];
            incomingTable[b, a] = true;
            outgoingTable[a, b] = true;
            outgoingList[a].Add(b);
        }
    }

    private void Traverse(int node, bool[] visited) {
        if (!_result || node == _destination) {
            return;
        }

        if (outgoingTable[node,node]) {
            _result = false;
            return;
        }

        var proceded = false;

        foreach (var o in outgoingList[node]) {
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

        for (int i = 0; i < n; i++) {
            if (outgoingTable[destination, i]) {
                 return false;
            }
        }

        var visited = new bool[n];
        visited[source] = true;
        Traverse(source, visited);

        return _result;
    }
}