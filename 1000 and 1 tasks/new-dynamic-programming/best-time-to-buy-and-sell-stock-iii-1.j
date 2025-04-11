import java.util.*;

class Solution {
    private final int CanBuyBought0 = 0;
    private final int CanSellBought1 = 1;
    private final int CanBuyBought1 = 2;
    private final int CanSellBought2 = 3;

    public int maxProfit(int[] prices) {
        var table = new int[prices.length + 1][4];
        for (var i = prices.length - 1; i >= 0; i--) {
            // could start with 0? or 3? YES
            for (var state = 0; state < 4; state++) {
                if (i == prices.length) {
                    table[i][state] = 0;
                }
                if (state == CanBuyBought0) {
                    var buy = - prices[i] + table[i + 1][CanSellBought1];
                    var skip = table[i + 1][CanBuyBought0];
                    table[i][state] =  Math.max(buy, skip);
                }
                else if (state == CanSellBought1) {
                    var sell = prices[i] + table[i+1][CanBuyBought1];
                    var skip = table[i + 1][CanSellBought1];
                    table[i][state] = Math.max(sell, skip);
                }
                else if (state == CanBuyBought1) {
                    var buy = - prices[i] + table[i + 1][CanSellBought2];
                    var skip = table[i + 1][CanBuyBought1];
                    table[i][state] =  Math.max(buy, skip);
                }
                else if (state == CanSellBought2) {
                    // any state doesnt matter, need to finish
                    var sell = prices[i];
                    var skip = table[i + 1][CanSellBought2];
                    table[i][state] =  Math.max(sell, skip);
                }
                else {
                    throw new IllegalArgumentException("Invalid state: " + state);
                }
            }
        }

        return table[0][CanBuyBought0];
    }
}