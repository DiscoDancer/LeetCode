import java.util.*;

// TL
// но меньше размерность

class Solution {

    private int[][] envelopes;

    private int F(int i, int prevI) {
        if (i == envelopes.length) {
            return 0;
        }

        var l = prevI == -1 ? 0 : envelopes[prevI][0];
        var r = prevI == -1 ? 0 : envelopes[prevI][1];

        var take = 0;
        // take
        if (l < envelopes[i][0] && r < envelopes[i][1]) {
            take = 1 + F(i + 1, i);
        }
        // skip
        var skip = F(i + 1, prevI);

        return Math.max(take, skip);
    }

    public int maxEnvelopes(int[][] envelopes) {
        // Sort based on the first element of each row
        Arrays.sort(envelopes, (a, b) -> Integer.compare(a[0], b[0]));
        this.envelopes = envelopes;

        return F(0, -1);
    }
}