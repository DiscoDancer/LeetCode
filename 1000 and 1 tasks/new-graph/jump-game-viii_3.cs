public class Solution {
    public long MinCost(int[] nums, int[] costs) {
        var minCosts = new long[nums.Length];
        Array.Fill(minCosts, long.MaxValue);
        minCosts[0] = 0;

        for (int j = 1; j < nums.Length; j++) {
            var i = j - 1;
            var maxK = long.MinValue;
            while (i >= 0) {
                if (nums[i] > maxK && nums[i] <= nums[j]) {
                    minCosts[j] = Math.Min(minCosts[j], minCosts[i] + costs[j]);
                }
                maxK = Math.Max(maxK, nums[i]);
                i--;
            }

            var minK = long.MaxValue;
            i = j - 1;
            while (i >= 0) {
                if (nums[i] > nums[j] && minK >= nums[i]) {
                    minCosts[j] = Math.Min(minCosts[j], minCosts[i] + costs[j]);
                }  
                minK = Math.Min(minK, nums[i]);
                i--;
            }
        }

        return minCosts[nums.Length - 1];
    }
}