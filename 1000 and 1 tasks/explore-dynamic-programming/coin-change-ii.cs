public class Solution {
    private int[] _coins;

    private int F(int i, int amount) {
        if (amount == 0) {
            return 1;
        }
        if (i == _coins.Length) {
            return 0;
        }

        // монетки не отсортированы
        if (_coins[i] > amount) {
            return F(i+1, amount);
        }

        return F(i, amount - _coins[i]) + F(i+1, amount);
    }

    // editorial
    public int Change(int amount, int[] coins) {
        _coins = coins;

        return F(0, amount);
    }
}