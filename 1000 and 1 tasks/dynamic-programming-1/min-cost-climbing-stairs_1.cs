public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        if (cost.Length == 2) {
            return cost.Min();
        }

        var prevPrev = 0;
        var prev = 0;

        for (int i = 2; i <= cost.Length; i++) {
            var cur = Math.Min(prev + cost[i-1], prevPrev + cost[i-2]);
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}