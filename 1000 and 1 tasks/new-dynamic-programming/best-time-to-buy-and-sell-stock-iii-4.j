import java.util.*;

class Solution {
    private final int CanBuyBought0 = 0;
    private final int CanSellBought1 = 1;
    private final int CanBuyBought1 = 2;
    private final int CanSellBought2 = 3;

    public int maxProfit(int[] prices) {
        var prevRow = new int[4];

        for (var i = prices.length - 1; i >= 0; i--) {
            // could start with 0? or 3? YES
            for (var state = 0; state < 4; state++) {
                if (state == CanBuyBought0) {
                    var buy = - prices[i] + prevRow[CanSellBought1];
                    var skip = prevRow[CanBuyBought0];
                    prevRow[state] =  Math.max(buy, skip);
                }
                else if (state == CanSellBought1) {
                    var sell = prices[i] + prevRow[CanBuyBought1];
                    var skip = prevRow[CanSellBought1];
                    prevRow[state] = Math.max(sell, skip);
                }
                else if (state == CanBuyBought1) {
                    var buy = - prices[i] + prevRow[CanSellBought2];
                    var skip = prevRow[CanBuyBought1];
                    prevRow[state] =  Math.max(buy, skip);
                }
                else if (state == CanSellBought2) {
                    // any state doesnt matter, need to finish
                    var sell = prices[i];
                    var skip = prevRow[CanSellBought2];
                    prevRow[state] =  Math.max(sell, skip);
                }
                else {
                    throw new IllegalArgumentException("Invalid state: " + state);
                }
            }
        }

        return prevRow[CanBuyBought0];
    }
}