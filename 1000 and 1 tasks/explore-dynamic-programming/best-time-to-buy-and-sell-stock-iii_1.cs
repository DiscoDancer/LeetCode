public class Solution {
    private int[] _prices;

    private int F(int dayIndex, int boughtPrice, int trCount) {
        if (dayIndex == _prices.Length || trCount == 4) {
            return 0;
        }

        // ничего не куплено, можем либо купить, либо не купить
        if (boughtPrice == -1) {
            // купили
            var a = F(dayIndex+1, _prices[dayIndex], trCount + 1) - _prices[dayIndex];
            // не купили
            var b = F(dayIndex+1, boughtPrice, trCount);
            return Math.Max(a, b);
        }
        else {
            // можем продать и купить
            int a = int.MinValue;
            if (trCount < 3) {
                a = F(dayIndex+1, _prices[dayIndex], trCount + 2) + _prices[dayIndex] - _prices[dayIndex];
            }
            var b = F(dayIndex+1, -1, trCount + 1) + _prices[dayIndex];
            var c = F(dayIndex+1, boughtPrice, trCount);

            return Math.Max(Math.Max(a,b), c);
        }
    }

    public int MaxProfit(int[] prices) {
        _prices = prices;

        return F(0, -1, 0);
    }
}