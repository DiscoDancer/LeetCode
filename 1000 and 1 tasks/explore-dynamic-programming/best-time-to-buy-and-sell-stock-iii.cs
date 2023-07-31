public class Solution {
    private int[] _prices;

    private int F(int dayIndex, int boughtPrice, int trCount) {
        if (dayIndex == _prices.Length || trCount == 4) {
            return 0;
        }

        // ничего не куплено, можем либо купить, либо не купить
        if (boughtPrice == -1) {
            if (trCount < 4) {
                // купили
                var a = F(dayIndex+1, _prices[dayIndex], trCount + 1) - _prices[dayIndex];
                // не купили
                var b = F(dayIndex+1, boughtPrice, trCount);
                return Math.Max(a, b);
            }
            else {
                return F(dayIndex+1, boughtPrice, trCount);
            }
        }
        else {
            int a = int.MinValue;
            int b = int.MinValue;
            int c = int.MinValue;

            if (trCount < 3) {
                // можем продать и купить
                a = F(dayIndex+1, _prices[dayIndex], trCount + 2) + _prices[dayIndex] - _prices[dayIndex];
            }
            if (trCount < 4) {
                b = F(dayIndex+1, -1, trCount + 1) + _prices[dayIndex];
            }
            c = F(dayIndex+1, boughtPrice, trCount);

            return Math.Max(Math.Max(a,b), c);
        }
    }

    // TL
    public int MaxProfit(int[] prices) {
        _prices = prices;

        return F(0, -1, 0);
    }
}