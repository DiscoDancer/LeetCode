import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// editorial


class Solution {

    public record Row(int count0, int count1) {
    }

    public int findMaxForm(String[] strs, int m, int n) {

        var arr = new Row[strs.length];
        for (var i = 0; i < strs.length; i++) {
            var s = strs[i];
            int count0 = 0;
            int count1 = 0;
            for (var c : s.toCharArray()) {
                if (c == '0') {
                    count0++;
                } else {
                    count1++;
                }
            }
            arr[i] = new Row(count0, count1);
        }

        var count0 = m;
        var count1 = n;

        var table = new int[count0 + 1][count1 + 1];

        for (var row: arr) {
            for (var cur0 = count0; cur0 >= row.count0; cur0--) {
                for (var cur1 = count1; cur1 >= row.count1; cur1--) {
                    table[cur0][cur1] = Math.max(table[cur0][cur1], table[cur0 - row.count0][cur1 - row.count1] + 1);
                }
            }
        }

        return table[count0][count1];
    }
}
