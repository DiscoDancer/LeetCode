import java.util.*;


class Solution {

    public int findLongestChain(int[][] pairs) {

        var state = new int[pairs.length];

        // Sort based on the first element of each row
        Arrays.sort(pairs, Comparator.comparingInt(a -> a[0]));

        var globalMax = pairs.length > 0 ? 1 : 0;

        for (var i = 0; i < pairs.length; i++) {
            if (i == 0) {
                state[i] = 1;
            } else {
                var max = 0;
                for (var j = 0; j < i; j++) {
                    if (pairs[j][1] < pairs[i][0]) {
                        max = Math.max(max, state[j]);
                    }
                }
                state[i] = max + 1;
                globalMax = Math.max(globalMax, state[i]);
            }
        }

        return globalMax;
    }
}
