public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        if (cost.Length == 2) {
            return cost.Min();
        }

        var res = new int[cost.Length + 1];
        res[0] = 0;
        res[1] = 0;

        for (int i = 2; i <= cost.Length; i++) {
            res[i] = Math.Min(res[i-1] + cost[i-1], res[i-2] + cost[i-2]);
        }

        return res.Last();
    }
}