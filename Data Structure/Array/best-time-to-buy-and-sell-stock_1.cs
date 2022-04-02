public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length == 1) {
            return 0;
        }
        
        var minPriceSoFar = prices[0];
        var maxProfitSoFar = 0;
        
        for (int i = 1; i < prices.Length; i++) {
            maxProfitSoFar = Math.Max(maxProfitSoFar, prices[i] - minPriceSoFar);
            minPriceSoFar = Math.Min(minPriceSoFar, prices[i]);
        }
        
        return maxProfitSoFar;
    }
}