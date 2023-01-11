public class Solution {
    // https://leetcode.com/problems/decode-ways/solutions/525903/decode-ways/?envType=study-plan&id=dynamic-programming-i&orderBy=most_votes
    public int NumDecodings(string s) {
        var dp = new int[s.Length + 1];
        dp[0] = 1;

        // с нуля ничего не может начинаться
        dp[1] = s[0] == '0' ? 0 : 1;

        for (int i = 2; i < dp.Length; i++) {
            dp[i] += s[i - 1] != '0' ? dp[i - 1] : 0;

            int twoDigit = int.Parse(s.Substring(i - 2, 2));
            dp[i] += twoDigit >= 10 && twoDigit <= 26 ? dp[i - 2] : 0;
        }

        return dp.Last();
    }
}