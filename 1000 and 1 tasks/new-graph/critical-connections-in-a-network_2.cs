// editorial
public class Solution {
    private Dictionary<int, List<int>> _graph;
    private int?[] _rank;
    private HashSet<(int x,int y)> _connDict;

    private int DFS(int node, int discoveryRank) {
        // That means this node is already visited. We simply return the rank.
        if (_rank[node] != null) {
            return _rank[node].Value;
        }

        // Update the rank of this node.
        _rank[node] = discoveryRank;

        // This is the max we have seen till now. So we start with this instead of INT_MAX or something.
        var minRank = discoveryRank + 1;

        foreach (var neighbor in _graph[node]) {
            // Skip the parent.
            var neighRank = _rank[neighbor];
            if (neighRank != null && neighRank == discoveryRank - 1) {
                continue;
            }

            // Recurse on the neighbor.
            var recursiveRank = DFS(neighbor, discoveryRank + 1);

            // Step 1, check if this edge needs to be discarded.
            if (recursiveRank <= discoveryRank) {
                var min = Math.Min(node,neighbor);
                var max = Math.Max(node,neighbor);
                _connDict.Remove((min, max));
            }

            // Step 2, update the minRank if needed.
            minRank = Math.Min(minRank, recursiveRank);
        }

        return minRank;
    }

    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        _graph= new Dictionary<int, List<int>>();
        _rank = new int?[n];
        _connDict = new HashSet<(int x,int y)>();

        for (int i = 0; i < n; i++) {
            _graph[i] = new ();
        }

        foreach (var connection in connections) {
            var a = connection[0];
            var b = connection[1];

            _graph[a].Add(b);
            _graph[b].Add(a);

            var min = Math.Min(a,b);
            var max = Math.Max(a,b);

            _connDict.Add((min,max));
        }

        DFS(0,0);

        var result = new List<IList<int>>();

        foreach (var k in _connDict) {
            result.Add(new int[] {k.x, k.y});
        }

        return result;
    }
}