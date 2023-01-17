public class Solution {
    // https://www.tutorialcup.com/leetcode-solutions/integer-break-leetcode-solution.htm
    public int IntegerBreak(int n) {
       var dp = new int[n + 1];
       dp[1] = 1;
       for(int i = 2; i <= n; i ++) {
           for(int j = 1; j < i; j ++) {
               dp[i] = Math.Max(dp[i], (Math.Max(j,dp[j])) * (Math.Max(i - j, dp[i - j])));
           }
       }
       return dp[n];
    }
}