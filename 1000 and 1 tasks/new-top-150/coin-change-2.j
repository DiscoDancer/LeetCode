import java.util.List;

class Solution {
    public int coinChange(int[] coins, int amount) {

        var table = new long[amount + 1];
        for (int i = 0; i < table.length; i++) {
            table[i] = Integer.MAX_VALUE;
        }
        table[0] = 0;

        for (int amountLeft = 1; amountLeft <= amount; amountLeft++) {
            long min = Integer.MAX_VALUE;

            for (var coin : coins) {
                if (amountLeft - coin >= 0) {
                    long subResult = 1 + table[amountLeft - coin];
                    min = Math.min(min, subResult);
                }
            }

            table[amountLeft] = min;
        }

        var result = table[amount];

        return result == Integer.MAX_VALUE ? -1 : (int)result;
    }
}