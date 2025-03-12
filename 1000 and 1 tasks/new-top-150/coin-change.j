import java.util.List;

class Solution {

    private int[] coins;
    private int result = Integer.MAX_VALUE;

    private void F(int amountLeft, int coinsUsed) {
        if (amountLeft == 0) {
            this.result = Math.min(this.result, coinsUsed);
            return;
        }

        for (var coin : this.coins) {
            if (amountLeft - coin >= 0) {
                F(amountLeft - coin, coinsUsed + 1);
            }
        }
    }

    public int coinChange(int[] coins, int amount) {
        this.coins = coins;

        F(amount, 0);

        return this.result == Integer.MAX_VALUE ? -1 : this.result;
    }
}