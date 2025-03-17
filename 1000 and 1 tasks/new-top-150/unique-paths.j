import java.util.ArrayDeque;
import java.util.List;

class Solution {

    public int uniquePaths(int m, int n) {
        var table = new int[m][n];


        for (var mi = 0; mi < m; mi++) {
            for (var ni = 0; ni < n; ni++) {
                if (mi == 0 && ni == 0) {
                    table[0][0] = 1;
                }
                else {
                    int takeTop = mi > 0 ? table[mi - 1][ni] : 0;
                    int takeLeft = ni > 0 ? table[mi][ni - 1] : 0;
                    table[mi][ni] = takeTop + takeLeft;
                }
            }
        }

        return table[m - 1][n - 1];
    }
}
