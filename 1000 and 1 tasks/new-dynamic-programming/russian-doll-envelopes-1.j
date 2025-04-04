import java.util.*;

class Solution {

    private int[][] envelopes;

    private int F(int i, int l, int r) {
        if (i == envelopes.length) {
            return 0;
        }

        var take = 0;
        // take
        if (l < envelopes[i][0] && r < envelopes[i][1]) {
            take = 1 + F(i + 1, envelopes[i][0], envelopes[i][1]);
        }
        // skip
        var skip = F(i + 1, l, r);

        return Math.max(take, skip);
    }

    public int maxEnvelopes(int[][] envelopes) {
        // Sort based on the first element of each row
        Arrays.sort(envelopes, (a, b) -> Integer.compare(a[0], b[0]));
        this.envelopes = envelopes;

        return F(0, 0, 0);
    }
}