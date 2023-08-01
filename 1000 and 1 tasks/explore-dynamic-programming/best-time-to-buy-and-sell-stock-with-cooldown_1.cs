public class Solution {
    public const int NotBought = 0;
    public const int Bought = 1;
    public const int Cooldown = 2;

    // см ii и iii
    public int MaxProfit(int[] prices) {
        var table = new int[prices.Length + 1, 3];

        for (var dayIndex = prices.Length-1; dayIndex >= 0; dayIndex--) {
            for (var hold = 0; hold < 3; hold++) {
                var doNothing = table[dayIndex+1, hold];
                if (hold == NotBought) {
                    var buy = table[dayIndex+1, Bought] - prices[dayIndex];
                    table[dayIndex, hold] = Math.Max(doNothing, buy);
                }
                else if (hold == Bought) {
                    var sell = table[dayIndex+1, Cooldown] + prices[dayIndex];
                    table[dayIndex, hold] = Math.Max(doNothing, sell);
                }
                else if (hold == Cooldown) {
                    table[dayIndex, hold] = table[dayIndex+1, NotBought];
                }
            }
        }

        return table[0, NotBought];
    }
}