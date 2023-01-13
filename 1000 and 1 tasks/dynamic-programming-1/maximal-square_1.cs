public class Solution {
    // https://leetcode.com/problems/maximal-square/solutions/127442/maximal-square/?orderBy=most_votes
    public int MaximalSquare(char[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var table = new int[m+1][];
        table[0] = new int[n+1];
        var max = 0;

        for (int i = 1; i <= m; i++) {
            table[i] = new int[n+1];
            for (int j = 1; j <= n; j++)  {
                if (matrix[i-1][j-1] != '1') continue;

                table[i][j] = Math.Min(Math.Min(table[i][j - 1], table[i - 1][j]), table[i - 1][j - 1]) + 1;
                max = Math.Max(max, table[i][j]);
            }
        }

        return max*max;
    }
}