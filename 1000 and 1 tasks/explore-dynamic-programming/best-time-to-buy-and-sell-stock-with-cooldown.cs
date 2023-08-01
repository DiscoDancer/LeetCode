public class Solution {
    private int[] _prices;
    private int?[,] _mem;

    public const int NotBought = 0;
    public const int Bought = 1;
    public const int Cooldown = 2;

    private int F(int dayIndex, int hold) {
        if (dayIndex == _prices.Length) {
            return 0;
        }
        if (_mem[dayIndex, hold] != null) {
            return _mem[dayIndex, hold].Value;
        }

        var doNothing = F(dayIndex+1, hold);

        if (hold == NotBought) {
            var buy = F(dayIndex+1, Bought) - _prices[dayIndex];
            _mem[dayIndex, hold] = Math.Max(doNothing, buy);
        }
        else if (hold == Bought) {
            var sell = F(dayIndex+1, Cooldown) + _prices[dayIndex];
            _mem[dayIndex, hold] = Math.Max(doNothing, sell);
        }
        else if (hold == Cooldown) {
            _mem[dayIndex, hold] = F(dayIndex+1, NotBought);
        }

        return _mem[dayIndex, hold].Value;
    }

    // см решения ii и iii
    public int MaxProfit(int[] prices) {
        _prices = prices;
        _mem = new int?[prices.Length + 1, 3];

        return F(0, NotBought);
    }
}