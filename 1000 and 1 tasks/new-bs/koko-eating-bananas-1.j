import java.math.BigInteger;
import java.util.*;

// still TL

class Solution {

    public int minEatingSpeed(int[] piles, int h) {
        var max = Arrays.stream(piles).max().orElse(0);

        // k - speed, bananas per hour
        for (var k = 1; k <= max; k++) {
            long requiredHours = 0;

            for (var pile : piles) {
                long x = pile / k;
                long r = pile % k;
                requiredHours += x + (r > 0 ? 1 : 0);
            }

            if (requiredHours <= h) {
                return k;
            }
        }

        return 42;
    }
}