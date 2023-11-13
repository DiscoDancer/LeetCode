public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        var prev1 = 0;
        var prev2 = 0;

        for (int i = 2; i < cost.Length + 1; i++) {
            var tmp = prev1;
            prev1 = Math.Min(cost[i-1] + prev1, cost[i-2] + prev2);
            prev2 = tmp;
        }

        return prev1;
    }
}