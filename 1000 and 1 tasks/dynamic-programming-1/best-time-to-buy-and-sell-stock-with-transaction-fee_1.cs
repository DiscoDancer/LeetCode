public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        var held = 0;
        var sold = 0;
        var reset = 0;

        held = reset - prices[0];

        for (int i = 1; i < prices.Length; i++) {
            var price = prices[i];

            var prevHeld = held;
            var prevSold = sold;

            sold = Math.Max(prevSold, prevHeld + price - fee);
            held = Math.Max(prevHeld, prevSold - price);
        }

        return Math.Max(sold, held);
    }
}