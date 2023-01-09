public class Solution {
    // https://leetcode.com/problems/maximum-sum-circular-subarray/solutions/2868539/maximum-sum-circular-subarray/?envType=study-plan&id=dynamic-programming-i
    public int MaxSubarraySumCircular(int[] nums) {
        var bestMaxSum = nums[0];
        var curMaxSum = 0;

        var bestMinSum = nums[0];
        var curMinSum = 0;

        var sum = 0;

        foreach (var n in nums) {
            curMaxSum = Math.Max(0, curMaxSum) + n;
            bestMaxSum = Math.Max(curMaxSum, bestMaxSum);

            curMinSum = Math.Min(0, curMinSum) + n;
            bestMinSum = Math.Min(curMinSum, bestMinSum);

            sum += n;
        }

        return sum == bestMinSum ? bestMaxSum : Math.Max(bestMaxSum, sum - bestMinSum);
    }
}