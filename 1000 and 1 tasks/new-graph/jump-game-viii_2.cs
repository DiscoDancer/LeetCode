public class Solution {
    public long MinCost(int[] nums, int[] costs) {
        var minCosts = new long[nums.Length];
        Array.Fill(minCosts, long.MaxValue);
        minCosts[0] = 0;

        for (int j = 1; j < nums.Length; j++) {
            for (int i = j - 1; i >= 0; i--) {
                var allKless = true;
                var allKBigger = true;
                for (int k = i + 1; k < j; k++) {
                    allKless &= nums[k] < nums[i];
                    allKBigger &= nums[k] >= nums[i];
                }
                if (allKless && nums[i] <= nums[j] || allKBigger && nums[i] > nums[j]) {
                    minCosts[j] = Math.Min(minCosts[j], minCosts[i] + costs[j]);
                }
            }
        }

        return minCosts[nums.Length - 1];
    }
}