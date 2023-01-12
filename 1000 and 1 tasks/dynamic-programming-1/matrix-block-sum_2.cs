public class Solution {
    // https://leetcode.com/problems/matrix-block-sum/solutions/477041/java-prefix-sum-with-picture-explain-clean-code-o-m-n/
    public int[][] MatrixBlockSum(int[][] mat, int K) {
        int m = mat.Length, n = mat[0].Length;

        var sum = new int[m + 1][]; // sum[i][j] is sum of all elements from rectangle (0,0,i,j) as left, top, right, bottom corresponding
        sum[0] = new int[n+1];
        for (int r = 1; r <= m; r++) {
            sum[r] = new int[n+1];
            for (int c = 1; c <= n; c++) {
                sum[r][c] = mat[r - 1][c - 1] + sum[r - 1][c] + sum[r][c - 1] - sum[r - 1][c - 1];
            }
        }

        // можно и потупее заполнить за 3 прохода n*m: строки, столбы и все вместе

        /*
        пример строк
                Table = new int[Rows][];
        for (int i = 0; i < Rows; i++) {
            Table[i] = new int[Rows + 1];
            for (int j = 0; j < Cols; j++) {
                Table[i][j+1] = Table[i][j] + mat[i][j];
            }
        }
        */

       var ans = new int[m][];
        for (int r = 0; r < m; r++) {
            ans[r] = new int[n];
            for (int c = 0; c < n; c++) {
                int r1 = Math.Max(0, r - K), c1 = Math.Max(0, c - K);
                int r2 = Math.Min(m - 1, r + K), c2 = Math.Min(n - 1, c + K);
                r1++; c1++; r2++; c2++; // Since `sum` start with 1 so we need to increase r1, c1, r2, c2 by 1
                ans[r][c] = sum[r2][c2] - sum[r2][c1-1] - sum[r1-1][c2] + sum[r1-1][c1-1];
            }
        }
        return ans;
    }
}