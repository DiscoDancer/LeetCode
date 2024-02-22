public class Solution {
    // not optimal
    public double FindMaxAverage(int[] nums, int k) {

        var max = double.MinValue;
        var l = k;
        var r = nums.Length;
        while (l <= r) {
            max = Math.Max(FindMaxExactAverage(nums,l), max);
            l++;
        }

        return max;
    }

    
    public double FindMaxExactAverage(int[] nums, int k) {
        long maxSum = 0;
        for (int i = 0; i < k; i++) {
            maxSum += nums[i];
        }

        long sum = maxSum;
        for (int i = 0; i < nums.Length - k; i++) {
            sum = sum - nums[i] + nums[i+k];
            maxSum = Math.Max(maxSum, sum);
        }

        return (double) maxSum / k;
    }
}