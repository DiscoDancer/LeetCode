public class Solution {
    private int _maxProfit = 0;
    private int[] _prices;

    private void F(int dayIndex, int bought) {
        if (dayIndex == _prices.Length) {
            return;
        }

        var todayPrice = _prices[dayIndex];
        if (bought != -1) {
            _maxProfit = Math.Max(_maxProfit, todayPrice - bought);
            F(dayIndex + 1, Math.Min(bought, todayPrice));
        }
        else {
            // хуже 0 не будет
            F(dayIndex + 1, todayPrice);
        }
    }

    // TL
    public int MaxProfit(int[] prices) {
        _prices = prices;
        F(0, -1);

        return _maxProfit;
    }
}