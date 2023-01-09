public class Solution {
    // Kadane algorithm
    public int MaxSubarraySumCircular(int[] nums) {
        var bestSum = 0;
        var curSum = 0;
        var max = nums[0];

        for (int start = 0; start < nums.Length; start++) {
            curSum = 0;
            for (int i = 0; i < nums.Length; i++) {
                var pos = (start + i) % nums.Length;
                var n = nums[pos];

                curSum = Math.Max(0, curSum + n);
                bestSum = Math.Max(curSum, bestSum);
                if (start == 0) {
                    max = Math.Max(max, n);
                }
            }
        }

        return max > 0 ? bestSum : max;
    }
}