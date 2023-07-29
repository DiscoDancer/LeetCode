public class Solution {
    private int[] _prices;

    private int F(int dayIndex, int bought) {
        if (dayIndex == _prices.Length) {
            return 0;
        }

        var currentProfit = _prices[dayIndex] - bought;
        var result = Math.Max(currentProfit, F(dayIndex + 1, Math.Min(bought, _prices[dayIndex])));
        return result;
    }

    public int MaxProfit(int[] prices) {
        _prices = prices;

        return F(1, _prices[0]);
    }
}