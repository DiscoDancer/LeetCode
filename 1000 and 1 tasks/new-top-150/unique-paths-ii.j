import java.util.ArrayDeque;
import java.util.List;

class Solution {

    // see part i

    public int uniquePathsWithObstacles(int[][] obstacleGrid) {
        var m = obstacleGrid.length;
        var n = obstacleGrid[0].length;

        var curLine = new int[n];
        var prevLine = new int[n];

        for (var mi = 0; mi < m; mi++) {
            curLine = new int[n];
            for (var ni = 0; ni < n; ni++) {
                if (obstacleGrid[mi][ni] == 1) {
                    curLine[ni] = 0;
                }
                else if (mi == 0 && ni == 0) {
                    curLine[0] = 1;
                }
                else if (mi == 0) {
                    curLine[ni] = curLine[ni - 1];
                }
                else if (ni == 0) {
                    curLine[ni] = prevLine[ni];
                }
                else {
                    int takeTop = prevLine[ni];
                    int takeLeft = curLine[ni - 1];
                    curLine[ni] = takeTop + takeLeft;
                }
            }
            prevLine = curLine;
        }

        return prevLine[n - 1];
    }
}
