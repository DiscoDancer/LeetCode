import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

// see part i

class Solution {
    public int uniquePathsWithObstacles(int[][] obstacleGrid) {

        var m = obstacleGrid.length;
        var n = obstacleGrid[0].length;

        var table = new int[m][n];

        for (var mi = 0; mi < m; mi++) {
            for (var ni = 0; ni < n; ni++) {
                if (obstacleGrid[mi][ni] == 1) {
                    table[mi][ni] = 0;
                } else if (mi == 0 && ni == 0) {
                    table[mi][ni] = 1;
                } else if (mi == 0) {
                    table[mi][ni] = table[mi][ni - 1];
                } else if (ni == 0) {
                    table[mi][ni] = table[mi - 1][ni];
                } else {
                    table[mi][ni] = table[mi - 1][ni] + table[mi][ni - 1];
                }
            }
        }


        return table[m - 1][n - 1];
    }
}
