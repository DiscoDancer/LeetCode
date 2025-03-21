class Solution {
    public int minCostClimbingStairs(int[] cost) {
        var prevPrev = 0;
        var prev = 0;

        for (int i = cost.length - 1; i >= 0; i--) {
            var cur = Math.min(prev, prevPrev) + cost[i];
            prevPrev = prev;
            prev = cur;
        }

        return Math.min(prev, prevPrev);
    }
}
