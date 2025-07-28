import java.util.Arrays;

class Solution {
    public int missingNumber(int[] nums) {
        long actualSum = 0;
        var min = nums[0];
        var max = nums[0];

        for (var x: nums) {
            actualSum += x;
            min = Math.min(min, x);
            max = Math.max(max, x);
        }

        if (min == 1) {
            return 0;
        }

        var expectedSumNoMissing = ((double)(min+max))/2*(nums.length);
        if (expectedSumNoMissing == actualSum && max == min + nums.length - 1) {
            return max + 1;
        }

        var expectedSum = ((double)(min+max))/2*(nums.length+1);

        var result = (int) (expectedSum - actualSum);
        if (result == 0) {
            return max + 1;
        }
        return result;
    }
}