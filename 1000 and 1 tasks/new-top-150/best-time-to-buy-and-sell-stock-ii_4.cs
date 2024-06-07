public class Solution {
    public const int YES = 0;
    public const int NO = 1;

    public int MaxProfit(int[] prices) {
        var table = new int[prices.Length + 1, 2];

        // купил
        table[0, NO] = -prices[0];
        // не купил
        table[0, YES] = 0;

        // как мне повернуть от 0 ?
        for (int i = 1; i < prices.Length; i++) {
            for (int canBuy = 0; canBuy < 2; canBuy++) {
                var idle = table[i-1, canBuy];
                if (canBuy == YES) {
                    var buy = table[i-1, NO] + prices[i];
                    table[i, canBuy] = Math.Max(buy, idle);
                }
                else {
                    var sell = table[i-1, YES] - prices[i];
                    table[i, canBuy] = Math.Max(sell, idle);
                }
            }
        }

        return Math.Max(table[prices.Length-1, YES], table[prices.Length-1, NO]);
    }
}