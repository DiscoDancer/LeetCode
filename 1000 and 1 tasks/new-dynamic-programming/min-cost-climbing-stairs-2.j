class Solution {
    public int minCostClimbingStairs(int[] cost) {
        var table = new int[cost.length + 2];
        for (int i = cost.length - 1; i >= 0; i--) {
            table[i] = Math.min(table[i+1], table[i+2]) + cost[i];
        }

        return Math.min(table[0], table[1]);
    }
}
