import java.util.*;

class Solution {
    public int maxProfit(int[] prices) {
        var table = new int[prices.length + 1][2];

        for (int canBuy = 0; canBuy < 2; canBuy++) {
            // 1 true, 0 false
            for (var i = prices.length; i >= 0; i--) {
                if (i == prices.length) {
                    table[i][canBuy] = 0;
                }
                else if (canBuy == 1) {
                    var buy = - prices[i] + table[i + 1][0];
                    var skip = table[i + 1][1];

                    table[i][canBuy] = Math.max(buy, skip);
                } else {
                    var sell = prices[i] + table[prices.length][0];
                    var skip = table[i + 1][0];

                    table[i][canBuy] = Math.max(sell, skip);
                }
            }
        }

        return table[0][1];
    }
}