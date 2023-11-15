public class Solution {

    private int _maxProfit = 0;
    private int _fee;
    private int[] _prices;

    private void F(int i, int stock, int profit) {
        _maxProfit = Math.Max(_maxProfit, profit);
        if (i == _prices.Length) {
            return;
        }

        if (stock == 1) {
            // sell
            F(i+1, 0, profit - _fee + _prices[i]);
            // idle
            F(i+1, 1, profit);
        }
        else if (stock == 0) {
            // idle
            F(i+1, 0, profit);
            // buy
            F(i+1, 1, profit - _prices[i]);
        }
    }

    // TL
    public int MaxProfit(int[] prices, int fee) {
        _fee = fee;
        _prices = prices;

        F(0,0,0);
        
        return _maxProfit;
    }
}