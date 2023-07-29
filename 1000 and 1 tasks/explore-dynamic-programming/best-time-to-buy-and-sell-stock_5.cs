public class Solution {
    public int MaxProfit(int[] prices) {
        var max = 0;
        var bought = prices[0];

        for (var dayIndex = 1; dayIndex < prices.Length; dayIndex++) {
            var currentProfit = prices[dayIndex] - bought;
            var minPrice = Math.Min(bought, prices[dayIndex]);
            bought = minPrice;
            max = Math.Max(max, currentProfit);
        }

        return max;
    }
}