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

        for (int i = 2; i < n+1; i++) {
            price[i] = Math.Min(cost[i-1] + price[i-1], cost[i-2] + price[i-2]); 
        }

        return price.Last();
    }
}