public class Solution {
    // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/submissions/
    public int MaxProfit(int[] prices) {
        var held = int.MinValue;
        var sold = int.MinValue;
        var reset = 0;

        foreach (var price in prices) {
            var prevSold = sold;
            sold = held + price;
            held = Math.Max(reset - price, held);
            reset = Math.Max(prevSold, reset);
        }

        return Math.Max(sold, reset);
    }
}