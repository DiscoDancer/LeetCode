public class Solution {
    private int _maxProfit = 0;
    private int[] _prices;

    private void F(int dayIndex, int bought) {
        if (dayIndex == _prices.Length) {
            return;
        }

        _maxProfit = Math.Max(_maxProfit, _prices[dayIndex] - bought);
        F(dayIndex + 1, Math.Min(bought, _prices[dayIndex]));
    }
    
    public int MaxProfit(int[] prices) {
        _prices = prices;
        F(1, _prices[0]);

        return _maxProfit;
    }
}