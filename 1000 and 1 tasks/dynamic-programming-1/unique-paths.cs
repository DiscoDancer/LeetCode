public class Solution {
    public int UniquePaths(int m, int n) {
        var table = new int[m][];

        for (int i = 0; i < m; i++) {
            table[i] = new int[n];
            for (int j = 0; j < n; j++) {
                if (i == 0 || j == 0) {
                    table[i][j] = 1;
                }
                else {
                    table[i][j] = table[i-1][j] + table[i][j-1];
                }
            }
        }

        return table.Last().Last();
    }
}