import java.util.*;

class Solution {
    public int maxEnvelopes(int[][] envelopes) {
        // Sort by first element, then by second element
        Arrays.sort(envelopes, (a, b) -> {
            if (a[0] != b[0]) {
                return Integer.compare(a[0], b[0]);
            } else {
                return Integer.compare(a[1], b[1]);
            }
        });

        var table = new int[envelopes.length];

        var globalMax = 1;

        for (var i = envelopes.length - 1; i >= 0; i--) {
            if (i == envelopes.length - 1) {
                table[i] = 1;
            } else {
                var max = 0;
                for (var j = i + 1; j < envelopes.length; j++) {
                    // 0 надо тоже проверять, потому что могут быть равны и тогда не подходит
                    // но я могу сразу прыгнуть как надо в отношении 0
                    if (envelopes[j][0] > envelopes[i][0] && envelopes[j][1] > envelopes[i][1]) {
                        max = Math.max(max, table[j]);
                    }
                }
                table[i] = max + 1;
                globalMax = Math.max(globalMax, table[i]);
            }
        }


        return globalMax;
    }
}