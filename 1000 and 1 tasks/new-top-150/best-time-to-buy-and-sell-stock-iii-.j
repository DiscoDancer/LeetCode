class Solution {
    private int[] prices;

    // transactionsCount 0 - can buy
    // transactionsCount 1 - can sell
    // transactionsCount 2 - can buy
    // transactionsCount 3 - can sell
    // transactionsCount 4 - must end

    private int F(int dayIndex, int transactionsCount) {
        if (dayIndex == prices.length || transactionsCount == 4) {
            return 0;
        }
        // transactionsCount 0 - can buy
        else if (transactionsCount == 0) {
            var buy = F(dayIndex  + 1, 1) - prices[dayIndex];
            var skip = F(dayIndex  + 1, 0);

            return Math.max(buy, skip);
        }
        // transactionsCount 1 - can sell
        else if (transactionsCount == 1) {
            // sell
            var sell = F(dayIndex  + 1, 2) + prices[dayIndex];
            var skip = F(dayIndex + 1, 1);

            return Math.max(sell, skip);
        }
        else if (transactionsCount == 2) {
            var buy = F(dayIndex  + 1, 3) - prices[dayIndex];
            var skip = F(dayIndex + 1, 2);

            return Math.max(buy, skip);
        }
        else if (transactionsCount == 3) {
            var sell = F(dayIndex  + 1, 4) + prices[dayIndex];
            var skip = F(dayIndex + 1, 3);

            return Math.max(sell, skip);
        }
        else {
            throw new IllegalArgumentException("Invalid transaction count");
        }
    }

    public int maxProfit(int[] prices) {
        this.prices = prices;

        return F(0, 0);
    }
}
