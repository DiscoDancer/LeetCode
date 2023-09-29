public class Solution {
    // середина посчитается 2 раза
    public int DiagonalSum(int[][] mat) {
        var n = mat.Length;

        var result = 0;
        for (int i = 0; i < n; i++) {
            result += mat[i][i];
            result += mat[i][n-1 - i];
        }

        if (n % 2 == 1) {
            result -= mat[n/2][n/2];
        }

        return result;
    }
}