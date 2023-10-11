public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        long sum = 0;

        for (int i = 0; i < k; i++) {
            sum += nums[i];
        }

        var max = sum;

        for (int i = k; i < nums.Length; i++) {
            sum -= nums[i-k];
            sum += nums[i];

            max = Math.Max(max, sum);
        }

        return (double)max / k;
    }
}