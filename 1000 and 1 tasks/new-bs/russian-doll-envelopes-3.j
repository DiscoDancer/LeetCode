import java.math.BigInteger;
import java.util.*;

// editorial TL

class Solution {
    public int maxEnvelopes(int[][] envelopes) {

        // sort on increasing in first dimension and decreasing in second
        Arrays.sort(envelopes, (arr1, arr2) -> {
            if (arr1[0] == arr2[0]) {
                return arr2[1] - arr1[1];
            } else {
                return arr1[0] - arr2[0];
            }
        });

        var table = new int[envelopes.length + 1];
        Arrays.fill(table, 1);

        var max = Math.min(1, envelopes.length);
        for (var i = envelopes.length - 1; i >= 0; i--) {
            for (var j = i + 1; j < envelopes.length; j++) {
                if (envelopes[i][0] != envelopes[j][0] && envelopes[i][1] < envelopes[j][1]) {
                    table[i] = Math.max(table[i], table[j] + 1);
                    max = Math.max(max, table[i]);
                }
            }

        }

        return max;
    }
}