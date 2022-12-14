public class Solution {
    // посчитать массивчик, а потом итеративно
    public int MinCostClimbingStairs(int[] cost) {
        var n = cost.Length;
        if (n < 3) {
            return cost.Min();
        }

        var price = new int[n+1];
        price[0] = 0;
        price[1] = 0;

        var cur = -1;
        var tmp = -1;
        var pr0 = 0;
        var pr1 = 0;

        for (int i = 2; i < n+1; i++) {
            tmp = pr0;
            cur = Math.Min(cost[i-1] + pr0, cost[i-2] + pr1); 
            pr0 = cur;
            pr1 = tmp; 
        }

        return cur;
    }
}