import java.math.BigInteger;
import java.util.*;

// TL

class Solution {

    public int minEatingSpeed(int[] piles, int h) {
        var max = Arrays.stream(piles).max().orElse(0);

        // k - speed, bananas per hour
        for (var k = 1; k <= max; k++) {
            var requiredHours = 0;

            for (var pile : piles) {
                long remaining = pile;
                while (remaining > 0) {
                    requiredHours++;
                    remaining -= k;
                }
            }

            if (requiredHours <= h) {
                return k;
            }
        }

        return 42;
    }
}