public class Solution {
    public const int YES = 0;
    public const int NO = 1;

    public int MaxProfit(int[] prices) {
        var table = new int[prices.Length + 1, 2];

        for (int i = prices.Length - 1; i >= 0; i--) {
            for (int canBuy = 0; canBuy < 2; canBuy++) {
                var idle = table[i+1, canBuy];
                if (canBuy == YES) {
                    var buy = table[i+1, NO] - prices[i];
                    table[i, canBuy] = Math.Max(buy, idle);
                }
                else {
                    var sell = table[i+1, YES] + prices[i];
                    table[i, canBuy] = Math.Max(sell, idle);
                }
            }
        }

        return table[0, YES];
    }
}