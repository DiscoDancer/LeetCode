public class Solution {
    // https://leetcode.com/problems/longest-common-subsequence/solutions/598321/longest-common-subsequence/?envType=study-plan&id=dynamic-programming-i&orderBy=most_votes
    public int LongestCommonSubsequence(string text1, string text2) {
        var dp = new int[text1.Length + 1][];
        for (int i = 0; i < text1.Length + 1; i++) {
            dp[i] = new int[text2.Length + 1];
        }

        for (int col = text2.Length - 1; col >= 0; col--) {
            for (int row = text1.Length - 1; row >= 0; row--) {
                if (text1[row] == text2[col]) {
                    dp[row][col] = 1 + dp[row + 1][col + 1];
                }
                else {
                    dp[row][col] = Math.Max(dp[row + 1][col], dp[row][col + 1]);
                }
            }
        }

        return dp[0][0];
    }
}