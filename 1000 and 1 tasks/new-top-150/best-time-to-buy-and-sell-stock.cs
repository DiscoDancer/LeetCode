public class Solution {
    public int MaxProfit(int[] prices) {
        var min = int.MaxValue;

        var maxProfit = 0;

        foreach (var x in prices) {
            if (x > min) {
                maxProfit = Math.Max(x-min, maxProfit);
            }
            min = Math.Min(x, min);
        }

        return maxProfit;
    }
}