public class Solution {
    private int _min = int.MaxValue;
    private int[] _coins;

    private void F(int amount, int count) {
        if (amount == 0) {
            _min = Math.Min(_min, count);
        }

        foreach (var c in _coins) {
            if (amount - c >= 0) {
                F(amount - c, count + 1);
            }
        }
    }

    // TL
    public int CoinChange(int[] coins, int amount) {
        _coins = coins;
        F(amount, 0);

        return _min == int.MaxValue ? -1 : _min;
    }
}