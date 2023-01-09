public class Solution {
    // Kadane algorithm
    public int MaxSubArray(int[] nums, int start) {
        var bestSum = 0;
        var curSum = 0;
        var max = nums[0];

        for (int i = 0; i < nums.Length; i++) {
            var pos = (start + i) % nums.Length;
            var n = nums[pos];

            curSum = Math.Max(0, curSum + n);
            bestSum = Math.Max(curSum, bestSum);
            max = Math.Max(max, n);
        }
        return max > 0 ? bestSum : max;
    }

    // n*n
    public int MaxSubarraySumCircular(int[] nums) {
        var max = int.MinValue;
        for (int start = 0; start < nums.Length; start++) {
            max = Math.Max(max, MaxSubArray(nums, start));
        }

        return max;
    }
}