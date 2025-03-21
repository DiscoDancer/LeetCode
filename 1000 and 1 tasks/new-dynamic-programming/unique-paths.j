import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int uniquePaths(int m, int n) {

        var table = new int[m][n];

        for (var mi = 0; mi < m; mi++) {
            for (var ni = 0; ni < n; ni++) {
                if (mi == 0 || ni == 0) {
                    table[mi][ni] = 1;
                } else {
                    table[mi][ni] = table[mi - 1][ni] + table[mi][ni - 1];
                }
            }
        }


        return table[m - 1][n - 1];
    }
}
