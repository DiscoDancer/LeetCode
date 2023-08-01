public class Solution {
    // см ii и iii
    public int MaxProfit(int[] prices, int fee) {
        var table = new int[prices.Length + 1, 2];
        
        for (var dayIndex = prices.Length-1; dayIndex >= 0; dayIndex--) {
            for (var hold = 0; hold < 2; hold++) {
                var doNothing = table[dayIndex+1, hold];
                if (hold == 0) {
                    var buy = table[dayIndex+1, 1] - prices[dayIndex];
                    table[dayIndex, hold] = Math.Max(doNothing, buy);
                }
                else if (hold == 1) {
                    var sell = table[dayIndex+1, 0] + prices[dayIndex] - fee;
                    table[dayIndex, hold] = Math.Max(doNothing, sell);
                }
            }
        }   

        return table[0,0];
    }
}