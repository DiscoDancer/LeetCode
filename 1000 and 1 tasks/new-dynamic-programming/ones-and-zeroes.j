import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


// TL


class Solution {

    public record Row(int count0, int count1) {}
    private Row[] arr;
    private int maxScore = 0;

    private void F(int i, int count0, int count1, int score) {
        maxScore = Math.max(maxScore, score);
        if (i >= arr.length) {
            return;
        }

        var cur = arr[i];
        // take the current element
        if (count0 >= cur.count0 && count1 >= cur.count1) {
            F(i + 1, count0 - cur.count0, count1 - cur.count1, score + 1);
        }
        // skip the current element
        F(i + 1, count0, count1, score);
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

        F(0, m, n, 0);

        return this.maxScore;
    }
}
