public class Solution {
    private int[] _prices;
    private int?[,,] _mem;


    // hold = 0 -> не купили
    // hold = 1 -> купили

    private int F(int dayIndex, int hold, int trCount) {
        if (dayIndex == _prices.Length || trCount == 4) {
            return 0;
        }
        if (_mem[dayIndex,hold,trCount] != null) {
            return _mem[dayIndex,hold,trCount].Value;
        }

        var doNothing = F(dayIndex+1, hold, trCount);

        // ничего не куплено, можем либо купить, либо не купить
        if (hold == 0) {
            // купили
            var buy = F(dayIndex+1, 1, trCount + 1) - _prices[dayIndex];
            _mem[dayIndex,hold,trCount] = Math.Max(buy, doNothing);
        }
        // математически видно, про продать и купить в тот же день, ничего не дает
        else {
            var sell = F(dayIndex+1, 0, trCount + 1) + _prices[dayIndex];
            _mem[dayIndex,hold,trCount] = Math.Max(sell, doNothing);
        }

        return _mem[dayIndex,hold,trCount].Value;
    }

    // editorial, passes
    public int MaxProfit(int[] prices) {
        _prices = prices;
        _mem = new int?[prices.Length+1, 2, 4];

        return F(0, 0, 0);
    }
}