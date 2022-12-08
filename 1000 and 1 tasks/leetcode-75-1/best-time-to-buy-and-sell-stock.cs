public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length == 1) {
            return 0;
        }

        var min = prices[0];
        var max = 0;
        for (int i = 1; i < prices.Length; i++) {
            min = Math.Min(min, prices[i]);
            max = Math.Max(max, prices[i] - min);
        }

        return max;
    }
}