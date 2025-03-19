class Solution {
    private int[] prices;
    private int max;

    // transactionsCount 0 - can buy
    // transactionsCount 1 - can sell
    // transactionsCount 2 - can buy
    // transactionsCount 3 - can sell
    // transactionsCount 4 - must end

    private void F(int dayIndex, int sum, int transactionsCount) {
        if (dayIndex == prices.length || transactionsCount == 4) {
            this.max = Math.max(max, sum);
        }
        // transactionsCount 0 - can buy
        else if (transactionsCount == 0) {
            // buy
            F(dayIndex  + 1, sum - prices[dayIndex], 1);
            // skip
            F(dayIndex  + 1, sum, 0);
        }
        // transactionsCount 1 - can sell
        else if (transactionsCount == 1) {
            // sell
            F(dayIndex  + 1, sum + prices[dayIndex], 2);
            // skip
            F(dayIndex  + 1, sum, 1);
        }
        else if (transactionsCount == 2) {
            // buy
            F(dayIndex  + 1, sum - prices[dayIndex], 3);
            // skip
            F(dayIndex  + 1, sum, 2);
        }
        else if (transactionsCount == 3) {
            // sell
            F(dayIndex  + 1, sum + prices[dayIndex], 4);
            // skip
            F(dayIndex  + 1, sum, 3);
        }
    }

    public int maxProfit(int[] prices) {
        this.prices = prices;

        F(0, 0, 0);

        return this.max;
    }
}
