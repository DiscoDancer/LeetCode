public class Solution {
    // https://leetcode.com/problems/edit-distance/solutions/3040251/edit-distance/?envType=study-plan&id=dynamic-programming-i&orderBy=most_votes
    public int MinDistance(string word1, string word2) {
        if (word1.Length == 0) {
            return word2.Length;
        }
        if (word2.Length == 0) {
            return word1.Length;
        }

        var dp = new int[word1.Length + 1][];
        for (int i = 0; i <= word1.Length; i++) {
            dp[i] = new int[word2.Length + 1];
        }

        for (int word1Index = 1; word1Index <= word1.Length; word1Index++) {
            dp[word1Index][0] = word1Index;
        }

        for (int word2Index = 1; word2Index <= word2.Length; word2Index++) {
            dp[0][word2Index] = word2Index;
        }

        for (int i = 1; i <= word1.Length; i++) {
            for (int j = 1; j <= word2.Length; j++) {
                if (word1[i-1] == word2[j-1]) {
                    dp[i][j] = dp[i-1][j-1];
                }
                else {
                    var deleteResult = 1 + dp[i-1][j];
                    var replaceResult = 1 + dp[i-1][j-1];
                    var addResult = 1 + dp[i][j-1];

                    dp[i][j] = Math.Min(deleteResult, replaceResult);
                    dp[i][j] = Math.Min(dp[i][j], addResult);
                }
            }
        }



        return dp.Last().Last();
    }
}