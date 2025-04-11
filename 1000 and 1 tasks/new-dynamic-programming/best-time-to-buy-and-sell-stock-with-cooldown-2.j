import java.util.*;

// see part 1

class Solution {
    public int maxProfit(int[] prices) {

        var prevPrevBuy = 0;
        var prevPrevSell = 0;
        var prevBuy = 0;
        var prevSell = 0;

        for (var i = prices.length; i >= 0; i--) {
            var curBuy = 0;
            var curSell = 0;
            for (int canBuy = 0; canBuy < 2; canBuy++) {
                if (i == prices.length) {
                    // do nothing
                }
                else if (canBuy == 1) {
                    var buy = - prices[i] + prevSell;
                    var skip = prevBuy;

                    curBuy = Math.max(buy, skip);
                } else {
                    var sell = prices[i] + prevPrevBuy;
                    var skip = prevSell;

                    curSell = Math.max(sell, skip);
                }
            }

            prevPrevBuy = prevBuy;
            prevPrevSell = prevSell;
            prevBuy = curBuy;
            prevSell = curSell;
        }


        return prevBuy;
    }
}