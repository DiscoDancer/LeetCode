import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedList;

class Solution {
    public int maxSubArray(int[] nums) {

        long max = Integer.MIN_VALUE;

        var lastPositiveSum = 0;
        var lastNegativeSum = 0;
        var curPositiveSum = 0;
        var curNegativeSum = 0;

        final int PLUS = 1;
        final int MINUS = 2;

        var prevSign = PLUS;

        for (int i = 0; i < nums.length; i++) {
            max = Math.max(max, nums[i]);

            var sign = nums[i] >= 0 ? PLUS : MINUS;
            if (sign != prevSign) {
                if (sign == PLUS) {
                    lastNegativeSum = curNegativeSum;
                    curNegativeSum = 0;

                    curPositiveSum += Math.max(0, lastNegativeSum + lastPositiveSum);
                }
                else {
                    lastPositiveSum = curPositiveSum;
                    curPositiveSum = 0;
                }
            }
            if (sign == PLUS) {
                curPositiveSum += nums[i];

            } else {
                curNegativeSum += nums[i];
            }
            if (nums[i] > 0) {
                max = Math.max(max, curPositiveSum);
            }
            prevSign = sign;
        }

        return (int)max;
    }
}