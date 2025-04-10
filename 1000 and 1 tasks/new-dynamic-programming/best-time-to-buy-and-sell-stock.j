import java.util.*;

class Solution {

    private int[] prices;
    private int max;

    private void F(int i, int sum, boolean canBuy) {
        if (i == prices.length) {
            max = Math.max(max, sum);
            return;
        }

        if (canBuy) {
            // Buy
            F(i + 1, sum - prices[i], false);
            // skip
            F(i + 1, sum, true);
        } else {
            // Sell
            F(this.prices.length, sum + prices[i], false);
            // not sell
            F(i + 1, sum, false);
        }
    }

    public int maxProfit(int[] prices) {
        this.prices = prices;

        F(0, 0, true);

        return this.max;
    }
}