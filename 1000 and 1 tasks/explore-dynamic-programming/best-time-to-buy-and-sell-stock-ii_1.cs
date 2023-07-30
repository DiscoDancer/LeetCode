public class Solution {
    private int[] _prices;

    private int F(int dayIndex, int boughtPrice) {
        if (dayIndex == _prices.Length) {
            return 0;
        }

        // ничего не куплено, можем либо купить, либо не купить
        if (boughtPrice == -1) {
            // купили
            var a = F(dayIndex+1, _prices[dayIndex]) - _prices[dayIndex];
            // не купили
            var b = F(dayIndex+1, boughtPrice);
            return Math.Max(a, b);
        }
        // уже куплено
        else {
            // можем продать и купить
            var a = F(dayIndex+1, _prices[dayIndex]) + _prices[dayIndex] - _prices[dayIndex];
            // можем продать и пойти дальше
            var b = F(dayIndex+1, -1) + _prices[dayIndex];
            // можем не продавать и пойти дальше
            var c = F(dayIndex+1, boughtPrice);

            return Math.Max(Math.Max(a,b), c);
        }
    }

    public int MaxProfit(int[] prices) {
        _prices = prices;

        return F(0, -1);
    }
}