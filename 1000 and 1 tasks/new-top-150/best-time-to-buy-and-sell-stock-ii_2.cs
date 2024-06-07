public class Solution {
    public int MaxProfit(int[] prices) {
        var table = new int[prices.Length + 1, 2];

        for (int i = prices.Length - 1; i >= 0; i--) {
            for (int j = 0; j < 2; j++) {
                var canBuy = j == 0;
                var idle = table[i+1, j];

                if (canBuy) {
                    var buy = table[i+1, 1] - prices[i];
                    table[i, j] = Math.Max(buy, idle);
                }
                else {
                    var sell = table[i+1, 0] + prices[i];
                    table[i, j] = Math.Max(sell, idle);
                }
            }
        }

        return table[0, 0];
    }
}