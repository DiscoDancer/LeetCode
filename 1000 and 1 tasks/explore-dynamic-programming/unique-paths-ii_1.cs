public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var row = new int[n];
        row[0] = obstacleGrid[0][0] == 1 ? 0 : 1;
        for (int i = 1; i < n; i++) {
            if (obstacleGrid[0][i] != 1) {
                row[i] = row[i-1];
            }
        }

        for (var x = 1; x < m; x++) {
            for (var y = 0; y < n; y++) {
                if (obstacleGrid[x][y] == 1) {
                     row[y] = 0;
                }
                else if (y == 0) {
                    // table[x,y] = table[x-1, y];
                }
                else {
                    row[y] = row[y-1] + row[y];
                    // table[x,y] = table[x,y-1] + table[x-1, y];
                }
            }
        }

        return row.Last();
    }
}