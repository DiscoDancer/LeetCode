public class Solution {
    // editorial
    // хуй догадаешься до всех условий
    public int MaxSubarraySumCircular(int[] nums) {
        var bestMax = -1000001;
        var curMax = bestMax;
        var sum = 0;
        var bestMin = 1000001;
        var curMin = bestMin;

        foreach (var n in nums) {
            curMax = Math.Max(n + curMax, n);
            bestMax = Math.Max(curMax, bestMax);

            sum += n;

            curMin = Math.Min(n + curMin, n);
            bestMin = Math.Min(curMin, bestMin);
        }

        if (sum == bestMin) {
            return bestMax;
        }

        return Math.Max(sum-bestMin, bestMax);
    }
}