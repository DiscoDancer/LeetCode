import java.math.BigInteger;
import java.util.*;

// TL

class Solution {

    private int[][] envelopes;
    private int max;

    private void f(int maxW, int maxH, int i, int score) {
        if (i == envelopes.length) {
            this.max = Math.max(this.max, score);
            return;
        }

        int w = envelopes[i][0];
        int h = envelopes[i][1];

        // Skip current envelope
        f(maxW, maxH, i + 1, score);

        // Take current envelope if it fits
        if (w > maxW && h > maxH) {
            f(w, h, i + 1, score + 1);
        }
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

        f(0, 0, 0, 0);

        return this.max;
    }
}
