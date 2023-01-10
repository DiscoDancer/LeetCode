public class Solution {
    // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/submissions/
public class Solution {
    public int MaxProfit(int[] prices) {
        var held = int.MinValue;
        var sold = int.MinValue;
        var reset = 0;

        foreach (var price in prices) {
            var prevSold = sold;
            var prevHeld = held;
            var prevReset = reset;

            sold = prevHeld + price;
            held = Math.Max(prevReset - price, prevHeld);
            reset = Math.Max(prevSold, prevReset);
        }

        return Math.Max(sold, reset);
    }
}
}