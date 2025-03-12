import java.util.List;

class Solution {

    private int[] coins;

    private long F(int amountLeft) {
        if (amountLeft == 0) {
            return 0;
        }

        long min = Integer.MAX_VALUE;

        for (var coin : this.coins) {
            if (amountLeft - coin >= 0) {
                long subResult = 1 + F(amountLeft - coin);
                min = Math.min(min, subResult);
            }
        }

        return min;
    }

    public int coinChange(int[] coins, int amount) {
        this.coins = coins;

        var result = F(amount);

        return result == Integer.MAX_VALUE ? -1 : (int)result;
    }
}