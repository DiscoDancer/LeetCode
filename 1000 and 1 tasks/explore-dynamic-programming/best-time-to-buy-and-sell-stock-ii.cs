public class Solution {
    private int _max = 0;
    private int[] _prices;

    private void F(int dayIndex, int boughtPrice, int profit) {
        _max = Math.Max(_max, profit);

        if (dayIndex == _prices.Length) {
            return;
        }

        // ничего не куплено, можем либо купить, либо не купить
        if (boughtPrice == -1) {
            // купили
            F(dayIndex+1, _prices[dayIndex], profit - _prices[dayIndex]);
            // не купили
            F(dayIndex+1, boughtPrice, profit);
        }
        // уже куплено
        else {
            // можем продать и купить
            F(dayIndex+1, _prices[dayIndex], profit + _prices[dayIndex] - _prices[dayIndex]);
            // можем продать и пойти дальше
            F(dayIndex+1, -1, profit + _prices[dayIndex]);
            // можем не продавать и пойти дальше
            F(dayIndex+1, boughtPrice, profit);
        }
    }

    // TL
    public int MaxProfit(int[] prices) {
        _prices = prices;

        F(0, -1, 0);

        return _max;
    }
}