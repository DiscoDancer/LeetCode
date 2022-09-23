public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length == 1) {
            return 0;
        }
        
        var minPrice = prices[0];
        var sum = 0;
        
        for (int i = 1; i < prices.Length; i++) {            
            var price = prices[i];
            
            if (price > minPrice) {
                sum += price - minPrice;
                
                minPrice = price;
            } else {
                minPrice = Math.Min(minPrice, prices[i]);
            }
        }
        
        return sum;
    }
}