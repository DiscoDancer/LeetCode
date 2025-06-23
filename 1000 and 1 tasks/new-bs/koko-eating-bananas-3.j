import java.math.BigInteger;
import java.util.*;

class Solution {

    private int[] piles;
    private int h;

    public boolean F(int k) {
        // important check due to my bs
        if (k <= 0) {
            return false;
        }

        long requiredHours = 0;

        for (var pile : piles) {
            long x = pile / k;
            long r = pile % k;
            requiredHours += x + (r > 0 ? 1 : 0);
        }

        return requiredHours <= h;
    }

    public int minEatingSpeed(int[] piles, int h) {
        this.piles = piles;
        this.h = h;

        var max = Arrays.stream(piles).max().orElse(0);

        var l = 1;
        var r = max;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (F(m) && (m == 0 || !F(m - 1))) {
                return m;
            } else if (F(m)) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return 42;
    }
}