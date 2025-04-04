import java.util.*;

// memory limit

class Solution {

    private int[][] envelopes;

    private int F(int i, int prevI) {
        if (i == envelopes.length) {
            return 0;
        }

        var l = envelopes[prevI][0];
        var r = envelopes[prevI][1];

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


        var biggerCopy = new int[envelopes.length + 1][envelopes[0].length];
        for (int i = 0; i < envelopes.length; i++) {
            biggerCopy[i+1] = envelopes[i];
        }
        biggerCopy[0] = new int[]{0, 0};
        envelopes = biggerCopy;
        this.envelopes = envelopes;

        var table = new int[this.envelopes.length + 1][this.envelopes.length + 1];

        for (var i = envelopes.length; i >= 0; i--) {
            for (var prevI = envelopes.length - 1; prevI >= 0; prevI--) {
                if (i == envelopes.length) {
                    table[i][prevI] = 0;
                    continue;
                }

                var l = envelopes[prevI][0];
                var r = envelopes[prevI][1];

                var take = 0;
                // take
                if (l < envelopes[i][0] && r < envelopes[i][1]) {
                    take = 1 + table[i+1][i];
                }
                // skip
                var skip = table[i+1][prevI];

                table[i][prevI] = Math.max(take, skip);
            }
        }

        return table[1][0];
    }
}