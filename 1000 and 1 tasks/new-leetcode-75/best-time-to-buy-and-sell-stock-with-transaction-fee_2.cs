public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        var table = new int[prices.Length + 1, 2];
        // explicit
        table[prices.Length, 0] = 0;
        table[prices.Length, 1] = 0;

        for (int i = prices.Length - 1; i >= 0; i--) {
            for (var stock = 0; stock < 2; stock++) {
                if (stock == 1) {
                    // sell
                    var sell = table[i+1, 0] - _fee + prices[i];
                    // idle
                    var idle = table[i+1, 1];

                    table[i, 1] = Math.Max(idle, sell);
                }
                else if (stock == 0) {
                    // idle
                    var idle = table[i+1, 0];
                    // buy
                    var buy = table[i+1, 1] - prices[i];

                    table[i, 0] = Math.Max(idle, buy);
                }
            }
        }

        return table[0,0];
    }
}