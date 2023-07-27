public class Solution {
    private int _min = int.MaxValue;
    private int[] _coins;

    private int F(int amount) {
        if (amount == 0) {
            return 0;
        }
        var anyBigger = false;
        foreach (var c in _coins) {
            if (c == amount) {
                return 1;
            }
            if (c < amount) {
                anyBigger = true;
            }
        }

        if (!anyBigger) {
            return -1;
        }

        var min = int.MaxValue;
        foreach (var c in _coins) {
            var sub = F(amount-c);
            if (sub != -1) {
                min = Math.Min(min, sub);
            }
        }
        if (min == int.MaxValue) {
            return -1;
        }
        return min + 1;
    }

    // TL
    public int CoinChange(int[] coins, int amount) {
        _coins = coins;
        return F(amount);
    }
}