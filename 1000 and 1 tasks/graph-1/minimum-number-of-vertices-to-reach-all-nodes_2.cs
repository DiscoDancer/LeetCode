public class Solution {
    // vertices 0..n-1
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        var reachable = new bool[n];


        foreach (var e in edges) {
            reachable[e.Last()] = true;
        }

        // То, что не достижимые должны быть в этом списке = очевидно
        // Но то, что достижимых в этом списке быть не может = не очевидно
        var res = new List<int>();
        for (int i = 0; i < n; i++) {
            if (!reachable[i]) {
                res.Add(i);
            }
        }

        return res;
    }
}