import java.util.*;

// TL

class Solution {

    private int[][] envelopes;
    private int max = 0;

    private void F(int i, int l, int r, int score) {
        if (i == envelopes.length) {
            this.max = Math.max(this.max, score);
            return;
        }

        // take
        if (l < envelopes[i][0] && r < envelopes[i][1]) {
            F(i + 1, envelopes[i][0], envelopes[i][1], score + 1);
        }
        // skip
        F(i + 1, l, r, score);
    }

    public int maxEnvelopes(int[][] envelopes) {
        // Sort based on the first element of each row
        Arrays.sort(envelopes, (a, b) -> Integer.compare(a[0], b[0]));
        this.envelopes = envelopes;

        F(0, 0, 0, 0);

        return this.max;
    }
}