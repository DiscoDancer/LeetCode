public class Solution {    
    // https://leetcode.com/submissions/detail/686550394/
    public int MaxSubarraySumCircular(int[] nums) {
        int curSum = nums[0];
        int maxSum = nums[0];
        
        for (int i = 1; i < nums.Length; i++) {
            curSum = Math.Max(nums[i], curSum + nums[i]);
            maxSum = Math.Max(maxSum, curSum);
        }
        
        var sum = nums.Aggregate((x,y) => x + y);
        
        curSum = nums[0];
        var minSum = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            curSum = Math.Min(nums[i], curSum + nums[i]);
            minSum = Math.Min(minSum, curSum);
        }

        return maxSum > 0 ? Math.Max(maxSum, sum - minSum) : nums.Max();
    }
}