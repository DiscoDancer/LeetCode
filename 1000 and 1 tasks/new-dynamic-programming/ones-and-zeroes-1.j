import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    public record Row(int count0, int count1) {}
    private Row[] arr;

    private int F(int i, int count0, int count1) {
        if (i >= arr.length) {
            return 0;
        }

        var cur = arr[i];
        var take = 0;
        // take the current element
        if (count0 >= cur.count0 && count1 >= cur.count1) {
            take = 1 + F(i + 1, count0 - cur.count0, count1 - cur.count1);
        }
        // skip the current element
        var skip = F(i + 1, count0, count1);

        return Math.max(take, skip);
    }

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

        return F(0, m, n);
    }
}
