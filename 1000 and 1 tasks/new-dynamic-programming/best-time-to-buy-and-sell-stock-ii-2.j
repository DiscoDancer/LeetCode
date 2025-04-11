import java.util.*;

class Solution {
    // see part 1
    public int maxProfit(int[] prices) {
        var prevRow = new int[2];

        for (var i = prices.length; i >= 0; i--) {
            var currRow = new int[2];
            for (int canBuy = 0; canBuy < 2; canBuy++) {
                if (i == prices.length) {
                    currRow[canBuy] = 0;
                }
                else if (canBuy == 1) {
                    var buy = - prices[i] + prevRow[0];
                    var skip = prevRow[1];

                    currRow[canBuy] = Math.max(buy, skip);
                } else {
                    var sell = prices[i] + prevRow[1];
                    var skip = prevRow[0];

                    currRow[canBuy] = Math.max(sell, skip);
                }
            }
            prevRow = currRow;
        }


        return prevRow[1];
    }
}