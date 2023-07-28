public class Solution {
    // editorial
    public bool WordBreak(string s, IList<string> wordDict) {
        var dp = new bool[s.Length];

        for (int i = 0; i < s.Length; i++) {
            foreach (var w in wordDict) {
                if (i >= w.Length-1 && (i == w.Length - 1 || dp[i-w.Length])) {
                    if (s.Substring(i-w.Length + 1, w.Length) == w) {
                        dp[i] = true;
                        break;
                    }
                }
            }
        }

        return dp[s.Length-1];
    }
}