public class Solution {
    private int[] _prices;

    private int F(int i, bool canBuy) {
        if (i == _prices.Length) {
            return 0;
        }

        var idle = F(i+1, canBuy);

        if (canBuy) {
            var buy = F(i+1, false) - _prices[i];
            return Math.Max(buy, idle);
        }
        else {
            var sell = F(i+1, true) + _prices[i];
            return Math.Max(sell, idle);
        }
    }

    public int MaxProfit(int[] prices) {
        _prices = prices;

        return F(0, true);
    }
}