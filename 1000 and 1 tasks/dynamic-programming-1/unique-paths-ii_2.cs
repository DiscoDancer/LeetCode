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
            for (int j = 0; j < n; j++) {
                if (obstacleGrid[i][j] == 1) {
                    prev[j] = 0;
                }
                else if (j != 0) {
                    prev[j] = prev[j] + prev[j-1];
                }
            }
        }

        return prev.Last();
    }
}