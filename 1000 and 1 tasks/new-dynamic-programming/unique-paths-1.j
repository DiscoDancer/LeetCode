import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int uniquePaths(int m, int n) {
        var prevLine = new int[n];
        Arrays.fill(prevLine, 1);

        for (var mi = 1; mi < m; mi++) {
            var curLine = new int[n];
            for (var ni = 0; ni < n; ni++) {
                if (mi == 0 || ni == 0) {
                    curLine[ni] = 1;
                } else {
                    curLine[ni] = prevLine[ni] + curLine[ni - 1];
                }
            }
            prevLine = curLine;
        }


        return prevLine[n - 1];
    }
}
