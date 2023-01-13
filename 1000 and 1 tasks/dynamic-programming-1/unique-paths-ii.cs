public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var prev = new int[n];
        var k = 0;
        while (k < n && obstacleGrid[0][k] == 0) {
            prev[k++] = 1;
        }
        // на выходе 11100000 если есть препятствие

        // остальные ряды
        for (int i = 1; i < m; i++) {
            var cur = new int[n];

            if (obstacleGrid[i][0] == 1 || prev[0] == 0) {
                cur[0] = 0;
            }
            else {
                cur[0] = 1;
            }

            for (int j = 1; j < n; j++) {
                if (obstacleGrid[i][j] == 1) {
                    continue;
                }
                cur[j] = prev[j] + cur[j-1];
            }

            prev = cur;
        }

        return prev.Last();
    }
}