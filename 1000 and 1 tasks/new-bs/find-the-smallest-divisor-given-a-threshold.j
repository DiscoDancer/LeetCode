import java.math.BigInteger;
import java.util.*;

class Solution {

    public int smallestDivisor(int[] nums, int threshold) {
        var max = Arrays.stream(nums).max().orElse(1);

        for (var divisor = 1; divisor <= max; divisor++) {
            var sum = 0;
            for (var x: nums) {
                sum += x / divisor;
                if (x % divisor != 0) {
                    sum++;
                }
            }

            if (sum <= threshold) {
                return divisor;
            }
        }

        return 42;
    }
}