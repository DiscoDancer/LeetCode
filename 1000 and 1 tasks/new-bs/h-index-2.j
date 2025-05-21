import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;

// based on my previous or editorial

class Solution {

    public int hIndex(int[] citations) {
        var table = new int[1003];
        for (var c: citations) {
            table[c]++;
        }

        var acc = 0;
        for (int i = 1000; i >= 0; i--) {
            var old = table[i];
            table[i] += acc;
            acc += old;
        }

        var l = 0;
        var r = 1000;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (m <= table[m] && m+1 > table[m+1]) {
                return m;
            } else if (m > table[m]) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return -1;
    }
}
