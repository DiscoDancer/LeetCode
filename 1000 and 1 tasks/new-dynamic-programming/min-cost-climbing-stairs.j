class Solution {

    // TL

    private int[] cost;
    private int min = Integer.MAX_VALUE;

    private void F(int i, int sum) {
        if (i >= cost.length) {
            min = Math.min(min, sum);
            return;
        }

        F(i+1, sum + cost[i]);
        F(i+2, sum + cost[i]);
    }

    public int minCostClimbingStairs(int[] cost) {
        this.cost = cost;

        F(0, 0);
        F(1, 0);

        return min;
    }
}
