public class Solution {
    public int MaxProfit(int[] prices) {
        var profit = 0;
        var minPrice = prices[0];

        for (int i = 1; i < prices.Length; i++) {
            if (prices[i] > minPrice) {
                profit += prices[i] - minPrice;
                minPrice = prices[i];
                continue;
            }
            minPrice = Math.Min(minPrice, prices[i]);
        }

        return profit;
    }
}