public class Solution {
    // https://leetcode.com/problems/coin-change-ii/solutions/430649/coin-change-ii/?orderBy=most_votes
    public int Change(int amount, int[] coins) {
        var dp = new int[amount + 1];
        dp[0] = 1;

        foreach (var coin in coins) {
            for (int i = coin; i <= amount; i++) {
                dp[i] += dp[i-coin];
            }
        }

        return dp[amount];
    }
}