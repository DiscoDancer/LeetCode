public class Solution {
    public int MaxSubArray(int[] nums) {
        int curSum = nums[0];
        int maxSum = nums[0];
        
        for (int i = 1; i < nums.Length; i++) {
            curSum = Math.Max(nums[i], curSum + nums[i]);
            maxSum = Math.Max(maxSum, curSum);
        }

        return maxSum;
    }
}