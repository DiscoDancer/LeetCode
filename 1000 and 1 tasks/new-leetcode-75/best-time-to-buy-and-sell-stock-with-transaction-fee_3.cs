public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        var prev0 = 0;
        var prev1 = 0;

        for (int i = prices.Length - 1; i >= 0; i--) {
            for (var stock = 0; stock < 2; stock++) {
                if (stock == 1) {
                    // sell
                    var sell = prev0 - fee + prices[i];
                    // idle
                    var idle = prev1;

                    prev1 = Math.Max(idle, sell);
                }
                else if (stock == 0) {
                    // idle
                    var idle = prev0;
                    // buy
                    var buy = prev1 - prices[i];

                    prev0 = Math.Max(idle, buy);
                }
            }
        }

        return prev0;
    }
}