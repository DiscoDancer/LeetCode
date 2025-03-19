class Solution {
    public int maxProfit(int[] prices) {
        var table = new int[prices.length + 1][5];

        for (int dayIndex = prices.length; dayIndex >= 0; dayIndex--) {
            for (int transactionsCount = 4; transactionsCount >= 0; transactionsCount--) {
                if (dayIndex == prices.length || transactionsCount == 4) {
                    table[dayIndex][transactionsCount] = 0;
                }
                else if (transactionsCount == 0) {
                    var buy = table[dayIndex + 1][1] - prices[dayIndex];
                    var skip = table[dayIndex + 1][0];

                    table[dayIndex][transactionsCount] = Math.max(buy, skip);
                }
                else if (transactionsCount == 1) {
                    var sell = table[dayIndex + 1][2] + prices[dayIndex];
                    var skip = table[dayIndex + 1][1];

                    table[dayIndex][transactionsCount] = Math.max(sell, skip);
                }
                else if (transactionsCount == 2) {
                    var buy = table[dayIndex + 1][3] - prices[dayIndex];
                    var skip = table[dayIndex + 1][2];

                    table[dayIndex][transactionsCount] = Math.max(buy, skip);
                }
                else if (transactionsCount == 3) {
                    var sell = table[dayIndex + 1][4] + prices[dayIndex];
                    var skip = table[dayIndex + 1][3];

                    table[dayIndex][transactionsCount] = Math.max(sell, skip);
                }
            }
        }

        return table[0][0];
    }
}
