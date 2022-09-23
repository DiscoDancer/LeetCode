public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length == 1) {
            return 0;
        }
        
        // хранить минимальные цены
        
        var minBuyPrice = new int[prices.Length];
        minBuyPrice[0] = prices[0];
        
        var D = new int[prices.Length];
        
        for (int i = 1; i < prices.Length; i++) {
            D[i] = prices[i] - minBuyPrice[i - 1];
            minBuyPrice[i] = Math.Min(minBuyPrice[i-1], prices[i]);
        }
        
        var max = D.Max();       
        return max > 0 ? max : 0;
    }
}