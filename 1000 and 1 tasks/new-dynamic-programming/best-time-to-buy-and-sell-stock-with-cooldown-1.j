import java.util.*;

// see part 1

class Solution {
    public int maxProfit(int[] prices) {
        var prevPrevRow = new int[2];
        var prevRow = new int[2];

        for (var i = prices.length; i >= 0; i--) {
            var curRow = new int[2];
            for (int canBuy = 0; canBuy < 2; canBuy++) {
                if (i == prices.length) {
                    // do nothing
                }
                else if (canBuy == 1) {
                    var buy = - prices[i] + prevRow[0];
                    var skip = prevRow[1];

                    curRow[canBuy] = Math.max(buy, skip);
                } else {
                    var sell = prices[i] + prevPrevRow[1];
                    var skip = prevRow[0];

                    curRow[canBuy] = Math.max(sell, skip);
                }
            }

            prevPrevRow = prevRow;
            prevRow = curRow;
        }


        return prevRow[1];
    }
}