import java.util.*;

class Solution {

    private int[] prices;

    private final int CanBuyBought0 = 0;
    private final int CanSellBought1 = 1;
    private final int CanBuyBought1 = 2;
    private final int CanSellBought2 = 3;

    private int F(int i, int state) {
        if (i == prices.length) {
            return 0;
        }

        if (state == CanBuyBought0) {
            var buy = - prices[i] + F(i + 1, CanSellBought1);
            var skip = F(i + 1, CanBuyBought0);
            return Math.max(buy, skip);
        }
        else if (state == CanSellBought1) {
            var sell = prices[i] + F(i+1, CanBuyBought1);
            var skip = F(i + 1, CanSellBought1);
            return Math.max(sell, skip);
        }
        else if (state == CanBuyBought1) {
            var buy = - prices[i] + F(i + 1, CanSellBought2);
            var skip = F(i + 1, CanBuyBought1);
            return Math.max(buy, skip);
        }
        else if (state == CanSellBought2) {
            // any state doesnt matter, need to finish
            var sell = prices[i];
            var skip = F(i + 1, CanSellBought2);
            return Math.max(sell, skip);
        }
        else {
            throw new IllegalArgumentException("Invalid state: " + state);
        }
    }

    public int maxProfit(int[] prices) {
        this.prices = prices;

        return F(0, CanBuyBought0);
    }
}