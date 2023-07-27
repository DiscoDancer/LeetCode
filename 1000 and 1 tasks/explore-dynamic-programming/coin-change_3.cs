public class Solution {
    private int _min = int.MaxValue;
    private int[] _coins;
    private int?[] _mem;

    private int F(int amount) {
        if (_mem[amount] != null) {
            return _mem[amount].Value;
        }

        var min = int.MaxValue;
        foreach (var c in _coins)
        {
            if (c < amount)
            {
                var sub = F(amount-c);
                if (sub != -1) {
                    min = Math.Min(min, sub);
                }
            }
        }

        _mem[amount] = min == int.MaxValue ? -1 : min + 1;
        return _mem[amount].Value;
    }

    // Passes
    public int CoinChange(int[] coins, int amount) {
        _coins = coins;
        _mem = new int?[amount+1];

        _mem[0] = 0;
        foreach (var c in _coins) {
            if (c <= amount) {
                _mem[c] = 1;
            }
        }

        return F(amount);
    }
}