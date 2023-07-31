public class Solution {
    public int MaxProfit(int[] prices) {
        
        var bought = new int[prices.Length + 1];
        var notBought = new int[prices.Length + 1];

        bought[0] = int.MinValue;
        notBought[0] = 0;

        for (int i = 1; i <= prices.Length; i++) {
            var price = prices[i-1];
            bought[i] = Math.Max(bought[i-1], notBought[i-1] - price);
            notBought[i] = Math.Max(notBought[i-1], bought[i-1] + price);
        }

        return Math.Max(bought.Last(), notBought.Last());
    }
}