public class Solution {
    // видимо это и есть Kadane algorithm
    public int MaxProfit(int[] prices) {
        var min = prices[0];
        var bestDeal = 0;

        for (int i = 1; i < prices.Length; i++) {
            var price = prices[i];
            bestDeal = Math.Max(bestDeal, price - min);
            min = Math.Min(min, price);
        }

        return bestDeal;
    }
}