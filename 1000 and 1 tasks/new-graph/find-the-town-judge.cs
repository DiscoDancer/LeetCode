public class Solution {
    public int FindJudge(int n, int[][] trust) {
        var iTrustTo = new List<int>[n+1];
        var meTrust = new List<int>[n+1];

        for (int i = 1; i <= n; i++) {
            iTrustTo[i] = new ();
            meTrust[i] = new ();
        }

        foreach (var ab in trust) {
            // a trusts b
            var a = ab.First();
            var b = ab.Last();

            iTrustTo[a].Add(b);
            meTrust[b].Add(a);
        }

        for (int i = 1; i <= n; i++) {
            if (iTrustTo[i].Count() == 0 && meTrust[i].Count() == n - 1) {
                return i;
            }
        }

        return -1;
    }
}