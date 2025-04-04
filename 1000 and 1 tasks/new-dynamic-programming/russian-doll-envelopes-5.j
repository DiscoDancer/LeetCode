import java.util.*;

class Solution {
    public int maxEnvelopes(int[][] envelopes) {
        // Sort based on the first element of each row
        Arrays.sort(envelopes, (a, b) -> Integer.compare(a[0], b[0]));

        var table = new int[envelopes.length];

        var globalMax = 1;

        for (var i = envelopes.length - 1; i >= 0; i--) {
            if (i == envelopes.length - 1) {
                table[i] = 1;
            } else {
                var max = 0;
                for (var j = i + 1; j < envelopes.length; j++) {
                    // 0 надо тоже проверять, потому что могут быть равны и тогда не подходит
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