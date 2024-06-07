// TL
public class Solution {
    private int[] _prices;
    private int _maxProfit = 0;

    private void F(int i, int balance, bool canBuy) {
        if (i == _prices.Length) {

            _maxProfit = Math.Max(balance, _maxProfit);

            return;
        }

        if (canBuy) {
            // buy
            F(i+1, balance - _prices[i], false);
            // idle
            F(i+1, balance, canBuy);
        }
        else {
            // sell
            F(i+1, balance + _prices[i], true);
            // idle
            F(i+1, balance, canBuy);
        }
    }

    public int MaxProfit(int[] prices) {
        _prices = prices;

        F(0, 0, true);

        return _maxProfit;
    }
}