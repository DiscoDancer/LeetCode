import java.math.BigInteger;
import java.util.*;

// see koko-eating-bananas

class Solution {

    private int[] nums;
    private int threshold;

    private boolean F(int divisor) {
        if (divisor <= 0) {
            return false;
        }

        var sum = 0;
        for (var x: nums) {
            sum += x / divisor;
            if (x % divisor != 0) {
                sum++;
            }
        }
        return sum <= threshold;
    }

    public int smallestDivisor(int[] nums, int threshold) {

        this.nums = nums;
        this.threshold = threshold;

        var max = Arrays.stream(nums).max().orElse(1);
        var min = 1;



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