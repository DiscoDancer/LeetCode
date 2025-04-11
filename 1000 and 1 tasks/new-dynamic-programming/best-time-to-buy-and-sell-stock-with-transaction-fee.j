import java.util.*;

// see part 1

class Solution {
    // see part 1
    public int maxProfit(int[] prices, int fee) {
        var prevCanBuy = 0;
        var prevCanSell = 0;

        for (var i = prices.length; i >= 0; i--) {
            var curCanBuy = 0;
            var curCanSell = 0;

            for (int canBuy = 0; canBuy < 2; canBuy++) {
                if (i == prices.length) {
                    continue;
                }
                else if (canBuy == 1) {
                    var buy = - prices[i] + prevCanSell;
                    var skip = prevCanBuy;

                    curCanBuy = Math.max(buy, skip);
                } else {
                    var sell = prices[i] + prevCanBuy - fee;
                    var skip = prevCanSell;

                    curCanSell = Math.max(sell, skip);
                }
            }
            prevCanBuy = curCanBuy;
            prevCanSell = curCanSell;
        }


        return prevCanBuy;
    }
}