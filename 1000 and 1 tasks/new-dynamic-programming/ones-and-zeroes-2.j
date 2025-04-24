import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    public record Row(int count0, int count1) {}
    private Row[] arr;

    public int findMaxForm(String[] strs, int m, int n) {

        arr = new Row[strs.length];
        for (var i = 0; i < strs.length; i++) {
            var s = strs[i];
            int count0 = 0;
            int count1 = 0;
            for (var c: s.toCharArray()) {
                if (c == '0') {
                    count0++;
                } else {
                    count1++;
                }
            }
            arr[i] = new Row(count0, count1);
        }

        var table = new int[strs.length + 1][m + 1][n + 1];

        for (var i = strs.length; i >= 0; i--) {
            for (var j = 0; j <= m; j++) {
                for (var k = 0; k <= n; k++) {
                    if (i == strs.length) {
                        table[i][j][k] = 0;
                    } else {
                        var cur = arr[i];
                        var take = 0;
                        // take the current element
                        if (j >= cur.count0 && k >= cur.count1) {
                            take = 1 + table[i + 1][j - cur.count0][k - cur.count1];
                        }
                        // skip the current element
                        var skip = table[i + 1][j][k];

                        table[i][j][k] = Math.max(take, skip);
                    }
                }
            }
        }

        return table[0][m][n];
    }
}
