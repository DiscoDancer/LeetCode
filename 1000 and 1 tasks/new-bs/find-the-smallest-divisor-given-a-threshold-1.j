import java.math.BigInteger;
import java.util.*;

class Solution {

    private int[] nums;
    private int threshold;

    private boolean F(int divisor) {
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

        for (var divisor = min; divisor <= max; divisor++) {
            if (F(divisor)) {
                return divisor;
            }
        }

        return 42;
    }
}