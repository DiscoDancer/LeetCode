public class Solution {
    // people 1..n
    // one of them maybe a judge
    // 1. The town judge trusts nobody.
    // 2. Everybody (except for the town judge) trusts the town judge.
    // 1 and 2 -> judge
    public int FindJudge(int n, int[][] trust) {
        var iTrust = new Dictionary<int, List<int>>();
        var trustMe = new Dictionary<int, List<int>>();

        foreach (var t in trust) {
            var i = t[0]; // I 
            var him = t[1]; // trust HIM

            if (!iTrust.ContainsKey(i)) {
                iTrust[i] = new List<int>();
            }
            iTrust[i].Add(him);

            if (!trustMe.ContainsKey(him)) {
                trustMe[him] = new List<int>();
            }
            trustMe[him].Add(i);
        }

        for (int i = 1; i <= n; i++) {
            var iTrustCount = iTrust.ContainsKey(i) ? iTrust[i].Count() : 0;
            var meTrustCount = trustMe.ContainsKey(i) ? trustMe[i].Count() : 0;

            if (meTrustCount == n - 1 && iTrustCount == 0) {
                return i;
            }
        }

        return -1;
    }
}