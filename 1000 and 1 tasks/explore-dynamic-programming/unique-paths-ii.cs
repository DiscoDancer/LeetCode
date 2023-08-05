public class Solution {
    // reuse solution for I
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var table = new int[m, n];

        for (var x = 0; x < m; x++) {
            for (var y = 0; y < n; y++) {
                if (obstacleGrid[x][y] == 1) {
                     table[x,y] = 0;
                }
                else if (x == 0 && y == 0) {
                    table[x,y] = 1;
                }
                else if (x == 0) {
                    table[x,y] = table[x,y-1]; 
                }
                else if (y == 0) {
                    table[x,y] = table[x-1, y];
                }
                else {
                    table[x,y] = table[x,y-1] + table[x-1, y];
                }
            }
        }

        return table[m-1,n-1];
    }
}