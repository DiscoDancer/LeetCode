import java.math.BigInteger;
import java.util.*;

// TL

class Solution {

    private int[][] envelopes;

    private int f(int maxW, int maxH, int i) {
        if (i == envelopes.length) {
            return 0;
        }

        int w = envelopes[i][0];
        int h = envelopes[i][1];

        var skip = f(maxW, maxH, i + 1);

        if (w > maxW && h > maxH) {
            var take = 1 + f(w, h, i + 1);
            return Math.max(skip, take);
        }

        return skip;
    }

    public int maxEnvelopes(int[][] envelopes) {

        // Sort by 0, then by 1
        Arrays.sort(envelopes, (a, b) -> {
            if (a[0] != b[0]) {
                return Integer.compare(a[0], b[0]);
            } else {
                return Integer.compare(a[1], b[1]);
            }
        });
        this.envelopes = envelopes;

        return f(0, 0, 0);
    }
}
