public class Solution {
    private int[] _prices;
    private int?[,] _mem;

    // hold 0 - not bought, 1 bought

    private int F(int dayIndex, int hold) {
        if (dayIndex == _prices.Length) {
            return 0;
        }
        if (_mem[dayIndex, hold] != null) {
            return _mem[dayIndex, hold].Value;
        }

        var doNothing = F(dayIndex+1, hold);

        if (hold == 0) {
            var buy = F(dayIndex+1, 1) - _prices[dayIndex];
            _mem[dayIndex, hold] = Math.Max(doNothing, buy);
        }
        else {
            var sell = F(dayIndex+1, 0) + _prices[dayIndex];
            _mem[dayIndex, hold] =  Math.Max(doNothing, sell);
        }

        return _mem[dayIndex, hold].Value;
    }

    // TL
    public int MaxProfit(int[] prices) {
        _prices = prices;
        _mem = new int?[prices.Length + 1, 2];

        return F(0, 0);
    }
}