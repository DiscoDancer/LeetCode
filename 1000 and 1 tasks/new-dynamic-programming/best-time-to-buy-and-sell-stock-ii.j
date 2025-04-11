import java.util.*;

class Solution {
    private int[] prices;

    private int F(int i, boolean canBuy) {
        if (i == prices.length) {
            return 0;
        }

        if (canBuy) {
            // Buy
            var buy = - prices[i] + F(i + 1, false);
            // skip
            var skip = F(i + 1, true);

            return Math.max(buy, skip);
        } else {
            // Sell
            var sell = prices[i] + F(i+1, true);
            // not sell
            var skip = F(i + 1, false);

            return Math.max(sell, skip);
        }
    }

    public int maxProfit(int[] prices) {
        this.prices = prices;

        return F(0, true);
    }
}