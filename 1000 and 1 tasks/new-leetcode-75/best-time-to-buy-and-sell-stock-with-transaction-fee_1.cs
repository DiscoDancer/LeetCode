public class Solution {
    private int _fee;
    private int[] _prices;

    private int F(int i, int stock) {
        if (i == _prices.Length) {
            return 0;
        }

        if (stock == 1) {
            // sell
            var sell = F(i+1, 0) - _fee + _prices[i];
            // idle
            var idle = F(i+1, 1);

            return Math.Max(idle, sell);
        }
        // if (stock == 0)
        else {
            // idle
            var idle = F(i+1, 0);
            // buy
            var buy = F(i+1, 1) - _prices[i];

            return Math.Max(idle, buy);
        }
    }

    public int MaxProfit(int[] prices, int fee) {
        _fee = fee;
        _prices = prices;

        return F(0,0);
    }
}