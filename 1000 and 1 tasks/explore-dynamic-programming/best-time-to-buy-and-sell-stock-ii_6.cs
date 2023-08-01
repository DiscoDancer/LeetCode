public class Solution {
    public int MaxProfit(int[] prices) {
        var table = new int[prices.Length + 1, 2];

        // base case
        table[prices.Length, 0] = 0;
        table[prices.Length, 1] = 0;

        for (var dayIndex = prices.Length-1; dayIndex >= 0; dayIndex--) {
            for (var hold = 0; hold < 2; hold++) {
                var doNothing = table[dayIndex+1, hold];
                if (hold == 0) {
                    var buy = table[dayIndex+1, 1] - prices[dayIndex];
                    table[dayIndex, hold] = Math.Max(doNothing, buy);
                }
                else if (hold == 1) {
                    var sell = table[dayIndex+1, 0] + prices[dayIndex];
                    table[dayIndex, hold] = Math.Max(doNothing, sell);
                }
            }
        }   

        return table[0,0];
    }
}