public class Solution {
    public long MinCost(int[] nums, int[] costs) {
        var minCosts = new long[nums.Length];
        Array.Fill(minCosts, long.MaxValue);
        minCosts[0] = 0;

        for (int index = 0; index < nums.Length; index++) {
            // go forward <= + go forward > 
            for (int j = index + 1; j < nums.Length; j++) {
                var allKless = true;
                var allKBigger = true;
                for (int k = index + 1; k < j; k++) {
                    allKless &= nums[k] < nums[index];
                    allKBigger &= nums[k] >= nums[index];
                }
                if (allKless && nums[index] <= nums[j] || allKBigger && nums[index] > nums[j]) {
                    minCosts[j] = Math.Min(minCosts[j], minCosts[index] + costs[j]);
                }
            }
        }

        return minCosts[nums.Length - 1];
    }
}