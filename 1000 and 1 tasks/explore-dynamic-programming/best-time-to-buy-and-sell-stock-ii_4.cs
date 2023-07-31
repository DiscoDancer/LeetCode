public class Solution {
    public int MaxProfit(int[] prices) {
        var bought = int.MinValue;
        var notBought = 0;

        for (int i = 1; i <= prices.Length; i++) {
            var price = prices[i-1];
            var bought1 = Math.Max(bought, notBought - price);
            var notBought1 = Math.Max(notBought, bought + price);

            bought = bought1;
            notBought = notBought1;
        }

        return Math.Max(bought, notBought);
    }
}