import java.math.BigInteger;
import java.util.*;

class Solution {

    private int[] piles;
    private int h;

    public boolean F(int k) {
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

        // k - speed, bananas per hour
        for (var k = 1; k <= max; k++) {
            if (F(k)) {
                return k;
            }
        }

        return 42;
    }
}