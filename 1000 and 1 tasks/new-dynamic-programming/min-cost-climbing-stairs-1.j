class Solution {

    private int[] cost;

    private int F(int i) {
        if (i >= cost.length) {
            return 0;
        }
        
        var option1 = F(i+1);
        var option2 = F(i+2);
        
        return Math.min(option1, option2) + cost[i];
    }

    public int minCostClimbingStairs(int[] cost) {
        this.cost = cost;
        
        return Math.min(F(0), F(1));
    }
}
