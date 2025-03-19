class Solution {

    // see best-time-to-buy-and-sell-stock-iii
    
    public int maxProfit(int k, int[] prices) {
        var table = new int[prices.length + 1][k*2 + 1];

        for (int dayIndex = prices.length; dayIndex >= 0; dayIndex--) {
            for (int transactionsCount = k*2; transactionsCount >= 0; transactionsCount--) {
                if (dayIndex == prices.length || transactionsCount == k*2) {
                    table[dayIndex][transactionsCount] = 0;
                }
                else if (transactionsCount % 2 == 0) {
                    var buy = table[dayIndex + 1][transactionsCount + 1] - prices[dayIndex];
                    var skip = table[dayIndex + 1][transactionsCount];

                    table[dayIndex][transactionsCount] = Math.max(buy, skip);
                }
                else if (transactionsCount % 2 == 1) {
                    var sell = table[dayIndex + 1][transactionsCount+1] + prices[dayIndex];
                    var skip = table[dayIndex + 1][transactionsCount];

                    table[dayIndex][transactionsCount] = Math.max(sell, skip);
                }
            }
        }

        return table[0][0];
    }
}
