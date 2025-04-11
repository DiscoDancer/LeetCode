import java.util.*;

class Solution {
    // see part 1
    public int maxProfit(int[] prices) {
        var table = new int[prices.length + 1][2];

        for (var i = prices.length; i >= 0; i--) {
            for (int canBuy = 0; canBuy < 2; canBuy++) {
                if (i == prices.length) {
                    table[i][canBuy] = 0;
                }
                else if (canBuy == 1) {
                    var buy = - prices[i] + table[i + 1][0];
                    var skip = table[i + 1][1];

                    table[i][canBuy] = Math.max(buy, skip);
                } else {
                    var sell = prices[i] + table[i+1][1];
                    var skip = table[i + 1][0];

                    table[i][canBuy] = Math.max(sell, skip);
                }
            }
        }


        return table[0][1];
    }
}