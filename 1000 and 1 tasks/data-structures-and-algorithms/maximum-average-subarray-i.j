import java.math.BigInteger;
import java.util.*;

class Solution {

    public double findMaxAverage(int[] nums, int k) {
        double sum = 0;
        for (var i = 0; i < k; i++) {
            sum += nums[i];
        }
        var max = sum / k;

        var countOfShifts = nums.length - k;

        for (var prevFirstIndex = 0; prevFirstIndex < countOfShifts; prevFirstIndex++) {
            sum -= nums[prevFirstIndex];
            sum += nums[prevFirstIndex + k];
            max = Math.max(max, sum / k);
        }

        return max;
    }
}