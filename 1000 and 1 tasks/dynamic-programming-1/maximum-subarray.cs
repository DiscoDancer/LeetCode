public class Solution {
    // Kadane algorithm
    public int MaxSubArray(int[] nums) {
        var bestSum = 0;
        var curSum = 0;
        var max = nums[0];
        foreach (var n in nums) {
            curSum = Math.Max(0, curSum + n);
            bestSum = Math.Max(curSum, bestSum);
            max = Math.Max(max, n);
        }

        return max > 0 ? bestSum : max;
    }
}