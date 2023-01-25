public class Solution {
    // vertices 0..n-1
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        var toTable = new Dictionary<int, List<int>>();

        foreach (var e in edges) {
            var from = e.First();
            var to = e.Last();
            if (!toTable.ContainsKey(to)) {
                toTable[to] = new List<int>();
            }
            toTable[to].Add(from);
        }

        // То, что не достижимые должны быть в этом списке = очевидно
        // Но то, что достижимых в этом списке быть не может = не очевидно
        var res = new List<int>();
        for (int i = 0; i < n; i++) {
            if (!toTable.ContainsKey(i)) {
                res.Add(i);
            }
        }

        return res;
    }
}