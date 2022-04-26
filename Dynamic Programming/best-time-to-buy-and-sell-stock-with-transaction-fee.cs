public class Solution {
    // min so far
    // state machine
    public int MaxProfit(int[] prices, int fee) {
        if (prices.Length == 1) {
            return 0;
        }
                
        var hold = -999999;
        var sold = -999999;
        var start = 0;
 
        for (int i = 0; i < prices.Length; i++) {
            var price = prices[i];
            
            var oldSold = sold;
            
            start = Math.Max(start, oldSold);
            hold = Math.Max(Math.Max(hold, start - price), oldSold - price);
            sold = hold + price - fee;
            
        }
        
        return Math.Max(Math.Max(hold, sold), start);
    }
}