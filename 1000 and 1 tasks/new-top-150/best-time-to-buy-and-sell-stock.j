class Solution {
    public int maxProfit(int[] prices) {
        var maxProfit = 0;

        var minSoFar = Integer.MAX_VALUE;

        for (int i = 0; i < prices.length; i++) {
            var curPrice = prices[i];
            if (curPrice > minSoFar) {
                maxProfit = Math.max(maxProfit, curPrice - minSoFar);
            }
            minSoFar = Math.min(minSoFar, curPrice);
        }

        return maxProfit;
    }
}
