import java.util.*;


// see prev

class Solution {

    public int maxProfit(int k, int[] prices) {
        var prevRow = new int[k*2];

        for (var i = prices.length - 1; i >= 0; i--) {
            // could start with 0? or 3? YES
            for (var state = 0; state < k*2; state++) {
                // can buy in general
                if (state % 2 == 0) {
                    var buy = - prices[i] + prevRow[state + 1];
                    var skip = prevRow[state];
                    prevRow[state] =  Math.max(buy, skip);
                }
                else if (state == k*2-1) {
                    // any state doesnt matter, need to finish
                    var sell = prices[i];
                    var skip = prevRow[state];
                    prevRow[state] =  Math.max(sell, skip);
                }
                else if (state % 2 == 1) {
                    var sell = prices[i] + prevRow[state+1];
                    var skip = prevRow[state];
                    prevRow[state] = Math.max(sell, skip);
                }
                else {
                    throw new IllegalArgumentException("Invalid state: " + state);
                }
            }
        }

        return prevRow[0];
    }
}