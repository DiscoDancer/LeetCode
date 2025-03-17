import java.util.ArrayDeque;
import java.util.List;

class Solution {

    public int uniquePaths(int m, int n) {
        // var table = new int[m][n];

        var curLine = new int[n];
        var prevLine = new int[n];


        for (var mi = 0; mi < m; mi++) {
            curLine = new int[n];
            for (var ni = 0; ni < n; ni++) {
                if (mi == 0 && ni == 0) {
                    curLine[0] = 1;
                }
                else if (mi == 0 || ni == 0) {
                    curLine[ni] = 1;
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
