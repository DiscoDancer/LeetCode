import java.util.Arrays;

// brut force, TL

class Solution {
    public int maxSubArray(int[] nums) {

        var max = Integer.MIN_VALUE;

        for (int length = 1; length <= nums.length; length++) {

            for (int start = 0; start < nums.length; start++) {
                var sum = 0;
                var count = 0;
                for (int i = start; i < nums.length && count < length; i++) {
                    sum += nums[i];
                    count++;
                }
                max = Math.max(max, sum);
            }
        }


        return max;
    }
}